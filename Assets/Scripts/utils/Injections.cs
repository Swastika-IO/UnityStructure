using Assets.Scripts.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.utils
{
    public class Injections
    {
        public static IDataManager ProvideAppDataManager()
        {
            return DataManager.getInstance();
        }

        public static SchedulerProvider ProvideSchedulerProvider()
        {
            return SchedulerProvider.getInstance();
        }
    }
}
