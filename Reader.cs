using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Velichka_Zhelyazkova_11zh.Data.Models
{
	public class Reader
	{
		[Key]
		public int Id { get; set; }
		[Required,StringLength(50,ErrorMessage ="името трябва да е максимално 50 символа")]
		public string Name { get; set; }
		[Required, Range(10, 80, ErrorMessage = "възраст между 9 и 81 години")]
		public int Age { get; set; }
		[Required, StringLength(20, ErrorMessage = "имейлът трябва да е максимално 20 символа")]
		public string Email { get; set; }
		[Required, Length(10,10,ErrorMessage = "телеффонния номер трябва да е  10 символа") ]
		public string PhoneNumber { get; set; }
		public List<Book> Books { get; set; }
		public Reader()
		{
			Books = new List<Book>();
		}
		public Reader(int id, string name,int age, string email,string phonenumber )
		{
			Books = new List<Book>();
			Id= id;
			Name= name;
			Age= age;
			Email= email;
			PhoneNumber= phonenumber;
		}
	}
}
