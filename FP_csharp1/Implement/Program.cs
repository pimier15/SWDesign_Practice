using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Implement.Lib.F;
using Implement.Lib;
using Implement.TypeClass;

namespace Implement
{
	class Program
	{
		static void Main( string[] args )
		{
			var temp = Nothing;
			var temp2 = Just(10);


		}

		Func<Maybe<int>, int> Add10
			=> val => val.Match(
				Nothing : () => 0,
				Just : ( value ) => value + 10 ); 

	}

	

}
