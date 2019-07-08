using AppXamarin.Models.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AppXamarin.ViewModels.UserViewModels
{
    public class UserViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ApplicationUser user { get; set; }


        public int Id
        {
            get { return user.Id; }
            set
            {
                if (user.Id != value)
                {
                    user.Id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        public string UserName
        {
            get { return user.UserName; }
            set
            {
                if (user.UserName != value) 
                {
                    user.UserName = value;
                    OnPropertyChanged("UserName");
                }
            }
        }


        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
