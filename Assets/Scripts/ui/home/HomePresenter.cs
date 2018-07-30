using Assets.Scripts.data;
using Assets.Scripts.utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ref: https://msdn.microsoft.com/en-us/library/ff649571.aspx

public class HomePresenter<V> : MyPresenterImpl<V> where V : IHomeView
{
    public HomePresenter(SchedulerProvider schedulerProvider, IDataManager dataManager)
        : base(schedulerProvider, dataManager)
    {
    }


}
