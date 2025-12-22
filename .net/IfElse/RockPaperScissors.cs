// RockPaperScissors.cs
// Implements simple 2-player RPS logic using nested conditionals.
using System;

public class RockPaperScissors
{
    public string Decide(string p1, string p2)
    {
        string a = p1.Trim().ToLower();
        string b = p2.Trim().ToLower();
        if (a == b) return "Tie.";

        if (a == "rock")
        {
            if (b == "scissors") return "Player 1 wins.";
            return "Player 2 wins.";
        }
        if (a == "paper")
        {
            if (b == "rock") return "Player 1 wins.";
            return "Player 2 wins.";
        }
        if (a == "scissors")
        {
            if (b == "paper") return "Player 1 wins.";
            return "Player 2 wins.";
        }
        return "Invalid input.";
    }
}
