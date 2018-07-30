using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRegisterView : IUnityView{

    void Invalidate(string strMess);
}
