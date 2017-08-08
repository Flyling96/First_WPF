using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace First_WPF
{
    /// <summary>
    /// Delete_Comment.xaml 的交互逻辑
    /// </summary>
    public partial class Delete_Comment : Window
    {
    
        MysqlConnent mysqlConnent = new MysqlConnent();
        string commentID = "";
        public Delete_Comment(string tmp)
        {
            this.Topmost = true;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            commentID = tmp;
            InitializeComponent();
        }

        private void yes_Click(object sender, RoutedEventArgs e)
        {
            mysqlConnent.MySqlWrite("UPDATE 评论表 SET IsCheck = '-1' WHERE CommentID ='" + commentID + "'");
            this.DialogResult = true;

        }

        private void no_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;

        }
    }
}
