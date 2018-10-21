using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataGridCustomization.Model;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Threading;
using DataGridCustomization.Helpers;
using System.Windows.Data;
using System.Windows.Input;

namespace DataGridCustomization.ViewModel
{
    class PersonManagementViewModel : ViewModelBase
    {
        PersonnelBusinessObject personnel; // The sealed business object (database layer, web service, etc)

        ObservableCollection<Person> _People;
        object _SelectedPerson;
        BindingGroup _UpdateBindingGroup;

        public ObservableCollection<Person> People
        {
            get
            {
                _People = new ObservableCollection<Person>(personnel.GetEmployees());
                return _People;
            }
        }

        public string ReportTitle
        {
            get
            {
                return personnel.ReportTitle;
            }
            set
            {
                if (personnel.ReportTitle != value)
                {
                    personnel.ReportTitle = value;
                    RaisePropertyChanged("ReportTitle");
                }
            }
        }

        public object SelectedPerson
        {
            get
            {
                return _SelectedPerson;
            }
            set
            {
                if (_SelectedPerson != value)
                {
                    _SelectedPerson = value;
                    RaisePropertyChanged("SelectedPerson");
                }
            }
        }

        public int SelectedIndex { get; set; }

        public BindingGroup UpdateBindingGroup
        {
            get
            {
                return _UpdateBindingGroup;
            }
            set
            {
                if (_UpdateBindingGroup != value)
                {
                    _UpdateBindingGroup = value;
                    RaisePropertyChanged("UpdateBindingGroup");
                }
            }
        }

        public RelayCommand CancelCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand AddUserCommand { get; set; }
        public RelayCommand DeleteUserCommand { get; set; }

        public RelayCommand CurrentCellChangedCommand { get; set; }

        public PersonManagementViewModel()
        {
            personnel = new PersonnelBusinessObject();
            personnel.PeopleChanged += new EventHandler(personnel_PeopleChanged);

            CancelCommand = new RelayCommand(DoCancel);
            SaveCommand = new RelayCommand(DoSave);
            AddUserCommand = new RelayCommand(AddUser);
            DeleteUserCommand = new RelayCommand(DeleteUser);

            CurrentCellChangedCommand = new RelayCommand(DoCurrentCellChanged);

            UpdateBindingGroup = new BindingGroup { Name = "Group1" };
        }

        void personnel_PeopleChanged(object sender, EventArgs e)
        {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
                {
                    RaisePropertyChanged("People");
                }));
        }

        void DoCancel(object param)
        {
            UpdateBindingGroup.CancelEdit();
            // if (SelectedIndex == -1)    //This only closes if new - just to show you how CancelEdit returns old values to bindings
            SelectedPerson = null;
        }

        void DoSave(object param)
        {
            UpdateBindingGroup.CommitEdit();
            var person = SelectedPerson as Person;
            if (SelectedIndex == -1)
            {
                personnel.AddPerson(person);
                RaisePropertyChanged("People"); // Update the list from the data source
            }
            else
                personnel.UpdatePerson(person);

            SelectedPerson = null;
        }

        void AddUser(object parameter)
        {
            SelectedPerson = null; // Unselects last selection. Essential, as assignment below won't clear other control's SelectedItems
            var person = new Person();
            SelectedPerson = person;
        }

        void DeleteUser(object parameter)
        {
            var person = SelectedPerson as Person;
            if (SelectedIndex != -1)
            {
                personnel.DeletePerson(person);
                RaisePropertyChanged("People"); // Update the list from the data source
            }
            else
                SelectedPerson = null; // Simply discard the new object
        }

        void DoCurrentCellChanged(object param)
        {
            
        }


    }
}