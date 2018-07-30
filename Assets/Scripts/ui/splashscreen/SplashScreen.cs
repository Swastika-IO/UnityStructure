using Assets.Scripts.connection;
using Assets.Scripts.utils;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.ui.splashscreen
{
    public class SplashScreen : BaseMonoBehaviour, ISplashView
    {
        SplashPresenter<ISplashView> mPresenter;
        // Use this for initialization
        public override void Awake()
        {
            mPresenter = new SplashPresenter<ISplashView>(Injections.ProvideSchedulerProvider(),
             Injections.ProvideAppDataManager());
            mPresenter.OnAttach(this);
        }

        public override void Start()
        {
            base.Start();
            StartCoroutine(InitLocalize());
            mPresenter.DoLogin();
        }

        private void Update()
        {
#if UNITY_EDITOR
            if (Input.GetMouseButton(0))
            {
                MyDBImpl.GetInstance().RemoveAllData();
            }
#endif
        }

        private IEnumerator InitLocalize()
        {
            while (!LocalizationManager.instance.GetIsReady())
            {
                LocalizationManager.instance.LoadLocalizedText("lang.json");
                yield return null;
            }
            yield return new WaitForSeconds(2);
        }


    }

}