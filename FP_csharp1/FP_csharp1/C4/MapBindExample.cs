using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FP_csharp1
{
	static class MapBindExample
	{

		public static void main()
		{
			var neighbours = new[]
		 {
			new {Name = "John", Pets = new Pet[] {"Fluffy", "Thor"}},
			new {Name = "Tim", Pets = new Pet[] {}},
			new {Name = "Carl", Pets = new Pet[] {"Sybil"}},
		 };

			IEnumerable<IEnumerable<Pet>> nested = neighbours.Map(n => n.Pets);
			IEnumerable<Pet> flat = neighbours.Bind(n => n.Pets);

			var res1 = nested.ToList();
			var res2 = neighbours.SelectMany( n => n.Pets).ToList();
		}

	}

	public class Neighbour
	{
		public string Name { get; set; }
		public IEnumerable<Pet> Pets { get; set; } = new Pet[] { };
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

	public static class ext
	{
		public static IEnumerable<R> Map<T, R>
		( this IEnumerable<T> list, Func<T, R> func )
		 => list.Select( func );


		public static IEnumerable<R> Bind<T, R>( this IEnumerable<T> list, Func<T, IEnumerable<R>> func )
		=> list.SelectMany( func );
	}
	

}
