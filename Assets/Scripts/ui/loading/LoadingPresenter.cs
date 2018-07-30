using Assets.Scripts.data;
using Assets.Scripts.utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingPresenter<V> : MyPresenterImpl<V> where V : ILoadingView
{
    public LoadingPresenter(SchedulerProvider schedulerProvider, IDataManager dataManager)
        : base(schedulerProvider, dataManager)
    {
    }

}
