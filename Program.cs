using System;

namespace SuncoastHumanResources
{
    class Program
    {
        static void DisplayGreeting()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("    Welcome to Our Employee Database    ");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine();
            Console.WriteLine();
        }

        static string PromptForString(string prompt)
        {
            Console.Write(prompt);
            var userInput = Console.ReadLine();

            return userInput;
        }

        static int PromptForInteger(string prompt)
        {
            Console.Write(prompt);
            int userInput;
            var isThisGoodInput = Int32.TryParse(Console.ReadLine(), out userInput);

            if (isThisGoodInput)
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("Sorry, that isn't a valid input, I'm using 0 as your answer.");
                return 0;
            }
        }
        // ^^^^^^^^^^^^^^^^^^^^Classes and Methods^^^^^^^^^^^^^^^^^
        static void Main(string[] args)
        {
            // Our list of employees
            // var employees = new List<Employee>();

            // Our databased 
            var database = new EmployeeDatabase();

            // Should we keep showing the menu?
            var keepGoing = true;

            DisplayGreeting();


            // While the user hasn't said QUIT yet
            while (keepGoing)
            {
                // Insert a blank line then prompt them and get their answer (force uppercase)
                Console.WriteLine();
                Console.WriteLine("What do you what to do?\n(A)dd an employee\n(S)how all the employees\n(F)ind an employee\n(D)elete an employee\n(U)pdate an employee\n(Q)uit database: ");
                var choice = Console.ReadLine().ToUpper();

                // switch (choice)
                if (choice == "Q")
                {
                    // They said quit, so set our keepGoing to false
                    keepGoing = false;
                }
                else if (choice == "D")
                {
                    DeleteEmployee(database);
                }
                else if (choice == "F")
                {
                    // Ask for the name of an employee
                    FindEmployee(database);
                }
                else if (choice == "S")
                {
                    ShowAllEmployees(database);

                }
                else if (choice == "A")
                {
                    AddEmployee(database);
                }
                else if (choice == "U")
                {
                    //ask for name 
                    UpdateEmployee(database);

                }
                else
                {
                    Console.WriteLine("That isn't a vail selection");
                }

                // end of the `while` statement

            }
        }

        private static void DeleteEmployee(EmployeeDatabase database)
        {
            //take input from user get employee name
            var name = PromptForString("What name are you looking for: ");
            //search the database to see if they exist
            //Employee foundEmployee = employees.FirstOrDefault(employee => employee.Name == name);
            Employee foundEmployee = database.FindOneEmployee(name);
            //if we didn't find an employee 
            if (foundEmployee == null)
            {
                //Show if no results have been found in search
                Console.WriteLine("No such employee!");
            }
            else
            {
                //display employee
                Console.WriteLine($"Found! {foundEmployee.Name} is in department {foundEmployee.Department} and makes ${foundEmployee.Salary}");
                //Ask to confirm
                var confirm = PromptForString("Please confirm that this is the name that you want to delete. [Y/N]").ToUpper();
                if (confirm == "Y")
                {
                    //if confirmed (Y)es delete employee
                    database.RemoveEmployee(foundEmployee);
                    //employees.Remove(foundEmployee);
                }

            }
        }

        private static void FindEmployee(EmployeeDatabase database)
        {
            var name = PromptForString("What name are you looking for: ");

            // Make a new variable to store the found employee, initializing
            // to null which will indicate no match found
            //like starting from zero with indexes
            //Employee foundEmployee = null;
            Employee foundEmployee = database.FindOneEmployee(name);
            //Employee foundEmployee = employees.FirstOrDefault(employee => employee.Name == name);
            // Go through all the employees
            // foreach (var employee in employees)
            // {
            //     if (employee.Name == name)
            //     {
            //         foundEmployee = employee;
            //     }
            // }

            // If the foundEmployee is still null, nothing was found
            if (foundEmployee == null)
            {
                Console.WriteLine("No match found for ");
            }
            else
            {
                // Otherwise print details of the found employee
                Console.WriteLine($"Found! {foundEmployee.Name} is in department {foundEmployee.Department} and makes ${foundEmployee.Salary}");
            }
        }

        private static void UpdateEmployee(EmployeeDatabase database)
        {
            var name = PromptForString("What name are you looking for: ");
            //search the database to see if they exist
            //Employee foundEmployee = employees.FirstOrDefault(employee => employee.Name == name);
            Employee foundEmployee = database.FindOneEmployee(name);
            //if we didn't find an employee 
            if (foundEmployee == null)
            {
                //Show if no results have been found in search
                Console.WriteLine("No such employee!");
            }
            else
            {
                // if find employee
                Console.WriteLine($"Found! {foundEmployee.Name} is in department {foundEmployee.Department} and makes ${foundEmployee.Salary}");
                var choiceChange = PromptForString("What would you like to change [Name/Department/Salary]").ToUpper();
                //  --if name 
                if (choiceChange == "NAME")
                {
                    //  --- prompt for new name
                    foundEmployee.Name = PromptForString("What is the new name? ");
                }
                else if (choiceChange == "DEPARTMENT")
                {
                    //  --if department number
                    //  --- prompt for new department number
                    foundEmployee.Department = PromptForInteger("What is the new department number");
                }
                else if (choiceChange == "SALARY")
                {
                    //  --if salary
                    //  --- prompt for new salary
                    foundEmployee.Salary = PromptForInteger("What is the new salary");
                }
                // if not found 
                // -- return message 
            }
        }

        private static void AddEmployee(EmployeeDatabase database)
        {
            // Make a new employee object
            var employee = new Employee();

            // Prompt for values and save them in the employee's properties
            employee.Name = PromptForString("What is your name? ");
            employee.Department = PromptForInteger("What is your department number? ");
            employee.Salary = PromptForInteger("What is your yearly salary (in dollars)? ");
            // Add it to the list
            database.AddEmployee(employee);
            // employees.Add(employee);
        }

        private static void ShowAllEmployees(EmployeeDatabase database)
        {
            var employees = database.GetAllEmployees();
            // Loop through each employee: Could replace with a LINQ function
            foreach (var employee in employees)
            {
                // And print details
                Console.WriteLine($"{employee.Name} is in department {employee.Department} and makes ${employee.Salary}");
            }
        }
    }
}