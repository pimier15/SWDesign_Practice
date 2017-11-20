using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Practice.dataType.Handler;
using Practice.dataType;
using Unit = System.ValueTuple;

namespace Practice.Exercises.C6
{
	class WakeUpSxamm_Either
	{
		Func<Either<Reasion , Unit>> WakeupEarly;
		Func<Unit,Either<Reasion, Ingredient>> ShopForIngredient;
		Func<Ingredient , Either<Reasion , Food>> Cookrecipe;

		Action<Food> EnjoyTogether;
		Action<Reasion> ComplainAbout;
		Action OrderPizza;

		void Start()
		{

			WakeupEarly()
				.Bind( ShopForIngredient )
				.Bind( Cookrecipe )
				.Match(
				Left: reasion => { ComplainAbout( reasion );
								   OrderPizza(); },
				Right: dish => EnjoyTogether( dish )
				);
		}

	}

	class Reasion
	{
		public string reasion;

		public Reasion( string res )
		{
			reasion = res;
		}
	}
	class Ingredient { }
	class Food { }
}
