using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit = System.ValueTuple;
using System.Collections.Immutable;

namespace Practice.dataType
{
	public static class EnumerableExtcs
	{
		public static IEnumerable<Unit> ForEach<A>
			( this IEnumerable<A> xs, Action<A> act )
			=> xs.Map( act.ToFunc() ).ToImmutableList();

		public static IEnumerable<A> List<A>( params A[] items )
			=> items.ToImmutableList();


	}

	

}
