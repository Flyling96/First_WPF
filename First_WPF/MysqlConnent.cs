using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Drawing.Imaging;
using System.Drawing;
using System.Net;
using System.IO;
using System.Threading;
using MySql.Data.MySqlClient;
using System;
using System.Diagnostics;

namespace First_WPF
{
    public class MysqlConnent
    {

        string Conn = "Database='travel_picture';Data Source='localhost';User Id='root';Password='960513';charset='utf8';pooling=true;Allow Zero Datetime=True";


        public string NewID()
        {
            string tmptime = DateTime.Now.ToLocalTime().ToString("yyyyMMddHHmmssfff");
            Random tmprandom = new Random();
            int RandomNumber = tmprandom.Next(10, 99);
            tmptime = tmptime.Substring(2, tmptime.Length - 2) + RandomNumber.ToString();
            return tmptime;
        }
        /// <summary>
        /// 对数据库进行写，删操作
        /// </summary>
        /// <param name="ClientSocket"></param>
        /// <param name="str_sql"></param>
        /// <param name="ReturnNumber"></param>
        public bool MySqlWrite(string str_sql)
        {
            MySqlConnection con = new MySqlConnection(Conn);
            con.Open();
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(str_sql, con))
                {
                    cmd.ExecuteNonQuery();

                }
                con.Dispose();
                con.Close();
                return true;
            }
            catch (Exception e)
            {
                con.Dispose();
                con.Close();
                Debug.WriteLine(12);
                Debug.WriteLine(e.ToString());
                return false;
            }


        }
        /// <summary>
        /// 查看数据库中是否拥有
        /// </summary>
        /// <param name="str_sql"></param>
        /// <returns></returns>
        public string MySqlHasRows(string str_sql)
        {
            MySqlConnection con = new MySqlConnection(Conn);
            MySqlDataReader tmp;
            con.Open();
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(str_sql, con))
                {
                    cmd.ExecuteNonQuery();
                    tmp = cmd.ExecuteReader();
                    if (tmp.HasRows)
                    {
                        return "true";
                    }
                    else
                    {
                        return "false";
                    }
                }

            }
            catch (Exception e)
            {
                con.Dispose();
                con.Close();
                return "false";
            }

        }

        /// <summary>
        /// 返回数据条数
        /// </summary>
        /// <param name="ClientSocket"></param>
        /// <param name="str_sql"></param>
        /// <param name="ReturnNumber"></param>
        /// <returns></returns>
        public int MySqlReadCount(string str_sql)
        {
            MySqlConnection con = new MySqlConnection(Conn);
            MySqlDataReader tmp;
            int ReturnCount = 0;
            con.Open();
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(str_sql, con))
                {
                    cmd.ExecuteNonQuery();
                    ReturnCount = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Dispose();
                    con.Close();
                    return ReturnCount;


                }
            }
            catch (Exception e)
            {
                con.Dispose();
                con.Close();
                Debug.WriteLine(14);
                Debug.WriteLine(e.ToString());
                return 0;
            }
        }


        /// <summary>
        /// 中途对数据库进行查找
        /// </summary>
        /// <param name="ClientSocket"></param>
        /// <param name="str_sql"></param>
        /// <param name="ReturnNumber"></param>
        /// <param name="tmp1"></param>
        /// <returns></returns>
        public string MySqlReadReturn(string str_sql, string tmp1)
        {
            MySqlConnection con = new MySqlConnection(Conn);
            MySqlDataReader tmp;
            con.Open();
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(str_sql, con))
                {
                    cmd.ExecuteNonQuery();
                    tmp = cmd.ExecuteReader();
                    if (tmp.HasRows)
                    {
                        tmp.Read();
                        string ReturnString = tmp[tmp1].ToString();
                        con.Dispose();
                        con.Close();
                        return ReturnString;
                    }
                    else
                    {
                        con.Dispose();
                        con.Close();
                        return null;
                    }
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine(19);
                Debug.WriteLine(e.ToString());
                con.Dispose();
                con.Close();

                return "error";
            }



        }

        /// <summary>
        /// 读取多条数据
        /// </summary>
        /// <param name="str_sql"></param>
        /// <param name="tmp1"></param>
        /// <returns></returns>
        public List<string> MySqlRead(string str_sql, string tmp1)
        {
            List<string> returnList = new List<string>();
            MySqlConnection con = new MySqlConnection(Conn);
            MySqlDataReader tmp;
            con.Open();
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(str_sql, con))
                {
                    cmd.ExecuteNonQuery();
                    tmp = cmd.ExecuteReader();
                    if (tmp.HasRows)
                    {
                        while (tmp.Read())
                        {
                            returnList.Add(tmp[tmp1].ToString());
                        }

                        con.Dispose();
                        con.Close();
                        return returnList;
                    }
                    else
                    {
                        con.Dispose();
                        con.Close();
                        returnList.Add("null");
                        return returnList;
                    }
                }

            }
            catch (MySqlException e)
            {
                Debug.WriteLine(19);
                Debug.WriteLine(e.ToString());
                con.Dispose();
                con.Close();
                returnList.Add("error");
                return returnList;
            }
        }

        /// <summary>
        /// 读取字典
        /// </summary>
        /// <param name="str_sql"></param>
        /// <param name="tmp1"></param>
        /// <returns></returns>
        public List<Dictionary<string, string>> MySqlReadDictionary(string str_sql, Dictionary<string, string> tmp1)
        {
            List<Dictionary<string, string>> returnList = new List<Dictionary<string, string>>();
            MySqlConnection con = new MySqlConnection(Conn);
            MySqlDataReader tmp;
            con.Open();
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(str_sql, con))
                {
                    cmd.ExecuteNonQuery();
                    tmp = cmd.ExecuteReader();
                    if (tmp.HasRows)
                    {
                        while (tmp.Read())
                        {
                            Dictionary<string, string> tmpDictionary = new Dictionary<string, string>();
                            foreach (string key in tmp1.Keys)
                            {
                                tmpDictionary.Add(key, tmp[key].ToString());
                            }

                            returnList.Add(tmpDictionary);
                        }

                        con.Dispose();
                        con.Close();
                        return returnList;
                    }
                    else
                    {
                        con.Dispose();
                        con.Close();
                        return null;
                    }
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine(19);
                Debug.WriteLine(e.ToString());
                con.Dispose();
                con.Close();
                returnList[0]["error"] = "error";
                return null;
            }
        }




    }
}
