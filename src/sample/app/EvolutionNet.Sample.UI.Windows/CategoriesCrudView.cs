using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EvolutionNet.MVP.UI.Windows;
using EvolutionNet.Sample.Core.View;

namespace EvolutionNet.Sample.UI.Windows
{
	public partial class CategoriesCrudView : BaseUCView, ICategoriesCrudView
	{
		public CategoriesCrudView()
		{
			InitializeComponent();

			// Do not create the presenter on visual studio design time, because it causes error
//			if (!IsVSDesigner)
//				new CategoriesCrudPresenter(this);
		}
	}
}
