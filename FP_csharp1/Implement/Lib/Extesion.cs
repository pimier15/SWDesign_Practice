using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unit = System.ValueTuple;

namespace Implement.Lib
{
	using static Main;
	class Extesion
	{
	}

	public static class ActionExt
	{
		public static Func<Unit> ToFunc( this Action action )
			=> () =>
		{
			action();
			return Unit();
		};

		public static Func<A,Unit> ToFunc<A>( this Action<A> action )
			=> a =>
			{
				action(a);
				return Unit();
			};
	}

	public static class EnuermerableExt
	{
		public static Func<T, IEnumerable<T>> Return<T>() => t => List( t );

		public static IEnumerable<R> Map<T, R>
		( this IEnumerable<T> list, Func<T, R> func )
		 => list.Select( func );

		public static IEnumerable<T> Append<T>( this IEnumerable<T> source
		   , params T[] ts ) => source.Concat( ts );

		static IEnumerable<T> Prepend<T>( this IEnumerable<T> source, T val )
		{
			yield return val;
			foreach ( T t in source ) yield return t;
		}

	}



}
