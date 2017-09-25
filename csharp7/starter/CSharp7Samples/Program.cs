using CSharp7Samples;
using DataLib;
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        //BinaryLiteralsAndDigitSeparators();
        //RefLocalAndRefReturn();
        //OutVars();
        //LocalFunctions();
        //LambdaExpressionsEverywhere();
        //ThrowExpressions();
        //PatternMatching();
        //TuplesAndDeconstruction();
        //GroupJoinWithMethodsAndNoTuples();
        GroupJoin();
    }

    private static void BinaryLiteralsAndDigitSeparators()
    {
        Console.WriteLine(nameof(BinaryLiteralsAndDigitSeparators));

        Console.WriteLine();
    }

    private static void RefLocalAndRefReturn()
    {
        Console.WriteLine(nameof(RefLocalAndRefReturn));

        Console.WriteLine();
    }

    private static void OutVars()
    {
        Console.WriteLine(nameof(OutVars));
        Console.WriteLine("enter a number:");
        string input = Console.ReadLine();

        int result;
        bool success = int.TryParse(input, out result);
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


        Console.WriteLine();
    }

    private static void LambdaExpressionsEverywhere()
    {
        Console.WriteLine(nameof(LambdaExpressionsEverywhere));


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


        Console.WriteLine();
    }

    private static void PatternMatching()
    {
        Console.WriteLine(nameof(PatternMatching));

        Console.WriteLine();
    }

    public static void IsPattern(object o)
    {

    }

    public static void SwitchPattern(object o)
    {

    }

    internal class RacerInfo
    {
        public int Year { get; set; }
        public int Position { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    static void GroupJoinWithMethodsAndNoTuples()
    {
        var racers = Formula1.GetChampionships()
            .SelectMany(cs => new List<RacerInfo>()
            {
                new RacerInfo
                {
                    Year = cs.Year,
                    Position = 1,
                    FirstName = cs.First.FirstName(),
                    LastName = cs.First.LastName()
                },
                new RacerInfo
                {
                    Year = cs.Year,
                    Position = 2,
                    FirstName = cs.Second.FirstName(),
                    LastName = cs.Second.LastName()
                },
                new RacerInfo
                {
                    Year = cs.Year,
                    Position = 3,
                    FirstName = cs.Third.FirstName(),
                    LastName = cs.Third.LastName()
                }
            });

        var q = Formula1.GetChampions()
            .GroupJoin(racers,
                r1 => new { r1.FirstName, r1.LastName },  // outer key selector
                r2 => new { r2.FirstName, r2.LastName },  // inner key selector
                (r1, r2s) => new { r1.FirstName, r1.LastName, r1.Wins, r1.Starts, Results = r2s });  // result selector


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
                     from r in new List<RacerInfo>()
                        {
                            new RacerInfo
                            {
                                Year = cs.Year,
                                Position = 1,
                                FirstName = cs.First.FirstName(),
                                LastName = cs.First.LastName()
                            },
                            new RacerInfo
                            {
                                Year = cs.Year,
                                Position = 2,
                                FirstName = cs.Second.FirstName(),
                                LastName = cs.Second.LastName()
                            },
                            new RacerInfo
                            {
                                Year = cs.Year,
                                Position = 3,
                                FirstName = cs.Third.FirstName(),
                                LastName = cs.Third.LastName()
                            }
                        }
                     select r;

        var q = (from r in Formula1.GetChampions()
                 join r2 in racers on
                 new
                 {
                     r.FirstName,
                     r.LastName
                 }
                 equals
                 new
                 {
                     r2.FirstName,
                     r2.LastName
                 }
                 into yearResults
                 select
                 new
                 {
                     r.FirstName,
                     r.LastName,
                     r.Wins,
                     r.Starts,
                     Results = yearResults
                 });

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