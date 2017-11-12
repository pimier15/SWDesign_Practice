using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.dataType;
using static Practice.dataType.Handler;
using static System.Console;
using static Practice.dataType.EnumerableExtcs;

namespace Practice.dataType
{

	public class BindExample
	{
		public void main()
		{
			string input = "";
			Maybe<int> optI = Int.Parse(input);
			var ageOptMap = optI.Map(i =>Age.Of(i) );
			var ageOptBind = optI.Bind(i =>Age.Of(i) );


			var stringlist = List("1","2","-1");
			var res1 = stringlist.Map( x => ToNatural(x) );

		}

		bool IsNatural( int i ) => i >= 0;
		Maybe<int> ToNatural( string s ) => Int.Parse( s ).Where( IsNatural );

		public Age ReadAge()
			=> Age.ParseAge( Prompt( "Write Your Age" ) )
				.Match(
				() => ReadAge(),
					age => age);

		string Prompt( string prompt )
		{
			WriteLine( prompt );
			return ReadLine();
		}

	}

	public class Age
	{
		public int Value { get; }

		public Age( int value )
		{
			if ( !IsValid( value ) )
				throw new ArgumentException( $"{value} is not a valid age" );

			Value = value;
		}

		private static bool IsValid( int age )
		   => 0 <= age && age < 120;

		public static Maybe<Age> Of
			( int self )
		{
			try { return Just( new Age( self ) ); }
			catch { return None; }
		}

		public static Func<string, Maybe<Age>> ParseAge
			=> s => Int.Parse( s ).Bind( x => Age.Of( x ) );
	}

	public static class AgeExt
	{
		
	}
	

	public static class Int
	{
		public static Maybe<int> Parse( string s )
		{
			int result;
			return int.TryParse( s, out result )
				? Just( result )
				: None;
		}
	}

}
