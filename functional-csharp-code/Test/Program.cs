using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaYumba.Functional;
using static LaYumba.Functional.F;

namespace Test
{
	class Program
	{
		static void Main( string[] args )
		{
			var neighbours = new[]
		 {
			new {Name = "John", Pets = new Pet[] {"Fluffy", "Thor"}},
			new {Name = "Tim", Pets = new Pet[] {}},
			new {Name = "Carl", Pets = new Pet[] {"Sybil"}},
		 };

			IEnumerable<IEnumerable<Pet>> nested = neighbours.Map(n => n.Pets);
			IEnumerable<Pet> flat = neighbours.Bind(n => n.Pets);

		}
	}

	public class PetsInNeighbourhood
	{
		public static void main_1()
		{
			var neighbours = new[]
		 {
			new {Name = "John", Pets = new Pet[] {"Fluffy", "Thor"}},
			new {Name = "Tim", Pets = new Pet[] {}},
			new {Name = "Carl", Pets = new Pet[] {"Sybil"}},
		 };

			IEnumerable<IEnumerable<Pet>> nested = neighbours.Map(n => n.Pets);
			IEnumerable<Pet> flat = neighbours.Bind(n => n.Pets);
		}

		class Neighbour
		{
			public string Name { get; set; }
			public IEnumerable<Pet> Pets { get; set; } = new Pet[] { };
		}
	}

	public class Pet
	{
		private readonly string name;

		private Pet( string name )
		{
			this.name = name;
		}

		public static implicit operator Pet( string name )
		   => new Pet( name );
	}

}
