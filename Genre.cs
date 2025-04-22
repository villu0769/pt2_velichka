using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Velichka_Zhelyazkova_11zh.Data.Models
{
	public class Genre
	{
		[Key]
		public int Id { get; set; }
		[Required, StringLength(20, ErrorMessage = "името на жaнрa трябва да е максимално 50 символа")]
		public string GenreName { get; set; }
		public List<Reader> Readers { get; set; }
		public Genre()
		{
			Readers = new List<Reader>();
		}
		public Genre(int id,string genreName)
		{
			Id = id;
			GenreName = genreName;
		}
	}
}
