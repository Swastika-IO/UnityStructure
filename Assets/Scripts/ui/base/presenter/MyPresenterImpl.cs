using Assets.Scripts.data;
using Assets.Scripts.utils;
using System;
using UniRx;
using UnityEngine;

public class MyPresenterImpl<V> : IMyPresenter<V> where V : IUnityView
{
    private CompositeDisposable _CompositeDisposable;
    private SchedulerProvider _SchedulerProvider;
    protected IDataManager _DataManager { get; set; }
    public V _BaseView { get; set; }

    public MyPresenterImpl(SchedulerProvider schedulerProvider, IDataManager dataManager)
    {
        _CompositeDisposable = new CompositeDisposable();
        _SchedulerProvider = schedulerProvider;
        _DataManager = dataManager;
    }

    public V GetBaseView()
    {
        return _BaseView;
    }

    public void Add(IDisposable item)
    {
        _CompositeDisposable.Add(item);
    }

    public CompositeDisposable GetCompositeDisposable()
    {
        return _CompositeDisposable;
    }

    public virtual void OnResponseData(string data)
    {
        Debug.Log(data);
    }

    public void OnAttach(V mvpView)
    {
        _BaseView = mvpView;
    }

    public virtual void OnDestroy()
    {
        _CompositeDisposable.Clear();
        _CompositeDisposable.Dispose();
    }

    public void OnDetach()
    {
        if (!_CompositeDisposable.IsDisposed)
        {
            _CompositeDisposable.Dispose();
        }
    }

    public void OnViewInitialized()
    {
        
    }

    public virtual void HandleApiError(WWWErrorException ex)
    {
        if (ex == null || ex.Data == null)
        {
            GetBaseView().OnConnectToServerError();
            return;
        }
        GetBaseView().OnError(string.IsNullOrEmpty(ex.Message) ? "" : ex.Message);
        GetBaseView().HideLoading();
    }

    public virtual void HandleApiError<T>(ResponseData<T> apiResponse)
    {
        switch (apiResponse.status)
        {
            //TODO: need to implement
        }
    }

    public void SetUserAsLoggedOut()
    {
        GetBaseView().OnTokenExpired();
    }

    public virtual void OnError(string msg)
    {
        LoadingUIUtil.instance.ShowMessage(msg);
    }

    public void CleanCompositeDisposable()
    {
        GetCompositeDisposable().Clear();
    }
}
