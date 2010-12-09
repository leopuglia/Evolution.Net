using System;
using System.Windows.Forms;

namespace EvolutionNet.MVP.UI.Windows
{
	public delegate void AfterLoadDelegate(object sender, EventArgs e);

	public partial class BaseFrm : Form
	{
		private bool IsInitialized = false;
		protected BaseUC baseUC = null;
		
		public event AfterLoadDelegate AfterLoad;
		
		public BaseFrm()
		{
			InitializeComponent();
		}
		
		private void Initialize()
		{
			if (!IsInitialized)
			{
				IsInitialized = true;

				OnAfterLoad(EventArgs.Empty);
			}
		}
		
		protected virtual void OnAfterLoad(EventArgs e)
		{
			if (AfterLoad != null)
				AfterLoad(this, e);

			if (baseUC != null)
				baseUC.DoAfterLoad(e);
		}

		private void BaseFrm_Activated(object sender, EventArgs e)
		{
			Initialize();
		}
	}
}