using System;
using System.Collections.Generic;
using System.Drawing;
using EleWise.ELMA.ComponentModel;
using EleWise.ELMA.Logging;
using EleWise.ELMA.Scheduling;
using EleWise.ELMA.Scheduling.Triggers;
using EleWise.ELMA.Services;
using Yambr.ELMA.Email.Managers;
using Yambr.ELMA.Email.Services;

namespace Yambr.ELMA.Email.Scheduler
{
    [Component(Type = ComponentType.WebServer)]
    public class SendMailboxesJobRepository : ISchedulerJobRepository
    {
        public ICollection<ISchedulerJob> GetSchedulerJobs()
        {
            return new List<ISchedulerJob> { new SendMailboxesJob() };
        }


        #region Private Members

        private class SendMailboxesJob : SchedulerJobBase
        {
            public SendMailboxesJob()
            {
                Trigger = new NthIncludedDayTrigger(new NthIncludedDaySettings
                {
                    ScheduleType = ScheduleType.Daily,
                    DailySettings = new DailySettings
                    {
                        EveryDay = 1,
                        OnlyWorkDays = false
                    },
                    RepeatSettings = new RepeatSettings
                    {
                        Enabled = true,
                        RepeatEvery = TimeSpan.FromMinutes(15.0),
                        RepeatTo = TimeSpan.FromHours(24.0)
                    },
                    StartDate = DateTime.Today
                }, Locator.GetServiceNotNull<IProductionCalendarService>().GetGlobalProductionSchedule())
                {
                    Name = "Триггер запуска отправки почтовых ящиков",
                    Id = new Guid("{3A6C7BC6-9B0D-41EB-9237-E693C2FCE5E2}")
                };
                Jobs = new List<IJob> { new JobImpl() };
            }

            public override ITrigger Trigger { get; }

            public override ICollection<IJob> Jobs { get; }

            private class JobImpl : IJob
            {

                public Guid Id => new Guid("{C9D566EF-87A3-42C5-BF03-144BE54577BC}");

                public string Name => "Отправка почтовых ящиков на чтение писем";

                public Image Icon => null;

                public JobResult Do(DateTime dateToRun)
                {
                    try
                    {
                        var rabbitMqService = Locator.GetServiceNotNull<IRabbitMQService>();
                        rabbitMqService.HealthCheck();
                        UserMailboxManager.Instance.SendToUpdate();
                    }
                    catch (Exception ex)
                    {
                        EmailLogger.Logger.Error(ex);

                        return new JobResult
                        {
                            Status = JobStatus.Fail,
                            Information = "Ошибка выполнения задачи",
                            ErrorDescription = ex.Message
                        };

                    }

                    return new JobResult
                    {
                        Status = JobStatus.Success,
                        Information = "Запуск прошел успшено",
                        NoSaveResult = true
                    };
                }
            }
        }

        #endregion
    }
}
