using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniRx;

namespace Assets.Scripts.data.connection
{
    public interface IApiHelper
    {
        IObservable<string> GetProvince();

        IObservable<string> GetCustomerList();

        IObservable<string> Login(PostLogin postLogin);

    }
}
