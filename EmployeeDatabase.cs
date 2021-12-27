using System.Collections.Generic;
using System.Linq;

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
        private List<Employee> employees = new List<Employee>();
        public void LoadEmployees()
        {

        }

        public void SaveEmployees()
        {

        }
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
            Employee foundEmployee = employees.FirstOrDefault(employee => employee.Name.ToUpper().Contains(name.ToUpper()));
            return foundEmployee;
        }
        // method for removing a employee from the list
        public void RemoveEmployee(Employee employee)
        {
            employees.Remove(employee);

        }


    }
}