using System;
using System.Drawing;
using EvolutionNet.MVP.Data.Access;
using EvolutionNet.MVP.Data.Definition;
using EvolutionNet.Sample.Data.Definition;
using EvolutionNet.Util.Imaging;
using NUnit.Framework;

namespace EvolutionNet.Sample.Test
{
	public static class DataFactory
	{
		public static IModel<IdT> GetModel<T, IdT>() where T : class, IModel<IdT>
		{
			if (typeof(T) == typeof(Category))
				return (IModel<IdT>) GetCategory();

			throw new ArgumentOutOfRangeException();
		}

		public static void GetModelEdited<T, IdT>(IModel<IdT> model) where T : class, IModel<IdT>
		{
			if (typeof(T) == typeof(Category))
				GetCategoryEdited((Category) model);
		}

		public static void SaveModelToDB<T, IdT>(T model) where T : class, IModel<IdT>
		{
//			var model = GetModel<T, IdT>();
			Dao<T, IdT>.SaveAndFlush(model);
			Assert.True(Dao<T, IdT>.Exists(model.ID));
			Assert.AreNotEqual(default(T), model.ID);
//			return model;
		}

		private static Category GetCategory()
		{
//			var path = helperFactory.PathHelper.GetPhysicalPath("~/Resources/Desert.jpg");
			const string path = @"D:\_LeoDev\DotNet\EvolutionNet\src\sample\test\EvolutionNet.Sample.Test\Resources\Desert.jpg";
			var image = ImageProcessing.Resize(path, new Size(160, 120));

			var category = new Category {CategoryName = "Teste", Description = "Testando", PictureImage = image};
			return category;
		}

		private static void GetCategoryEdited(Category category)
		{
//			var path = helperFactory.PathHelper.GetPhysicalPath("~/Resources/Lighthouse.jpg");
			const string path = @"D:\_LeoDev\DotNet\EvolutionNet\src\sample\test\EvolutionNet.Sample.Test\Resources\Lighthouse.jpg";
			var image = ImageProcessing.Resize(path, new Size(160, 120));

//			var category = new Category();
			category.CategoryName = "Teste2";
			category.Description = "Testando2";
			category.PictureImage = image;
//			return category;
		}

	}
}