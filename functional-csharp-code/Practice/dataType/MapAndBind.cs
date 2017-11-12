using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.dataType
{
	using static Practice.dataType.Handler ;
	using Practice.dataType.MaybeType;
	using static MapExt;
	using static System.Linq.Enumerable;
	public class MapAndBind
	{
		public void main()
		{
			Func<int,string>  toText = x => x.ToString();
			Range( 3, 1 ).Map( toText );
		}

	}

	public static class MapExt
	{
		public static IEnumerable<B> Map<A, B>
			( this IEnumerable<A> self, Func<A, B> f )
		{
			foreach ( var x in self )
			{
				yield return f( x );
			}
		}

		public static IEnumerable<B> MapSameSelext<A, B>
			( this IEnumerable<A> self, Func<A, B> f )
			=> self.Select( f );

		public static Maybe<B> Map<A, B>
			( this Nothing self, Func<A, B> f )
			=> None;

		public static Maybe<B> Map<A, B>
			( this Just<A> self, Func<A, B> f )
			=> Just( f( self.Value ) );

		public static Maybe<B> Map<A, B>
			( this Maybe<A> self, Func<A, B> f )
			=> self.Match(
				Just: x => Just(f(x)) ,
				Nothing : () =>  None);
	}

	public static class BindExt
	{
		public static Maybe<B> Bind<A, B>
			( this Maybe<A> self, Func<A, Maybe<B>> f )
			=> self.Match(
				Nothing : () => None ,
				Just : x => f(x));

		public static IEnumerable<R> Bind<T, R>
			( this IEnumerable<T> ts, Func<T, IEnumerable<R>> f )
		{
			foreach ( T t in ts )
				foreach ( R r in f( t ) )
					yield return r;
		}

	}


}
