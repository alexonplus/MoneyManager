using System;

public class Transaction
{
    // Description of the transaction (e.g., "Salary", "Groceries")
    public string Description { get; set; }

    // Amount of money: positive = income, negative = expense
    public decimal Amount { get; set; }

    // Category of the transaction (e.g., "Food", "Transport")
    public string Category { get; set; }

    // Date of the transaction in "YYYY-MM-DD" format
    public string Date { get; set; }

    // Constructor to create a new transaction with all details
    public Transaction(string description, decimal amount, string category, string date)
    {
        Description = description;
        Amount = amount;
        Category = category;
        Date = date;
    }

    // Display transaction info in console
    // Optional index parameter to show numbered list
    public void ShowInfo(int index = -1)
    {
        if (index >= 0)
            Console.Write($"[{index}] "); // Show index if provided

        if (Amount >= 0)
        {
            // Income is green
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{Description} | +{Amount:C} | {Category} | {Date}");
        }
        else
        {
            // Expense is red
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{Description} | {Amount:C} | {Category} | {Date}");
        }

        // Reset console color to default
        Console.ResetColor();
    }
}



/*Klass: Transaction
 🧾 Innehåller egenskaper för:
Description (t.ex. “Lön”, “Matinköp”)
Amount (decimal, positivt = inkomst, negativt = utgift)
Category (t.ex. “Mat”, “Transport”, “Hyra”, “Inkomst”)
Date (skrivs som text, t.ex. “2025-10-10”)
💬 Metod:
ShowInfo() – skriver ut all information om transaktionen.*/