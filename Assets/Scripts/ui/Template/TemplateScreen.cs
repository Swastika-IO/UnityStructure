using Assets.Scripts.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.ui.Template
{
    class TemplateScreen : BaseMonoBehaviour, ITemplateView
    {
        TemplatePresenter<ITemplateView> mPresenter;

        public override void Awake()
        {
            mPresenter = new TemplatePresenter<ITemplateView>(Injections.ProvideSchedulerProvider(),
                Injections.ProvideAppDataManager());
            mPresenter.OnAttach(this);
        }

        public override void OnDismissNotifyConnectionDialog(string status)
        {
            base.OnDismissNotifyConnectionDialog(status);
            mPresenter.CleanCompositeDisposable();
        }

        private void OnDestroy()
        {
            mPresenter.OnDetach();
            mPresenter.OnDestroy();
        }
    }
}
