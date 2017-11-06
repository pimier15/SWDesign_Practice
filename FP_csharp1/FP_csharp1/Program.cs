using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FP_csharp1
{
	class Program
	{
		static void Main( string [ ] args )
		{
			MapBindExample.main();

			Digit haha = new Digit(3);
			byte temp = 3;
			var res = temp + haha;
			var ya = (string)haha;
			Console.WriteLine( res );
			Console.WriteLine( haha );
			Console.WriteLine( ya );
			Console.ReadLine();
		}
	}

	struct Digit
	{
		byte value;

		public Digit( byte val )
		{
			if ( val > 9 ) throw new ArgumentException();
			this.value = val;
		}

		public static implicit operator byte(Digit d)
			=> d.value;

		public static explicit operator string(Digit d)
			=> d.value.ToString() + "convered";
	}


	
}
