using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Exercises.C6
{
	using BOC.Domain;

	public class TransferExample
	{


	}

	public static class Error
	{
		public static InvalidBic InValidBic => new InvalidBic();

		public static TransferDateIsPast TransferDateIsPast
			=> new TransferDateIsPast();
	}

}

namespace BOC.Domain
{
	using Practice.dataType;
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
}

namespace Practice.dataType
{
	public class Error
	{
		public virtual string Message { get; }

	}
}
