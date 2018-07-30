

using Assets.Scripts.data;
using Assets.Scripts.utils;
using UniRx;

public class RegisterPresenter<V> : MyPresenterImpl<V> where V : IRegisterView
{

    public RegisterPresenter(SchedulerProvider schedulerProvider, IDataManager dataManager)
    : base(schedulerProvider, dataManager)
    {
    }

    //Check data input from user is valid and submit data to Server
    public void ValidateForm(PostRegister postData)
    {
        if (string.IsNullOrEmpty(postData.FullName))
        {
            GetBaseView().Invalidate(LocalizationManager.
                instance.GetLocalizedValue(LocalizedKey.INVALID_YOUR_NAME));
            return;
        }
        if (string.IsNullOrEmpty(postData.Email))
        {
            GetBaseView().Invalidate(LocalizationManager.
                instance.GetLocalizedValue(LocalizedKey.INVALID_EMAIL));
            return;
        }
        if (string.IsNullOrEmpty(postData.Password))
        {
            GetBaseView().Invalidate(LocalizationManager.
                instance.GetLocalizedValue(LocalizedKey.INVALID_PASSWORD));
            return;
        }
        if (string.IsNullOrEmpty(postData.Birthday))
        {
            GetBaseView().Invalidate(LocalizationManager.
                instance.GetLocalizedValue(LocalizedKey.INVALID_BOD));
            return;
        }
        if (string.IsNullOrEmpty(postData.Email))
        {
            GetBaseView().Invalidate(LocalizationManager.
                instance.GetLocalizedValue(LocalizedKey.INVALID_PHONE_NUMBER));
            return;
        }

        SubmitRegister(postData);
    }


    private void SubmitRegister(PostRegister postData)
    {
        GetBaseView().ShowLoading();
        //Connection<PostRegister> cRegister = new Connection<PostRegister>();
        //cRegister.AddOnResponse(OnResponseData);
        //cRegister.AddOnFail(OnFail);

        //_CompositeDisposable.Add
        //    (cRegister.MethodPostWWW(MyApi.USER_REQUEST_REGISTER,
        //    MakeDataRequest.GetRegisterAPI(postData)));
    }

    //public override void OnResponseData<T>(ResponseData<T> data)
    //{
    //    base.OnResponseData(data);
    //    if (data.IsSuccess)
    //    {

    //    }
    //}

    //public override void OnFail(string msg)
    //{
    //    base.OnFail(msg);
    //}

    //public override void OnDestroy()
    //{
    //    base.OnDestroy();
      
    //}
}
