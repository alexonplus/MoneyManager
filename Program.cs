using Spectre.Console;
using System;

using System.Threading;
using System.Transactions;

class Program
{
    // Create a BudgetManager object to store all transactions
    static BudgetManager manager = new BudgetManager();

    static void Main()
    {
        // Set console to support UTF-8 characters (for emojis)
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Start the main menu
        RunMenu();
    }

    // Show the main title of the program with color
    static void ShowTitle()
    {
        // "BUDGET" in red
        AnsiConsole.Write(new FigletText("BUDGET").Centered().Color(Color.Red));
        // "TRACKER" in yellow
        AnsiConsole.Write(new FigletText("TRACKER").Centered().Color(Color.Yellow));
        Console.WriteLine();
    }

    // Main menu loop
    static void RunMenu()
    {
        string[] options = {
            "➕  Lägg till transaktion",      // Add transaction
            "📋  Visa alla transaktioner",    // Show all transactions
            "💰  Visa total balans",          // Show total balance
            "🗑️  Ta bort transaktion",        // Delete a transaction
            "💾  Avsluta"                     // Exit program
        };

        int index = 0;       // Current selected menu item
        bool running = true; // Menu loop control

        while (running)
        {
            Console.Clear();
            ShowTitle();
            Console.WriteLine("Use ↑ and ↓ to select, Enter to confirm\n");

            // Center the menu in the console
            int padLeft = (Console.WindowWidth - 30) / 2;
            for (int i = 0; i < options.Length; i++)
            {
                string pointer = (i == index) ? "▶ " : "  "; // Highlight selected item
                Console.WriteLine(new string(' ', padLeft) + pointer + options[i]);
            }

            // Read user key input
            var key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    // Move selection up
                    index = (index == 0) ? options.Length - 1 : index - 1;
                    break;
                case ConsoleKey.DownArrow:
                    // Move selection down
                    index = (index == options.Length - 1) ? 0 : index + 1;
                    break;
                case ConsoleKey.Enter:
                    // Execute selected menu option
                    HandleChoice(index, ref running);
                    break;
                case ConsoleKey.Escape:
                    // Exit program if Esc is pressed
                    running = false;
                    break;
            }
        }

        // Goodbye message
        Console.Clear();
        Console.WriteLine("Thank you for using Budget Tracker!");
    }

    // Execute the action based on menu selection
    static void HandleChoice(int index, ref bool running)
    {
        Console.Clear();
        ShowTitle();

        switch (index)
        {
            case 0: AddTransactionFlow(); break;       // Add a new transaction
            case 1: manager.ShowAll(); Pause(); break; // Show all transactions
            case 2:                                   // Show total balance
                decimal balance = manager.CalculateBalance();
                Console.WriteLine($"\nCurrent balance: {balance:C}\n");
                Pause();
                break;
            case 3: DeleteTransactionFlow(); break;   // Delete a transaction
            case 4: running = false; break;           // Exit
        }
    }

    // Add a new transaction
    static void AddTransactionFlow()
    {
        Console.Write("Description: ");
        string desc = Console.ReadLine() ?? "";

        decimal amount;
        while (true)
        {
            Console.Write("Amount (positive=income, negative=expense): ");
            if (decimal.TryParse(Console.ReadLine(), out amount)) break;
            Console.WriteLine("Invalid number, try again.");
        }

        Console.Write("Category: ");
        string cat = Console.ReadLine() ?? "";

        // Automatically use today's date
        string date = DateTime.Now.ToString("yyyy-MM-dd");

        // Add transaction to the manager
        manager.AddTransaction(new Transaction(desc, amount, cat, date));
        Console.WriteLine("✅ Transaction added!");
        Pause();
    }

    // Delete a transaction by index
    static void DeleteTransactionFlow()
    {
        manager.ShowAll();
        Console.Write("\nEnter the index of the transaction to delete: ");
        if (int.TryParse(Console.ReadLine(), out int idx))
        {
            if (manager.DeleteTransaction(idx))
                Console.WriteLine("Transaction deleted.");
            else
                Console.WriteLine("Invalid index!");
        }
        else
        {
            Console.WriteLine("Invalid input!");
        }
        Pause();
    }

    // Wait for user to press a key before returning to menu
    static void Pause()
    {
        Console.WriteLine("\nPress any key to return to the menu...");
        Console.ReadKey(true);
    }
}



/* Programmet ska ha minst följande menyval:
 1️⃣ ➕ Lägg till transaktion
 2️⃣ 📋 Visa alla transaktioner
 3️⃣ 💰 Visa total balans
 4️⃣ 🗑️ Ta bort transaktion
 5️⃣ 💾 Avsluta programmet

(Bonus: skapa en extra meny för att visa transaktioner per kategori.)*/
