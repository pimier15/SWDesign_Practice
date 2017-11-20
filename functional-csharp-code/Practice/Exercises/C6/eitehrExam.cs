using System;185*98
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.dataType;
using static Practice.dataType.Handler;

namespace Practice.Exercises.C6
{
	class eitherExam_either
	{
		Func<Candidate , bool> IsEligible;
		Func<Candidate , Either<Rejection,Candidate>> TechTest;
		Func<Candidate , Either<Rejection,Candidate>> Interview;

		Either<Rejection, Candidate> CheckEligibility( Candidate c )
		{
			if ( IsEligible( c ) ) return c;
			else return new Rejection("No eligible");
		}

		Either<Rejection, Candidate> Recruit( Candidate c )
			=> Right( c )
				.Bind( CheckEligibility )
			    .Bind( TechTest )
			    .Bind( Interview );
	}



	class eitehrExam_Maybe
	{
		Func<Candidate , bool> IsEligible;
		Func<Candidate , Maybe<Candidate>> TechTest;
		Func<Candidate , Maybe<Candidate>> Interview;

		Maybe<Candidate> Recruit( Candidate c )
			=> Just( c )
				.Where(IsEligible)
				.Bind(TechTest)
				.Bind(Interview);
	}


	class Candidate { }
	class Rejection
	{
		private string reason;

		public Rejection( string reason )
		{
			this.reason = reason;
		}
	}
}
