using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace trainServer
{
    class DB
    {
        private String mysqlcon =
            "database=train;Password=123456;User ID=root;server=127.0.0.1";
        private MySqlConnection conn;
        private MySqlCommand cmd;

        public DB()
        {
            try
            {
                conn = new MySqlConnection(mysqlcon);
                conn.Open();
                cmd = conn.CreateCommand();
                Console.WriteLine("连接数据库成功");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        //注册
        public void regesterTrain(int trainid, String ipa, int groupid)
        {
            try
            {
                cmd.CommandText = "INSERT INTO locomt values(" + trainid + ",'" + ipa + "'," + groupid + ")";
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        //注销
        public void unregesterTrain(int trainid)
        {
            try
            {
                cmd.CommandText = "DELETE FROM locogroup WHERE locoid=" + trainid;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        //更新编组表
        public void updateGroup(int groupid, int locoid, int master, int loconum)
        {
            cmd.CommandText = "INSERT INTO locogroup values(" + groupid + "," + locoid + "," + master + "," + loconum + ")";
            cmd.ExecuteNonQuery();
        }
        //判断是否有主车
        public Boolean hasMaster()
        {
            try
            {
                cmd.CommandText = "SELECT * FROM locogroup";
                MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adap.Fill(ds);
                int count = ds.Tables[0].Rows.Count;
                return count == 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
