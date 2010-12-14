using System;
using System.Windows.Forms;
using EvolutionNet.MVP.UI.Windows;
using EvolutionNet.Sample.Core.View;
using EvolutionNet.Sample.Presenter;

namespace EvolutionNet.Sample.UI.Windows
{
    public partial class MainView : BaseUCView, IMainView
    {
        public MainView()
        {
            InitializeComponent();

            // Do not create the presenter on visual studio design time, because it causes error
            if (! IsVSDesigner)
                new MainPresenter(this);
        }

        public object AddMenuItem(string text, string name)
        {
            return AddMenuItem(text, name, null);
        }

        public object AddMenuItem(string text, string name, EventHandler eventHandler)
        {
            var menu = menuStrip1.Items.Add(text, null, eventHandler);
            menu.Name = name;

            return menu;
        }

        public object AddMenuItem(string text, string name, object parent)
        {
            return AddMenuItem(text, name, parent, null);
        }

        public object AddMenuItem(string text, string name, object parent, EventHandler eventHandler)
        {
            var parentItem = (ToolStripMenuItem) parent;
            var menu = parentItem.DropDownItems.Add(text, null, eventHandler);
            menu.Name = name;

            return menu;
        }
    }
}
