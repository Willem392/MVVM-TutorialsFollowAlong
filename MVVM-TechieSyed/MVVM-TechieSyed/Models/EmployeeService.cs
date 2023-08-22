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
        private static ObservableCollection<Employee> ObjEmployeesList;
        public EmployeeService()
        {
            ObjEmployeesList = new ObservableCollection<Employee>()
            {
                new Employee{Id = 101, Name = "Will", Age = 22}
            };
        }
        public ObservableCollection<Employee> GetAll()
        {
            return ObjEmployeesList;
        }
        public bool Add(Employee objNewEmployee)
        {
            // Age must be between 21 and 58
            if(objNewEmployee.Age < 21 || objNewEmployee.Age > 58)
            {
                throw new ArgumentException("Invalid age limit for employee");
            }
            ObjEmployeesList.Add(objNewEmployee);
            return true;
        }

        public bool Update(Employee objEmployeeToUpdate)
        {
            bool IsUpdated = false;
            foreach (Employee objEmployee in ObjEmployeesList)
            {
                if (objEmployee.Id == objEmployeeToUpdate.Id)
                {
                    objEmployee.Age = objEmployeeToUpdate.Age;
                    objEmployee.Name = objEmployeeToUpdate.Name;
                    IsUpdated = true;
                    break;
                }
            }
            return IsUpdated;
        }

        public bool Delete(int id)
        {
            bool IsDeleted = false;
            foreach (Employee objEmployee in ObjEmployeesList)
            {
                if (objEmployee.Id == id)
                {
                    ObjEmployeesList.Remove(objEmployee);
                    IsDeleted = true;
                    break;
                }
            }
            return IsDeleted;
        }

        public Employee Search(int id)
        {
            return ObjEmployeesList.FirstOrDefault(e=>e.Id==id);
        }
    }
}
