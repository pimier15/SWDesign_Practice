using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LaYumba.Functional;
using Unit = System.ValueTuple;
using System.Text.RegularExpressions;

namespace Examples.Chapter06.Boc.TransferOnHandler2
{
	using Either;
    public class Example1 : Controller
    {

		DateTime now;
		Regex bicRegex = new Regex("[A-Z]{11}");

		Either<Error, Unit> Handle( BookTransfer cmd )
			=> Validate( cmd )
				.Bind(ValidateBic)
				.Bind(ValidateData)
				.Bind(Save);

		Either<Error, BookTransfer> Validate( BookTransfer cmd )
			=> new Either<Error, BookTransfer>();

	

		Either<Error, BookTransfer> ValidateBic( BookTransfer cmd )
		{
			if ( !bicRegex.IsMatch( cmd.Bic ) )
				return Errors.InvalidBic;
			else return cmd;
		}

		Either<Error, BookTransfer> ValidateData( BookTransfer request )
		{
			if (request.Date <= now.Date )
				return Errors.TransferDateIsPast;
			else return request;
		}

		Either<Error, Unit> Save( BookTransfer request )
		{
			if ( request.Date <= now.Date )
				return Errors.TransferDateIsPast;
			else return default(Unit);
		}


	}


	

	public sealed class InvalidBic : Error
	{
		public override string Message { get; }
		  = "The beneficiary's BIC/SWIFT code is invalid";
	}
	public sealed class TransferDateIsPast : Error
	{
		public override string Message { get; }
		   = "Transfer date cannot be in the past";
	}

	public class Error
	{
		public virtual string Message { get; }

	}

	public class BookTransfer : MakeTransfer { }
	public class MakeTransfer 
	{
		public Guid DebitedAccountId { get; set; }

		public string Beneficiary { get; set; }
		public string Iban { get; set; }
		public string Bic { get; set; }

		public DateTime Date { get; set; }
		public decimal Amount { get; set; }
		public string Reference { get; set; }
	}



}

namespace Either
{
	using Examples.Chapter06.Boc.TransferOnHandler2;
	public static class Errors
	{
		public static InvalidBic InvalidBic => new InvalidBic();

		public static TransferDateIsPast TransferDateIsPast
			=> new TransferDateIsPast();
	}
}
