using System;
using System.Threading;
using EleWise.ELMA.Runtime.NH;
using EleWise.ELMA.Security;
using EleWise.ELMA.Security.Managers;
using EleWise.ELMA.Services;
using EleWise.ELMA.Threading;

namespace Yambr.ELMA.Email.Extensions
{
    public static class ActionExtensions
    {
        /// <summary>
        /// Выполнить действие в отдельном потоке и транзакции
        /// ---
        ///  объекты должны быть независимы в действии, можно передавать Id сущности и после выполнения в исходном потоке вызвать Refresh
        /// </summary>
        /// <param name="action"> действие </param>
        /// <param name="name">название операции</param>
        /// <param name="errorCallback">обработка ошибки</param>
        /// <param name="successCallback">действие после успеха</param>
        /// <param name="minutes">количество минут выделенное на операцию (максимум 9)</param>
        public static void InNewThread(
            this Action action,
            string name,
            Action<Exception> errorCallback,
            Action successCallback,
            int minutes = 2)
        {
            Exception exception = null;
            Thread thread = null;
            try
            {
                thread = ThreadStarter.StartNewThread((ThreadStart)delegate
                {
                    var backgroundTask = new BackgroundTask(() =>
                    {
                        var securityService = Locator.GetService<ISecurityService>();
                        securityService.RunByUser(UserManager.Instance.Load(SecurityConstants.AdminUserUid),
                            () =>
                            {
                                var unitOfWorkManager = Locator.GetServiceNotNull<IUnitOfWorkManager>();
                                using (var unitOfWork = unitOfWorkManager.Create(string.Empty, true, System.Data.IsolationLevel.ReadCommitted))
                                {
                                    try
                                    {
                                        action.Invoke();
                                        unitOfWork.Commit();
                                    }
                                    catch (Exception ex)
                                    {
                                        unitOfWork.Rollback();
                                        exception = ex;
                                    }

                                }
                            });
                    }, typeof(Action), action.Method.Name, name);
                    backgroundTask.Execute();
                });
                thread.IsBackground = true;
                if (!thread.Join(TimeSpan.FromMinutes(minutes)))
                {
                    thread.Abort();
                    var message = $"Действие \"{name}\" выполнялось более {minutes} минут и было прервано";
                    exception = exception != null ? new Exception(message, exception) : new Exception(message);
                }
                if (exception != null)
                {
                    if (errorCallback != null)
                    {
                        errorCallback.Invoke(exception);
                    }
                    else
                    {
                        throw exception;
                    }
                }
                else
                {
                    successCallback?.Invoke();
                }
            }
            catch (ThreadAbortException)
            {
                thread?.Abort();
                throw;
            }
        }
    }
}
