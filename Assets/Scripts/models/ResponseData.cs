using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class ResponseData<T>
{
    public int status = -1;
    public string message;
    public T data;

    public bool IsSuccess
    {
        get
        {
            return status == 200;
        }
    }
}
