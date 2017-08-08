using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;
using System.ComponentModel;

namespace First_WPF
{
      
    public class Image : INotifyPropertyChanged
    {
        private string ImageName;
        public string imageName
        {
            get { return ImageName; }
            set
            {
                ImageName = value;
                if(this.PropertyChanged !=null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("imageName"));
                }
            }
        }

        private string Account;
        public string account
        {
            get { return Account; }
            set
            {
                Account = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("account"));
                }
            }
        }

        private string Introduce;
        public string introduce
        {
            get { return Introduce; }
            set
            {
                Introduce = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("introduce"));
                }
            }
        }

        private string UploadTime;
        public string uploadTime
        {
            get { return UploadTime; }
            set
            {
                UploadTime = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("uploadTime"));
                }
            }
        }

        private string ImagePath;
        public string imagePath
        {
            get { return ImagePath; }
            set
            {
                ImagePath = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("imagePath"));
                }
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

      


    }
}
