using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestDataWWW  {

    //private string url;
    //private WWWForm form;

    //public string URL
    //{
    //    get
    //    {
    //        return url;
    //    }
    //    set
    //    {
    //        url = value;
    //    }
    //}

    //public WWWForm Form
    //{
    //    get
    //    {
    //        return form;
    //    }
    //    set
    //    {
    //        form = value;
    //    }
    //}

    ///**
    // * Make a WWWForm to submit data to Server
    // **/
    //public RequestDataWWW(string url, Dictionary<string, string> post)
    //{
    //    Ref: https://forums.hololens.com/discussion/2604/how-to-integrate-rest-api-get-and-post-call-unity-c

    //    this.url = url;
    //    form = new WWWForm();
    //    form.AddField("Username", "shtnapoxydiumatponds");
    //    form.AddField("Password", "imnXPtoBpCDMof50");
    //    form.headers["Authorization"] = "Basic " + System.Convert.ToBase64String(
    //        System.Text.Encoding.ASCII.GetBytes("shtnapoxydiumatponds:imnXPtoBpCDMof50"));
    //    foreach (KeyValuePair<string, string> post_arg in post)
    //    {
    //        form.AddField(post_arg.Key, post_arg.Value);
    //    }
    //}


    ///**
    //* Make a WWWForm to submit data to Server without dataPost
    //**/
    //public RequestDataWWW(string url)
    //{
    //    Ref: https://forums.hololens.com/discussion/2604/how-to-integrate-rest-api-get-and-post-call-unity-c

    //    this.url = url;
    //    form = new WWWForm();
    //    form.AddField("Username", "shtnapoxydiumatponds");
    //    form.AddField("Password", "imnXPtoBpCDMof50");
    //    form.headers["Authorization"] = "Basic " + System.Convert.ToBase64String(
    //        System.Text.Encoding.ASCII.GetBytes("shtnapoxydiumatponds:imnXPtoBpCDMof50"));
    //}

    public static WWWForm GetLoginForm(PostLogin postLogin)
    {
        WWWForm form = new WWWForm();
        form.AddField("u_name", postLogin.Name);
        form.AddField("u_password", postLogin.Password);
        form.AddField("u_facebook", postLogin.FacebookId);
        form.AddField("u_google", postLogin.GoogleId);
        return form;
    }

    public static byte[] GetParamWaitingCustomer()
    {
        string jsonPost = "{\"key\":\"0\"}";
        byte[] pData = System.Text.Encoding.ASCII.GetBytes(jsonPost.ToCharArray());
        return pData;
    }

    public static byte[] GetParamBook(string phoneNumber)
    {
        string jsonPost = "{\"phoneNumber\":\"" + phoneNumber + "\",\"items\":[]}";
        byte[] pData = System.Text.Encoding.ASCII.GetBytes(jsonPost.ToCharArray());
        return pData;
    }
}
