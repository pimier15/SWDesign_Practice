using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implement.Lib
{
	public static class F
	{
		public static None None = None.Defult;
		public static int k = 10;
		public static string yy {get;set;}
	}

	class Option
	{
	}



	public struct None
	{
		internal static readonly None Defult = new None();
	}
}
