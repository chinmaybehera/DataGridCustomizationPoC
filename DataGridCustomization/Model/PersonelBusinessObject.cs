using System.Collections.Generic;
using DataGridCustomization.Data;
using System;
using System.Threading;

namespace DataGridCustomization.Model
{
    class PersonnelBusinessObject
    {


        public event EventHandler PeopleChanged;

        List<Person> People { get; set; }
        public string ReportTitle { get; set; }


        public PersonnelBusinessObject()
        {
            People = FakeDatabaseLayer.GetPersons();
        }



        public List<Person> GetEmployees()
        {
            return People;
        }

        public void AddPerson(Person person)
        {
            People.Add(person);
            OnPeopleChanged();
        }

        public void DeletePerson(Person person)
        {
            People.Remove(person);
            OnPeopleChanged();
        }

        public void UpdatePerson(Person person)
        {

        }

        void OnPeopleChanged()
        {
            if (PeopleChanged != null)
                PeopleChanged(this, null);
        }
    }
}
