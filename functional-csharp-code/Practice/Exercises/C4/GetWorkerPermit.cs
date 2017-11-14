using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Practice.dataType.Handler;
namespace Practice.dataType
{
	public static class ext
	{
		public static Maybe<A> Lookup<K, A>
			(this Dictionary<K, A> self, K key )
		{
			A res;
			return self.TryGetValue( key, out res )
				? Just( res )
				: None;
		}
	}

	class GetWorkerPermit
	{
		

		Maybe<WorkPermit> GetWorkPermit
		( Dictionary<string, Employee> people, string employeeId )
		{
			var temp = people.Lookup( employeeId )
						.Map( x => x.WorkPermit );

			return people.Lookup( employeeId )
						 .Bind( x =>  x.WorkPermit );



			//Employee res;
			//return people.TryGetValue( employeeId, out res )
			//		?  res.WorkPermit.Match(
			//			() => None ,
			//			permit => permit.Expiry < res.JoinedOn 
			//			 ? Just(permit)
			//			 : None ) 
			//		: None;
		}

		Maybe<WorkPermit> GetValidWorkPermit( Dictionary<string, Employee> employees, string employeeId )
		 => employees
			.Lookup( employeeId )
			.Bind( x => x.WorkPermit )
			.Where( t => t.Expiry < DateTime.Now.Date );
			//.Where( HasExpired(t) );

		Func<WorkPermit, bool> HasExpired => permit => permit.Expiry > DateTime.Now.Date;


		double AverageYearsWorkedAtTheCompany( List<Employee> employees )
			=> employees.Bind( x => x.LeftOn.Map( lfton => YearsBetween( x.JoinedOn, lfton ) ) )
					    .Average();

		double YearsBetween( DateTime start, DateTime end )
				=> ( end - start ).Days / 365d;

	}
		public class Employee
	{
		public string Id { get; set; }
		public Maybe<WorkPermit> WorkPermit { get; set; }

		public DateTime JoinedOn { get; }
		public Maybe<DateTime> LeftOn { get; }
	}

	public struct WorkPermit
	{
		public string Number { get; set; }
		public DateTime Expiry { get; set; }
	}
}
