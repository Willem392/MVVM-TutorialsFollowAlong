using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_TechieSyed.Models
{
    public class EmployeeService
    {
        // Creates context to talk to database via entity framework and a local list of employeeDTOs
        MVVM_TechieSyedTutEntities ObjContext;
        private static ObservableCollection<EmployeeDTO> ObjEmployeesList;
        public EmployeeService()
        {
            ObjContext = new MVVM_TechieSyedTutEntities();
        }

        // Looks into the database and grabs all entries from the employee table then puts them into the local list
        public List<EmployeeDTO> GetAll()
        {
            List<EmployeeDTO> ObjEmployeesList = new List<EmployeeDTO>();
            try
            {
                var ObjQuery = from employee in ObjContext.Employees select employee;
                foreach(var employee in ObjQuery)
                {
                    ObjEmployeesList.Add(new EmployeeDTO { Id = employee.Id, Name = employee.Name, Age = employee.Age });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjEmployeesList;
        }

        // Adds an employee into the database after checking their age
        public bool Add(EmployeeDTO objNewEmployee)
        {
            bool IsAdded = false;
            if(objNewEmployee.Age < 21 || objNewEmployee.Age > 58)
            {
                throw new ArgumentException("Invalid age limit for employee");
            }
            try
            {
                var ObjEmployee = new Employee();
                ObjEmployee.Id = objNewEmployee.Id;
                ObjEmployee.Name = objNewEmployee.Name;
                ObjEmployee.Age = objNewEmployee.Age;

                ObjContext.Employees.Add(ObjEmployee);
                var NoOfRowsAffected = ObjContext.SaveChanges();
                IsAdded = NoOfRowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return IsAdded;
        }

        // Updates an employee
        public bool Update(EmployeeDTO objEmployeeToUpdate)
        {
            bool IsUpdated = false;
            try
            {
                var ObjEmployee = ObjContext.Employees.Find(objEmployeeToUpdate.Id);
                ObjEmployee.Name = objEmployeeToUpdate.Name;
                ObjEmployee.Age = objEmployeeToUpdate.Age;
                var NoOfRowsAffected = ObjContext.SaveChanges();
                IsUpdated = NoOfRowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return IsUpdated;
        }
        
        // Removes an employee from the database based on key search ID
        public bool Delete(int id)
        {
            bool IsDeleted = false;
            try
            {
                var ObjEmployeeToDelete = ObjContext.Employees.Find(id);
                ObjContext.Employees.Remove(ObjEmployeeToDelete);
                var NoOfRowsAffected = ObjContext.SaveChanges();
                IsDeleted = NoOfRowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return IsDeleted;
        }

        // Searches the table based on key search ID
        public EmployeeDTO Search(int id)
        {
            EmployeeDTO ObjEmployee = null;
            try
            {
                var ObjEmployeeToFind = ObjContext.Employees.Find(id);
                if (ObjEmployeeToFind != null)
                {
                    ObjEmployee = new EmployeeDTO { Id = ObjEmployeeToFind.Id, Name = ObjEmployeeToFind.Name, Age = ObjEmployeeToFind.Age };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjEmployee;
        }
    }
}
