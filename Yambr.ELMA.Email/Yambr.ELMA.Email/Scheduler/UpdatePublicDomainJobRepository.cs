using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using EleWise.ELMA.ComponentModel;
using EleWise.ELMA.Logging;
using EleWise.ELMA.Scheduling;
using EleWise.ELMA.Scheduling.Triggers;
using EleWise.ELMA.Security;
using EleWise.ELMA.Services;
using Yambr.ELMA.Email.Managers;

namespace Yambr.ELMA.Email.Scheduler
{
    [Component(Type = ComponentType.WebServer)]
    public class UpdatePublicDomainJobRepository : ISchedulerJobRepository
    {
        public ICollection<ISchedulerJob> GetSchedulerJobs()
        {
            return new List<ISchedulerJob> { new UpdatePublicDomainJob() };
        }


        #region Private Members

        private class UpdatePublicDomainJob : SchedulerJobBase
        {
            public UpdatePublicDomainJob()
            {
                Trigger = new NthIncludedDayTrigger(
                    new NthIncludedDaySettings
                    {
                        ScheduleType = ScheduleType.Daily,
                        DailySettings = new DailySettings()
                        {
                            EveryDay = 1,
                            OnlyWorkDays = false
                        },
                        StartDate = DateTime.Today.AddMinutes(10),
                        OvertimeToRun = TimeSpan.FromDays(1)
                    },
                    Locator.GetService<IProductionCalendarService>().GetGlobalProductionSchedule())
                {
                    Name = "Триггер запуска обновления списка публичных доменов",
                    Id = new Guid("01B49D04-342E-46C2-86F9-EC8445740856")
                };
                Jobs = new List<IJob> { new JobImpl() };
            }

            public override ITrigger Trigger { get; }

            public override ICollection<IJob> Jobs { get; }

            private class JobImpl : IJob
            {

                public Guid Id => new Guid("{6627E4DB-E4A8-4FF4-A2A6-707BA84EAFD4}");

                public string Name => "Обновление списка публичных доменов";

                public Image Icon => null;

                public JobResult Do(DateTime dateToRun)
                {
                    

                       var ex = PublicDomainManager.Instance.UpdateDomains();

                       if (ex != null)
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
