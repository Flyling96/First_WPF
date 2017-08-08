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
    class Comment : INotifyPropertyChanged
    {
        private string CommentID;
        public string commentID
        {
            get { return CommentID; }
            set
            {
                CommentID = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("commentID"));
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

        private string CommentText;
        public string commentText
        {
            get { return CommentText; }
            set
            {
                CommentText = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("commentText"));
                }
            }
        }

        private string DateTime;
        public string dateTime
        {
            get { return DateTime; }
            set
            {
                DateTime = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("dateTime"));
                }
            }
        }




        public event PropertyChangedEventHandler PropertyChanged;




    }
}
