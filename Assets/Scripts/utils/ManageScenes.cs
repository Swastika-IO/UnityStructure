using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScenes {

	public static void ChangeScene(SceneEnum targetScene)
    {
        SceneManager.LoadSceneAsync((int)targetScene);
    }

    public static void ChangeSceneWithLoading(SceneEnum targetScene)
    {
        Util.ID_NextScene = (int)targetScene;
        SceneManager.LoadSceneAsync((int)SceneEnum.LoadingScreen);
    }
}
