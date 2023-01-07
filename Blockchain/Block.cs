using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace Methodology_Blockchain_bash
{

    public class Block
    {
        public int Index { get; set; }
        public DateTime TimeStamp { get; set; }
        public string PreviousHash { get; set; }
        public string Hash { get; set; }
        public string module { get; set; }
        public string ids { get; set; }
        public string Data { get; set; }
        public string des { get; set; }

        public string Mode { get; set; }

        public Block(int Indexs , DateTime timeStamp, string previousHash, string key_module, string identity, string data, string description, string Mode,string hashs)
        {
           

            if (Mode == "new")
            {
                Index = 0;
                TimeStamp = timeStamp;
                PreviousHash = previousHash;
                module = key_module;
                ids = identity;
                Data = data;
                des = description;
                Hash = CalculateHash();

            }
            else if (Mode == "update")
            {
                Index = Indexs;
                TimeStamp = timeStamp;
                PreviousHash = previousHash;
                module = key_module;
                ids = identity;
                Data = data;
                des = description;
                Hash = hashs;
            }
                 
        }
      
        public string CalculateHash()
        {
            SHA256 sha256 = SHA256.Create();

            byte[] inputBytes = Encoding.ASCII.GetBytes($"{TimeStamp}-{PreviousHash ?? ""}-{Data}");
            byte[] outputBytes = sha256.ComputeHash(inputBytes);

           

            return Convert.ToBase64String(outputBytes);
        }




    }

}