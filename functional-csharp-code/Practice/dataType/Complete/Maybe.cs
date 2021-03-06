﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit = System.ValueTuple;

namespace Practice.dataType
{
	using MaybeType;
	using static Handler;
	public static partial class Handler
	{
		// Return , Lift 함수
		public static MaybeType.Nothing None => Nothing.Defualt;
		public static Maybe<A> Just<A>( A value ) => new MaybeType.Just<A>( value );
	}

	
		public struct Maybe<A>
		{
			public A Value;

			public bool IsJust;

			public Maybe( A value )
			{
				Value = value;
				IsJust = true;
			}
			
			public static implicit operator Maybe<A>(MaybeType.Nothing _) => new Maybe<A>();
			public static implicit operator Maybe<A>(MaybeType.Just<A> just) => new Maybe<A>(just.Value);

		public B Match<B>( Func<B> Nothing , Func<A, B> Just  )
			=> this.IsJust ? Just( this.Value ) : Nothing();



		public IEnumerable<A> AsEnumerable()
		{
			if ( IsJust ) yield return Value;
		}

		}

	public static class MaybeExt
	{
		public static Maybe<B> Map<A, B>
			( this Maybe<A> self, Func<A, B> f )
			=> self.Match(
				Just: x => Just( f( x ) ),
				Nothing: () => None );

		public static IEnumerable<R> Bind<T, R> // Bind Maybe => IEnumerable
			( this Maybe<T> self, Func<T, IEnumerable<R>> func )
		=> self.AsEnumerable().Bind( func );

		public static Maybe<B> Bind<A, B>
			( this Maybe<A> self, Func<A, Maybe<B>> f )
			=> self.Match(
				Nothing: () => None,
				Just: x => f( x ) );

		public static Maybe<Unit> ForEach<A>
			( this Maybe<A> self, Action<A> act )
			=> Map( self, act.ToFunc() );

		public static Maybe<A> Where<A>
			( this Maybe<A> self, Func<A, bool> pred )
			=> self.Match(
				() => None,
				x => pred( x ) ? self : None );



	}
	namespace MaybeType
	{
		public struct Nothing
		{
			internal static readonly Nothing Defualt = new Nothing();
		}

		public struct Just<A>
		{
			public A Value { get; }

			public Just( A value )
			{
				if ( value == null ) throw new ArgumentNullException("Create Just with value not null");
				Value = value;
			}

		}
	}
	


}
