using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVM_TechieSyed.Models;
using MVVM_TechieSyed.Commands;
using System.ComponentModel;
using System.Collections.ObjectModel;
namespace MVVM_TechieSyed.ViewModels
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        // Implements the methods needed when inheriting INotifyPropertyChanged
        #region INotifyPropertyChanged_Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        // Constructor that instantiates all four commands, loads the table, and creates a new Employee Service
        EmployeeService ObjEmployeeService;
        public EmployeeViewModel()
        {
            ObjEmployeeService = new EmployeeService();
            LoadData();
            CurrentEmployee = new EmployeeDTO();
            saveCommand = new RelayCommand(Save);
            searchCommand = new RelayCommand(Search);
            updateCommand = new RelayCommand(Update);
            deleteCommand = new RelayCommand(Delete);
        }

        #region DisplayOperation
        
        // Employees list property
        private List<EmployeeDTO> employeesList;
        public List<EmployeeDTO> EmployeesList
        {
            get { return employeesList; }
            set { employeesList = value; OnPropertyChanged("EmployeesList"); }
        }
        
        private void LoadData()
        {
            EmployeesList = ObjEmployeeService.GetAll();
        }
        #endregion

        // Current employee property used for making edits of one employee at a time
        private EmployeeDTO currentEmployee;
        public EmployeeDTO CurrentEmployee
        {
            get { return currentEmployee; }
            set { currentEmployee = value; OnPropertyChanged("CurrentEmployee"); }
        }

        // Message property used to display messages after each of the commands execute
        private string message;
        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }

        // Save command which add's a new employee to the database
        private RelayCommand saveCommand;
        public RelayCommand SaveCommand
        {
            get { return saveCommand; }
        }
        public void Save()
        {
            try
            {
                var IsSaved = ObjEmployeeService.Add(currentEmployee);
                LoadData();
                if(IsSaved == true)
                {
                    Message = "Employee saved";
                } else
                {
                    Message = "Save Operation Failed";
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }

        // Search Command which looks through the database based on a given Id
        private RelayCommand searchCommand;
        public RelayCommand SearchCommand
        {
            get { return searchCommand; }
        }

        public void Search()
        {
            try
            {
                var ObjEmployee = ObjEmployeeService.Search(currentEmployee.Id);
                if (ObjEmployee != null)
                {
                    CurrentEmployee.Name = ObjEmployee.Name;
                    CurrentEmployee.Age = ObjEmployee.Age;
                    Message = "Found";
                }
                else
                {
                    Message = "Not Found";
                }
            }
            catch(Exception ex)
            {
                message = ex.Message;
            }
            LoadData();
        }

        // Update command to edit an employee based on the given ID
        private RelayCommand updateCommand;
        public RelayCommand UpdateCommand
        {
            get { return updateCommand; }
        }
        public void Update()
        {
            try
            {
                var ObjEmployee = ObjEmployeeService.Update(CurrentEmployee);
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            LoadData();
        }

        // Delete command which removes an employee from the database determined by their ID
        private RelayCommand deleteCommand;
        public RelayCommand DeleteCommand
        {
            get { return deleteCommand; }
        }
        public void Delete()
        {
            try
            {
                var IsDeleted = ObjEmployeeService.Delete(CurrentEmployee.Id);
                if(IsDeleted == true)
                {
                    Message = "Deleted";
                } else
                {
                    Message = "Not Deleted";
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            LoadData();
        }
    }
}