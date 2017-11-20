using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit = System.ValueTuple;


namespace Practice.dataType
{
	using static Handler;

	public static partial class Handler
	{
		public static Either.Left<L> Left<L>( L l ) => new Either.Left<L>( l );
		public static Either.Right<R> Right<R>( R r ) => new Either.Right<R>( r ); // For f(x)
	}

	public struct Either<L,R>
	{
		internal L Left { get; set; }
		internal R Right { get; set; }

		private bool IsRight { get; }
		private bool IsLeft => !IsRight;

		internal Either( L left )
		{
			IsRight = false;
			Left = left;
			Right = default( R );
		}

		internal Either( R right )
		{
			IsRight = true;
			Left = default( L );
			Right = right;
		}

		public static implicit operator Either<L,R>(L left) => new Either<L, R>(left);
		public static implicit operator Either<L,R>(R right) => new Either<L, R>(right);

		public static implicit operator Either<L,R> (Either.Left<L> left) => new Either<L, R>(left.Value);
		public static implicit operator Either<L,R> (Either.Right<R> right) => new Either<L, R>(right.Value);


		public TR Match<TR>( Func<L, TR> Left, Func<R, TR> Right )
			=> IsLeft ? Left( this.Left ) : Right( this.Right );

		public Unit Match( Action<L> Left, Action<R> Right )
			=> Match( Left.ToFunc(), Right.ToFunc() );

	}

	public static class Either
	{
		public struct Left<L>
		{
			internal L Value { get; }
			internal Left( L value ) { Value = value; }
			public override string ToString() => $"Left({Value})";
			
		}

		public struct Right<R>
		{
			internal R Value { get; }
			internal Right( R value ) { Value = value; }
			public override string ToString() => $"Right({Value})";

			public Right<RR> Map<L, RR>( Func<R, RR> f ) => Right( f( Value ) );
			public Either<L, RR> Bind<L, RR>( Func<R, Either<L, RR>> f ) => f( Value );
		}
	}

	public static class EitherExt
	{
		public static Either<L, RR> Map<L, R, RR>
			( this Either<L, R> self, Func<R, RR> f )
			=> self.Match<Either<L, RR>>(
				l => Left( l ),
				r => Right(f(r)));

		public static Either<LR, RR> Map<L, LR, R, RR>
			( this Either<L, R> self, Func<L, LR> left, Func<R, RR> right )
			=> self.Match<Either<LR,RR>>(
				l => Left(left(l)),
				r => Right(right(r)));

		public static Either<L, Unit> ForEach<L, R>
			( this Either<L, R> self, Action<R> act )
			=> Map( self, act.ToFunc() );

		public static Either<L, RR> Bind<L, R, RR>
			( this Either<L, R> self, Func<R, Either<L, RR>> f )
			=> self.Match(
				l => Left(l) ,
				r => f(r));

		public static Either<L, RR> Select<L, R, RR>
			( this Either<L, R> self, Func<R, RR> map )
			=> self.Map( map );

		public static Either<L, RR> SelectMany<L, T, R, RR>
			( this Either<L, T> self, Func<T, Either<L, R>> bind, Func<T, R, RR> project )
			=> self.Match(
				Left : l => Left(l) ,
				Right : t => bind(self.Right).Match<Either<L,RR>>(
					Left: l => Left(l) ,
					Right : r => project(t,r)));
	}



}
