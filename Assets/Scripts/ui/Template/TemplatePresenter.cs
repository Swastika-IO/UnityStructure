using Assets.Scripts.data;
using Assets.Scripts.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.ui.Template
{
    class TemplatePresenter<V> : MyPresenterImpl<V> where V : ITemplateView
    {
        public TemplatePresenter(SchedulerProvider schedulerProvider, IDataManager dataManager)
        : base(schedulerProvider, dataManager)
        {
        }
    }
}
