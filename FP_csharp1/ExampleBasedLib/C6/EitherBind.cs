using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleBasedLib.C6
{
	public class EitherBind
	{
	}





	public static class PlrCrd
	{
		public static double Rho;
		

		public static implicit operator PlrCrd(double rho )
			=> new PlrCrd()


	}


}
