using System;
using Assets.Scripts.utils;
using UnityEngine;
using UnityEngine.UI;

public class RegisterScene : BaseMonoBehaviour, IRegisterView {

    private RegisterPresenter<IRegisterView> mRegisterPresenter;

    public InputField FName;
    public InputField FEmail;
    public InputField FPassword;
    public InputField FRePassword;
    public InputField FNumberPhone;
    public Text TBod;
    // Use this for initialization
    public override void Start()
    {
        mRegisterPresenter.OnAttach(this);
        mRegisterPresenter._BaseView = this;
    }

    public void ValidateField()
    {
        PostRegister postData = new PostRegister();
        postData.FullName = FName.text;
        postData.Email = FEmail.text;
        postData.PhoneNumber = FNumberPhone.text;
        postData.FullName = FName.text;
        postData.Birthday = TBod.text;
        if (!String.IsNullOrEmpty(FPassword.text))
        {
            if (FPassword.text.Equals(FRePassword.text))
            {
                postData.Password = FPassword.text;
            }
            else
            {
                //Show message Invalide
                Invalidate(LocalizationManager.instance.GetLocalizedValue
                    (LocalizedKey.INVALID_DONT_MATCH_REPASSWORD));
                return;
            }
        }
        mRegisterPresenter.ValidateForm(postData);
    }

    public void HideDialogLoading()
    {
        LoadingUIUtil.instance.HideLoading();
    }

    public void Invalidate(string strMess)
    {
        LoadingUIUtil.instance.ShowMessage(strMess);
    }

    public void ShowDialogLoading()
    {
        LoadingUIUtil.instance.ShowLoading();
    }

   
}
