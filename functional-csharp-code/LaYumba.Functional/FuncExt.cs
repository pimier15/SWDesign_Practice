﻿using System;
using Unit = System.ValueTuple;

namespace LaYumba.Functional
{
   using static F;

   public static class FuncExt
   {
      public static Func<T> ToNullary<T>(this Func<Unit, T> f)
          => () => f(Unit());

      public static Func<T1, R> Compose<T1, T2, R>(this Func<T2, R> g, Func<T1, T2> f)
         => x => g(f(x));

      public static Func<T, bool> Negate<T>(this Func<T, bool> pred) => t => !pred(t);

      public static Func<T2, R> Apply<T1, T2, R>(this Func<T1, T2, R> func, T1 t1)
          => t2 => func(t1, t2);

      public static Func<T2, T3, R> Apply<T1, T2, T3, R>(this Func<T1, T2, T3, R> func, T1 t1)
          => (t2, t3) => func(t1, t2, t3);

      public static Func<I1, I2, R> Map<I1, I2, T, R>(this Func<I1, I2, T> @this, Func<T, R> func)
         => (i1, i2) => func(@this(i1, i2));
   }


   // Env -> T (aka. Reader)
   public static class FuncTRExt
   {
      public static Func<Env, R> Map<Env, T, R>
         (this Func<Env, T> f, Func<T, R> g)
         => x => g(f(x));

      public static Func<Env, R> Bind<Env, T, R>
         (this Func<Env, T> f, Func<T, Func<Env, R>> g)
         => env => g(f(env))(env);

      // same as above, in uncurried form
      public static Func<Env, R> Bind<Env, T, R>
         (this Func<Env, T> f, Func<T, Env, R> g)
         => env => g(f(env), env);


      // LINQ

      public static Func<Env, R> Select<Env, T, R>(this Func<Env, T> f, Func<T, R> g) => f.Map(g);

      public static Func<Env, P> SelectMany<Env, T, R, P>
         (this Func<Env, T> f, Func<T, Func<Env, R>> bind, Func<T, R, P> project)
         => env =>
         {
            var t = f(env);
            var r = bind(t)(env);
            return project(t, r);
         };
   }
}
