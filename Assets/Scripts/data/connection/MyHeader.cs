using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.connection
{
    class MyHeader
    {
        private static MyHeader mInstance;
        private Dictionary<string, string> _PublicParamHeader;
        private Dictionary<string, string> _PrivateParamHeader;

        public static MyHeader GetIntance()
        {
            if(mInstance == null)
            {
                mInstance = new MyHeader();
            }
            return mInstance;
        }

        public MyHeader()
        {
            _PublicParamHeader = new Dictionary<string, string>
            {
                {
                    "X-CSRF-Token", "9beee20cc560a594fb734604b03d5e946b73b95efbaca9b393abdfd2865221c7"
                },
                {
                    "Content-Type", "application/x-www-form-urlencoded"
                },
                {
                    "Platform", "Android"
                }
            };
        }

        public void UpdatePrivateHeader(string key, string param)
        {
            if(_PrivateParamHeader == null)
            {
                _PrivateParamHeader = new Dictionary<string, string>();
            }
            _PrivateParamHeader.Add(key, param);
        }

        public Dictionary<string,string> GetPublicHeader()
        {
            return _PublicParamHeader;
        }
    }
}
