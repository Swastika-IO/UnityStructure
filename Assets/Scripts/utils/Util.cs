using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util {
    #if UNITY_EDITOR
        public const bool IS_DEBUG = true;
#else
        public const bool IS_DEBUG = false;
#endif

    public static int ID_NextScene = 0;
}
