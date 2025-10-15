Budget Tracker💵


Budget Tracker is a simple console application written in C# that allows users to manage their personal finances.
It supports adding income and expense transactions, viewing all transactions, calculating the total balance, and deleting entries.
The app also uses Spectre.Console to provide a colorful, interactive console menu.

![Menu](https://github.com/alexonplus/MoneyManager/blob/main/menu.jpg?raw=true)


Features

* Add a new transaction with description, amount, category, and date (automatically set to current date).

* View all transactions in a formatted list with color-coded income (green) and expenses (red).

* Calculate and display the total balance.

* Delete transactions by index.

  Program Flow:
1. Start the program
2. Display main menu
3. User selects an option:
   - Add transaction
   - View all transactions
   - Show total balance
   - Delete transaction
   - Exit
4. Perform the selected action
5. Return to main menu
6. Repeat until exit

![Program Flow](https://github.com/alexonplus/MoneyManager/blob/main/flow.png?raw=true)


Installation

Clone the repository:

git clone https://github.com/<username>/<repo>.git


Open the project in Visual Studio or any C# IDE.

Make sure Spectre.Console is installed via NuGet:

Install-Package Spectre.Console:

> dotnet add package Spectre.Console
> dotnet add package Spectre.Console.Cli


## Classes

The project uses the following classes:

| Class Name       | Description                                                                |
|-----------------|-----------------------------------------------------------------------------|
| `Transaction`   | Represents a single financial transaction. Stores Description, Amount, Category, and Date. Includes `ShowInfo()` method to display transaction details with color. |
| `BudgetManager` | Manages a list of `Transaction` objects. Provides methods to add, delete, show all transactions, calculate balance, and get statistics. |
| `Program`       | Contains the main program flow. Handles interactive console menu using Spectre.Console and connects user input with `BudgetManager`. |

![Diagram](https://github.com/alexonplus/MoneyManager/blob/main/diagram-Manager.jpg?raw=true)









