using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

public class BudgetManager
{
    // List to store all transactions
    private List<Transaction> transactions = new List<Transaction>();

    // Add a new transaction to the list
    public void AddTransaction(Transaction t)
    {
        transactions.Add(t);
    }

    // Show all transactions in the console
    public void ShowAll()
    {
        if (!transactions.Any())
        {
            Console.WriteLine("No transactions found.");
            return;
        }

        // Print each transaction with its index
        for (int i = 0; i < transactions.Count; i++)
        {
            transactions[i].ShowInfo(i);
        }
    }

    // Calculate total balance (sum of all transactions)
    public decimal CalculateBalance()
    {
        return transactions.Sum(t => t.Amount);
    }

    // Delete a transaction by its index
    // Returns true if deleted successfully, false if index is invalid
    public bool DeleteTransaction(int index)
    {
        if (index < 0 || index >= transactions.Count) return false;
        transactions.RemoveAt(index);
        return true;
    }

    // Bonus: Filter transactions by category (case-insensitive)
    public List<Transaction> FilterByCategory(string category)
    {
        return transactions
            .Where(t => t.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    // Bonus: Get statistics
    // Returns total number of transactions, total income, total expenses
    public (int totalCount, decimal totalIncome, decimal totalExpense) GetStatistics()
    {
        int count = transactions.Count;
        decimal income = transactions.Where(t => t.Amount > 0).Sum(t => t.Amount);
        decimal expense = transactions.Where(t => t.Amount < 0).Sum(t => t.Amount);
        return (count, income, expense);
    }
}



/*Klass: BudgetManager
 📂 Innehåller en lista av Transaction-objekt.
 💡 Ska ha metoder för:
AddTransaction() – lägger till en ny post.
ShowAll() – visar alla transaktioner.
CalculateBalance() – räknar ut total balans.
DeleteTransaction() – tar bort en post.*/
