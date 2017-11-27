using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.dataType;
using static Practice.dataType.PartialApply;

namespace Practice.Exercises.C7
{
    using Name = System.String;
    using Greeting = System.String;
    using PersonalizedGreeting = System.String;
    using static System.Console;
    class GreetingExample
    {
        Func<Greeting, Name, PersonalizedGreeting> greet
            => ( gr, Name ) => $"{gr} , {Name}";

        Name[] names = { "Thris" , "Ivan"};

        public void main()
        {
            names.Map( g => greet( "Hi", g ) )
                .ForEach( WriteLine );

            var greetFormally = greetWith("Good Night");
            names.Map( greetFormally ).ForEach(WriteLine);

            var greetApply = greet.Apply("Good Morning");
            names.Map( greetApply ).ForEach( WriteLine );
        }

        Func<Greeting , Func<Name , PersonalizedGreeting>> greetWith
            => gr => Name => $"{gr} , {Name}";

		PersonalizedGreeting GreeterMethod (Greeting gr , Name name)
			=> $"{gr} , {name}";

		Func<Name, PersonalizedGreeting> GreetWith_1( Greeting greeting )
			=> PartialApply.Apply<Greeting, Name, PersonalizedGreeting>
				( GreeterMethod, greeting );  // not good

		Func<Name, PersonalizedGreeting> GreetWith_2( Greeting greeting )
			=> new Func<Greeting, Name, PersonalizedGreeting>( GreeterMethod ).Apply( greeting ); // not good

    }

	// solution

	public class TypeInference_delegate
	{
		string seperator = "!";

		Func<Greeting , Name , PersonalizedGreeting> GreeterField
			= (gr , name) => $"{gr} , {name}"; //이렇게 필드로 사용시 seperator를 사용 못함.

		Func<Greeting , Name , PersonalizedGreeting> GreeterProperty
				=> (gr , name) => $"{gr} ,{seperator} , {name}"; // => 사용해서 프로퍼티로 사용시 클래스내 필드 멤버 사용가능

		Func<Greeting, T, PersonalizedGreeting> GreeterFactory<T>()
			=> ( gr, t ) => $"{gr}{seperator}{t}"; // 팩토리 패턴

		public void main()
		{
			GreeterField.Apply( "" );
			GreeterProperty.Apply( "" );
			GreeterFactory<Name>().Apply( "" );

		}

	}



}
