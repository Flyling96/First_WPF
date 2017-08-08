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
    /// ListViewUserControl.xaml 的交互逻辑
    /// </summary>
    public partial class ListViewUserControl : UserControl
    {
        // public List<Image> ImageList { get; set; }

        List<Image> ImageList = new List<Image>();
        List<Comment> CommentList = new List<Comment>();
        int viewNum = 0;
        public ListViewUserControl()
        {
            viewNum = 0;
            InitializeComponent();
            //List<Image> ImageList = new List<Image>();
            ImageList = GetImage();
            this.DataContext = ImageList;

            //Binding imageListBd = new Binding();
            //imageListBd.Source = this.ImageList;

        }

        private  void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (viewNum == 0)
                {
                    Image tmp = lv.SelectedItem as Image;
                    Delete_Image window = new Delete_Image(tmp.imageName);
                    if (window.ShowDialog().Value == true)
                    {
                        ImageList.Remove(tmp);
                    }
                }
                else
                {
                    Comment tmp = lv.SelectedItem as Comment;
                    Delete_Comment window = new Delete_Comment(tmp.commentID);
                    if (window.ShowDialog().Value == true)
                    {
                        CommentList.Remove(tmp);
                    }
                }
                
                lv.Items.Refresh();
            }
            catch(Exception E)
            {
                Debug.WriteLine(E.ToString());
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MysqlConnent mysqlConnent = new MysqlConnent();
            if (viewNum == 0)
            {
                foreach (Image item in ImageList)
                {
                    mysqlConnent.MySqlReadCount("UPDATE 图片表 SET IsCheck = '1' WHERE ImageName = '" + item.imageName + "'");
                }
                ImageList.Clear();
            }
            else
            {
                foreach (Comment item in CommentList)
                {
                    mysqlConnent.MySqlReadCount("UPDATE 评论表 SET IsCheck = '1' WHERE CommentID = '" + item.commentID + "'");
                }
                CommentList.Clear();
            }
            lv.Items.Refresh();
        }


        private List<Image> GetImage()
        {
            List<Image> tmpList = new List<Image>();
            try
            {
                MysqlConnent mysqlConnent = new MysqlConnent();

                int count = mysqlConnent.MySqlReadCount("SELECT COUNT(*) FROM 图片表 WHERE IsCheck = '0' AND IsPublic = '1'");
                Debug.WriteLine(count);
                List<string> account = new List<string>();
                List<string> imageName = new List<string>();
                List<string> introduce = new List<string>();
                List<string> uploadTime = new List<string>();
                account = mysqlConnent.MySqlRead("SELECT * FROM 图片表 WHERE IsCheck = '0' AND IsPublic = '1' ORDER BY uploadtime DESC", "account");
                imageName = mysqlConnent.MySqlRead("SELECT * FROM 图片表 WHERE IsCheck = '0' AND IsPublic = '1' ORDER BY uploadtime DESC", "imageName");
                introduce = mysqlConnent.MySqlRead("SELECT * FROM 图片表 WHERE IsCheck = '0' AND IsPublic = '1' ORDER BY uploadtime DESC", "introduce");
                uploadTime = mysqlConnent.MySqlRead("SELECT * FROM 图片表 WHERE IsCheck = '0' AND IsPublic = '1' ORDER BY uploadtime DESC", "uploadTime");
                for (int i = 0; i < count; i++)
                {
                    Image tmp = new Image();
                    tmp.account = account[i];
                    tmp.imageName = imageName[i];
                    tmp.introduce = introduce[i];
                    tmp.uploadTime = uploadTime[i];
                    tmp.imagePath = "C:/Users/Administrator/Desktop/test3/Image/" + imageName[i] + ".jpg";
                    //tmp.imagePath = "D:/Image/" + imageName[i] + ".jpg";
                    tmpList.Add(tmp);
                }
                return tmpList;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                tmpList = null;
                return tmpList;
            }
        }

        private List<Comment> GetComment()
        {
            List<Comment> tmpList = new List<Comment>();
            try
            {
                MysqlConnent mysqlConnent = new MysqlConnent();

                int count = mysqlConnent.MySqlReadCount("SELECT COUNT(*) FROM 评论表 WHERE IsCheck = '0'");
                Debug.WriteLine(count);
                List<string> account = new List<string>();
                List<string> comment = new List<string>();
                List<string> dateTime = new List<string>();
                List<string> commentID = new List<string>();
                account = mysqlConnent.MySqlRead("SELECT * FROM 评论表 WHERE IsCheck = '0'  ORDER BY DateTime DESC", "account");
                comment = mysqlConnent.MySqlRead("SELECT * FROM 评论表 WHERE IsCheck = '0' ORDER BY DateTime DESC", "comment");
                dateTime = mysqlConnent.MySqlRead("SELECT * FROM 评论表 WHERE IsCheck = '0'  ORDER BY DateTime DESC", "dateTime");
                commentID = mysqlConnent.MySqlRead("SELECT * FROM 评论表 WHERE IsCheck = '0'  ORDER BY DateTime DESC", "commentID");
                for (int i = 0; i < count; i++)
                {
                    Comment tmp = new Comment();
                    tmp.account = account[i];
                    tmp.commentText = comment[i];
                    tmp.dateTime = dateTime[i];
                    tmp.commentID = commentID[i];
                    tmpList.Add(tmp);
                }
                return tmpList;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                tmpList = null;
                return tmpList;
            }
        }



        private void imageButton_Click(object sender, RoutedEventArgs e)
        {
            viewNum = 0;
            var view = (GridView)this.FindResource("View0");
            ImageList = GetImage();
            this.DataContext = ImageList;
            this.lv.View = view;
        }

        private void commentButton_Click(object sender, RoutedEventArgs e)
        {
            viewNum = 1;
            var view = (GridView)this.FindResource("View1");
            CommentList = GetComment();
            this.DataContext = CommentList;
            this.lv.View = view;
        }


    }
}
