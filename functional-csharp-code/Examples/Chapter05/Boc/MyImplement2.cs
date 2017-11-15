using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using LaYumba.Functional;
using static LaYumba.Functional.F;

namespace Examples.Chapter05.Boc
{
	public class MakeTransferController_Impretive : Controller
	{
		IValidator<MakeTransfer> validator;

		[HttpPost, Route( "api/MakeTranfer" )]
		public void MakeTransfer( [FromBody] MakeTransfer transfer ) //MakeTranfer에 요청사항이 담겨있다.
		{
			if ( validator.IsValid( transfer ) ) // Valid 하다면
				Book( transfer ); // Book 해라
		}

		void Book( MakeTransfer trnsfer )
			=> Console.WriteLine(trnsfer.Date);

	}

	public class MakeTransferController_FP : Controller
	{
		IValidator_FP<MakeTransfer> validator;

		[HttpPost, Route( "api/MakeTranfer" )]
		public void MakeTransfer( [FromBody] MakeTransfer transfer ) //MakeTranfer에 요청사항이 담겨있다.
		{
			validator.IsValid( transfer )
					.Bind(x =>  Book(x) );


		}

		Option<MakeTransfer> Book( MakeTransfer trnsfer )
			=> None;

	}

	public class MakeTransferController_FPExample : Controller
	{
		IValidator_FP2<MakeTransfer> validator;

		[HttpPost, Route( "api/MakeTranfer" )]
		public void MakeTransfer( [FromBody] MakeTransfer transfer ) //MakeTranfer에 요청사항이 담겨있다. 
		{
			Some( transfer )
					.Map(Normalize)
					.Where( validator.IsValid ) // MakeTransfer 는 데이터이다. 따라서 이 데이터로 시작해야한다.
				    .ForEach( Book );


		}


		void Book( MakeTransfer trnsfer )
				=> Console.WriteLine( trnsfer.Date );

		MakeTransfer Normalize( MakeTransfer transfer )
			=> transfer;

	}


	public interface IValidator_FP<A>
	{
		Option<A> IsValid( A a );
	}

	public interface IValidator_FP2<A>
	{
		bool IsValid( A a );
	}



	public sealed class MakeTransfer 
	{
		public Guid DebitedAccountId { get; set; } //인출된 계좌ID
		public string Beneficiary { get; set; } // Bank Name
		public string Iban { get; set; } // International Bank Account Number
		public string Bic { get; set; } // Bank Identifier Code

		public decimal Amount { get; set; }
		public DateTime Date { get; set; }
	}

	//여기에서 Validation 체크하는 클래스들 만든다. 
	public interface IValidator<A>
	{
		bool IsValid( A a );
	}


	// MakeTransfer 에 대한 Validation 검증. 그중 bic 검증
	public sealed class BicFormatValidator : IValidator<MakeTransfer>
	{
		static readonly Regex regex = new Regex("^[A-Z]{6}[A-Z1-9]{5}$");

		public bool IsValid( MakeTransfer t )
		   => regex.IsMatch( t.Bic );
	}


	#region DataNotPastValidator
	public class DataNotPastValidator : IValidator<MakeTransfer>
	{
		public bool IsValid( MakeTransfer cmd )
			=> ( DateTime.UtcNow.Date <= cmd.Date.Date ); //현재보다 미래의 시간에 송금이 되야함
	}


	#region oop style
	public interface IDateTimeService
	{
		DateTime UtcNow { get; }
	}

	public class DefualtDataTimeService : IDateTimeService
	{
		public DateTime UtcNow => DateTime.UtcNow; // 이걸쓰면 unpure 해짐
	}

	public class DefualtDataTimeServiceForTest : IDateTimeService
	{
		public DateTime UtcNow => new DateTime( 2016, 1, 1 ); // 이걸쓰면 pure 해짐
	}

	public class DataNotPastValidator_OOP : IValidator<MakeTransfer>
	{
		private readonly IDateTimeService clock;
		public DataNotPastValidator_OOP( IDateTimeService clock )
		{
			this.clock = clock;
		}

		public bool IsValid( MakeTransfer request )
			=> clock.UtcNow.Date <= request.Date.Date; //IDateTImeService의 인스턴스에 따라서 Pure한지 아닌지 결정된다.
	}

	#endregion

	#region fp style
	public class DateNotPAstvalidator_FP
	{
		private readonly DateTime today;

		public DateNotPAstvalidator_FP( DateTime today )
		{
			this.today = today;
		}

		public bool IsValid( MakeTransfer cmd )
			=> today <= cmd.Date.Date;
	}


	#endregion

	#endregion

	#region BicExistValidator

	public sealed class BicExistValidator : IValidator<MakeTransfer>
	{
		readonly IEnumerable<string> validCode;

		public bool IsValid( MakeTransfer cmd )
			=> validCode.Contains( cmd.Bic );
	}

	public sealed class BicExistValidator_FP : IValidator<MakeTransfer>
	{
		readonly Func<IEnumerable<string>> getValidCodes;

		public BicExistValidator_FP( Func<IEnumerable<string>> getValidCodes )
		{
			this.getValidCodes = getValidCodes;
		}

		public bool IsValid( MakeTransfer cmd )
			=> getValidCodes().Contains( cmd.Bic );
	}

	#endregion

}
