using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaYumba.Functional;
using static LaYumba.Functional.F;

namespace Examples.Chapter05.Boc
{
	#region Good

	// 여기서 돈 일출하는것을 구현한다.
	public class _AccountState
	{
		public double Balance { get; }
		public _AccountState( double balnace)
		{
			Balance = balnace;
		}
	}

	public static class _Account
	{
		public static Option<_AccountState> Debit
			( this _AccountState acc, double amount )
			=> ( acc.Balance < amount )
			? None
			: Some( new _AccountState( acc.Balance - amount ) );
	}

	#endregion

	#region Bad
	public class Account_Bad
	{
		public double Balance { get; private set; }

		public Account_Bad( double balance )
		{
			Balance = balance;
		}


		public void Debit( double amount )
		{
			if ( Balance < amount )
				throw new InvalidOperationException();
			Balance -= amount;
		}

	}

	#endregion	

}
