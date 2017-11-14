using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit = System.ValueTuple;

namespace Practice.dataType
{
	using static Handler;
	public static partial class Handler
	{
		public static Unit Unit() => default(Unit);
	}

	public static class ActionExt
	{
		public static Func<Unit> ToFunc( this Action act )
			=> () => { act(); return Unit(); };

		public static Func<A, Unit> ToFunc<A>( this Action<A> act )
			=> a => { act( a ); return Unit(); };

		public static Func<A,B, Unit> ToFunc<A,B>( this Action<A,B> act )
			=> (a,b) => { act( a ,b); return Unit(); };


	}
}
