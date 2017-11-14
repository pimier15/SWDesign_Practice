using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.dataType
{
	using static Practice.dataType.Handler ;
	using Practice.dataType.MaybeType;
	using static System.Linq.Enumerable;
	public class MapAndBind
	{
		public void main()
		{
			Func<int,string>  toText = x => x.ToString();
		}

	}

	public static class ISet_IDict_Map
	{
		public static ISet<R> Map<T, R>
			( this ISet<T> self, Func<T, R> f )
		{
			return new HashSet<R>( self.Select( x => f( x ) ) );
		}

		public static IDictionary<K, R> Map<K, T, R>
			( this IDictionary<K, T> self, Func<T, R> f )
		{
			var res = new Dictionary<K , R>();
			foreach ( var item in self )
			{
				res[item.Key] = f( item.Value );
			}
			return res;
		}

	}

	public static class ExerciseBindMap
	{
		//public static Maybe<B> Map<A, B>(
		//	this Maybe<A> self, Func<A, B> f )
		//		=> self.Bind( x => Just(f(x)) );
		//      => Just(f(self.Value));

		//public static IEnumerable<B> Map<A, B>
		//	( this IEnumerable<A> self, Func<A, B> f )
		//	=> self.Bind( x => List( f( x ) ) );

	}


}
