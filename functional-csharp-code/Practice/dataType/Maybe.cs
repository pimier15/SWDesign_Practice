using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit = System.ValueTuple;

namespace Practice.dataType
{
	using MaybeType;
	public static class Handler
	{

		public static MaybeType.Nothing None => Nothing.Defualt;
		public static Maybe<A> Just<A>( A value ) => new MaybeType.Just<A>( value );
	}

	
		public struct Maybe<A>
		{
			public A Value;

			public bool IsJust;

			public Maybe( A value )
			{
				Value = value;
				IsJust = true;
			}
			
			public static implicit operator Maybe<A>(MaybeType.Nothing _) => new Maybe<A>();
			public static implicit operator Maybe<A>(MaybeType.Just<A> just) => new Maybe<A>(just.Value);

		}
	namespace MaybeType
	{
		public struct Nothing
		{
			internal static readonly Nothing Defualt = new Nothing();
		}

		public struct Just<A>
		{
			public A Value { get; }

			public Just( A value )
			{
				if ( value == null ) throw new ArgumentNullException("Create Just with value not null");
				Value = value;
			}

		}
	}
	


}
