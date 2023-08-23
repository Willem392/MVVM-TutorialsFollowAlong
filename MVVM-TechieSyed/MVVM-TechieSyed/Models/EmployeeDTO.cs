using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace MVVM_TechieSyed.Models
{

    // Sets up the original class to store employee's, contains Id, Name, and Age along with it's getters and setters
    // Important to note that this inherits from INotifyPropertyChanged, which allows us to update DTO's as soon as a property gets changed
    public class EmployeeDTO : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged("Id"); }
        }
        
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }

        private int age;
        public int Age
        {
            get { return age; }
            set { age = value; OnPropertyChanged("Age"); }
        }

    }
}
