using Microsoft.AspNetCore.Mvc;
using System;
using LaYumba.Functional;
using static LaYumba.Functional.F;
using Boc.Commands;
using Boc.Services;

namespace Boc.Chapter5
{
   // top-level workflow

   public class Chapter5_TransfersController : Controller
   {
      IValidator<MakeTransfer> validator;
      IRepository<AccountState> accounts;
      ISwiftService swift;
      
      public void MakeTransfer([FromBody] MakeTransfer transfer)
         => Some(transfer)
            .Map(Normalize) //왜 Map 썻냐? Normalize 함수 자체가 F<A,B> 이기 때문에 만약 F<A,M<B>> 시 Bind 사용해야함. 
            .Where(validator.IsValid) // A -> bool 인 필터 
            .ForEach(Book); // Book 은 Side Effect 함수이다. 

      void Book(MakeTransfer transfer)
         => accounts.Get(transfer.DebitedAccountId)
            .Bind(account => account.Debit(transfer.Amount))
            .ForEach(newState =>
               {
                  accounts.Save(transfer.DebitedAccountId, newState);
                  swift.Wire(transfer, newState);
               });

      MakeTransfer Normalize(MakeTransfer request) 
         => request; // remove whitespace, toUpper, etc.
   }


   // domain model

   public class AccountState
   {
      public decimal Balance { get; }
      public AccountState(decimal balance) { Balance = balance; }
   }

   public static class Account
   {
      public static Option<AccountState> Debit
         (this AccountState acc, decimal amount)
         => (acc.Balance < amount)
            ? None
            : Some(new AccountState(acc.Balance - amount));
   }
   

   // dependencies

   public interface IRepository<T>
   {
      Option<T> Get(Guid id);
      void Save(Guid id, T t);
   }

   interface ISwiftService
   {
      void Wire(MakeTransfer transfer, AccountState account);
   }
}