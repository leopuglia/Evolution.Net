using System;
using System.Drawing;
using System.Windows.Forms;

namespace EvolutionNet.MVP.UI.Windows.Common
{
	public partial class ProgressDlgFrm : Form
	{
		private readonly DateTime timeIni = DateTime.Now;

		#region Propriedades Públicas (da instância)

		public new string Text
		{
			get { return lblText.Text; }
			set { lblText.Text = value; }
		}

		public string Caption
		{
			get { return base.Text; }
			set { base.Text = value; }
		}

		public int Progress
		{
			get { return progressBar1.Value; }
			set { progressBar1.Value = value; }
		}

		#endregion

		#region Construtor

		protected ProgressDlgFrm()
		{
			InitializeComponent();
		}

		#endregion

		#region Métodos de Eventos

		private void timer1_Tick(object sender, EventArgs e)
		{
			if (progressBar1.Value == 100)
				progressBar1.Value = 0;
			else if (progressBar1.Value == 90)
				progressBar1.Value = 99;
			else
				progressBar1.PerformStep();
		}

		private void timer2_Tick(object sender, EventArgs e)
		{
			TimeSpan time = (DateTime.Now - timeIni);
			lblTime.Text = string.Format("{0:00}:{1:00}:{2:00}", time.Hours, time.Minutes, time.Seconds);
		}

		#endregion

		#region Métodos Públicos (da instância)

		public new void Hide()
		{
			Owner.Enabled = true;
			base.Hide();
		}

		public new void Close()
		{
			Owner.Enabled = true;
			base.Close();
		}

		public void SetProgressTick()
		{
			timer1.Enabled = true;
		}

		public void ProgressStep()
		{
			progressBar1.PerformStep();
		}

		public void ProgressIncrement(int value)
		{
			progressBar1.Increment(value);
		}

		#endregion

		#region Métodos Estáticos de Exibição

		public static ProgressDlgFrm Show(Form owner)
		{
			return Show(owner, null);
		}
		
		public static ProgressDlgFrm Show(Form owner, string text)
		{
			return Show(owner, null, null);
		}

		public static ProgressDlgFrm Show(Form owner, string text, string caption)
		{
			return Show(owner, null, null, ProgressoDlgButtons.Cancel);
		}
		
		public static ProgressDlgFrm Show(
			Form owner, string text, string caption, ProgressoDlgButtons buttons)
		{
			ProgressDlgFrm frm = new ProgressDlgFrm();

			if (text == null)
				text = "Aguarde enquanto os dados são carregados...";

			if (caption == null)
				caption = "Progresso";
			
			frm.Text = text;
			frm.Caption = caption;
			
			switch(buttons)
			{
				case ProgressoDlgButtons.Cancel:
					frm.btnOK.Visible = false;
					break;
				case ProgressoDlgButtons.Ok:
					frm.btnCancelar.Visible = false;
					frm.btnOK.Location = new Point(frm.btnCancelar.Location.X, frm.btnCancelar.Location.Y);
					break;
			}

			frm.Owner = owner;
			owner.Enabled = false;

			frm.Show((IWin32Window)owner);

			return frm;
		}

		#endregion

	}
	
	public enum ProgressoDlgButtons
	{
		Cancel,
		OkCancel,
		Ok
	}
}