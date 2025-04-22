using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Velichka_Zhelyazkova_11zh.Data;
using Velichka_Zhelyazkova_11zh.Data.Models;

namespace Velichka_Zhelyazkova_11zh.Controllers
{
	public class BookController
	{
		private readonly Context context;

		public BookController()
		{
			context=new Context();
		}
		public void AddBook(int id,string title, string author)
		{
			var book = new Book
			{
				Id = id,
				Title = title,
				Author = author,
				Readers = new List<Reader>(),
				Genres = new List<Genre>()
			};
			context.Books.Add(book);
			context.SaveChanges();
		}
		public List<Book> GetBooks()
		{
			return context.Books.ToList();
		}
		public Book GetBookById(int id) => context.Books.Find(id);
		public void EditFlight(int id, string title, string author, List<Reader> readers,List<Genre> genres)
		{
			var book = context.Books.FirstOrDefault(a => a.Id == id);

			if (book == null)
			{
				Console.WriteLine("книгата не е намерен. ");
				return;
			}
			book.Id = id;
			book.Title = title;
			book.Author = author;
			book.Readers = readers;
			book.Genres = genres;

			context.SaveChanges();
			Console.WriteLine("книгата е обновена ");
		}

		public void DeleteBook(int id)
		{
			var book = context.Books.FirstOrDefault(a => a.Id == id);

			if (book == null)
			{
				Console.WriteLine("книгата не е намерен.");
				return;
			}
			book.Genres.Clear();
			book.Readers.Clear();

			context.Books.Remove(book);
			context.SaveChanges();

			Console.WriteLine("книгата е изтрита успешно");
		}
	}
}
