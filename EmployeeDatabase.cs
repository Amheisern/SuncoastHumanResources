using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace SuncoastHumanResources
{
    class EmployeeDatabase
    {
        // Keep a *private* copy of the employee list.
        //
        // We make this private since we don't want code from
        // outside this class to have access to it. All access
        // to this information comes through the methods of the
        // class.
        private List<Employee> Employees { get; set; } = new List<Employee>();

        private string FileName = "employees.csv";
        public void LoadEmployees()
        {
            if (File.Exists(FileName))
            {
                var fileReader = new StreamReader(FileName);

                var csvReader = new CsvReader(fileReader, CultureInfo.InvariantCulture);

                // Replace our BLANK list of employees with the ones that are in the CSV file
                Employees = csvReader.GetRecords<Employee>().ToList();

                fileReader.Close();
            }
        }

        public void SaveEmployees()
        {
            var fileWriter = new StreamWriter(FileName);

            var csvWriter = new CsvWriter(fileWriter, CultureInfo.InvariantCulture);

            csvWriter.WriteRecords(Employees);

            fileWriter.Close();
        }
        // Get a list of all the employees
        public List<Employee> GetAllEmployees()
        {
            return Employees;
        }

        // Get a list of all the employees
        public void AddEmployee(Employee newEmployee)
        {
            Employees.Add(newEmployee);
        }

        // Given a name as a string, look through the list of
        // employees. If we find one with a matching name, return
        // the employee. If nothing is found, return a null.
        public Employee FindOneEmployee(string name)
        {
            // to null which will indicate no match found
            Employee foundEmployee = Employees.FirstOrDefault(employee => employee.Name.ToUpper().Contains(name.ToUpper()));
            return foundEmployee;
        }
        // method for removing a employee from the list
        public void RemoveEmployee(Employee employee)
        {
            Employees.Remove(employee);

        }


    }
}