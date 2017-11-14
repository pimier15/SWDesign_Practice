using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
	public static class ComposeSimpleEx
	{
		static double AverageEarningsOfRichestQuartile( List<Person> population )
		=> population
				.OrderByDescending( p => p.Earnings )
				.Take( population.Count / 4 )
				.Select( p => p.Earnings )
				.Average();

		static double AverageEarningsOfRichestQuartile_New( List<Person> population )
			=> population.RichestQuartile()
						 .AverageEarnings();

		public static double AverageEarnings
			( this IEnumerable<Person> population )
			=> population.Average( p => p.Earnings );

		public static IEnumerable<Person> RichestQuartile
			(this List<Person> pop)
			=> pop.OrderByDescending( k => k.Earnings )
				  .Take(pop.Count/4)

	}

	public class Person
	{
		public double Earnings;
	}
}
