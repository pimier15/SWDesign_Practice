using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit = System.ValueTuple;
using System.Collections.Immutable;

namespace Practice.dataType
{
	public static partial class Handler
	{
		public static IEnumerable<A> List<A>( params A[] x )
			=> x.AsEnumerable();
	}

	public static class EnumerableExtcs
	{
		public static IEnumerable<B> Map<A, B>
			( this IEnumerable<A> self, Func<A, B> f )
		{
			foreach ( var x in self )
			{
				yield return f( x );
			}
		}

		public static IEnumerable<B> Map2<A, B>
			( this IEnumerable<A> self, Func<A, B> f )
			=> self.Select( f );

		public static IEnumerable<R> Bind<T, R>
		( this IEnumerable<T> ts, Func<T, IEnumerable<R>> f )
		{
			foreach ( T t in ts )
				foreach ( R r in f( t ) )
					yield return r;
		}

		public static IEnumerable<R> Bind<T, R> // Bind IEnumerable => Maybe
			( this IEnumerable<T> self, Func<T, Maybe<R>> func )
			=> self.Bind( t => func( t ).AsEnumerable() );


		

		public static IEnumerable<Unit> ForEach<A>
			( this IEnumerable<A> xs, Action<A> act )
			=> xs.Map( act.ToFunc() ).ToImmutableList();

	

	}

	

}
