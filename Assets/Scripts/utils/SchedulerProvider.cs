using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniRx;

namespace Assets.Scripts.utils
{
    public class SchedulerProvider : IScheduleProvider
    {
        private static SchedulerProvider INSTANCE;

        public static SchedulerProvider getInstance()
        {
            if (INSTANCE == null)
            {
                INSTANCE = new SchedulerProvider();
            }
            return INSTANCE;
        }

        public IScheduler Ui()
        {
            return Scheduler.MainThread;
        }
    }
}
