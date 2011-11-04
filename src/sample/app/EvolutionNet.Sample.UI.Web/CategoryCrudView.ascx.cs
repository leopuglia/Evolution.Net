using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;
using EvolutionNet.MVP.View;
using EvolutionNet.Sample.Core.View;
using EvolutionNet.Sample.Data.Definition;
using EvolutionNet.Sample.Presenter;
using EvolutionNet.Sample.UI.Web.Base;
using EvolutionNet.Util.Collection;

namespace EvolutionNet.Sample.UI.Web
{
	public partial class CategoryCrudView 
		: BaseSampleView, ICategoryCrudView, IEditViewContainer<ICategoryEditView>
		, ICallbackEventHandler
	{
		private const int StandardSlowWorkTime = 5;
		private CategoryCrudPresenter presenter;

//		private Guid taskID;

		#region Public Properties

		public int CurrentPosition
		{
			get { return ViewState["CurrentPosition"] == null ? -1 : (int)ViewState["CurrentPosition"]; }
			set { ViewState["CurrentPosition"] = value; }
		}

		public Category CurrentEditModel
		{
			get { return CategoryEditUC1.Model; }
//			set { CategoryEditUC1.Model = value; }
		}

		public IList<Category> CurrentList
		{
//			get
//			{
//				var list = new List<Category>();
//				foreach (DataGridViewRow row in DataGridCategories.s)
//				{
//					list.Add(BindableList[row.Index]);
//				}
//
//				return list;
//			}
			get { return new List<Category>(); }
		}

		public SortableBindingList<Category> BindableList
		{
			get { return DataGridCategories.DataSource as SortableBindingList<Category>; }
			set
			{
				DataGridCategories.DataSource = value;
				DataGridCategories.DataBind();
			}
		}

		public PropertySortInfo SortInfo
		{
			get
			{
				return ViewState["SortInfo"] == null
					? new PropertySortInfo() : (PropertySortInfo)ViewState["SortInfo"];
			}
			set { ViewState["SortInfo"] = value; }
		}

		public IEnumerable WebCache
		{
			get { return Cache; }
		}

		public int SlowWorkTime
		{
			get { return string.IsNullOrEmpty(TxtSlowWorkTime.Text) ? StandardSlowWorkTime : int.Parse(TxtSlowWorkTime.Text); }
			set { TxtSlowWorkTime.Text = value.ToString(); }
//			get { return StandardSlowWorkTime; }
//			set { throw new NotImplementedException(); }
		}

		public ICategoryEditView EditView
		{
			get { return CategoryEditUC1; }
		}

		#endregion

		#region Event Methods

		protected void Page_Load(object sender, EventArgs e)
		{
			RegisterControlOnClientStartup("txtSlowWorkTime", TxtSlowWorkTime.ClientID);

			ClientScriptManager cm = Page.ClientScript;
			String cbReference = cm.GetCallbackEventReference(this, "arg", "ReceiveServerData", "");
			String callbackScript = "function CallServer(arg, context) {" + cbReference + "; }";
			cm.RegisterClientScriptBlock(GetType(), "CallServer", callbackScript, true);

/*
			ProgressUC progressUC = null;
			if (Page.Master != null && Page.Master.Master != null)
			{
				progressUC = ((_BaseMaster)Page.Master.Master).ProgressUC;

				if (progressUC.TaskID == Guid.Empty)
					taskID = progressUC.TaskID = Guid.NewGuid();
				else
					taskID = progressUC.TaskID;
			}
*/

			presenter = CategoryEditUC1.Presenter = new CategoryCrudPresenter(this);
		}

/*
		private void DoWork(int time)
		{
			Thread x = new Thread(start);
			x.Start(time);
		}

		private void start(object data)
		{
			var time = (int) data * 2;
			for (int i = 1; i <= time; i++)
			{
				Cache[taskID.ToString()] = (i * 100) / time;
				Thread.Sleep(500);
			}
		}
*/

		protected void DataGridCategories_RowEditing(object sender, GridViewEditEventArgs e)
		{
			CurrentPosition = e.NewEditIndex + (DataGridCategories.PageIndex * DataGridCategories.PageSize);
			presenter.Edit();
		}

		protected void DataGridCategories_RowDeleting(object sender, GridViewDeleteEventArgs e)
		{
			CurrentPosition = e.RowIndex + (DataGridCategories.PageIndex * DataGridCategories.PageSize);
			presenter.Delete();
		}

		protected void DataGridCategories_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			DataGridCategories.PageIndex = e.NewPageIndex;
			presenter.FindAllDataBind();
		}

		protected void DataGridCategories_Sorting(object sender, GridViewSortEventArgs e)
		{
			PropertySortOrder propertySortOrder = PropertySortOrder.Ascending;

			if (SortInfo.PropertyName == e.SortExpression)
			{
				switch (SortInfo.SortOrder)
				{
					case PropertySortOrder.Ascending:
						propertySortOrder = PropertySortOrder.Descending;
						e.SortDirection = SortDirection.Descending;
						break;
					case PropertySortOrder.Descending:
						propertySortOrder = PropertySortOrder.Ascending;
						e.SortDirection = SortDirection.Ascending;
						break;
				}
			}
			SortInfo = new PropertySortInfo(e.SortExpression, propertySortOrder);

			presenter.FindAllDataBind();
		}

		protected void BtnSlowWork_Click(object sender, EventArgs e)
		{
			//TODO: Aqui eu tenho que remover todas, ou pelo menos a maior parte das referências do backgroundworker ao progress uc, talvez usar threads de verdade, ao invés do backgroundworker, pra fazer a chamada assíncrona, criar a nova thread, colocar os resultados no cache e verificá-lo de vez em quando no progress uc
//			presenter.RunSlowWork();
//			DoWork(10);
		}

		#endregion

		#region Public Methods

		public void Clear()
		{
			CategoryEditUC1.Clear();
		}

		public void ShowModalDialog()
		{
			ModalPopupNew.Show();
		}

		public void HideModalDialog()
		{
			ModalPopupNew.Hide();
		}

		public void AdjustDataGridRowHeightColumnWidth()
		{
		}

		#endregion

		public void RaiseCallbackEvent(string eventArgument)
		{
//			DoWork(int.Parse(eventArgument));
			presenter.RunSlowWork();
		}

		public string GetCallbackResult()
		{
//			return "Sucesso";
			return "";
		}
	}
}