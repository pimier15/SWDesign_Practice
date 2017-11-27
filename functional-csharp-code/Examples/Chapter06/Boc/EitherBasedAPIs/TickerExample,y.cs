using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaYumba.Functional;
using Unit = System.ValueTuple;
using Microsoft.AspNetCore.Mvc;

namespace Examples.Chapter06.Boc.EitherBasedAPIs22
{
    public class TickerExample_y
    {
    }

	public interface IInstrumentService
	{
		Option<InstrumentDetails> GetInstrumentDetails( string ticker );
	}

	public class InstrumentDetails
	{ }

	public class InstrumentController : Controller
	{
		private IInstrumentService instruments;
		Func<string , Option<InstrumentDetails>> getInstrumentDetails;

		public IActionResult GetInstrumentDetails( string ticker )
			=> getInstrumentDetails( ticker )
				.Match<IActionResult>(
				()=> new HttpNotFound() ,
				result => Ok(result));

		public IActionResult GetInstrumentDetails2( string ticker )
		=> instruments.GetInstrumentDetails( ticker )
			.Match<IActionResult>(
			 None : NotFound,
			 Some : Ok);


	}

	public static class Ext
	{
		public static IActionResult HTTPNotFound => new HttpNotFound();
		public static IActionResult OK => new OK();
	}

	public class HttpNotFound : IActionResult
	{
		public Task ExecuteResultAsync( ActionContext context )
		{
			throw new NotImplementedException();
		}
	}

	public class OK : IActionResult
	{
		public Task ExecuteResultAsync( ActionContext context )
		{
			throw new NotImplementedException();
		}
	}



}
