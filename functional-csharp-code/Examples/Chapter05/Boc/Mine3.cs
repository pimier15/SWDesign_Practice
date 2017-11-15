using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaYumba.Functional;
using static LaYumba.Functional.F;
using Microsoft.AspNetCore.Mvc;

namespace Examples.Chapter05.Boc.Mine
{

	public class MakeTransferController : Controller
	{
		IValidator<MakeTransfer> validator;
		IRepository<AccountState> accounts;
		ISwiftService swift;

		public void MakeTransfer( [FromBody] MakeTransfer transfer )
			=> Some( transfer ) // Return Transfer
				.Map( Normalize ) // Normalize Transfer
				.Where( validator.IsValid ) // Check Valid Transfer
				.ForEach( Book ); // Book Transfer

		void Book( MakeTransfer transfer ) // last layer
			 => accounts.Get( transfer.DebitedAccountId ) //어카운트 로드
					    .Bind( account => account.Debit( transfer.Amount ) ) // 돈인출
						.ForEach( newstate =>
						{
							accounts.Save( transfer.DebitedAccountId, newstate );
							swift.Wire( transfer, newstate ); // Side Effect Region
						});

		MakeTransfer Normalize( MakeTransfer request )
	   => request;
	}

	public sealed class MakeTransfer // State
	{
		public Guid DebitedAccountId { get; set; } //인출된 계좌ID
		public string Beneficiary { get; set; } // Bank Name
		public string Iban { get; set; } // International Bank Account Number
		public string Bic { get; set; } // Bank Identifier Code

		public double Amount { get; set; }
		public DateTime Date { get; set; }
	}


	public interface IValidator<T>
	{
		bool IsValid( T t );
	}

	// domain model
	public class AccountState
	{
		public double Balance { get; }
		public AccountState( double balnace )
		{
			Balance = balnace;
		}
	}

	public static class Account
	{
		public static Option<AccountState> Debit
			( this AccountState acc, double amount )
			=> ( acc.Balance < amount )
			? None
			: Some( new AccountState( acc.Balance - amount ) );
	}

	// api for swift
	public interface IRepository<T>
	{
		Option<T> Get( Guid id );
		void Save( Guid id, T t );
	}

	interface ISwiftService
	{
		void Wire( MakeTransfer transfer, AccountState account );
	}

	
}
