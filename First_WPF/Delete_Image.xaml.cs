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
    /// Delete_Image.xaml 的交互逻辑
    /// </summary>
    public partial class Delete_Image : Window
    {
        MysqlConnent mysqlConnent = new MysqlConnent();
        string imageName = "";
        public Delete_Image(string tmp)
        {
            this.Topmost = true;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            imageName = tmp;
            InitializeComponent();
        }

        private void yes_Click(object sender, RoutedEventArgs e)
        {
            mysqlConnent.MySqlWrite("UPDATE 图片表 SET IsCheck = '-1' WHERE ImageName ='" + imageName + "'");
            this.DialogResult = true;
     
        }

        private void no_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
           
        }
    }
}
