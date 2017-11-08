using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Immutable;

namespace Test
{
	using static ext;
	class Program
	{
		static void Main( string[] args )
		{

			var tt = List(2,3,4,5,6,7,5,3);

		}
	}

	public static class ext
	{
		public static IEnumerable<T> List<T>( params T[] items )
			=> items.ToImmutableList().ToArray();


	}

}
