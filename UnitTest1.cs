using Microsoft.EntityFrameworkCore;
using NUnit.Framework.Legacy;
using Velichka_Zhelyazkova_11zh.Data;
using Velichka_Zhelyazkova_11zh.Data.Models;
using Velichka_Zhelyazkova_11zh.Controllers;
using Azure;
namespace TestProject2
{
	public class Tests
	{

		private Context context;
		private ReaderController readerController;


		[SetUp]
		public void Setup()
		{
			var options = new DbContextOptionsBuilder<Context>().
			UseInMemoryDatabase(databaseName: "BooksAppTestDB").Options;

			context = new Context(options);
			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();

			Reader reader = new Reader
			{
				Id = 1,
				Name = "reader 1",
				Age = 29,
				Email = "reader1@gmail.com",
				PhoneNumber = "1234567895",
			};
			context.Readers.Add(reader);
			context.SaveChanges();

			readerController = new ReaderController(context);
		}

		[Test]
		public void Get_reader_name()
		{
			var result = readerController.GetReaders();
			ClassicAssert.AreEqual(1, result.Count);
			ClassicAssert.AreEqual("reader 1", result[0].Name);
		}
		[Test]

		public void Get_ValidId_ReturnsReader()
		{
			var res = readerController.GetReaderById(1);
			ClassicAssert.IsNotNull(res);
			ClassicAssert.AreEqual(29, res.Age);
		}
		[Test]
		public void AddReader_AddsReaderSuccessfully()
		{

			readerController.AddReader(2,"reader 2",42,"reader2@gmail.com","0800000000");
			var added = context.Readers.FirstOrDefault(r => r.Name == "reader 2");
			ClassicAssert.AreEqual(42, added.Age);
		}
		[Test]

		public void UpdateUser_ExistingUser_UpdatesSuccessfully()
		{
			var originalReader = new Reader
			{
				Id = 7,
				Name = "reader new",
				Age = 25,
				Email = "reader3@gmail.com",
				PhoneNumber = "1234567890"
			};
			context.Readers.Add(originalReader);
			context.SaveChanges();


			readerController.EditReader(7,"edited reader", 32, "gmail@abv.bg", "1234567890");

			var updated = context.Readers.FirstOrDefault(r => r.Id == 7);
			ClassicAssert.IsNotNull(updated);
			ClassicAssert.AreEqual("edited reader", updated.Name);
			ClassicAssert.AreEqual(32, updated.Age);
			ClassicAssert.AreEqual("gmail@abv.bg", updated.Email);
		}
	}
}
