using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.dataType
{
	public class BindExample2
	{
		public void main()
		{
			var neighbors = new[]
			{
			   new { Name = "John", Pets = new Pet[] {"Fluffy", "Thor"} },
			   new { Name = "Tim", Pets = new Pet[] {} },
			   new { Name = "Carl", Pets = new Pet[] {"Sybil"} },
			};

			var nestedMap = neighbors.Map( x => x.Pets);
			//IEnumerable<Pet[]> nestedMap = neighbors.Map( x => x.Pets);
			var bindcase = neighbors.Bind( x => x.Pets);
			//IEnumerable<Pet> bindcase = neighbors.Bind( x => x.Pets);

		}


	}

	public class Pet
	{
		public string name;

		public Pet( string name )
		{
			this.name = name;
		}

		public static implicit operator Pet(string s)
			=> new Pet(s);

		public static implicit operator string( Pet pet )
			=> pet.name;
	}
}
