using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.dataType2
{
	
	public static class HandlerTest
	{
		public static MaybeType.None None => MaybeType.None.Defualt;
		public static Maybe2<A> Just<A>( A val ) => new MaybeType.Just<A>( val );
	}

	public struct Maybe2<A>
	{
		public static A Value;
		public static bool IsJust;
		public Maybe2( A value )
		{
			Value = value;
			IsJust = true;
		}
		
		public static implicit operator Maybe2<A>( MaybeType.None _) => new Maybe2<A>();
		public static implicit operator Maybe2<A>( MaybeType.Just<A> just) => new Maybe2<A>(just.Value);

	}

	namespace MaybeType
	{
		public struct None
		{
			public static readonly None Defualt = new None();
		}

		public struct Just<A>
		{
			public readonly A Value;

			public Just( A val )
			{
				if ( val == null ) throw new ArgumentException();
				Value = val;
			}
		}
	}




	class Class1
	{
	}



}
