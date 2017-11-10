using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleBasedLib.Datas
{
	public static class Type
	{
		public static void main()
		{
			var temp = new Age(2);
			var addAge = temp + 10;
			var res = temp*10;


		}

	}

	public class Age
	{
		public readonly double age;
		public Age( double age )
		{ this.age = age; }

		public static implicit operator Age(double age)
			=> new Age(age);
		public static implicit operator double(Age age)
			=> age.age;
	}

}
