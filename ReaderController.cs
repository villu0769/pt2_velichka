using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Velichka_Zhelyazkova_11zh.Data.Models;
using Velichka_Zhelyazkova_11zh.Data;

namespace Velichka_Zhelyazkova_11zh.Controllers
{
	public class ReaderController
	{
		private readonly Context context;

		public ReaderController()
		{
			context = new Context();
		}
		public ReaderController(Context context)
		{
			this.context = context;
		}
		public void AddReader(int id, string name,int age,string email, string phNumber)
		{
			var reader = new Reader
			{
				Id = id,
				Name = name,
				Age = age,
				Email = email,
				PhoneNumber = phNumber,
				Books = new List<Book>()
			};
			context.Readers.Add(reader);
			context.SaveChanges();
		}
		public List<Reader> GetReaders()
		{
			return context.Readers.ToList();
		}
		public Reader GetReaderById(int id) => context.Readers.Find(id);
		public void EditReader(int id, string name, int age, string email, string phNumber)
		{
			var reader = context.Readers.FirstOrDefault(a => a.Id == id);

			if (reader == null)
			{
				Console.WriteLine("читателят не е намерен. ");
				return;
			}
			reader.Id = id;
			reader.Name = name;
			reader.Age = age;
			reader.Email = email;
			reader.PhoneNumber = phNumber;

			context.SaveChanges();
			Console.WriteLine("читателят е обновена ");
		}

		public void DeleteReader(int id)
		{
			var reader = context.Readers.FirstOrDefault(a => a.Id == id);

			if (reader == null)
			{
				Console.WriteLine("читателят не е намерен.");
				return;
			}
			reader.Books.Clear();

			context.Readers.Remove(reader);
			context.SaveChanges();

			Console.WriteLine("читателят е изтрита успешно");
		}
	}
}
