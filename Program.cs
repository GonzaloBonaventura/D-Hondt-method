using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using System.Drawing;

class Program
{
    static List<string> names = new List<string> { };
    static List<int> votes = new List<int> { };
    static void Main()
    {
        bool run = true;
        System("Welcome, this is a simulator for the D'Hondt method to allocate seats in parliaments.");
        System("D'Hondt works by taking each party's total votes and dividing them by 1, 2, 3, and so on until you have at least as many results as seats.");
        System("All those results from every party are put together in one list, then sorted from the biggest to the smallest, and the top results win the seats.");
        System("Each time a party appears in that top group, it gets one seat. That is the whole method: divide votes, mix the results, sort them, and the highest numbers decide who gets the seats");
        while (run)
        {
            Run();
            run = Line("Do you want to run the program again?", true);
            names =  new List<string> { };
            votes = new List<int> { };
        }
    }
    static void Run()
    {
        bool keepadding = true;
        Line();
        while (keepadding)
        {
            Line("Let's add a party.");
            NewParty();
            keepadding = Line("Do you want to add another party?", true);
        }
        Calculate();
        Line();
    }
    static bool Line(string msg = "", bool question = false)
    {
        Console.WriteLine(msg);
        while (question)
        {
            WriteColor("yes ", ConsoleColor.Green);
            Console.Write("| ");
            WriteColor("no", ConsoleColor.Red);
            Line();
            string ans = Read();
            switch (ans.ToLower())
            {
                case "y":
                case "yes":
                    return true;
                case "n":
                case "no":
                    return false;
                default:
                    Error("Invalid answer.");
                    break;
            }
        }
        return false;
    }
    static void NewParty()
    {
        System("Enter the party's name");
        string name = Read();
        int value = Tryint("Enter the party total votes");

        names.Add(name);
        votes.Add(value);
        Line();
    }
    static void Calculate()
    {
        int[] totalSeats = new int[names.Count];
        int seats = Tryint("Enter the total number of seats for this election.");

        for (int i = 0; i < seats; i++)
        {
            int max = 0;
            int id = 0;
            for (int index = 0; index < votes.Count; index++)
            {
                var item = votes[index];
                int after = item / (totalSeats[index] + 1);
                if (after > max)
                {
                    max = after;
                    id = index;
                }
            }
            totalSeats[id]++;
            WriteColor(i + 1 + ". ", ConsoleColor.DarkCyan);
            WriteColor(names[id] + " <" + totalSeats[id] + "> ", ConsoleColor.Cyan);
            Line(" " + votes[id] / totalSeats[id]);
        }
    }

    static void Error(string msg)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(msg);
        Console.ResetColor();
    }
    static void System(string msg)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(msg);
        Console.ResetColor();
    }
    static void WriteColor(string msg,ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(msg);
        Console.ResetColor();
    }
    static string Read()
    {
        while (true)
        {
            string? input = Console.ReadLine();
            if (!String.IsNullOrEmpty(input))
            {
                return input;
            }
            Error("Invalid input, try again.");
        }
    }
    static int Tryint(string msg)
    {
        bool go = true;
        int num = 0;
        while (go)
        {
            System(msg);
            string ans = Read();
            if (int.TryParse(ans, out num))
            {
                go = !Line("Is this correct : \"" + num + "\"?", true);
            }
            else
            {
                Error("Enter an integer.");
            }
        }
        return num;
    }
}