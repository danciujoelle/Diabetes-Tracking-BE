using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesTrackingServer.EmailRelated
{
    public class JobScheduler
    {
		public static void Start()
		{
			ISchedulerFactory schedFact = new StdSchedulerFactory();
			IScheduler scheduler = schedFact.GetScheduler().GetAwaiter().GetResult();
			IJobDetail emailJob = JobBuilder.Create<EmailJob>()
				  .WithIdentity("job1")
				  .Build();

			ITrigger trigger = TriggerBuilder.Create()
				.WithDailyTimeIntervalSchedule
				  (s =>
					 s.WithIntervalInSeconds(30)
					.OnEveryDay()
				  )
				 .ForJob(emailJob)
				 .WithIdentity("trigger1")
				 .StartNow()
				 .WithCronSchedule("0 43 18 ? * MON-SUN *")
				 .Build();

			ISchedulerFactory sf = new StdSchedulerFactory();
			IScheduler sc = sf.GetScheduler().GetAwaiter().GetResult();
			sc.ScheduleJob(emailJob, trigger);
			sc.Start();
			/*scheduler.ScheduleJob(emailJob, trigger);
			scheduler.Start(); */
		}

        internal static object StartAsync()
        {
            throw new NotImplementedException();
        }
    }
}
