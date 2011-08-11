using System;
using System.Collections.Generic;
using EvolutionNet.MVP.Data.Access;
using EvolutionNet.MVP.Data.Definition;
using EvolutionNet.MVP.Presenter;
using EvolutionNet.MVP.View;
using NUnit.Framework;
using NUnit.Mocks;

namespace EvolutionNet.Sample.Test.Presenter
{
	public abstract class BaseCrudPresenterTest<ViewT, PresenterT, TO, T, IdT> : BaseTest , IBaseCrudTest
		where ViewT : IControlView
		where PresenterT : ICrudListPresenter<TO, T, IdT> 
		where TO : CrudListTO<T, IdT>
		where T : class, IModel<IdT>
	{
		protected DynamicMock viewMock;
		protected ViewT viewInstance;
		protected PresenterT presenter;

		protected abstract IEnumerable<string> PropertiesToCompare { get; }

		public abstract void Add();
		public abstract void Edit();
		public abstract void Save();
		public abstract void Delete();

		[TestFixtureSetUp]
		protected override void Setup()
		{
			base.Setup();

			viewMock = GetViewMock<ViewT>();
			viewInstance = (ViewT)viewMock.MockInstance;
			presenter = (PresenterT)Activator.CreateInstance(typeof(PresenterT), viewInstance);
//			presenter = new CategoryCrudPresenter(viewInstance);
		}

		protected virtual void DoAdd()
		{
			presenter.Add();
			AssertAfterAdd(presenter.To.CurrentModel);
		}

		protected virtual void DoEdit()
		{
			T model = (T)DataFactory.GetModel<T, IdT>();
			DataFactory.SaveModelToDB<T, IdT>(model);

//			AssertBeforeEdit(model, edited);
			presenter.To.CurrentModel = model;
			presenter.Edit();
			AssertAfterEdit(model.ID, model);
		}

		protected virtual void DoSave()
		{
			var model = presenter.To.CurrentModel = (T)DataFactory.GetModel<T, IdT>();
			presenter.Save();
			AssertAfterSave(model.ID, model);
		}

		protected virtual void DoDelete()
		{
			T model = (T)DataFactory.GetModel<T, IdT>();
			DataFactory.SaveModelToDB<T, IdT>(model);

			presenter.To.CurrentModel = model;
			presenter.Delete();

			AssertAfterDelete(model);
		}

		protected void AssertAfterAdd(T model)
		{
			Assert.AreNotEqual(default(IdT), model.ID);

			AssertAfterSave(model.ID, model);
		}

/*
		protected void AssertBeforeEdit(T model, T edited)
		{
			Assert.AreNotEqual(default(IdT), model.ID);

			foreach (var property in PropertiesToCompare)
			{
				var expected = typeof(T).GetProperty(property).GetValue(model, null);
				var actual = typeof(T).GetProperty(property).GetValue(edited, null);
				Assert.AreNotEqual(expected, actual);
			}
		}
*/

		protected void AssertAfterEdit(IdT id, T edited)
		{
			Assert.AreNotEqual(default(IdT), id);
//			Assert.AreEqual(id, edited.ID);

			T model = (T) DataFactory.GetModel<T, IdT>();
			foreach (var property in PropertiesToCompare)
			{
				var expected = typeof(T).GetProperty(property).GetValue(model, null);
				var actual = typeof(T).GetProperty(property).GetValue(edited, null);
				Assert.AreNotEqual(expected, actual);
			}
			AssertAfterSave(id, edited);
		}

		protected void AssertAfterSave(IdT id, T model)
		{
			T fetched = Dao<T, IdT>.FindByPrimaryKey(id);
//			AssertAfterSaveProperties<T, IdT>(model, fetched);
			foreach (var property in PropertiesToCompare)
			{
				var expected = typeof(T).GetProperty(property).GetValue(model, null);
				var actual = typeof(T).GetProperty(property).GetValue(fetched, null);
				Assert.AreEqual(
					expected, actual);
			}

			Dao<T, IdT>.Delete(model);
			Assert.False(Dao<T, IdT>.Exists(model.ID));
		}

		protected void AssertAfterDelete(T model)
		{
			Assert.False(Dao<T, IdT>.Exists(model.ID));
		}

	}
}