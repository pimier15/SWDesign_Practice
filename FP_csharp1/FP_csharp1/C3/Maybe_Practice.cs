using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaYumba.Functional;
using static LaYumba.Functional.F;
namespace FP_csharp1.C3
{
	class Maybe_Practice
	{
		
		Option<string> _ = None;
		Option<string> john = Some("John");

		string greet( Option<string> greetee )
			=> greetee.Match(
				None : () => "Sorry" ,
				Some : (name) => "Hi");

		public void main()
		{

		}
	}



}
