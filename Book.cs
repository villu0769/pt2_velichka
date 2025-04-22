using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Velichka_Zhelyazkova_11zh.Data.Models
{
	public  class Book
	{
		[Key]
		public int Id { get; set; }
		[Required, StringLength(50, ErrorMessage = "името на книгата трябва да е максимално 50 символа")]
		public string Title { get; set; }
		[ StringLength(50, ErrorMessage = "авторът трябва да е максимално 50 символа")]
		public string Author { get; set; }
		public List<Reader> Readers { get; set; }
		public List<Genre> Genres { get; set; }
		public Book()
		{
			Readers = new List<Reader>();
			Genres = new List<Genre>();
		}
		public Book(int id,string title, string author)
		{
			Id = id;
			Title = title;
			Author = author;
			Readers = new List<Reader>();
			Genres = new List<Genre>();
		}
	}
}
