using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit = System.ValueTuple;
using System.Collections.Immutable;

namespace Implement.Lib
{
	public static partial class Main
	{
		public static Unit Unit() => default( Unit );

		public static IEnumerable<T> List<T>( params T[] items ) => items.ToImmutableList();
	}
}
