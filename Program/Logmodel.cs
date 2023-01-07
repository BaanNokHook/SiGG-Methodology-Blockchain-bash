
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;



namespace Methodology_Blockchain_bash
{
   
   

    public class Logmodel
    {
        private void exits_msglog() {
            string path = Directory.GetCurrentDirectory()+"/Msglog";
            if (Directory.Exists(path))
            {
            }
            else
            {
                System.IO.Directory.CreateDirectory(path);
            }

        }
       
        public string info(string rawlog) {

            exits_msglog();

            string path = Directory.GetCurrentDirectory() + "/Msglog/log_info_" + DateTime.Now.ToString("yyyy_MM_dd") + ".txt";
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, true))
            {
                file.WriteLine(DateTime.Now.ToString("yyyy:MM:dd HH:mm:ss") + " : "+ rawlog);
                file.Dispose();
                file.Close();
            }
          
         
            return "";
        }

       



    }
}