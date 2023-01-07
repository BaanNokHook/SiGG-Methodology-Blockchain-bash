using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Drawing.Imaging;
using System.Diagnostics;

namespace Methodology_Blockchain_bash
{
    class Programdata
    {
     
        public static string blockchain_document(string filename)
        {

            string chain = DateTime.Now.ToString("yyyMMdd_HH_mm_ss_")+filename;

            Blockchain chainflow = new Blockchain(chain, "new");

         
            var chain_status = new Dictionary<object, object>();
            var newblock = "";

            chainflow.AddBlock(new Block(0, DateTime.Now, null, chain, "firstblock", "", "firstblock", "new", "hash"));
     

            Stopwatch process_screen = new Stopwatch();
            process_screen.Start();


            int[] countlist = { 10, 100,1000,10000 };

            foreach (int countdata in countlist)
            {

                int total = countdata;

                Console.WriteLine(" RUN : Start ==========> Count : " + total);

                object[] encodlist = { "md5", "sha", "sha256", "sha512", "aes" };

                foreach (var encodeing in encodlist)
                {
                    string encode_type = encodeing.ToString();


                    for (int i = 1; i <= total; i++)
                    {
                        string default_env = "dev"; // --dev -- Evo_pc -- Evo_mini  -- aeautnp 

                        string path = "";

                       
                        if (default_env == "Evo_pc")
                        {
                           
                            path = "C:\\Users\\Evolution\\Desktop\\Methodology_Blockchain\\Appdata\\" + filename;
                        }
                        if (default_env == "Evo_mini")
                        {                            
                            path = "C:\\Users\\Evolution\\Desktop\\Methodology_Blockchain\\Appdata\\" + filename;
                        }
                        if (default_env == "aeautnp")
                        {
                            path = "/Users/tanaporn/Desktop/Methodology_Blockchain/Appdata/" + filename;
                        }
                        else if (default_env == "dev")
                        {
                             path = fileinpath(filename);

                        }


                        FileInfo f = new FileInfo(path);
                        long filesize = f.Length;

                        string base64String = "";
                        // string path = "";
                        using (Image image = Image.FromFile(path))
                        {
                            using (MemoryStream m = new MemoryStream())
                            {
                                image.Save(m, image.RawFormat);
                                byte[] imageBytes = m.ToArray();
                                base64String = Convert.ToBase64String(imageBytes);

                            }
                        }


                        Encryption_model encode = new Encryption_model();
                        var hash = "";
                        Stopwatch encodetime = new Stopwatch();
                        Stopwatch blockchaintime = new Stopwatch();


                        string start_encodetime = "";
                        string end_encodetime = "";

                        string start_blockchaintime = "";
                        string end_blockchaintime = "";

                        var ins_db = new Dictionary<object, object>();

                        switch (encode_type)
                        {
                            case "md5":

                                encodetime.Start();
                                start_encodetime = DateTime.Now.ToString(" yyyMMdd HH:mm:ss.ffffff");
                                hash = encode.md5(base64String);
                                end_encodetime = DateTime.Now.ToString(" yyyMMdd HH:mm:ss.ffffff");
                                encodetime.Stop();
                                blockchaintime.Start();
                                start_blockchaintime = DateTime.Now.ToString(" yyyMMdd HH:mm:ss.ffffff");



                                using (MemoryStream ms = new MemoryStream())
                                {
                                    var transction_detail = new Dictionary<object, object>();
                                    transction_detail.Add("filename", filename);
                                    transction_detail.Add("filesize", filesize.ToString());
                                    transction_detail.Add("content_size", base64String.Length);
                                    transction_detail.Add("content_identity", Blockchain_model.identity_value(hash.ToString()));
                                    transction_detail.Add("hash_size", hash.Length);
                                    transction_detail.Add("modifydate", DateTime.Now.ToString(" yyyMMdd HH:mm:ss"));


                                    //var param = new Dictionary<object, object>();
                                    //param.Add("Chain_valid", chainflow.IsValid());
                                    //param.Add("encodeing", encode_type);
                                    //param.Add("chain", filename);
                                    //param.Add("identity", Blockchain_model.identity_value(hash.ToString()));
                                    //param.Add("data", base64String);
                                    //param.Add("description", JsonConvert.SerializeObject(transction_detail));

                                    newblock = chainflow.AddBlock(new Block(0, DateTime.Now, null, chain, Blockchain_model.identity_value(hash.ToString()), "", JsonConvert.SerializeObject(transction_detail), "update", "hash"));
                                  
                                }
                                end_blockchaintime = DateTime.Now.ToString(" yyyMMdd HH:mm:ss.ffffff");
                                blockchaintime.Stop();

                                Console.WriteLine("Blockchain encode " + encode_type + " :  " + i.ToString() + "=====> chain " + chain);


                               
                                ins_db.Add("chain", chain);
                                ins_db.Add("valid", chainflow.IsValid());
                                ins_db.Add("encoding", encode_type);
                                ins_db.Add("sequence", total.ToString());
                                ins_db.Add("block", newblock);
                                ins_db.Add("lastblock", chainflow.GetLatestBlock().PreviousHash);
                                ins_db.Add("file", filename);
                                ins_db.Add("dataspace", filesize.ToString());
                                ins_db.Add("content_size", base64String.Length);
                                ins_db.Add("hash_space", hash.Length);
                                ins_db.Add("content_identity", Blockchain_model.identity_value(hash.ToString()));
                                ins_db.Add("encodeing_start", start_encodetime);
                                ins_db.Add("encodeing_end", end_encodetime);
                                ins_db.Add("encoding_avg", encodetime.Elapsed.TotalMilliseconds);
                                ins_db.Add("block_start", start_blockchaintime);
                                ins_db.Add("block_end", end_blockchaintime);
                                ins_db.Add("block_avg", blockchaintime.Elapsed.TotalMilliseconds);
                                ins_db.Add("remark1", DateTime.Now.ToString("yyyMMdd HH:mm:ss.ffffff"));
                                //ins_db.Add("remark2", "");

                                Edocumentmng.t_log_blockchain_performance(JsonConvert.SerializeObject(ins_db));



                                break;
                            case "sha":
                                encodetime.Start();
                                start_encodetime = DateTime.Now.ToString(" yyyMMdd HH:mm:ss.ffffff");
                                hash = encode.sha(base64String);
                                end_encodetime = DateTime.Now.ToString(" yyyMMdd HH:mm:ss.ffffff");
                                encodetime.Stop();
                                blockchaintime.Start();
                                start_blockchaintime = DateTime.Now.ToString(" yyyMMdd HH:mm:ss.ffffff");
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    var transction_detail = new Dictionary<object, object>();
                                    transction_detail.Add("filename", filename);
                                    transction_detail.Add("filesize", filesize.ToString());
                                    transction_detail.Add("content_size", base64String.Length);
                                    transction_detail.Add("content_identity", Blockchain_model.identity_value(hash.ToString()));
                                    transction_detail.Add("hash_size", hash.Length);
                                    transction_detail.Add("modifydate", DateTime.Now.ToString(" yyyMMdd HH:mm:ss"));


                                    //var param = new Dictionary<object, object>();
                                    //param.Add("Chain_valid", chainflow.IsValid());
                                    //param.Add("encodeing", encode_type);
                                    //param.Add("chain", filename);
                                    //param.Add("identity", Blockchain_model.identity_value(hash.ToString()));
                                    //param.Add("data", base64String);
                                    //param.Add("description", JsonConvert.SerializeObject(transction_detail));

                                    newblock = chainflow.AddBlock(new Block(0, DateTime.Now, null, chain, Blockchain_model.identity_value(hash.ToString()), "", JsonConvert.SerializeObject(transction_detail), "update", "hash"));
                                
                                }
                                end_blockchaintime = DateTime.Now.ToString(" yyyMMdd HH:mm:ss.ffffff");
                                blockchaintime.Stop();

                              
                                Console.WriteLine("Blockchain encode " + encode_type + " :  " + i.ToString() + "=====> chain " + chain);


                                
                                ins_db.Add("chain", chain);
                                ins_db.Add("valid", chainflow.IsValid());
                                ins_db.Add("encoding", encode_type);
                                ins_db.Add("sequence", total.ToString());
                                ins_db.Add("block", newblock);
                                ins_db.Add("lastblock", chainflow.GetLatestBlock().PreviousHash);
                                ins_db.Add("file", filename);
                                ins_db.Add("dataspace", filesize.ToString());
                                ins_db.Add("content_size", base64String.Length);
                                ins_db.Add("hash_space", hash.Length);
                                ins_db.Add("content_identity", Blockchain_model.identity_value(hash.ToString()));
                                ins_db.Add("encodeing_start", start_encodetime);
                                ins_db.Add("encodeing_end", end_encodetime);
                                ins_db.Add("encoding_avg", encodetime.Elapsed.TotalMilliseconds);
                                ins_db.Add("block_start", start_blockchaintime);
                                ins_db.Add("block_end", end_blockchaintime);
                                ins_db.Add("block_avg", blockchaintime.Elapsed.TotalMilliseconds);
                                ins_db.Add("remark1", DateTime.Now.ToString("yyyMMdd HH:mm:ss.ffffff"));
                                //ins_db.Add("remark2", "");

                                Edocumentmng.t_log_blockchain_performance(JsonConvert.SerializeObject(ins_db));
                                break;
                            case "sha256":
                                encodetime.Start();
                                start_encodetime = DateTime.Now.ToString(" yyyMMdd HH:mm:ss.ffffff");
                                hash = encode.sha256(base64String);
                                end_encodetime = DateTime.Now.ToString(" yyyMMdd HH:mm:ss.ffffff");
                                encodetime.Stop();
                                blockchaintime.Start();
                                start_blockchaintime = DateTime.Now.ToString(" yyyMMdd HH:mm:ss.ffffff");
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    var transction_detail = new Dictionary<object, object>();
                                    transction_detail.Add("filesize", filesize.ToString());
                                    transction_detail.Add("content_size", base64String.Length);
                                    transction_detail.Add("content_identity", Blockchain_model.identity_value(hash.ToString()));
                                    transction_detail.Add("hash_size", hash.Length);
                                    transction_detail.Add("modifydate", DateTime.Now.ToString(" yyyMMdd HH:mm:ss"));

                                    //var param = new Dictionary<object, object>();
                                    //param.Add("Chain_valid", chainflow.IsValid());
                                    //param.Add("encodeing", encode_type);
                                    //param.Add("chain", filename);
                                    //param.Add("identity", Blockchain_model.identity_value(hash.ToString()));
                                    //param.Add("data", base64String);
                                    //param.Add("description", JsonConvert.SerializeObject(transction_detail));

                                    newblock = chainflow.AddBlock(new Block(0, DateTime.Now, null, chain, Blockchain_model.identity_value(hash.ToString()), "", JsonConvert.SerializeObject(transction_detail), "update", "hash"));
                               
                                }
                                end_blockchaintime = DateTime.Now.ToString(" yyyMMdd HH:mm:ss.ffffff");
                                blockchaintime.Stop();

                                Console.WriteLine("Blockchain encode " + encode_type + " :  " + i.ToString() + "=====> chain " + chain);



                                ins_db.Add("chain", chain);
                                ins_db.Add("valid", chainflow.IsValid());
                                ins_db.Add("encoding", encode_type);
                                ins_db.Add("sequence", total.ToString());
                                ins_db.Add("block", newblock);
                                ins_db.Add("lastblock", chainflow.GetLatestBlock().PreviousHash);
                                ins_db.Add("file", filename);
                                ins_db.Add("dataspace", filesize.ToString());
                                ins_db.Add("content_size", base64String.Length);
                                ins_db.Add("hash_space", hash.Length);
                                ins_db.Add("content_identity", Blockchain_model.identity_value(hash.ToString()));
                                ins_db.Add("encodeing_start", start_encodetime);
                                ins_db.Add("encodeing_end", end_encodetime);
                                ins_db.Add("encoding_avg", encodetime.Elapsed.TotalMilliseconds);
                                ins_db.Add("block_start", start_blockchaintime);
                                ins_db.Add("block_end", end_blockchaintime);
                                ins_db.Add("block_avg", blockchaintime.Elapsed.TotalMilliseconds);
                                ins_db.Add("remark1", DateTime.Now.ToString("yyyMMdd HH:mm:ss.ffffff"));
                                //ins_db.Add("remark2", "");

                                Edocumentmng.t_log_blockchain_performance(JsonConvert.SerializeObject(ins_db));

                                break;
                            case "sha512":
                                encodetime.Start();
                                start_encodetime = DateTime.Now.ToString(" yyyMMdd HH:mm:ss.ffffff");
                                hash = encode.sha512(base64String);
                                end_encodetime = DateTime.Now.ToString(" yyyMMdd HH:mm:ss.ffffff");
                                encodetime.Stop();
                                blockchaintime.Start();
                                start_blockchaintime = DateTime.Now.ToString(" yyyMMdd HH:mm:ss.ffffff");
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    var transction_detail = new Dictionary<object, object>();
                                    transction_detail.Add("filesize", filesize.ToString());
                                    transction_detail.Add("content_size", base64String.Length);
                                    transction_detail.Add("content_identity", Blockchain_model.identity_value(hash.ToString()));
                                    transction_detail.Add("hash_size", hash.Length);
                                    transction_detail.Add("modifydate", DateTime.Now.ToString(" yyyMMdd HH:mm:ss"));



                                    //var param = new Dictionary<object, object>();
                                    //param.Add("Chain_valid", chainflow.IsValid());
                                    //param.Add("encodeing", encode_type);
                                    //param.Add("chain", filename);
                                    //param.Add("identity", Blockchain_model.identity_value(hash.ToString()));
                                    //param.Add("data", base64String);
                                    //param.Add("description", JsonConvert.SerializeObject(transction_detail));

                                    newblock = chainflow.AddBlock(new Block(0, DateTime.Now, null, chain, Blockchain_model.identity_value(hash.ToString()), "", JsonConvert.SerializeObject(transction_detail), "update", "hash"));
                                   
                                }
                                end_blockchaintime = DateTime.Now.ToString(" yyyMMdd HH:mm:ss.ffffff");
                                blockchaintime.Stop();



                                Console.WriteLine("Blockchain encode " + encode_type + " :  " + i.ToString() + "=====> chain " + chain);



                                ins_db.Add("chain", chain);
                                ins_db.Add("valid", chainflow.IsValid());
                                ins_db.Add("encoding", encode_type);
                                ins_db.Add("sequence", total.ToString());
                                ins_db.Add("block", newblock);
                                ins_db.Add("lastblock", chainflow.GetLatestBlock().PreviousHash);
                                ins_db.Add("file", filename);
                                ins_db.Add("dataspace", filesize.ToString());
                                ins_db.Add("content_size", base64String.Length);
                                ins_db.Add("hash_space", hash.Length);
                                ins_db.Add("content_identity", Blockchain_model.identity_value(hash.ToString()));
                                ins_db.Add("encodeing_start", start_encodetime);
                                ins_db.Add("encodeing_end", end_encodetime);
                                ins_db.Add("encoding_avg", encodetime.Elapsed.TotalMilliseconds);
                                ins_db.Add("block_start", start_blockchaintime);
                                ins_db.Add("block_end", end_blockchaintime);
                                ins_db.Add("block_avg", blockchaintime.Elapsed.TotalMilliseconds);
                                ins_db.Add("remark1", DateTime.Now.ToString("yyyMMdd HH:mm:ss.ffffff"));
                                //ins_db.Add("remark2", "");

                                Edocumentmng.t_log_blockchain_performance(JsonConvert.SerializeObject(ins_db));



                                //Console.WriteLine("Blockchain encode " + encode_type + " :  " + i.ToString() + "=====> chain " + chain);
                                //Console.WriteLine("Blockchain encode " + encode_type + " :  " + i.ToString() + "=====> Valid " + chainflow.IsValid());

                                //Console.WriteLine("Blockchain encode " + encode_type + " :  " + i.ToString() + "=====> method " + encode_type);
                                //Console.WriteLine("Blockchain encode " + encode_type + " :  " + i.ToString() + "=====> sequence " + total.ToString());

                                //Console.WriteLine("Blockchain encode " + encode_type + " :  " + i.ToString() + "=====> block " + newblock);
                                //Console.WriteLine("Blockchain encode " + encode_type + " :  " + i.ToString() + "=====> lastblock " + chainflow.GetLatestBlock().PreviousHash);

                                //Console.WriteLine("Blockchain encode " + encode_type + " :  " + i.ToString() + "=====> filename " + filename);
                                //Console.WriteLine("Blockchain encode " + encode_type + " :  " + i.ToString() + "=====> filesize " + filesize.ToString());

                                //Console.WriteLine("Blockchain encode " + encode_type + " :  " + i.ToString() + "=====> content_size " + base64String.Length);
                                //Console.WriteLine("Blockchain encode " + encode_type + " :  " + i.ToString() + "=====> hash_size " + hash.Length);
                                //Console.WriteLine("Blockchain encode " + encode_type + " :  " + i.ToString() + "=====> content_identity " + Blockchain_model.identity_value(hash.ToString()));


                                //Console.WriteLine("Blockchain encode " + encode_type + " :  " + i.ToString() + "=====> encode Start " + start_encodetime);
                                //Console.WriteLine("Blockchain encode " + encode_type + " :  " + i.ToString() + "=====> encode End " + end_encodetime);
                                //Console.WriteLine("Blockchain encode " + encode_type + " :  " + i.ToString() + "=====> encode Avg " + encodetime.Elapsed.TotalMilliseconds);

                                //Console.WriteLine("Blockchain encode " + encode_type + " :  " + i.ToString() + "=====> Blockchain Start " + start_blockchaintime);
                                //Console.WriteLine("Blockchain encode " + encode_type + " :  " + i.ToString() + "=====> Blockchain End " + end_blockchaintime);
                                //Console.WriteLine("Blockchain encode " + encode_type + " :  " + i.ToString() + "=====> Blockchain Avg " + blockchaintime.Elapsed.TotalMilliseconds);

                                break;
                            case "aes":
                                encodetime.Start();
                                start_encodetime = DateTime.Now.ToString(" yyyMMdd HH:mm:ss.ffffff");
                                hash = encode.encode_aes("encrypt", base64String);
                                end_encodetime = DateTime.Now.ToString(" yyyMMdd HH:mm:ss.ffffff");
                                encodetime.Stop();
                                blockchaintime.Start();
                                start_blockchaintime = DateTime.Now.ToString(" yyyMMdd HH:mm:ss.ffffff");
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    var transction_detail = new Dictionary<object, object>();
                                    transction_detail.Add("filesize", filesize.ToString());
                                    transction_detail.Add("content_size", base64String.Length);
                                    transction_detail.Add("content_identity", Blockchain_model.identity_value(hash.ToString()));
                                    transction_detail.Add("hash_size", hash.Length);
                                    transction_detail.Add("modifydate", DateTime.Now.ToString(" yyyMMdd HH:mm:ss"));



                                    //var param = new Dictionary<object, object>();
                                    //param.Add("Chain_valid", chainflow.IsValid());
                                    //param.Add("encodeing", encode_type);
                                    //param.Add("chain", filename);
                                    //param.Add("identity", Blockchain_model.identity_value(hash.ToString()));
                                    //param.Add("data", base64String);
                                    //param.Add("description", JsonConvert.SerializeObject(transction_detail));


                                    newblock = chainflow.AddBlock(new Block(0, DateTime.Now, null, chain, Blockchain_model.identity_value(hash.ToString()), "", JsonConvert.SerializeObject(transction_detail), "update", "hash"));
                                
                                }
                                end_blockchaintime = DateTime.Now.ToString(" yyyMMdd HH:mm:ss.ffffff");
                                blockchaintime.Stop();


                                Console.WriteLine("Blockchain encode " + encode_type + " :  " + i.ToString() + "=====> chain " + chain);



                                ins_db.Add("chain", chain);
                                ins_db.Add("valid", chainflow.IsValid());
                                ins_db.Add("encoding", encode_type);
                                ins_db.Add("sequence", total.ToString());
                                ins_db.Add("block", newblock);
                                ins_db.Add("lastblock", chainflow.GetLatestBlock().PreviousHash);
                                ins_db.Add("file", filename);
                                ins_db.Add("dataspace", filesize.ToString());
                                ins_db.Add("content_size", base64String.Length);
                                ins_db.Add("hash_space", hash.Length);
                                ins_db.Add("content_identity", Blockchain_model.identity_value(hash.ToString()));
                                ins_db.Add("encodeing_start", start_encodetime);
                                ins_db.Add("encodeing_end", end_encodetime);
                                ins_db.Add("encoding_avg", encodetime.Elapsed.TotalMilliseconds);
                                ins_db.Add("block_start", start_blockchaintime);
                                ins_db.Add("block_end", end_blockchaintime);
                                ins_db.Add("block_avg", blockchaintime.Elapsed.TotalMilliseconds);
                                ins_db.Add("remark1", DateTime.Now.ToString("yyyMMdd HH:mm:ss.ffffff"));
                                //ins_db.Add("remark2", "");

                                Edocumentmng.t_log_blockchain_performance(JsonConvert.SerializeObject(ins_db));


                                break;
                            default:

                                break;

                        }


                       


                    
                        // Edocumentmng.insertDocument("ite_Methodlogy_Blockchain", base64String, filename, encode_type, hash);
                        // Edocumentmng.t_log_performance("ite_Methodlogy_Blockchain", filename, encode_type, start_encodetime.ToString(), end_encodetime.ToString(), "", filesize.ToString(), avg, hash);
                        // Edocumentmng.t_log_blockchain_performance("ite_Methodlogy_Blockchain", filename, encode_type, start_encodetime.ToString(), end_encodetime.ToString(), "", filesize.ToString(), avg, start_blockchaintime.ToString(), end_blockchaintime.ToString(), avg_blockchain, filename, filesize.ToString(), base64String.Length.ToString(), Blockchain_model.identity_value(hash.ToString()), hash.Length.ToString(), hash);



                    }
                }
            }
            process_screen.Stop();
            Console.WriteLine("Time Processing =====================================> "+ process_screen.Elapsed.TotalSeconds);

            Thread.Sleep(1000);
            string response = JsonConvert.SerializeObject(chain_status);

            // log.info("End ======================Tiger Upload=====================");
            return response;
        }

        public static string blockchain_documentsp(string filename)
        {

            string chain = DateTime.Now.ToString("yyyMMdd_HH_mm_ss_") + filename;

            Blockchain chainflow = new Blockchain(chain, "new");


            var chain_status = new Dictionary<object, object>();
            var newblock = "";

            chainflow.AddBlock(new Block(0, DateTime.Now, null, chain, "firstblock", "", "firstblock", "new", "hash"));


            Stopwatch process_screen = new Stopwatch();
            process_screen.Start();


            int[] countlist = { 10, 100, 1000, 10000,100000 };

            foreach (int countdata in countlist)
            {

                int total = countdata;

                Console.WriteLine(" RUN : Start ==========> Count : " + total);

                object[] encodlist = { "md5", "sha", "sha256", "sha512", "aes" };

                foreach (var encodeing in encodlist)
                {
                    string encode_type = encodeing.ToString();


                    for (int i = 1; i <= total; i++)
                    {
                        string default_env = "dev"; // --dev -- Evo_pc -- Evo_mini  -- aeautnp 

                        string path = "";


                        if (default_env == "Evo_pc")
                        {

                            path = "C:\\Users\\Evolution\\Desktop\\Methodology_Blockchain\\Appdata\\" + filename;
                        }
                        if (default_env == "Evo_mini")
                        {
                            path = "C:\\Users\\Evolution\\Desktop\\Methodology_Blockchain\\Appdata\\" + filename;
                        }
                        if (default_env == "aeautnp")
                        {
                            path = "/Users/tanaporn/Desktop/Methodology_Blockchain/Appdata/" + filename;
                        }
                        else if (default_env == "dev")
                        {
                            path = fileinpath(filename);

                        }


                        FileInfo f = new FileInfo(path);
                        long filesize = f.Length;

                        string base64String = "";
                        // string path = "";
                        using (Image image = Image.FromFile(path))
                        {
                            using (MemoryStream m = new MemoryStream())
                            {
                                image.Save(m, image.RawFormat);
                                byte[] imageBytes = m.ToArray();
                                base64String = Convert.ToBase64String(imageBytes);

                            }
                        }


                        Encryption_model encode = new Encryption_model();
                        var hash = "";
                        Stopwatch encodetime = new Stopwatch();
                        Stopwatch blockchaintime = new Stopwatch();


                        string start_encodetime = "";
                        string end_encodetime = "";

                        string start_blockchaintime = "";
                        string end_blockchaintime = "";

                        var ins_db = new Dictionary<object, object>();

                        switch (encode_type)
                        {
                            case "md5":

                                encodetime.Start();
                                start_encodetime = DateTime.Now.ToString(" yyyMMdd HH:mm:ss.ffffff");
                                hash = encode.md5(base64String);
                                end_encodetime = DateTime.Now.ToString(" yyyMMdd HH:mm:ss.ffffff");
                                encodetime.Stop();
                                blockchaintime.Start();
                                start_blockchaintime = DateTime.Now.ToString(" yyyMMdd HH:mm:ss.ffffff");



                                using (MemoryStream ms = new MemoryStream())
                                {
                                    var transction_detail = new Dictionary<object, object>();
                                    transction_detail.Add("filename", filename);
                                    transction_detail.Add("filesize", filesize.ToString());
                                    transction_detail.Add("content_size", base64String.Length);
                                    transction_detail.Add("content_identity", Blockchain_model.identity_value(hash.ToString()));
                                    transction_detail.Add("hash_size", hash.Length);
                                    transction_detail.Add("modifydate", DateTime.Now.ToString(" yyyMMdd HH:mm:ss"));


                                    //var param = new Dictionary<object, object>();
                                    //param.Add("Chain_valid", chainflow.IsValid());
                                    //param.Add("encodeing", encode_type);
                                    //param.Add("chain", filename);
                                    //param.Add("identity", Blockchain_model.identity_value(hash.ToString()));
                                    //param.Add("data", base64String);
                                    //param.Add("description", JsonConvert.SerializeObject(transction_detail));

                                    newblock = chainflow.AddBlock(new Block(0, DateTime.Now, null, chain, Blockchain_model.identity_value(hash.ToString()), "", JsonConvert.SerializeObject(transction_detail), "update", "hash"));

                                }
                                end_blockchaintime = DateTime.Now.ToString(" yyyMMdd HH:mm:ss.ffffff");
                                blockchaintime.Stop();

                                Console.WriteLine("Blockchain encode " + encode_type + " :  " + i.ToString() + "=====> chain " + chain);



                                ins_db.Add("chain", chain);
                                ins_db.Add("valid", chainflow.IsValid());
                                ins_db.Add("encoding", encode_type);
                                ins_db.Add("sequence", total.ToString());
                                ins_db.Add("block", newblock);
                                ins_db.Add("lastblock", chainflow.GetLatestBlock().PreviousHash);
                                ins_db.Add("file", filename);
                                ins_db.Add("dataspace", filesize.ToString());
                                ins_db.Add("content_size", base64String.Length);
                                ins_db.Add("hash_space", hash.Length);
                                ins_db.Add("content_identity", Blockchain_model.identity_value(hash.ToString()));
                                ins_db.Add("encodeing_start", start_encodetime);
                                ins_db.Add("encodeing_end", end_encodetime);
                                ins_db.Add("encoding_avg", encodetime.Elapsed.TotalMilliseconds);
                                ins_db.Add("block_start", start_blockchaintime);
                                ins_db.Add("block_end", end_blockchaintime);
                                ins_db.Add("block_avg", blockchaintime.Elapsed.TotalMilliseconds);
                                ins_db.Add("remark1", DateTime.Now.ToString("yyyMMdd HH:mm:ss.ffffff"));
                                //ins_db.Add("remark2", "");

                                Edocumentmng.t_log_blockchain_performance(JsonConvert.SerializeObject(ins_db));



                                break;
                            case "sha":
                                encodetime.Start();
                                start_encodetime = DateTime.Now.ToString(" yyyMMdd HH:mm:ss.ffffff");
                                hash = encode.sha(base64String);
                                end_encodetime = DateTime.Now.ToString(" yyyMMdd HH:mm:ss.ffffff");
                                encodetime.Stop();
                                blockchaintime.Start();
                                start_blockchaintime = DateTime.Now.ToString(" yyyMMdd HH:mm:ss.ffffff");
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    var transction_detail = new Dictionary<object, object>();
                                    transction_detail.Add("filename", filename);
                                    transction_detail.Add("filesize", filesize.ToString());
                                    transction_detail.Add("content_size", base64String.Length);
                                    transction_detail.Add("content_identity", Blockchain_model.identity_value(hash.ToString()));
                                    transction_detail.Add("hash_size", hash.Length);
                                    transction_detail.Add("modifydate", DateTime.Now.ToString(" yyyMMdd HH:mm:ss"));


                                    //var param = new Dictionary<object, object>();
                                    //param.Add("Chain_valid", chainflow.IsValid());
                                    //param.Add("encodeing", encode_type);
                                    //param.Add("chain", filename);
                                    //param.Add("identity", Blockchain_model.identity_value(hash.ToString()));
                                    //param.Add("data", base64String);
                                    //param.Add("description", JsonConvert.SerializeObject(transction_detail));

                                    newblock = chainflow.AddBlock(new Block(0, DateTime.Now, null, chain, Blockchain_model.identity_value(hash.ToString()), "", JsonConvert.SerializeObject(transction_detail), "update", "hash"));

                                }
                                end_blockchaintime = DateTime.Now.ToString(" yyyMMdd HH:mm:ss.ffffff");
                                blockchaintime.Stop();


                                Console.WriteLine("Blockchain encode " + encode_type + " :  " + i.ToString() + "=====> chain " + chain);



                                ins_db.Add("chain", chain);
                                ins_db.Add("valid", chainflow.IsValid());
                                ins_db.Add("encoding", encode_type);
                                ins_db.Add("sequence", total.ToString());
                                ins_db.Add("block", newblock);
                                ins_db.Add("lastblock", chainflow.GetLatestBlock().PreviousHash);
                                ins_db.Add("file", filename);
                                ins_db.Add("dataspace", filesize.ToString());
                                ins_db.Add("content_size", base64String.Length);
                                ins_db.Add("hash_space", hash.Length);
                                ins_db.Add("content_identity", Blockchain_model.identity_value(hash.ToString()));
                                ins_db.Add("encodeing_start", start_encodetime);
                                ins_db.Add("encodeing_end", end_encodetime);
                                ins_db.Add("encoding_avg", encodetime.Elapsed.TotalMilliseconds);
                                ins_db.Add("block_start", start_blockchaintime);
                                ins_db.Add("block_end", end_blockchaintime);
                                ins_db.Add("block_avg", blockchaintime.Elapsed.TotalMilliseconds);
                                ins_db.Add("remark1", DateTime.Now.ToString("yyyMMdd HH:mm:ss.ffffff"));
                                //ins_db.Add("remark2", "");

                                Edocumentmng.t_log_blockchain_performance(JsonConvert.SerializeObject(ins_db));
                                break;
                            case "sha256":
                                encodetime.Start();
                                start_encodetime = DateTime.Now.ToString(" yyyMMdd HH:mm:ss.ffffff");
                                hash = encode.sha256(base64String);
                                end_encodetime = DateTime.Now.ToString(" yyyMMdd HH:mm:ss.ffffff");
                                encodetime.Stop();
                                blockchaintime.Start();
                                start_blockchaintime = DateTime.Now.ToString(" yyyMMdd HH:mm:ss.ffffff");
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    var transction_detail = new Dictionary<object, object>();
                                    transction_detail.Add("filesize", filesize.ToString());
                                    transction_detail.Add("content_size", base64String.Length);
                                    transction_detail.Add("content_identity", Blockchain_model.identity_value(hash.ToString()));
                                    transction_detail.Add("hash_size", hash.Length);
                                    transction_detail.Add("modifydate", DateTime.Now.ToString(" yyyMMdd HH:mm:ss"));

                                    //var param = new Dictionary<object, object>();
                                    //param.Add("Chain_valid", chainflow.IsValid());
                                    //param.Add("encodeing", encode_type);
                                    //param.Add("chain", filename);
                                    //param.Add("identity", Blockchain_model.identity_value(hash.ToString()));
                                    //param.Add("data", base64String);
                                    //param.Add("description", JsonConvert.SerializeObject(transction_detail));

                                    newblock = chainflow.AddBlock(new Block(0, DateTime.Now, null, chain, Blockchain_model.identity_value(hash.ToString()), "", JsonConvert.SerializeObject(transction_detail), "update", "hash"));

                                }
                                end_blockchaintime = DateTime.Now.ToString(" yyyMMdd HH:mm:ss.ffffff");
                                blockchaintime.Stop();

                                Console.WriteLine("Blockchain encode " + encode_type + " :  " + i.ToString() + "=====> chain " + chain);



                                ins_db.Add("chain", chain);
                                ins_db.Add("valid", chainflow.IsValid());
                                ins_db.Add("encoding", encode_type);
                                ins_db.Add("sequence", total.ToString());
                                ins_db.Add("block", newblock);
                                ins_db.Add("lastblock", chainflow.GetLatestBlock().PreviousHash);
                                ins_db.Add("file", filename);
                                ins_db.Add("dataspace", filesize.ToString());
                                ins_db.Add("content_size", base64String.Length);
                                ins_db.Add("hash_space", hash.Length);
                                ins_db.Add("content_identity", Blockchain_model.identity_value(hash.ToString()));
                                ins_db.Add("encodeing_start", start_encodetime);
                                ins_db.Add("encodeing_end", end_encodetime);
                                ins_db.Add("encoding_avg", encodetime.Elapsed.TotalMilliseconds);
                                ins_db.Add("block_start", start_blockchaintime);
                                ins_db.Add("block_end", end_blockchaintime);
                                ins_db.Add("block_avg", blockchaintime.Elapsed.TotalMilliseconds);
                                ins_db.Add("remark1", DateTime.Now.ToString("yyyMMdd HH:mm:ss.ffffff"));
                                //ins_db.Add("remark2", "");

                                Edocumentmng.t_log_blockchain_performance(JsonConvert.SerializeObject(ins_db));

                                break;
                            case "sha512":
                                encodetime.Start();
                                start_encodetime = DateTime.Now.ToString(" yyyMMdd HH:mm:ss.ffffff");
                                hash = encode.sha512(base64String);
                                end_encodetime = DateTime.Now.ToString(" yyyMMdd HH:mm:ss.ffffff");
                                encodetime.Stop();
                                blockchaintime.Start();
                                start_blockchaintime = DateTime.Now.ToString(" yyyMMdd HH:mm:ss.ffffff");
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    var transction_detail = new Dictionary<object, object>();
                                    transction_detail.Add("filesize", filesize.ToString());
                                    transction_detail.Add("content_size", base64String.Length);
                                    transction_detail.Add("content_identity", Blockchain_model.identity_value(hash.ToString()));
                                    transction_detail.Add("hash_size", hash.Length);
                                    transction_detail.Add("modifydate", DateTime.Now.ToString(" yyyMMdd HH:mm:ss"));



                                    //var param = new Dictionary<object, object>();
                                    //param.Add("Chain_valid", chainflow.IsValid());
                                    //param.Add("encodeing", encode_type);
                                    //param.Add("chain", filename);
                                    //param.Add("identity", Blockchain_model.identity_value(hash.ToString()));
                                    //param.Add("data", base64String);
                                    //param.Add("description", JsonConvert.SerializeObject(transction_detail));

                                    newblock = chainflow.AddBlock(new Block(0, DateTime.Now, null, chain, Blockchain_model.identity_value(hash.ToString()), "", JsonConvert.SerializeObject(transction_detail), "update", "hash"));

                                }
                                end_blockchaintime = DateTime.Now.ToString(" yyyMMdd HH:mm:ss.ffffff");
                                blockchaintime.Stop();



                                Console.WriteLine("Blockchain encode " + encode_type + " :  " + i.ToString() + "=====> chain " + chain);



                                ins_db.Add("chain", chain);
                                ins_db.Add("valid", chainflow.IsValid());
                                ins_db.Add("encoding", encode_type);
                                ins_db.Add("sequence", total.ToString());
                                ins_db.Add("block", newblock);
                                ins_db.Add("lastblock", chainflow.GetLatestBlock().PreviousHash);
                                ins_db.Add("file", filename);
                                ins_db.Add("dataspace", filesize.ToString());
                                ins_db.Add("content_size", base64String.Length);
                                ins_db.Add("hash_space", hash.Length);
                                ins_db.Add("content_identity", Blockchain_model.identity_value(hash.ToString()));
                                ins_db.Add("encodeing_start", start_encodetime);
                                ins_db.Add("encodeing_end", end_encodetime);
                                ins_db.Add("encoding_avg", encodetime.Elapsed.TotalMilliseconds);
                                ins_db.Add("block_start", start_blockchaintime);
                                ins_db.Add("block_end", end_blockchaintime);
                                ins_db.Add("block_avg", blockchaintime.Elapsed.TotalMilliseconds);
                                ins_db.Add("remark1", DateTime.Now.ToString("yyyMMdd HH:mm:ss.ffffff"));
                                //ins_db.Add("remark2", "");

                                Edocumentmng.t_log_blockchain_performance(JsonConvert.SerializeObject(ins_db));



                                //Console.WriteLine("Blockchain encode " + encode_type + " :  " + i.ToString() + "=====> chain " + chain);
                                //Console.WriteLine("Blockchain encode " + encode_type + " :  " + i.ToString() + "=====> Valid " + chainflow.IsValid());

                                //Console.WriteLine("Blockchain encode " + encode_type + " :  " + i.ToString() + "=====> method " + encode_type);
                                //Console.WriteLine("Blockchain encode " + encode_type + " :  " + i.ToString() + "=====> sequence " + total.ToString());

                                //Console.WriteLine("Blockchain encode " + encode_type + " :  " + i.ToString() + "=====> block " + newblock);
                                //Console.WriteLine("Blockchain encode " + encode_type + " :  " + i.ToString() + "=====> lastblock " + chainflow.GetLatestBlock().PreviousHash);

                                //Console.WriteLine("Blockchain encode " + encode_type + " :  " + i.ToString() + "=====> filename " + filename);
                                //Console.WriteLine("Blockchain encode " + encode_type + " :  " + i.ToString() + "=====> filesize " + filesize.ToString());

                                //Console.WriteLine("Blockchain encode " + encode_type + " :  " + i.ToString() + "=====> content_size " + base64String.Length);
                                //Console.WriteLine("Blockchain encode " + encode_type + " :  " + i.ToString() + "=====> hash_size " + hash.Length);
                                //Console.WriteLine("Blockchain encode " + encode_type + " :  " + i.ToString() + "=====> content_identity " + Blockchain_model.identity_value(hash.ToString()));


                                //Console.WriteLine("Blockchain encode " + encode_type + " :  " + i.ToString() + "=====> encode Start " + start_encodetime);
                                //Console.WriteLine("Blockchain encode " + encode_type + " :  " + i.ToString() + "=====> encode End " + end_encodetime);
                                //Console.WriteLine("Blockchain encode " + encode_type + " :  " + i.ToString() + "=====> encode Avg " + encodetime.Elapsed.TotalMilliseconds);

                                //Console.WriteLine("Blockchain encode " + encode_type + " :  " + i.ToString() + "=====> Blockchain Start " + start_blockchaintime);
                                //Console.WriteLine("Blockchain encode " + encode_type + " :  " + i.ToString() + "=====> Blockchain End " + end_blockchaintime);
                                //Console.WriteLine("Blockchain encode " + encode_type + " :  " + i.ToString() + "=====> Blockchain Avg " + blockchaintime.Elapsed.TotalMilliseconds);

                                break;
                            case "aes":
                                encodetime.Start();
                                start_encodetime = DateTime.Now.ToString(" yyyMMdd HH:mm:ss.ffffff");
                                hash = encode.encode_aes("encrypt", base64String);
                                end_encodetime = DateTime.Now.ToString(" yyyMMdd HH:mm:ss.ffffff");
                                encodetime.Stop();
                                blockchaintime.Start();
                                start_blockchaintime = DateTime.Now.ToString(" yyyMMdd HH:mm:ss.ffffff");
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    var transction_detail = new Dictionary<object, object>();
                                    transction_detail.Add("filesize", filesize.ToString());
                                    transction_detail.Add("content_size", base64String.Length);
                                    transction_detail.Add("content_identity", Blockchain_model.identity_value(hash.ToString()));
                                    transction_detail.Add("hash_size", hash.Length);
                                    transction_detail.Add("modifydate", DateTime.Now.ToString(" yyyMMdd HH:mm:ss"));



                                    //var param = new Dictionary<object, object>();
                                    //param.Add("Chain_valid", chainflow.IsValid());
                                    //param.Add("encodeing", encode_type);
                                    //param.Add("chain", filename);
                                    //param.Add("identity", Blockchain_model.identity_value(hash.ToString()));
                                    //param.Add("data", base64String);
                                    //param.Add("description", JsonConvert.SerializeObject(transction_detail));


                                    newblock = chainflow.AddBlock(new Block(0, DateTime.Now, null, chain, Blockchain_model.identity_value(hash.ToString()), "", JsonConvert.SerializeObject(transction_detail), "update", "hash"));

                                }
                                end_blockchaintime = DateTime.Now.ToString(" yyyMMdd HH:mm:ss.ffffff");
                                blockchaintime.Stop();


                                Console.WriteLine("Blockchain encode " + encode_type + " :  " + i.ToString() + "=====> chain " + chain);



                                ins_db.Add("chain", chain);
                                ins_db.Add("valid", chainflow.IsValid());
                                ins_db.Add("encoding", encode_type);
                                ins_db.Add("sequence", total.ToString());
                                ins_db.Add("block", newblock);
                                ins_db.Add("lastblock", chainflow.GetLatestBlock().PreviousHash);
                                ins_db.Add("file", filename);
                                ins_db.Add("dataspace", filesize.ToString());
                                ins_db.Add("content_size", base64String.Length);
                                ins_db.Add("hash_space", hash.Length);
                                ins_db.Add("content_identity", Blockchain_model.identity_value(hash.ToString()));
                                ins_db.Add("encodeing_start", start_encodetime);
                                ins_db.Add("encodeing_end", end_encodetime);
                                ins_db.Add("encoding_avg", encodetime.Elapsed.TotalMilliseconds);
                                ins_db.Add("block_start", start_blockchaintime);
                                ins_db.Add("block_end", end_blockchaintime);
                                ins_db.Add("block_avg", blockchaintime.Elapsed.TotalMilliseconds);
                                ins_db.Add("remark1", DateTime.Now.ToString("yyyMMdd HH:mm:ss.ffffff"));
                                //ins_db.Add("remark2", "");

                                Edocumentmng.t_log_blockchain_performance(JsonConvert.SerializeObject(ins_db));


                                break;
                            default:

                                break;

                        }






                        // Edocumentmng.insertDocument("ite_Methodlogy_Blockchain", base64String, filename, encode_type, hash);
                        // Edocumentmng.t_log_performance("ite_Methodlogy_Blockchain", filename, encode_type, start_encodetime.ToString(), end_encodetime.ToString(), "", filesize.ToString(), avg, hash);
                        // Edocumentmng.t_log_blockchain_performance("ite_Methodlogy_Blockchain", filename, encode_type, start_encodetime.ToString(), end_encodetime.ToString(), "", filesize.ToString(), avg, start_blockchaintime.ToString(), end_blockchaintime.ToString(), avg_blockchain, filename, filesize.ToString(), base64String.Length.ToString(), Blockchain_model.identity_value(hash.ToString()), hash.Length.ToString(), hash);



                    }
                }
            }
            process_screen.Stop();
            Console.WriteLine("Time Processing =====================================> " + process_screen.Elapsed.TotalSeconds);

            Thread.Sleep(1000);

            string response = JsonConvert.SerializeObject(chain_status);

            // log.info("End ======================Tiger Upload=====================");
            return response;
        }


        public string bitmap()
        {
            Logmodel log = new Logmodel();
            var path = Path.Combine(Directory.GetCurrentDirectory() + "/App_data/", "totoro.jpg");
            var dest = Path.Combine(Directory.GetCurrentDirectory() + "/App_data/", "C_totoro.jpg");

            log.info(" File path : " + path.ToString());
            log.info(" File path : " + dest.ToString());


            System.Drawing.Image bitmap = (System.Drawing.Image)Bitmap.FromFile(path); // set image                                                                                                              //draw the image object using a Graphics object
            Graphics graphicsImage = Graphics.FromImage(bitmap);

            StringFormat stringformat = new StringFormat();
            stringformat.Alignment = StringAlignment.Far;
            stringformat.LineAlignment = StringAlignment.Far;

            Color StringColor = System.Drawing.ColorTranslator.FromHtml("#933eea");
            string text = "testtest";

            graphicsImage.DrawString(text, new Font("arial", 40,
            FontStyle.Regular), new SolidBrush(StringColor), new Point(220, 150),
            stringformat);

            bitmap.Save(dest, ImageFormat.Jpeg);

            return "ok";
        }

        public static string fileinpath(string filename)
        {

            var osprocess = GetOsPlatform();

            var appRoot = "";
            string appdata = "";
            string path = "";

            switch (osprocess)
            {
                case "LINUX":
                    //appRoot = apppath();
                    appRoot = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"));
                    appdata = appRoot + "/Appdata/" + filename;
                    path = appdata;
                    break;
                case "WINDOWS":
                    //appRoot = apppath();
                    appRoot = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"));
                    appdata = appRoot + "\\Appdata\\" + filename;
                    path = appdata;
                    break;
                case "OSX":
                    //appRoot = apppath();
                    appRoot = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"));
                    appdata = appRoot + "/Appdata/" + filename;
                    path = appdata;
                    break;

                default:
                    //appRoot = apppath();
                    appRoot = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"));
                    appdata = appRoot + "/Appdata/" + filename;
                    path = appdata;

                    break;

            }

            return path;
        }
        public static string resultinpath(string filename)
        {

            var osprocess = GetOsPlatform();

            var appRoot = "";
            string appdata = "";
            string path = "";

            switch (osprocess)
            {
                case "LINUX":


                   //appRoot = apppath();
                    appRoot = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"));
                    appdata = appRoot + "/Result/" + filename;
                    path = appdata;
                    break;
                case "WINDOWS":
                    //appRoot = apppath();
                    appRoot = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"));
                    appdata = appRoot + "\\Result\\" + filename;
                    path = appdata;
                    break;
                case "OSX":
                    //appRoot = apppath();
                    appRoot = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"));
                    appdata = appRoot + "/Result/" + filename;
                    path = appdata;
                    break;

                default:
                    //appRoot = apppath();
                    appRoot = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"));
                    appdata = appRoot + "/Result/" + filename;
                    path = appdata;

                    break;

            }

            return path;
        }
       
        enum OS
        {
            LINUX,
            WINDOWS,
            OSX
        }

        public static string GetOsPlatform()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return OS.WINDOWS.ToString();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return OS.LINUX.ToString();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return OS.OSX.ToString();
            }

            throw new Exception("PdfGenerator: OS Environment could not be probed, halting!");
        }

        public static string chain_checker(string filename) {

           // string filename = "md5.jpg";
            var chain_status = new Dictionary<object, object>();


            var param = new Dictionary<object, object>();
            param.Add("chain", filename);
            param.Add("identity", Blockchain_model.identity_value(""));
            param.Add("data", "");
            param.Add("description", "");

         //   chain_status = Blockchain_model.blockchain_valid(JsonConvert.SerializeObject(param));

            return JsonConvert.SerializeObject(chain_status);
        }

        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats officedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }

       
     



    }
}
