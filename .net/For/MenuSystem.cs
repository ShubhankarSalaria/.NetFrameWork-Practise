// MenuSystem.cs
// Persistent console menu using do-while and switch; includes sample operations that use for-loops.
using System;

public class MenuSystem
{
    public string RunOnce(int choice)
    {
        switch (choice)
        {
            case 1:
                // sample: sum first 10 numbers using for
                int sum = 0;
                for (int i = 1; i <= 10; i++) sum += i;
                return "Sum 1..10 = " + sum;
            case 2: return "Option 2 selected.";
            default: return "Unknown option.";
        }
    }
}
