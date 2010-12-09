using System;
using System.Windows.Forms;
using EvolutionNet.MVP.View;

namespace EvolutionNet.MVP.UI.Windows
{
	public delegate void AfterLoadDelegate(object sender, EventArgs e);

    public partial class BaseFrm : Form, IControlView
	{
        #region Vari�veis

        private bool IsInitialized;
//        protected BaseMessageUC messageUC;

        #endregion

        #region Propriedades P�blicas

        public IPathHelper PathHelper
        {
            get { return WinPathHelper.Instance; }
        }

        #endregion

        #region Construtor

        protected BaseFrm()
        {
            InitializeComponent();

            DoLoad();
        }

        #endregion

        #region Defini��o de Eventos

        public event AfterLoadDelegate AfterLoad;

        private void OnAfterLoad(EventArgs e)
        {
            if (AfterLoad != null)
                AfterLoad(this, e);

            if (BaseUC != null)
                BaseUC.DoAfterLoad(e);
        }

        #endregion

        #region Implementa��o de Eventos

        private void BaseFrm_Activated(object sender, EventArgs e)
        {
            Initialize();

            DoLoadComplete();
        }

        #endregion

	    #region M�todos P�blicos (IControlView)

        public virtual void DoLoad()
	    {
	    }

	    public virtual void DoLoadComplete()
	    {
	    }

	    public virtual void ShowMessage(string caption, string message)
	    {
//	        messageUC.ShowMessage(caption, message);
	    }

	    public virtual void ShowErrorMessage(string caption, string message, string exceptionMessage)
	    {
//            messageUC.ShowErrorMessage(caption, message, exceptionMessage);
	    }

	    public virtual T CreateControlView<T>() where T : IControlView
	    {
//	        return ControlHelper.CreateControlFromView<T>(this);
            throw new NotImplementedException();
	    }

	    public virtual T CreateControlView<T>(params object[] args) where T : IControlView
	    {
	        throw new NotImplementedException();
	    }

	    public virtual T GetControlView<T>(object sender) where T : IControlView
	    {
	        while (!(sender is T))
	        {
	            sender = ((Control)sender).Parent;
	        }

	        return (T)sender;
	    }

	    public virtual void AddControlView(IControlView view)
	    {
	        Controls.Add((Control)view);
	    }

	    public virtual void AddControlViewAt(int index, IControlView view)
	    {
	        Controls.Add((Control)view);
	    }

	    public virtual void RemoveControlView(IControlView view)
	    {
	        Controls.Remove((Control)view);
	    }

	    public virtual void RemoveControlViewAt(int index)
	    {
	        Controls.RemoveAt(index);
	    }

	    #endregion

	    #region M�todods Locais (Inicializa��o)

        private void Initialize()
        {
            if (!IsInitialized)
            {
                IsInitialized = true;

                OnAfterLoad(EventArgs.Empty);
            }
        }

	    #endregion

    }
}
