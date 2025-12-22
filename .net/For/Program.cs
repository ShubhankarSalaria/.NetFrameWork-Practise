// See https://aka.ms/new-console-template for more information
using System;

public class Program{
	public static void Main(string[] args)
	{
		// 1 Fibonacci
		Console.WriteLine("Fibonacci: Enter N:");
		string? sn = Console.ReadLine();
		if (int.TryParse(sn, out int n)) Console.WriteLine(new Fibonacci().GetSeries(n));

		// 2 Prime
		Console.WriteLine("Prime Check: Enter number:");
		string? sp = Console.ReadLine();
		if (int.TryParse(sp, out int pv)) Console.WriteLine(new PrimeChecker().IsPrime(pv));

		// 3 Armstrong
		Console.WriteLine("Armstrong Check: Enter number:");
		string? sa = Console.ReadLine();
		if (int.TryParse(sa, out int av)) Console.WriteLine(new Armstrong().Check(av));

		// 4 Reverse & Palindrome
		Console.WriteLine("Reverse & Palindrome: Enter integer:");
		string? sr = Console.ReadLine();
		if (int.TryParse(sr, out int rv)) Console.WriteLine(new ReversePalindrome().Check(rv));

		// 5 GCD and LCM
		Console.WriteLine("GCD & LCM: Enter two integers (one per line):");
		string? g1 = Console.ReadLine();
		string? g2 = Console.ReadLine();
		if (int.TryParse(g1, out int gA) && int.TryParse(g2, out int gB)) Console.WriteLine(new GcdLcm().Get(gA, gB));

		// 6 Pascal's Triangle
		Console.WriteLine("Pascal's Triangle: Enter rows N:");
		string? spn = Console.ReadLine();
		if (int.TryParse(spn, out int pn)) Console.WriteLine(new PascalsTriangle().GetRows(pn));

		// 7 Binary to Decimal
		Console.WriteLine("Binary to Decimal: Enter binary string:");
		string? sb = Console.ReadLine();
		if (sb != null) Console.WriteLine(new BinaryToDecimal().Convert(sb.Trim()));

		// 8 Diamond Pattern
		Console.WriteLine("Diamond Pattern: Enter size (n):");
		string? sd = Console.ReadLine();
		if (int.TryParse(sd, out int dn)) Console.WriteLine(new DiamondPattern().Get(dn));

		// 9 Factorial (large)
		Console.WriteLine("Factorial: Enter N:");
		string? sf = Console.ReadLine();
		if (int.TryParse(sf, out int fn)) Console.WriteLine(new FactorialLarge().Compute(fn));

		// 10 Guessing Game (do-while)
		Console.WriteLine("Guessing Game: I chose a number between 1 and 100. Try to guess!");
		var rnd = new Random();
		int secret = rnd.Next(1, 101);
		int guess;
		int attempts = 0;
		do
		{
			Console.Write("Enter guess: ");
			string? gs = Console.ReadLine();
			if (!int.TryParse(gs, out guess)) { Console.WriteLine("Invalid"); continue; }
			attempts++;
			if (guess < secret) Console.WriteLine("Higher");
			else if (guess > secret) Console.WriteLine("Lower");
			else Console.WriteLine("Correct! Attempts: " + attempts);
		} while (guess != secret);

		// 11 Sum of Digits (Digital Root)
		Console.WriteLine("Digital Root: Enter number:");
		string? sdr = Console.ReadLine();
		if (int.TryParse(sdr, out int drn)) Console.WriteLine(new DigitalRoot().Compute(drn));

		// 12 Continue Usage
		Console.WriteLine("Continue Usage (1..50 skip multiples of 3):");
		Console.WriteLine(new ContinueSkip().Get());

		// 13 Menu System (simple demo)
		Console.WriteLine("Menu System demo - enter option (1 or 2):");
		string? smenu = Console.ReadLine();
		if (int.TryParse(smenu, out int mopt)) Console.WriteLine(new MenuSystem().RunOnce(mopt));

		// 14 Strong Number
		Console.WriteLine("Strong Number: Enter number:");
		string? sstr = Console.ReadLine();
		if (int.TryParse(sstr, out int sn)) Console.WriteLine(new StrongNumber().Check(sn));

		// 15 Search with goto
		Console.WriteLine("Goto Search: Enter rows and cols for a small matrix:");
		string? srows = Console.ReadLine();
		string? scols = Console.ReadLine();
		if (int.TryParse(srows, out int r) && int.TryParse(scols, out int c))
		{
			int[,] mat = new int[r, c];
			Console.WriteLine("Enter matrix elements row-wise (r*c integers):");
			for (int i = 0; i < r; i++)
				for (int j = 0; j < c; j++)
				{
					string? se = Console.ReadLine();
					mat[i, j] = int.TryParse(se, out int v) ? v : 0;
				}
			Console.WriteLine("Enter target to search:");
			string? st = Console.ReadLine();
			if (int.TryParse(st, out int target)) Console.WriteLine(new GotoSearch().Find(mat, target));
		}
	}
}