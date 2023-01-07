using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace Methodology_Blockchain_bash
{
    public class Core_mssql
    {

        public static string connection(string conn_db)
        {

            //10.9.101.12   sa  3cats@Z00  // For Aew
            //192.168.1.4  sa  password  EvolYYion Desktop  //instance 1

            //10.9.101.99  p@ssw0rd

            //139.5.145.64 cloud
            //c local
            //192.168.1.4

            return "Server=" + "10.9.101.12"
             + ";Database=" + "Methodology_Blockchain"
             + ";user id=" + "sa"
             + ";password=" + "3cats@Z00"
             + ";multipleactiveresultsets=True;";


            //return "Server=" + "10.9.101.12"
            //    + ";Database=" + "Methodology_Blockchain"
            //    + ";user id=" + "sa"
            //    + ";password=" + "3cats@Z00"
            //    + ";multipleactiveresultsets=True;";
        }


        public static Dictionary<object, object> data_utility(string conn_db ,string SqlCommand, Dictionary<object, object> param)
        {
            var result_query = "";
            string configdb = connection(conn_db).ToString();
            using (SqlConnection connection = new SqlConnection(configdb))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                SqlTransaction transaction;

                transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted, "Sqltransaction");
                command.Connection = connection;
                command.Transaction = transaction;

                try
                {
                    command.CommandText = SqlCommand;
                    if (param.Count == 0)
                    {
                    }
                    else
                    {
                        for (int index = 0; index < param.Count; index++)
                        {
                            var item = param.ElementAt(index);
                            command.Parameters.Add(new SqlParameter(item.Key.ToString(), item.Value));
                        }
                    }
                    command.ExecuteNonQuery();
                    transaction.Commit();
                    result_query = "success";


                }
                catch (Exception e)
                {
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (SqlException ex)
                    {
                        if (transaction.Connection != null)
                        {

                        }
                    }

                    result_query = "fail : "+e.ToString();
                }
                //connection.Dispose();
                //connection.Close();
            }

            Dictionary<object, object> param_result = new Dictionary<object, object>();
            param_result.Add("Query", result_query.ToString());
            param_result.Add("Date", DateTime.Now.ToString());

            return param_result;

        }


        public static string data_json(string conn_db, string SqlCommand, Dictionary<object, object> param)
        {
            string configdb = connection(conn_db).ToString();

            //logger.Log(LogLevel.Info, "SqlCommand : " + SqlCommand.ToString());
            //logger.Log(LogLevel.Info, "log connect db : " + configdb.ToString());

            SqlConnection condb = new SqlConnection();
            condb.ConnectionString = configdb;
            condb.Open();

            SqlCommand cmd = new SqlCommand(SqlCommand, condb);
            if (param.Count == 0)
            {
            }
            else
            {
                for (int index = 0; index < param.Count; index++)
                {
                    var item = param.ElementAt(index);
                    cmd.Parameters.Add(new SqlParameter(item.Key.ToString(), item.Value.ToString()));
                }
            }

            var reader = cmd.ExecuteReader();
            var result = new List<object>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var dict = new Dictionary<string, string>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        dict.Add(reader.GetName(i).ToString(), reader.GetValue(i).ToString());
                    }
                    result.Add(dict);
                }
            }
            condb.Dispose();
            condb.Close();

            string return_val = JsonConvert.SerializeObject(result);   
            return return_val;
        }

        public static List<object> data_array(string conn_db, string SqlCommand, Dictionary<object, object> param)
        {
            string configdb = connection(conn_db).ToString();

            SqlConnection condb = new SqlConnection();
            condb.ConnectionString = configdb;
            condb.Open();

            SqlCommand cmd = new SqlCommand(SqlCommand, condb);
            if (param.Count == 0)
            {
            }
            else
            {
                for (int index = 0; index < param.Count; index++)
                {
                    var item = param.ElementAt(index);
                    cmd.Parameters.Add(new SqlParameter(item.Key.ToString(), item.Value.ToString()));
                }
            }
            var reader = cmd.ExecuteReader();
            var result = new List<object>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var dict = new List<string>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {

                        dict.Add(reader.GetValue(i).ToString());
                    }
                    result.Add(dict);
                }
            }
            condb.Dispose();
            condb.Close();

            return result;
        }
        public static List<object> data_with_col(string conn_d, string SqlCommand, Dictionary<object, object> param)
        {
            string configdb = connection(conn_d).ToString();


            SqlConnection condb = new SqlConnection();
            condb.ConnectionString = configdb;
            condb.Open();

            SqlCommand cmd = new SqlCommand(SqlCommand, condb);
            if (param.Count == 0)
            {
            }
            else
            {
                for (int index = 0; index < param.Count; index++)
                {
                    var item = param.ElementAt(index);
                    cmd.Parameters.Add(new SqlParameter(item.Key.ToString(), item.Value.ToString()));
                }
            }
            var reader = cmd.ExecuteReader();
            var result = new List<object>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var dict = new Dictionary<string, string>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        dict.Add(reader.GetName(i).ToString(), reader.GetValue(i).ToString());
                    }
                    result.Add(dict);
                }
            }
            condb.Dispose();
            condb.Close();

            return result;
        }

        public static string data_schema(string conn_d, string SqlCommand, Dictionary<object, object> param)
        {
            string configdb = connection(conn_d).ToString();

            SqlConnection condb = new SqlConnection();
            condb.ConnectionString = configdb;
            condb.Open();

            SqlCommand cmd = new SqlCommand(SqlCommand, condb);
            if (param.Count == 0)
            {
            }
            else
            {
                for (int index = 0; index < param.Count; index++)
                {
                    var item = param.ElementAt(index);
                    cmd.Parameters.Add(new SqlParameter(item.Key.ToString(), item.Value.ToString()));
                }
            }
            var reader = cmd.ExecuteReader();
            var result = new List<string>();

            for (int i = 0; i < reader.FieldCount; i++)
            {
                result.Add(reader.GetName(i).ToString());
            }

            condb.Dispose();
            //condb.Close();

            return JsonConvert.SerializeObject(result);
        }

        public static int data_count_row(string conn_d, string SqlCommand, Dictionary<object, object> param)
        {
            string configdb = connection(conn_d).ToString();
            SqlConnection condb = new SqlConnection();
            condb.ConnectionString = configdb;
            condb.Open();

            SqlCommand cmd = new SqlCommand(SqlCommand, condb);
            if (param.Count == 0)
            { }
            else
            {
                for (int index = 0; index < param.Count; index++)
                {
                    var item = param.ElementAt(index);
                    cmd.Parameters.Add(new SqlParameter(item.Key.ToString(), item.Value.ToString()));
                }
            }

            var reader = cmd.ExecuteReader();

            int i = 0;
            while (reader.Read())
            {
                i++;
            }
            condb.Dispose();
            condb.Close();
            return i;
        }




    }
} 