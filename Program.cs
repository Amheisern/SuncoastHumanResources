﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SuncoastHumanResources
{
    class Employee
    {
        public string Name { get; set; }
        public int Department { get; set; }
        public int Salary { get; set; }
        public int MonthlySalary()
        {
            return Salary / 12;
        }
    }

    class EmployeeDatabase
    {
        // Keep a *private* copy of the employee list.
        //
        // We make this private since we don't want code from
        // outside this class to have access to it. All access
        // to this information comes through the methods of the
        // class.
        private List<Employee> employees = new List<Employee>();

        // Get a list of all the employees
        public List<Employee> GetAllEmployees()
        {
            return employees;
        }

        // Get a list of all the employees
        public void AddEmployee(Employee newEmployee)
        {
            employees.Add(newEmployee);
        }

        // Given a name as a string, look through the list of
        // employees. If we find one with a matching name, return
        // the employee. If nothing is found, return a null.
        public Employee FindOneEmployee(string name)
        {
            // to null which will indicate no match found
            Employee foundEmployee = employees.FirstOrDefault(employee => employee.Name == name);
            return foundEmployee;
        }
        // method for removing a employee from the list
        public void RemoveEmployee(Employee employee)
        {
            employees.Remove(employee);

        }


    }
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
                Console.WriteLine("What do you what to do?\n(A)dd an employee\n(S)how all the employees\n(F)ind an employee\n(D)elete an employee(Q)uit: ");
                var choice = Console.ReadLine().ToUpper();

                if (choice == "Q")
                {
                    // They said quit, so set our keepGoing to false
                    keepGoing = false;
                }
                else if (choice == "D")
                {
                    //take input from user get employee name
                    var name = PromptForString("What name are you looking for: ");
                    //search the database to see if they exist
                    //Employee foundEmployee = employees.FirstOrDefault(employee => employee.Name == name);
                    Employee foundEmployee = database.FindOneEmployee(name);
                    //if we found an employee 
                    if (foundEmployee != null)
                    {
                        //display employee
                        Console.WriteLine($"Found! {foundEmployee.Name} is in department {foundEmployee.Department} and makes ${foundEmployee.Salary}");
                        //Ask to confirm
                        var confirm = PromptForString("Please confirm that this is the name that you want to delete. [Y/N]").ToUpper();
                        if (confirm == "N")
                        {
                            //if they say (N)o do nother

                        }
                        else
                        {
                            //if confirmed (Y)es delete employee
                            database.RemoveEmployee(foundEmployee);
                            //employees.Remove(foundEmployee);
                        }

                    }

                    else
                    {
                        //Show if no results have been found in search
                        Console.WriteLine("No such employee!");
                    }


                    //otherwise 

                }
                else if (choice == "F")
                {
                    // Ask for the name of an employee
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
                else if (choice == "S")
                {
                    var employees = database.GetAllEmployees();
                    // Loop through each employee: Could replace with a LINQ function
                    foreach (var employee in employees)
                    {
                        // And print details
                        Console.WriteLine($"{employee.Name} is in department {employee.Department} and makes ${employee.Salary}");
                    }

                }
                else
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
                // end of the `while` statement

            }
        }
    }
}