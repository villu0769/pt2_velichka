using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Velichka_Zhelyazkova_11zh.Data;

namespace Velichka_Zhelyazkova_11zh.Controllers
{
	public class GenreController
	{
		private readonly Context context;

		public GenreController()
		{
			context = new Context();
		}
	}
}
