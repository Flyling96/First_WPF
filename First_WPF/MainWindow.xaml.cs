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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace First_WPF
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

             //SetSource(image, "/image/login.png");
             image.Source = new BitmapImage(new Uri(@"/image/login.png", UriKind.Relative));
             //MessageBox.Show("账号或密码错误");
        }


        private void button_Click(object sender, RoutedEventArgs e)
        {
            string account = textBox.Text;
            string password = passwordBox.Password;
            MysqlConnent mysqlConnent = new MysqlConnent();
            string isTrue = mysqlConnent.MySqlHasRows("SELECT * FROM 管理员账号表 WHERE CheckAccount ='" + account + "' AND CheckPassword ='" + password + "'");
            if (isTrue == "true")
            {
                ListWindows tmp = new ListWindows();
                tmp.Show();
            this.Close();
            }
            else
            {
                MessageBox.Show("账号或密码错误");
            }
        }
    }
}
