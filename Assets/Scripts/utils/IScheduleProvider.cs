using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniRx;

namespace Assets.Scripts.utils
{
    public interface IScheduleProvider
    {
        IScheduler Ui();

    }
}
