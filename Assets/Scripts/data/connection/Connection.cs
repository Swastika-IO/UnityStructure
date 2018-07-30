using UnityEngine;
using System.Collections.Generic;
using System;
using UniRx;

public class Connection<T>
{
    public bool isConnect = false;
	public delegate void EventOnResponse(ResponseData<T> result);
    public delegate void EventOnFail(string result);
    public event EventOnResponse DLOnResponse;
    public event EventOnFail DLOnFail;
    
    private WWW www = null;
	private RequestDataWWW requestData = null;

    public void AddOnResponse(EventOnResponse eventHandler){
		this.DLOnResponse += eventHandler;
	}

	public void AddOnFail(EventOnFail eventHandler){
		this.DLOnFail += eventHandler;
	}

    /**
     * Make a formWWW to request Server
     * uri : Full api use to call server
     * post: list Parameters 
    **/
	//private IDisposable MethodPostWWW(string url,Dictionary<string, string> post)
 //   {
 //       ExitDownload ();
	//	isConnect = true;

 //       requestData = new RequestDataWWW(url, post);
 //       IDisposable iDis= ObservableWWW.Post(requestData.URL,
 //           requestData.Form.data)
 //           .CatchIgnore((WWWErrorException ex)=>
 //           {
 //               // If WWW has .error, ObservableWWW throws WWWErrorException to onError pipeline.
 //               // WWWErrorException has RawErrorMessage, HasResponse, StatusCode, ResponseHeaders
 //               #if UNITY_EDITOR
 //               if (Util.IS_DEBUG)
 //                   {
 //                       Debug.Log(ex.RawErrorMessage);
 //                   }
 //               #endif
 //               if (ex.HasResponse)
 //               {
 //                   #if UNITY_EDITOR
 //                       if (Util.IS_DEBUG)
 //                       {
 //                           Debug.Log(ex.StatusCode);
 //                       }
 //                   #endif
 //               }
 //               foreach (var item in ex.ResponseHeaders)
 //               {
 //                   #if UNITY_EDITOR
 //                       if (Util.IS_DEBUG)
 //                       {
 //                           Debug.Log(item.Key + ":" + item.Value);
 //                       }
 //                   #endif
 //               }

 //               DLOnFail(ex.RawErrorMessage);
 //           }).Subscribe(jsonData => {
 //               ResponseData<T> objResponse = 
 //               JsonUtility.FromJson<ResponseData<T>>(jsonData);

 //               DLOnResponse(objResponse);
 //           });

	//	isConnect = false;

 //       return iDis;
 //   }

    /**
     * Make a formWWW to request Server
     * uri : Full api use to call server
    **/
    //private IDisposable MethodGetWWW(string url)
    //{
    //    ExitDownload();
    //    isConnect = true;
    //    requestData = new RequestDataWWW(url);
    //    IDisposable iDis = ObservableWWW.Get(requestData.URL)
    //        .CatchIgnore((WWWErrorException ex) =>
    //        {
    //            // If WWW has .error, ObservableWWW throws WWWErrorException to onError pipeline.
    //            // WWWErrorException has RawErrorMessage, HasResponse, StatusCode, ResponseHeaders
    //            #if UNITY_EDITOR
    //                if (Util.IS_DEBUG)
    //                {
    //                    Debug.Log(ex.RawErrorMessage);
    //                }
    //            #endif
    //            if (ex.HasResponse)
    //            {
    //                #if UNITY_EDITOR
    //                    if (Util.IS_DEBUG)
    //                    {
    //                        Debug.Log(ex.StatusCode);
    //                    }
    //                #endif
    //            }
    //            foreach (var item in ex.ResponseHeaders)
    //            {
    //                #if UNITY_EDITOR
    //                    if (Util.IS_DEBUG)
    //                    {
    //                        Debug.Log(item.Key + ":" + item.Value);
    //                    }
    //                #endif
    //            }

    //            DLOnFail(ex.RawErrorMessage);
    //        }).Subscribe(jsonData => {
    //            ResponseData<T> objResponse =
    //            JsonUtility.FromJson<ResponseData<T>>(jsonData);

    //            DLOnResponse(objResponse);
    //        });

    //    isConnect = false;

    //    return iDis;
    //}


    public void ExitDownload(){
		if (requestData != null)
			requestData = null;
		if (www != null) {
			www.Dispose ();
			www = null;
		}
	}

}

