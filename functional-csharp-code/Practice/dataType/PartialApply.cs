using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.dataType
{
    public static class PartialApply
    {
        public static Func<B, R> Apply<A, B, R>
            ( this Func<A, B, R> f, A a )
            => b => f( a, b );

        public static Func<B, C, R> Apply<A, B, C, R>
            ( this Func<A, B, C, R> f, A a )
            => ( b, c ) => f( a, b, c );

	}
}
