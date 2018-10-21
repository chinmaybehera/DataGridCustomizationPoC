using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using DataGridCustomization.Model;

namespace DataGridCustomization.Data
{
    class FakeDatabaseLayer
    {
        public static List<Person> GetPersons()
        {
            return new List<Person>
            {
                new Person { FirstName="Chinmay", LastName="Behera", Gender="Male", Address = "Bhubaneswar, OD", Phone="97XXX50XX5",
                    Val_01_01 = 10.23, Val_01_02 = 11.23, Val_01_03 = 12.23, Val_01_04 = 13.23, Val_01_05 = 14.23, Val_01_06 = 15.23, Val_01_07 = 16.23, Val_01_08 = 17.23, Val_01_09 = 18.23, Val_01_10 = 19.23,
                    Val_02_01 = 10.23   ,   Val_02_02 = 11.23   ,   Val_02_03 = 12.23   ,   Val_02_04 = 13.23   ,   Val_02_05 = 14.23   ,   Val_02_06 = 15.23   ,   Val_02_07 = 16.23   ,   Val_02_08 = 17.23   ,   Val_02_09 = 18.23   ,   Val_02_10 = 19.23,
                    Val_03_01 = 10.23   ,   Val_03_02 = 11.23   ,   Val_03_03 = 12.23   ,   Val_03_04 = 13.23   ,   Val_03_05 = 14.23   ,   Val_03_06 = 15.23   ,   Val_03_07 = 16.23   ,   Val_03_08 = 17.23   ,   Val_03_09 = 18.23   ,   Val_03_10 = 19.23

                },
                new Person { FirstName="Roydon", LastName="P", Gender="Male", Address = "Virar, MH", Phone="97XXX20XX5",
                       Val_01_01 = 10.23, Val_01_02 = 11.23, Val_01_03 = 12.23, Val_01_04 = 13.23, Val_01_05 = 14.23, Val_01_06 = 15.23, Val_01_07 = 16.23, Val_01_08 = 17.23, Val_01_09 = 18.23, Val_01_10 = 19.23,
                    Val_02_01 = 10.23   ,   Val_02_02 = 11.23   ,   Val_02_03 = 12.23   ,   Val_02_04 = 13.23   ,   Val_02_05 = 14.23   ,   Val_02_06 = 15.23   ,   Val_02_07 = 16.23   ,   Val_02_08 = 17.23   ,   Val_02_09 = 18.23   ,   Val_02_10 = 19.23,
                    Val_03_01 = 10.23   ,   Val_03_02 = 11.23   ,   Val_03_03 = 12.23   ,   Val_03_04 = 13.23   ,   Val_03_05 = 14.23   ,   Val_03_06 = 15.23   ,   Val_03_07 = 16.23   ,   Val_03_08 = 17.23   ,   Val_03_09 = 18.23   ,   Val_03_10 = 19.23
},
                new Person { FirstName="Deeksha", LastName="Aswal", Gender="Female", Address = "Powai, MH", Phone="97XXX11XX5",
                Val_01_01 = 10.23, Val_01_02 = 11.23, Val_01_03 = 12.23, Val_01_04 = 13.23, Val_01_05 = 14.23, Val_01_06 = 15.23, Val_01_07 = 16.23, Val_01_08 = 17.23, Val_01_09 = 18.23, Val_01_10 = 19.23},
                new Person { FirstName="Santosh", LastName="Bugade", Gender="Male", Address = "Madgaon, GA", Phone="97XXX34XX5",
                       Val_01_01 = 10.23, Val_01_02 = 11.23, Val_01_03 = 12.23, Val_01_04 = 13.23, Val_01_05 = 14.23, Val_01_06 = 15.23, Val_01_07 = 16.23, Val_01_08 = 17.23, Val_01_09 = 18.23, Val_01_10 = 19.23,
                    Val_02_01 = 10.23   ,   Val_02_02 = 11.23   ,   Val_02_03 = 12.23   ,   Val_02_04 = 13.23   ,   Val_02_05 = 14.23   ,   Val_02_06 = 15.23   ,   Val_02_07 = 16.23   ,   Val_02_08 = 17.23   ,   Val_02_09 = 18.23   ,   Val_02_10 = 19.23,
                    Val_03_01 = 10.23   ,   Val_03_02 = 11.23   ,   Val_03_03 = 12.23   ,   Val_03_04 = 13.23   ,   Val_03_05 = 14.23   ,   Val_03_06 = 15.23   ,   Val_03_07 = 16.23   ,   Val_03_08 = 17.23   ,   Val_03_09 = 18.23   ,   Val_03_10 = 19.23
},
                new Person { FirstName="Divya", LastName="Maloo", Gender="Female", Address = "Ujjain, MP", Phone="97XXX12XX5"},
            };
        }
    }
}
