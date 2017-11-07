
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implement.Lib
{
	using Implement.Type;

	public static partial class Main
	{
		public static Nothing Nothing = Nothing.Defult;
		public static Just<T> Just<T>( T value ) => new Just<T>( value );
	}
}
namespace Implement.TypeClass
{
	using Implement.Type;
	public struct Maybe<A>
	{
		readonly bool isJust;
		readonly A Value;

		private Maybe( A value )
		{
			this.isJust = true;
			this.Value = value;
		}

		public static implicit operator Maybe<A>( Nothing _ )
			=> new Maybe<A>();

		public static implicit operator Maybe<A>( Just<A> just )
			=> new Maybe<A>( just.Value );

		public B Match<B>( Func<B> Nothing, Func<A, B> Just )
			=> isJust ? Just( Value ) : Nothing();
	}
}
namespace Implement.Type
{
		public struct Nothing
	{
		internal static readonly Nothing Defult = new Nothing();
	}

	public struct Just<T>
	{
		internal T Value { get; }
		internal Just( T value )
		{
			if ( value == null ) throw new ArgumentNullException();
			Value = value;
		}
	}
}
