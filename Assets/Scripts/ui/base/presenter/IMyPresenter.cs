using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public interface IMyPresenter<V> where V : IUnityView
{
    void OnAttach(V mvpView);

    void OnDetach();

    void OnViewInitialized();

    void OnDestroy();

    void HandleApiError(WWWErrorException ex);

    void HandleApiError<T>(ResponseData<T> apiResponse);

    void OnResponseData(string data);

    void SetUserAsLoggedOut();

    void CleanCompositeDisposable();

}
