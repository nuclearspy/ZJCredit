﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;

namespace ZJCredit
{
    public class MySqlHelper
    {
        private string _dbServer = "127.0.0.1";
        private string _dbName = "zhanxian";
        private string _dbUserName = "root";
        private string _dbPassWord = "root";

        /// <summary>
        /// 无参数的构造函数
        /// </summary>
        public MySqlHelper()
        {
        }

        /// <summary>
        /// 设置参数的构造函数
        /// </summary>
        /// <param name="dbServer"></param>
        /// <param name="dbName"></param>
        /// <param name="dbUserName"></param>
        /// <param name="dbPassWord"></param>
        public MySqlHelper(string dbServer, string dbName, string dbUserName, string dbPassWord)
        {
            this._dbServer = dbServer;
            this._dbName = dbName;
            this._dbUserName = dbUserName;
            this._dbPassWord = dbPassWord;
        }

        /// <summary>
        /// InitParameter
        /// </summary>
        /// <param name="dbServer"></param>
        /// <param name="dbName"></param>
        /// <param name="dbUserName"></param>
        /// <param name="dbPassWord"></param>
        public void InitParameter(string dbServer, string dbName, string dbUserName, string dbPassWord)
        {
            this._dbServer = dbServer;
            this._dbName = dbName;
            this._dbUserName = dbUserName;
            this._dbPassWord = dbPassWord;
        }

        /// <summary>
        /// GetMySqlConnection
        /// </summary>
        /// <returns></returns>
        public MySqlConnection GetMySqlConnection()
        {
            string conn = $"server={_dbServer};database={_dbName};Uid={_dbUserName};Pwd={_dbPassWord}";
            var mySqlConnection = new MySqlConnection(conn);
            return mySqlConnection;
        }

        /// <summary>
        /// GetMySqlCommand
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="mySqlConnection"></param>
        /// <returns></returns>
        public MySqlCommand GetMySqlCommand(string sql, MySqlConnection mySqlConnection)
        {
            var mySqlCommand = new MySqlCommand(sql, mySqlConnection);
            return mySqlCommand;
        }



        /// <summary>
        /// GetSelectResult
        /// </summary>
        /// <param name="mySqlCommand"></param>
        public MySqlDataReader GetSelectReader(MySqlCommand mySqlCommand)
        {
            var reader = mySqlCommand.ExecuteReader();
            return reader;
        }

        /// <summary>
        /// GetSelectDataTable
        /// </summary>
        /// <param name="mySqlCommand"></param>
        /// <returns></returns>
        public DataTable GetSelectDataTable(MySqlCommand mySqlCommand)
        {
            //得到reader对象
            var reader = GetSelectReader(mySqlCommand);
            var dataTable = new DataTable();
            dataTable.Load(reader);
            return dataTable;
        }

        /// <summary>
        /// GetSelectDic
        /// </summary>
        /// <param name="mySqlCommand"></param>
        /// <returns></returns>
        public Dictionary<string, List<object>> GetSelectDic(MySqlCommand mySqlCommand)
        {
            var dataTable = GetSelectDataTable(mySqlCommand);
            var dic = new Dictionary<string, List<object>>();
            var columns = dataTable.Columns;
            var countColumns = columns.Count;
            var rows = dataTable.Rows;
            var countRows = rows.Count;

            //列
            for (var j = 0; j < countColumns; j++)
            {
                var list = new List<object>();
                //行
                for (var i = 0; i < countRows; i++)
                {

                    list.Add(rows[i][j]);

                }
                dic.Add(columns[j].ToString(), list);
            }



            return dic;
        }





        /// <summary>
        /// GetSelectDicBySql
        /// </summary>
        /// <param name="sqlSelect"></param>
        /// <returns></returns>
        public Dictionary<string, List<object>> GetSelectDicBySql(string sqlSelect)
        {
            var mySqlConnection = GetMySqlConnection();
            var mySqlCommand = GetMySqlCommand(sqlSelect, mySqlConnection);

            mySqlConnection.Open();

            var dic = GetSelectDic(mySqlCommand);

            mySqlConnection.Close();

            return dic;
        }

        /// <summary>
        /// UpdateTable
        /// </summary>
        /// <param name="mySqlCommand"></param>
        public void UpdateTable(MySqlCommand mySqlCommand)
        {
            mySqlCommand.ExecuteNonQuery();
        }

        /// <summary>
        /// UpdateTable
        /// </summary>
        /// <param name="sqlUpdate"></param>
        public void UpdateTable(string sqlUpdate)
        {
            var mySqlConnection = GetMySqlConnection();
            var mySqlCommand = GetMySqlCommand(sqlUpdate, mySqlConnection);
            mySqlConnection.Open();
            UpdateTable(mySqlCommand);
            mySqlConnection.Close();
        }

        /// <summary>
        /// DeleteTable
        /// </summary>
        /// <param name="mySqlCommand"></param>
        public void DeleteTable(MySqlCommand mySqlCommand)
        {
            mySqlCommand.ExecuteNonQuery();
        }

        /// <summary>
        /// DeleteTable
        /// </summary>
        /// <param name="sqlDelete"></param>
        public void DeleteTable(string sqlDelete)
        {
            var mySqlConnection = GetMySqlConnection();
            var mySqlCommand = GetMySqlCommand(sqlDelete, mySqlConnection);
            mySqlConnection.Open();
            DeleteTable(mySqlCommand);
            mySqlConnection.Close();
        }

        /// <summary>
        /// InsertTable
        /// </summary>
        /// <param name="mySqlCommand"></param>
        public void InsertTable(MySqlCommand mySqlCommand)
        {
            mySqlCommand.ExecuteNonQuery();
        }

        /// <summary>
        /// InsertTable
        /// </summary>
        /// <param name="sqlInsert"></param>
        public void InsertTable(string sqlInsert)
        {
            var mySqlConnection = GetMySqlConnection();
            var mySqlCommand = GetMySqlCommand(sqlInsert, mySqlConnection);
            mySqlConnection.Open();
            InsertTable(mySqlCommand);
            mySqlConnection.Close();
        }



        /// <summary>
        /// InsertTable
        /// </summary>
        /// <param name="infoDic"></param>
        /// <param name="tableName"></param>
        public void InsertTable(Dictionary<string, string> infoDic, string tableName)
        {
            using (var mySqlConnection = GetMySqlConnection())
            {
                //打开连接
                mySqlConnection.Open();
                var strPart1 = $"INSERT INTO {tableName}";
                var strPart2 = " VALUES";
                var curIndex = 0;
                var length = infoDic.Count;
                foreach (var info in infoDic)
                {
                    if (curIndex == 0)
                    {
                        strPart1 = $"{strPart1}({info.Key}";
                        strPart2 = $"{strPart2}(@{info.Key}";
                    }
                    else if (curIndex == length - 1)
                    {
                        strPart1 = $"{strPart1},{info.Key})";
                        strPart2 = $"{strPart2},@{info.Key})";
                    }
                    else
                    {
                        strPart1 = $"{strPart1},{info.Key}";
                        strPart2 = $"{strPart2},@{info.Key}";
                    }

                    curIndex++;

                }

                var str = $"{strPart1}{strPart2}";

                var mySqlCommand = GetMySqlCommand(str, mySqlConnection);


                foreach (var info in infoDic)
                {
                    mySqlCommand.Parameters.AddWithValue($"@{info.Key}", info.Value);
                }

                switch (mySqlCommand.ExecuteNonQuery())
                {
                    case 1:
                        Console.WriteLine($"向{tableName}表插入新记录成功！");
                        break;
                    case 0:
                        throw new Exception($"向{tableName}表插入新记录失败！");
                    default:
                        throw new Exception($"向{tableName}表插入了多条新记录！");
                }
                //关闭连接
                mySqlConnection.Close();
            }

        }

        /// <summary>
        /// CreateTable
        /// </summary>
        /// <param name="infoDic"></param>
        /// <param name="dataTypeDic"></param>
        public void CreateTable(Dictionary<string, string> infoDic, Dictionary<string, string> dataTypeDic)
        {

        }


        /// <summary>
        /// GetLock
        /// </summary>
        /// <param name="mySqlConnection"></param>
        /// <param name="lockName"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public bool GetLock(MySqlConnection mySqlConnection, string lockName, int timeout = 10)
        {
            var sqlLock = $"SELECT GET_LOCK('{lockName}',{timeout});";
            var mySqlCommandLock = GetMySqlCommand(sqlLock, mySqlConnection);
            //mySqlConnection.Open();
            var result = mySqlCommandLock.ExecuteScalar();
            //mySqlConnection.Close();
            return result.ToString() == "1";
        }


        /// <summary>
        /// GetReleaseLock
        /// </summary>
        /// <param name="mySqlConnection"></param>
        /// <param name="lockName"></param>
        /// <returns></returns>
        public bool GetReleaseLock(MySqlConnection mySqlConnection, string lockName)
        {
            var sqlUnLock = $"SELECT RELEASE_LOCK('{lockName}');";
            var mySqlCommandReleaseLock = GetMySqlCommand(sqlUnLock, mySqlConnection);
            //mySqlConnection.Open();
            var result = mySqlCommandReleaseLock.ExecuteScalar();
            //mySqlConnection.Close();
            return result.ToString() == "1";
        }


        /// <summary>
        /// Test
        /// </summary>
        public void Test()
        {
            //var mysqlHelper = new MysqlHelper("127.0.0.1", "zhanxian", "root", "root");
            var mySqlHelper = new MySqlHelper();
            var mySqlConnection = GetMySqlConnection();
            var sqlSelect = "SELECT company FROM jd";
            var mySqlCommand = GetMySqlCommand(sqlSelect, mySqlConnection);

            mySqlConnection.Open();

            var dic = GetSelectDic(mySqlCommand);

            mySqlConnection.Close();

        }

        /// <summary>
        /// Test1
        /// </summary>
        public void Test1()
        {
            //var mySqlHelper = new MySqlHelper("211.149.245.126", "renwu_dianshang", "asst2", "fx*#sjTx");
            //var dic = mySqlHelper.GetSelectDicBySql("SELECT companyname FROM renwu_gongshang_x315_attr");
            //var keys = dic.Keys;
            //var list = dic[keys.ElementAt(0)];
            //var dic1 = mySqlHelper.GetSelectDicBySql("SELECT * FROM renwu_gongshang_x315_attr");

            var mySqlHelper = new MySqlHelper();


            //var mySqlConnection = GetMySqlConnection();
            //var sqlUpdate = "UPDATE renwu_gongshang_x315_attr SET TaskStatue = 1 WHERE companyname = '温州红辣椒电子商务有限公司'";
            //var mySqlCommand = GetMySqlCommand(sqlUpdate, mySqlConnection);
            //mySqlConnection.Open();
            //UpdateTable(mySqlCommand);
            //mySqlConnection.Close();

            var sqlUpdate = "UPDATE renwu_gongshang_x315_attr SET TaskStatue = 1 WHERE companyname = '温州红辣椒电子商务有限公司'";
            UpdateTable(sqlUpdate);

            Console.WriteLine("QAQ");
            Console.WriteLine("orz");
        }
    }
}
