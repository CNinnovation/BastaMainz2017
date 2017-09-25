using CSharp7Samples;
using DataLib;
using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        BinaryLiteralsAndDigitSeparators();
        RefLocalAndRefReturn();
        OutVars();
        LocalFunctions();
        LambdaExpressionsEverywhere();
        ThrowExpressions();
        PatternMatching();
        TuplesAndDeconstruction();
        GroupJoinWithMethodsAndTuples();
    }

    private static void BinaryLiteralsAndDigitSeparators()
    {
        Console.WriteLine(nameof(BinaryLiteralsAndDigitSeparators));
        int b1 = 0b1010111100001100;

        Console.WriteLine($"{b1:X}");

        int b2 = 0b1010_0000_1111_1100;

        int b3 = b1 | b2;
        Console.WriteLine($"{b3:X}");
        Console.WriteLine();
    }

    private static void RefLocalAndRefReturn()
    {
        Console.WriteLine(nameof(RefLocalAndRefReturn));
        int[] data = { 1, 2, 3, 4 };
        ref int a = ref GetArrayElement(data, 2);
        Console.WriteLine(a);
        a = 33;
        Console.WriteLine(data[2]);
        Console.WriteLine();
    }

    private static ref int GetArrayElement(int[] arr, int index)
    {
        ref int x = ref arr[index];  // ref local
        return ref x;  // ref return
    }

    private static void OutVars()
    {
        Console.WriteLine(nameof(OutVars));
        Console.WriteLine("enter a number:");
        string input = Console.ReadLine();
        bool success = int.TryParse(input, out var result);
        if (success)
        {
            Console.WriteLine($"this number: {result}");
        }
        else
        {
            Console.WriteLine("NaN");
        }
        Console.WriteLine();
    }

    private static void LocalFunctions()
    {
        Console.WriteLine(nameof(LocalFunctions));
        int z = 3;
        int InnerMethod(int x, int y) => x + y + z;
        //{

        //    return x + y + z;
        //}

        int result = InnerMethod(1, 2);
        Console.WriteLine(result);
        Console.WriteLine();
    }

    private static void LambdaExpressionsEverywhere()
    {
        Console.WriteLine(nameof(LambdaExpressionsEverywhere));
        var p = new Person("Stephanie Nagel");
        Console.WriteLine(p.FirstName);
        Console.WriteLine();
    }

    private static void ThrowExpressions()
    {
        Console.WriteLine(nameof(ThrowExpressions));

        int x = 42;

        int y = 0;
        if (x <= 42)
        {
            y = x;
        }
        else
        {
            throw new Exception("bad value");
        }

        Console.WriteLine($"y: {y}");

        Console.WriteLine();
    }

    private static void TuplesAndDeconstruction()
    {
        Console.WriteLine(nameof(TuplesAndDeconstruction));
        (var s, var i) = ("magic", 42);
        Console.WriteLine(s);

        var t = Divide(7, 3);
        Console.WriteLine($"result: {t.Result}, reminder: {t.Remainder}");

        var oldtuple = t.ToTuple();
        Console.WriteLine($"result: {oldtuple.Item1}, reminder: {oldtuple.Item2}");
        (var res, var rem) = Divide(18, 4);
        Console.WriteLine($"result: {res}, remainder: {rem}");

        var p = new Person("Matthias Nagel");
        p.Age = 6;
        (var firstname, var lastname, var age) = p;
        Console.WriteLine($"{firstname}");
        Console.WriteLine();

        var people = new List<Person>()
        {
            p,
            new Person("Stephanie Nagel"),
            new Person("Katharina Nagel")
        };

        foreach ((string first, string last) in people)
        {
            Console.WriteLine(first);
        }
    }

    public static (int Result, int Remainder) Divide(int val1, int val2)
    {
        int result = val1 / val2;
        int remainder = val1 % val2;
        return (result, remainder);
    }

    private static void PatternMatching()
    {
        Console.WriteLine(nameof(PatternMatching));
        object[] data = { null, 42, new Person("Matthias Nagel"), new Person("Katharina Nagel") };

        foreach (var item in data)
        {
            IsPattern(item);
        }
        foreach (var item in data)
        {
            SwitchPattern(item);
        }
        Console.WriteLine();
    }

    public static void IsPattern(object o)
    {
        if (o is null) Console.WriteLine("it's a constant pattern");

        if (o is 42) Console.WriteLine("it's 42"); // constant pattern

        if (o is int i) Console.WriteLine($"it's a type pattern with an int and the value {i}");

        if (o is var x) Console.WriteLine($"it's a var pattern with the type {x?.GetType()?.Name}");

        if (o is Person p) Console.WriteLine($"it's a person: {p.FirstName}");

        if (o is Person p2 && p2.FirstName.StartsWith("Ka")) Console.WriteLine($"it's a person starting with Ka {p2.FirstName}");
    }

    public static void SwitchPattern(object o)
    {
        switch (o)
        {
            case null:
                Console.WriteLine("it's a constant pattern");
                break;
            case int i:
                Console.WriteLine("it's an int");
                break;
            case Person p when p.FirstName.StartsWith("Ka"):
                Console.WriteLine($"a Ka person {p.FirstName}");
                break;
            case var x:
                Console.WriteLine("it's a var pattern");
                break;
            default:
                break;
        }
    }

    static void GroupJoinWithMethodsAndTuples()
    {
        var racers = Formula1.GetChampionships()
          .SelectMany(cs => new List<(int Year, int Position, string FirstName, string LastName)>
          {
              (cs.Year, Position: 1, FirstName: cs.First.FirstName(), LastName: cs.First.LastName()),
              (cs.Year, Position: 2, FirstName: cs.Second.FirstName(), LastName: cs.Second.LastName()),
              (cs.Year, Position: 3, FirstName: cs.Third.FirstName(), LastName: cs.Third.LastName())
          });

        var q = Formula1.GetChampions()
            .GroupJoin(racers,
                r1 => (r1.FirstName, r1.LastName),
                r2 => (r2.FirstName, r2.LastName),
                (r1, r2s) => (r1.FirstName, r1.LastName, r1.Wins, r1.Starts, Results: r2s));


        foreach (var r in q)
        {
            Console.WriteLine($"{r.FirstName} {r.LastName}");
            foreach (var results in r.Results)
            {
                Console.WriteLine($"{results.Year} {results.Position}");
            }
        }
    }

    static void GroupJoin()
    {
        var racers = from cs in Formula1.GetChampionships()
                     from r in new List<(int Year, int Position, string FirstName, string LastName)>()
                     {
                         (cs.Year, Position: 1, FirstName: cs.First.FirstName(), LastName: cs.First.LastName()),
                         (cs.Year, Position: 2, FirstName: cs.Second.FirstName(), LastName: cs.Second.LastName()),
                         (cs.Year, Position: 3, FirstName: cs.Third.FirstName(), LastName: cs.Third.LastName())
                     }
                     select r;

        var q = (from r in Formula1.GetChampions()
                 join r2 in racers on
                 (
                     r.FirstName,
                     r.LastName
                 )
                 equals
                 (
                     r2.FirstName,
                     r2.LastName
                 )
                 into yearResults
                 select
                 (
                     r.FirstName,
                     r.LastName,
                     r.Wins,
                     r.Starts,
                     Results: yearResults
                 ));

        foreach (var r in q)
        {
            Console.WriteLine($"{r.FirstName} {r.LastName}");
            foreach (var results in r.Results)
            {
                Console.WriteLine($"\t{results.Year} {results.Position}");
            }
        }
    }
}