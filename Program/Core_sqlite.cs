using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Methodology_Blockchain_bash
{
    public class Core_sqlite
    {

        private static  string dbsqlite = "blockchain";

        public static string currentDir = Path.GetDirectoryName(Environment.CurrentDirectory);
        public static string projectName = Assembly.GetCallingAssembly().GetName().Name;

        public static string appRoot = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"));


        public static List<object> sqlite_push(string command, Dictionary<object, object> param)
        {
            string pathdb = appRoot + "/Appdata/Schema/"+ dbsqlite + ".db";
            string connectionstr = @"Data Source=" + pathdb + ";Version=3; FailIfMissing=True; Foreign Keys=True;";

            var result = new List<object>();
            var result_sqlite = new Dictionary<object, object>();

            using (SQLiteConnection conn = new SQLiteConnection(connectionstr))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = command;
                    if (param.Count == 0)
                    {
                    }
                    else
                    {
                        for (int index = 0; index < param.Count; index++)
                        {
                            var item = param.ElementAt(index);
                            cmd.Parameters.AddWithValue("@" + item.Key.ToString(), item.Value.ToString());

                        }
                    }
                    cmd.Prepare();
                    try
                    {
                        var resultadd = cmd.ExecuteNonQuery();
                        result_sqlite.Add("Status", "Done");
                    }
                    catch (SQLiteException e)
                    {
                        result_sqlite.Add("Status", "Fail "+ e.Source);
                    }
                }
                conn.Close();
                conn.Dispose();
            }

            result.Add(result_sqlite);

            return result;

        }


        public static string sqlite_pull(string command, Dictionary<object, object> param)
        {
            string pathdb = appRoot + "/Appdata/Schema/" + dbsqlite + ".db";
            string connectionstr = @"Data Source=" + pathdb + ";Version=3; FailIfMissing=True; Foreign Keys=True;";


            var result = new List<object>();
            using (SQLiteConnection conn = new SQLiteConnection(connectionstr))
            {
                conn.Open();
                string sql = command;

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.CommandText = command;
                    if (param.Count == 0)
                    {
                    }
                    else
                    {
                        for (int index = 0; index < param.Count; index++)
                        {
                            var item = param.ElementAt(index);
                            cmd.Parameters.AddWithValue("@" + item.Key.ToString(), item.Value.ToString());
                        }
                    }
                    cmd.Prepare();
                    // cmd.Parameters.AddWithValue("@access_token", access_token);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var dict = new Dictionary<object, object>();
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    dict.Add(reader.GetName(i).ToString(), reader.GetValue(i).ToString());
                                }
                                result.Add(dict);
                            }
                        }
                    }
                }
                conn.Close();
                conn.Dispose();
            }
            return JsonConvert.SerializeObject(result);
        }



    }
}