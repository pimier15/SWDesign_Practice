using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.dataType
{
	public static class HandlerTest
	{

	}



	public static class Maybe2
	{


	}


	namespace MaybeType
	{
		public struct None
		{
			public readonly Nothing
		}

		public struct Some<A>
		{
			public readonly A Value;

			public Some( A val )
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
