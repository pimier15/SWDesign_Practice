using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.dataType;
using static System.Linq.Enumerable;
using static System.Console;
using static Practice.dataType.EnumerableExtcs;
using static Practice.dataType.Handler;

namespace Practice
{
	class Program
	{
		static void Main( string[] args )
		{
			new MaybeAndEnumerableExample().main();


			int[][] tt = new int[3][];
			tt[0] = new int[] { 1, 2, 3 };
			tt[1] = new int[] { 10, 20, 30 };
			tt[2] = new int[] { 1000, 2000 };
			var res= tt.Map( x => x.Map(y => y*10000).ToList() ).ToList();
			var res2 = tt.Bind( x=> x.Map(y => y*10000)).ToList();


			var temp = List(1,2,3);
			var rang1 = List( Range( 1,3).ToArray() );
			var rang2 = List( Range( 1,3).ToList() );

			Just( 1 ).AsEnumerable().Count();
		}




	}
}
