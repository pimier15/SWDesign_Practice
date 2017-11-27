using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.dataType;


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


    }


}
