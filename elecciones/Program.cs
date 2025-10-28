using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;

class Program
{
    static List<string> names = new List<string> { };
    static List<int> votes = new List<int> { };
    static List<string> result = new List<string> { };


    static void Main()
    {
        bool keepadding = true;
        Line("Welcome, this is the D'Hondt votes simulator for the senate.");
        Console.WriteLine("D'Hondt works by taking each party's total votes and dividing them by 1, 2, 3, and so on until you have at least as many results as seats.");
        Console.WriteLine("All those results from every party are put together in one list, then sorted from the biggest to the smallest, and the top results win the seats.");
        Console.WriteLine("Each time a party appears in that top group, it gets one seat. That is the whole method: divide votes, mix the results, sort them, and the highest numbers decide who gets the seats");

        Line();
        while (keepadding)
        {
            Line("let's add a party.");
            NewParty();
            keepadding = Line("Do you want to add another party?", true);
        }
        Calculate();
    }
    static bool Line(string msg = "", bool question = false)
    {
        Console.WriteLine(msg);
        while (question)
        {
            Console.WriteLine("yes | no");
            string ans = Console.ReadLine();
            switch (ans.ToLower())
            {
                case "y":
                case "yes":
                    return true;
                case "n":
                case "no":
                    return false;
                default:
                    Console.WriteLine("invalid answer.");
                    break;
            }
        }
        return false;
    }
    static void NewParty()
    {
        bool go = true;
        string name = "";
        string vote = "";
        int value = 0;
        while (go)
        {
            Line("introduce party name");
            name = Console.ReadLine();
            //go = !Line("is this correct : \"" + name + "\"?", true);
            go = false;
        }
        go = true;
        while (go)
        {
            Line("introduce total votes for the party");
            vote = Console.ReadLine();
            if (int.TryParse(vote, out value))
            {
                go = !Line("is this correct : \"" + value + "\"?", true);
            }
            else
            {
                Console.WriteLine("introduce an integer.");
            }

        }
        names.Add(name);
        votes.Add(value);
        Line();
    }
    static void Calculate()
    {
        int[] totalSeats = new int[names.Count];
        bool go = true;
        int seats = 0;
        while (go)
        {
            Line("introduce the total amount of seats at play");
            string ans = Console.ReadLine();
            if (int.TryParse(ans, out seats))
            {
                go = !Line("is this correct : \"" + seats + "\"?", true);
            }
            else
            {
                Console.WriteLine("introduce an integer.");
            }
        }

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
            result.Add(i + 1 + ". " + names[id] + " " + totalSeats[id] + ". " + votes[id]/totalSeats[id]);
        }
        foreach (var item in result)
        {
            Line(item);
        }
    }
}