
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Methodology_Blockchain_bash
{

    public class Blockchain_model
    {
        Logmodel log = new Logmodel();
        private static Dictionary<string, string> chain_detail;
        public static bool chain_valid { get; private set; }
        public static object chainflow { get; private set; }

       // public static Blockchain chainflow = new Blockchain("test", "new");

        public static Dictionary<object, object> blockchain_edocument(string data)
        {
            Logmodel log = new Logmodel();
            /// log.info("==============Start blockchain_edocument ===============");
            var chain = "";
            var chain_identity = "";
            var chain_data = "";
            var chain_description = "";
            string result_exits = "";
            var blockchain_list = "";

            if (data != "" | data != null)
            {
                try
                {
                    var key_val = JObject.Parse(data);
                    chain = key_val["chain"].ToString();
                    chain_identity = key_val["identity"].ToString();
                    chain_data = key_val["data"].ToString();
                    chain_description = key_val["description"].ToString();

                  //  result_exits = exits_module_edocument(chain);
                }
                catch (Exception)
                {
                    chain = "";
                    chain_identity = "";
                    chain_data = "";
                    chain_description = "";
                    result_exits = "default";
                }
            }



                Blockchain chainflow = new Blockchain(chain, "new");

                var ctr_chain = new Dictionary<object, object>();


                Console.WriteLine(" RUN : ctr_chain ======>  " + ctr_chain.Count.ToString());

                if (ctr_chain.Count.ToString() == "0")
                {
                    chainflow.AddBlock(new Block(0, DateTime.Now, null, chain, chain_identity, "", chain_description, "new", "hash"));
                    ctr_chain.Add(ctr_chain.Count.ToString(), DateTime.Now);
                }
                else {

                    chainflow.AddBlock(new Block(0, DateTime.Now, null, chain, chain_identity, "", chain_description, "update", "hash"));
                    ctr_chain.Add(ctr_chain.Count.ToString(), DateTime.Now);
                }


                Console.WriteLine(" RUN : ctr_chain ======>  " + JsonConvert.SerializeObject(ctr_chain));


                chain_valid = chainflow.IsValid();
            
          
            
          
         
          


            Dictionary<object, object> chain_detail = new Dictionary<object, object>();
            chain_detail.Add("blockchain_valid", chain_valid.ToString());
            chain_detail.Add("Date", DateTime.Now.ToString());
            //chain_detail.Add("chain_block", temp_detail_chain.Count());
            //chain_detail.Add("chain_detail", temp_detail_chain);

            Console.WriteLine(" RUN : blockchain_edocument  chain_detail ======>  " + JsonConvert.SerializeObject(chainflow));
            return chain_detail;
        }


      

        public static string identity_value(string encodeString)
        {
                    Logmodel log = new Logmodel();
                    //Converting base64 value to number
                    byte[] output = Convert.FromBase64String(encodeString);

                    int rslt = 0;
                    for (int i = 0; i<output.Length; ++i)
                    {
                        rslt <<= 8;
                        rslt += output[i];
                    }

                  
                    //log.info("rslt is :" + rslt.ToString());
                    //log.info("double is :" + ((double) rslt / 1150.78));

                    return  rslt.ToString();
        }


        public static string exits_module_edocument(string chain)
        {
          
            string chain_status = "";

            chain_status = "new";
           
           
            
      
            Console.WriteLine(" RUN : Chain Total  ");

          

            // string Command = "SELECT * from blockchain_edocument WHERE module = @1 ";

            // Dictionary<object, object> param = new Dictionary<object, object>();
            //param.Add("1", chain.ToString());

            //  var data_1 = Core_mssql.data_count_row("ite_Methodlogy_Blockchain", Command, param);

            //if (data_1.ToString() == "0")
            //{
            //    chain_status = "new";
            //}
            // else
            // {
            //     chain_status = "exits";
            // }
            return chain_status;
        }
       





    }
}