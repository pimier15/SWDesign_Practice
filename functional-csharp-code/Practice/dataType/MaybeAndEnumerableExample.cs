using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.dataType
{
	public class MaybeAndEnumerableExample
	{
		class Subject
		{
			public Maybe<Age> Age { get; set; }
		}

		// Flattend IEnuemrable<Maybe<Age>> => IEnuermable<Age>
		IEnumerable<Subject> Population => new[]
		{
			new Subject { Age = Age.Of(33)} ,
			new Subject { } ,
			new Subject { Age = Age.Of(45)}
		};


		public void main()
		{
			// need to calculate avg of age

			var avg = Population.Select( x => x.Age.Value).Average();




		}



	}

	
	
}
