
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Methodology_Blockchain_bash
{

    public class Blockchain
    {
        public IList<Block> Chain { set; get; }

        public   Blockchain(string key_module,string mode)
        {
            if (mode == "new")
            {
                InitializeChain();
                AddGenesisBlock(key_module);
            }
            else if (mode == "load")
            {
                InitializeChain();
            }
            else if (mode == "update")
            {

            }
            


        }


        public async Task Renew_Blockchain(string key_module)
        {

            //string Command = "SELECT * FROM blockchain_edocument WHERE module = @mm";
            //Dictionary<object, object> param = new Dictionary<object, object>();
            //param.Add("mm", key_module);
            //var data1 =  JsonConvert.DeserializeObject(Core_mssql.data_json("ite_Methodlogy_Blockchain",Command, param));
            //   JArray dataarray1 = JArray.Parse(JsonConvert.SerializeObject(data1));
            //  for (int i = 0; i < dataarray1.Count; i++)
            //  {
            //     Chain.Add(new Block(i, DateTime.Parse(dataarray1[i]["TimeStamp"].ToString()), dataarray1[i]["PreviousHash"].ToString(), dataarray1[i]["module"].ToString(), dataarray1[i]["identity"].ToString(), dataarray1[i]["Data"].ToString(), dataarray1[i]["description"].ToString(), "update", dataarray1[i]["Hash"].ToString()));
            //  }

            Console.WriteLine(">>>>>>>"+Chain);

        }
   
        public void InitializeChain()
        {
            Chain = new List<Block>();
        }

        public Block CreateGenesisBlock(string key_module)
        {
          
            return new Block(0,DateTime.Now, "", key_module,"{}", "{}","{}","new","hashs");
        }

        public void AddGenesisBlock(string key_module)
        {           
            Chain.Add(CreateGenesisBlock(key_module));         
        }

        public Block GetLatestBlock()
        {
            return Chain[Chain.Count - 1];
        }

        public  string AddBlock(Block block)
        {
            Logmodel log = new Logmodel();
            Block latestBlock = GetLatestBlock();
            block.Index = latestBlock.Index + 1;
            block.PreviousHash = latestBlock.Hash;
            block.Hash = block.CalculateHash();
          
            Chain.Add(block);

            // string command = "INSERT INTO [blockchain_edocument] ([Index], [TimeStamp], [PreviousHash], [Hash], [module],[identity], [Data],[description]) VALUES (@1, @2, @3, @4, @5,@6,@7,@8)";
            // Dictionary<object, object> param = new Dictionary<object, object>();
            // param.Add("1", block.Index.ToString());
            // param.Add("2", block.TimeStamp.ToString());
            // param.Add("3", latestBlock.Hash);
            // param.Add("4", block.Hash);
            // param.Add("5", block.module);
            // param.Add("6", block.ids);
            //  param.Add("7", "");
            // param.Add("8", "");

            // Core_mssql.data_utility("ite_Methodlogy_Blockchain", command, param);

            log.info("Hash detail : "+block.Hash.ToString());

            return block.Hash.ToString();
        }
    
        public bool IsValid()
        {
            for (int i = 1; i < Chain.Count; i++)
            {
                Block currentBlock = Chain[i];
                Block previousBlock = Chain[i - 1];

                
                if (currentBlock.PreviousHash != previousBlock.Hash)
                {
                    return false;
                }
            }
            
            return true;
        }

        public string chain_count()
        {
            return Chain.Count.ToString();
        }

    }

}