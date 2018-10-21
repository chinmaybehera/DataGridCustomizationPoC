using System;
using System.ComponentModel;

namespace DataGridCustomization.Model
{
    public class Person : INotifyPropertyChanged
    {
        string _FirstName;
        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                if (_FirstName != value)
                {
                    _FirstName = value;
                    RaisePropertyChanged("FirstName");
                }
            }
        }

        string _LastName;
        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                if (_LastName != value)
                {
                    _LastName = value;
                    RaisePropertyChanged("LastName");
                }
            }
        }

        string _Gender;
        public string Gender
        {
            get
            {
                return _Gender;
            }
            set
            {
                if (_Gender != value)
                {
                    _Gender = value;
                    RaisePropertyChanged("Gender");
                }
            }
        }

        string _Address;
        public string Address
        {
            get
            {
                return _Address;
            }
            set
            {
                if (_Address != value)
                {
                    _Address = value;
                    RaisePropertyChanged("Address");
                }
            }
        }

        string _Phone;
        public string Phone
        {
            get
            {
                return _Phone;
            }
            set
            {
                if (_Phone != value)
                {
                    _Phone = value;
                    RaisePropertyChanged("Phone");
                }
            }
        }

        public double? Val_01_01 { get; set; }
        public double? Val_01_02 { get; set; }
        public double? Val_01_03 { get; set; }
        public double? Val_01_04 { get; set; }
        public double? Val_01_05 { get; set; }
        public double? Val_01_06 { get; set; }
        public double? Val_01_07 { get; set; }
        public double? Val_01_08 { get; set; }
        public double? Val_01_09 { get; set; }
        public double? Val_01_10 { get; set; }
        public double? Val_02_01 { get; set; }
        public double? Val_02_02 { get; set; }
        public double? Val_02_03 { get; set; }
        public double? Val_02_04 { get; set; }
        public double? Val_02_05 { get; set; }
        public double? Val_02_06 { get; set; }
        public double? Val_02_07 { get; set; }
        public double? Val_02_08 { get; set; }
        public double? Val_02_09 { get; set; }
        public double? Val_02_10 { get; set; }
        public double? Val_03_01 { get; set; }
        public double? Val_03_02 { get; set; }
        public double? Val_03_03 { get; set; }
        public double? Val_03_04 { get; set; }
        public double? Val_03_05 { get; set; }
        public double? Val_03_06 { get; set; }
        public double? Val_03_07 { get; set; }
        public double? Val_03_08 { get; set; }
        public double? Val_03_09 { get; set; }
        public double? Val_03_10 { get; set; }


        void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
