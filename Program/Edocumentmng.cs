
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading;

namespace Methodology_Blockchain_bash
{

    public class Edocumentmng
    {
        Logmodel log = new Logmodel();

        public static string insertDocument(string connectdb, string fileorg, string filename, string userid,string checksum) {
            var temp_data = new List<object>();
            string Command = "INSERT INTO [t_documentFileTemp] ([fileorg],[filename],[updatetime],[status],[userid],[checksum])VALUES(@1,@2,@3,@4,@5,@6);";
            Dictionary<object, object> param = new Dictionary<object, object>();
            param.Add("1", "");
            param.Add("2", filename);
            param.Add("3", DateTime.Now.ToString("yyyMMdd HH:mm:ss"));
            param.Add("4", "N");
            param.Add("5", userid);
            param.Add("6", "");

            //param.Add("1", fileorg);
            //param.Add("2", filename);
            //param.Add("3", DateTime.Now.ToString());
            //param.Add("4", "N");
            //param.Add("5", userid);
            //param.Add("6", checksum);

            var data_1 = Core_mssql.data_utility(connectdb, Command, param);

            //var data_1 =  Core_sqlite.sqlite_push(Command, param);
            temp_data.Add(data_1);

            //Console.WriteLine("Log insertDocument :  " + JsonConvert.SerializeObject(data_1));


            return JsonConvert.SerializeObject(temp_data);
        }

        public static void t_log_performance(string connectdb, string case_test, string channel, string start_date, string end_date, string log_date, string size, object avg_time,string ex_case)
        {
            Logmodel log = new Logmodel();
            var temp_data = new List<object>();
            string Command = "INSERT INTO [t_log_performance] ([case],[channel],[start_date],[end_date],[log_date],[size],[avg_time],[ex_case])VALUES(@1,@2,@3,@4,@5,@6,@7,@8);";
            Dictionary<object, object> param = new Dictionary<object, object>();
            param.Add("1", case_test);
            param.Add("2", channel);
            param.Add("3", start_date);
            param.Add("4", end_date);
            param.Add("5", DateTime.Now.ToString("yyyyMMdd HH:mm:ss"));
            param.Add("6", size);
            param.Add("7", avg_time);
            param.Add("8", "");


            //param.Add("1", case_test);
            //param.Add("2", channel);
            //param.Add("3", start_date);
            //param.Add("4", end_date);
            //param.Add("5", DateTime.Now.ToString("yyyyMMdd HH:mm:ss"));
            //param.Add("6", size);
            //param.Add("7", avg_time);
            //param.Add("8", ex_case);

            //DateTime.Now.ToString("yyyymmdd HH:mm:ss")

            var data_1 = Core_mssql.data_utility(connectdb, Command, param);
           // var data_1 = Core_sqlite.sqlite_push(Command, param);


            //log.info("result t_log_performance: " + JsonConvert.SerializeObject(data_1));

            // Console.WriteLine("Log t_log_performance :  " + JsonConvert.SerializeObject(data_1));

            temp_data.Add(data_1);
        }


        public static void clear_t_log_blockchain_performance()
        {

           

            Logmodel log = new Logmodel();

            string Command = "TRUNCATE TABLE [t_log_blockchain_performance]";
               
            Dictionary<object, object> param = new Dictionary<object, object>();
            param.Add("", "");
           

            var data_1 = Core_mssql.data_utility("t_log_blockchain_performance", Command, param);

            Console.WriteLine("Result ins_db ===== > " + JsonConvert.SerializeObject(data_1));

            Thread.Sleep(1000);


        }
        public static void t_log_blockchain_performance(string data)
        {

            var ins_db = JObject.Parse(data);

            Logmodel log = new Logmodel();
          
            string Command = "INSERT INTO [t_log_blockchain_performance] (" +
                "[chain]," +
                "[valid]," +
                "[encoding]," +
                "[sequence]," +
                "[block]," +
                "[lastblock]," +
                "[file]," +
                "[dataspace]," +
                "[content_size]," +
                "[hash_space]," +
                "[content_identity]," +
                "[encodeing_start]," +
                "[encodeing_end]," +
                "[encoding_avg]," +
                "[block_start]," +
                "[block_end]," +
                "[block_avg]," +
                "[remark1]" +
              // "[remark2]" +
                ")";
            Command += "VALUES(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15,@16,@17,@18);";
            Dictionary<object, object> param = new Dictionary<object, object>();
            param.Add("1", ins_db["chain"].ToString());
            param.Add("2", ins_db["valid"].ToString());
            param.Add("3", ins_db["encoding"].ToString());
            param.Add("4", ins_db["sequence"].ToString());
            param.Add("5", ins_db["block"].ToString());
            param.Add("6", ins_db["lastblock"].ToString());
            param.Add("7", ins_db["file"].ToString());
            param.Add("8", ins_db["dataspace"].ToString());
            param.Add("9", ins_db["content_size"].ToString());
            param.Add("10", ins_db["hash_space"].ToString());
            param.Add("11", ins_db["content_size"].ToString());
            param.Add("12", ins_db["encodeing_start"].ToString());
            param.Add("13", ins_db["encodeing_end"].ToString());
            param.Add("14", ins_db["encoding_avg"].ToString());
            param.Add("15", ins_db["block_start"].ToString());
            param.Add("16", ins_db["block_end"].ToString());
            param.Add("17", ins_db["block_avg"].ToString());
            param.Add("18", ins_db["remark1"].ToString());
          //  param.Add("19", ins_db["remark2"].ToString());

            var data_1 = Core_mssql.data_utility("t_log_blockchain_performance", Command, param);

            Console.WriteLine("Result ins_db ===== > " + JsonConvert.SerializeObject(data_1));
            
        //CREATE TABLE[dbo].[t_log_blockchain_performance]
        //(

          //    [id] int IDENTITY(1,1) NOT NULL,
          //    [chain] varchar(255) COLLATE Thai_CI_AS NULL,
          //    [valid] varchar(255) COLLATE Thai_CI_AS NULL,
          //    [encoding] varchar(100) COLLATE Thai_CI_AS NULL,
          //    [sequence] varchar(100) COLLATE Thai_CI_AS NULL,
          //    [block] varchar(255) COLLATE Thai_CI_AS NULL,
          //    [lastblock] varchar(255) COLLATE Thai_CI_AS NULL,
          //    [file] varchar(255) COLLATE Thai_CI_AS NULL,
          //    [dataspace] varchar(100) COLLATE Thai_CI_AS NULL,
          //    [content_size] varchar(100) COLLATE Thai_CI_AS NULL,
          //    [hash_space] varchar(100) COLLATE Thai_CI_AS NULL,
          //    [content_identity] varchar(100) COLLATE Thai_CI_AS NULL,
          //    [encodeing_start] datetime NULL,
          //    [encodeing_end] datetime NULL,
          //    [encoding_avg] varchar(200) COLLATE Thai_CI_AS NULL,
          //    [block_start] datetime NULL,
          //    [block_end] datetime NULL,
          //    [block_avg] varchar(200) COLLATE Thai_CI_AS NULL,
          //    [remark1] varchar(255) COLLATE Thai_CI_AS NULL,
          //    [remark2] varchar(255) COLLATE Thai_CI_AS NULL
          //)  
          //ON[PRIMARY]
          //TEXTIMAGE_ON[PRIMARY]
          //GO

          
        }











    }
}
