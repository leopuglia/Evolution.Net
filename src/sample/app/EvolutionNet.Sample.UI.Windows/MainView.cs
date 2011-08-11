using System;
using System.Windows.Forms;
using EvolutionNet.MVP.Business;
using EvolutionNet.MVP.UI.Windows;
using EvolutionNet.MVP.View;
using EvolutionNet.Sample.Core.View;
using EvolutionNet.Sample.Presenter;
using EvolutionNet.Util.IoC;

namespace EvolutionNet.Sample.UI.Windows
{
	public partial class MainView : BaseUCView, IMainView
	{
		public int TabSelectedIndex
		{
			get { return tabControl1.SelectedIndex; }
			set { tabControl1.SelectedIndex = value; }
		}

		public int TabCount
		{
			get { return tabControl1.TabCount; }
		}

		public MainView()
		{
			InitializeComponent();

			// TODO: Essa chamada é essencial, pois inicializa o ActiveRecord. Possivelmente deveria ser chamada no evento OnLoad, com tratamento de excessões, permitindo corrigir parâmetros do app.config pra inicializar corretamente o aplicativo
			// O certo seria colocar todas as inicializações dentro de um try-catch e exibir uma mensagem de erro amigável, possibilitando, até, corrigir o app.config com configurações válidas para a inicialização do aplicativo, dependendo do tipo de excessão ativado, especialmente na chamada da inicialização do ActiveRecord
			// Uma abordagem interessante seria que o aplicativo tivesse um conhecimento básico dos parâmetros necessários, permitindo-o criar um app.config, caso o mesmo não exista
			// Outra idéia interessante seria que permitisse selecionar a conexão desejada, com conhecimento das connection strings, armazenando-as e permitindo que o mesmo aplicativo conecte-se a outros datasources, caso o principal não seja encontrado
			// Com isso eu poderia ter um botão, ou coisa do gênero que me permitisse conectar a outro BD, como por exemplo, um contendo TODOS os dados do passado, evitando de ter a necessidade de outra instância do SysVip instalada na máquina
			AbstractIoCFactory<IBusinessFactory>.Instance.Initialize();

			// Do not create the presenter on visual studio design time, because it causes error
//			if (!IsVSDesigner)
//				new MainPresenter(this);
		}

		private void MainView_Load(object sender, EventArgs e)
		{
			// Do not create the presenter on visual studio design time, because it causes error
			if (!IsVSDesigner)
				new MainPresenter(this);
		}

		public void AddTabPage(string text, IControlView controlView)
		{
			TabPage tabPage = new TabPage(text);
			tabPage.Padding = new Padding(3);
			tabPage.UseVisualStyleBackColor = true;

			((Control) controlView).Dock = DockStyle.Fill;
			tabPage.Controls.Add((Control)controlView);

			tabControl1.TabPages.Add(tabPage);
			tabControl1.SelectedTab = tabPage;
//			tabPage.Focus();
		}

		public void RemoveSelectedTabPage()
		{
			if (tabControl1.SelectedTab != null)
				tabControl1.TabPages.Remove(tabControl1.SelectedTab);
		}

	}
}
