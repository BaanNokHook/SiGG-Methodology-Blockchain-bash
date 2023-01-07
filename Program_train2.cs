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
using Newtonsoft.Json.Linq;

namespace Methodology_Blockchain_bash
{
    class Program_train2
    {
    
        public static string blockchain_documentspcial1()
        {

            string chain = DateTime.Now.ToString("yyyMMdd_HH_mm_ss_") + "train_index";
            Blockchain chainflow = new Blockchain(chain, "new");

            var consolidatedata = "";
            var chain_status = new Dictionary<object, object>();
            var newblock = "";
            var filename = "";
            var gen_block = "";
            gen_block = chainflow.AddBlock(new Block(0, DateTime.Now, null, chain, "firstblock", "", "firstblock", "new", "hash"));

            var gen_db = new Dictionary<object, object>();

            gen_db.Add("chain", chain);
            gen_db.Add("valid", "");
            gen_db.Add("encoding", "");
            gen_db.Add("sequence", "");
            gen_db.Add("block", gen_block);
            gen_db.Add("lastblock", "{}");
            gen_db.Add("file", "");
            gen_db.Add("dataspace", "");
            gen_db.Add("content_size", "");
            gen_db.Add("hash_space", "");
            gen_db.Add("content_identity", "");
            gen_db.Add("encodeing_start", "");
            gen_db.Add("encodeing_end", "");
            gen_db.Add("encoding_avg", "");
            gen_db.Add("block_start", "");
            gen_db.Add("block_end", "");
            gen_db.Add("block_avg", "");
            gen_db.Add("remark1", DateTime.Now.ToString("yyyMMdd HH:mm:ss.ffffff"));
            //ins_db.Add("remark2", "");

            Edocumentmng.t_log_blockchain_performance(JsonConvert.SerializeObject(gen_db));



            Stopwatch process_screen = new Stopwatch();
            process_screen.Start();


            int[] countlist = {10,100,1000,10000};
            foreach (int countdata in countlist)
            {

                int total = countdata;

                Console.WriteLine(" RUN : Start ==========> Count : " + total);

                object[] encodlist = { "aes" };

                foreach (var encodeing in encodlist)
                {
                    string encode_type = encodeing.ToString();


                    for (int i = 1; i <= total; i++)
                    {
                        string default_env = "dev"; // --dev -- Evo_pc -- Evo_mini  -- aeautnp 

                        string path = "";


                        
                        

                        if (i.ToString() == "1")
                        {
                             filename = "1.jpg";
                        }
                        else {

                             filename = "2.jpg";
                        }




                        if (default_env == "Evo_pc")
                        {

                            path = "C:\\Users\\Evolution\\Desktop\\Methodology_Blockchain\\Appdata\\train\\" + filename;
                        }
                        if (default_env == "Evo_mini")
                        {
                            path = "C:\\Users\\Evolution\\Desktop\\Methodology_Blockchain\\Appdata\\train\\" + filename;
                        }
                        if (default_env == "aeautnp")
                        {
                            path = "/Users/tanaporn/Desktop/Methodology_Blockchain/Appdata/train/" + filename;
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

                                // =================test ================================
                                if (i.ToString() == "20")
                                {
                                    consolidatedata = Program_test.blockchain_documentspcial1(chain, "1.jpg", "md5");
                                    Edocumentmng.t_log_blockchain_performance(consolidatedata);
                                }
                                else if (i.ToString() == "40")
                                {
                                    consolidatedata = Program_test.blockchain_documentspcial1(chain, "2.jpg", "md5");
                                    Edocumentmng.t_log_blockchain_performance(consolidatedata);
                                }
                                else if (i.ToString() == "60")
                                {
                                    consolidatedata = Program_test.blockchain_documentspcial1(chain, "3.jpg", "md5");
                                    Edocumentmng.t_log_blockchain_performance(consolidatedata);
                                }
                                else if (i.ToString() == "80")
                                {
                                    consolidatedata = Program_test.blockchain_documentspcial1(chain, "4.jpg", "md5");
                                    Edocumentmng.t_log_blockchain_performance(consolidatedata);
                                }
                                else if (i.ToString() == "100")
                                {
                                    consolidatedata = Program_test.blockchain_documentspcial1(chain, "5.jpg", "md5");
                                    Edocumentmng.t_log_blockchain_performance(consolidatedata);
                                }

                                //====================== test ===========================




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

                                // =================test ================================
                                if (i.ToString() == "20")
                                {
                                    consolidatedata = Program_test.blockchain_documentspcial1(chain, "1.jpg", "sha");
                                    Edocumentmng.t_log_blockchain_performance(consolidatedata);
                                }
                                else if (i.ToString() == "40")
                                {
                                    consolidatedata = Program_test.blockchain_documentspcial1(chain, "2.jpg", "sha");
                                    Edocumentmng.t_log_blockchain_performance(consolidatedata);
                                }
                                else if (i.ToString() == "60")
                                {
                                    consolidatedata = Program_test.blockchain_documentspcial1(chain, "3.jpg", "sha");
                                    Edocumentmng.t_log_blockchain_performance(consolidatedata);
                                }
                                else if (i.ToString() == "80")
                                {
                                    consolidatedata = Program_test.blockchain_documentspcial1(chain, "4.jpg", "sha");
                                    Edocumentmng.t_log_blockchain_performance(consolidatedata);
                                }
                                else if (i.ToString() == "100")
                                {
                                    consolidatedata = Program_test.blockchain_documentspcial1(chain, "5.jpg", "sha");
                                    Edocumentmng.t_log_blockchain_performance(consolidatedata);
                                }

                                //====================== test ===========================


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

                                // =================test ================================
                                if (i.ToString() == "20")
                                {
                                    consolidatedata = Program_test.blockchain_documentspcial1(chain, "1.jpg", "sha256");
                                    Edocumentmng.t_log_blockchain_performance(consolidatedata);
                                }
                                else if (i.ToString() == "40")
                                {
                                    consolidatedata = Program_test.blockchain_documentspcial1(chain, "2.jpg", "sha256");
                                    Edocumentmng.t_log_blockchain_performance(consolidatedata);
                                }
                                else if (i.ToString() == "60")
                                {
                                    consolidatedata = Program_test.blockchain_documentspcial1(chain, "3.jpg", "sha256");
                                    Edocumentmng.t_log_blockchain_performance(consolidatedata);
                                }
                                else if (i.ToString() == "80")
                                {
                                    consolidatedata = Program_test.blockchain_documentspcial1(chain, "4.jpg", "sha256");
                                    Edocumentmng.t_log_blockchain_performance(consolidatedata);
                                }
                                else if (i.ToString() == "100")
                                {
                                    consolidatedata = Program_test.blockchain_documentspcial1(chain, "5.jpg", "sha256");
                                    Edocumentmng.t_log_blockchain_performance(consolidatedata);
                                }

                                //====================== test ===========================


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


                                // =================test ================================
                                if (i.ToString() == "20")
                                {
                                    consolidatedata = Program_test.blockchain_documentspcial1(chain, "1.jpg", "sha512");
                                    Edocumentmng.t_log_blockchain_performance(consolidatedata);
                                }
                                else if (i.ToString() == "40")
                                {
                                    consolidatedata = Program_test.blockchain_documentspcial1(chain, "2.jpg", "sha512");
                                    Edocumentmng.t_log_blockchain_performance(consolidatedata);
                                }
                                else if (i.ToString() == "60")
                                {
                                    consolidatedata = Program_test.blockchain_documentspcial1(chain, "3.jpg", "sha512");
                                    Edocumentmng.t_log_blockchain_performance(consolidatedata);
                                }
                                else if (i.ToString() == "80")
                                {
                                    consolidatedata = Program_test.blockchain_documentspcial1(chain, "4.jpg", "sha512");
                                    Edocumentmng.t_log_blockchain_performance(consolidatedata);
                                }
                                else if (i.ToString() == "100")
                                {
                                    consolidatedata = Program_test.blockchain_documentspcial1(chain, "5.jpg", "sha512");
                                    Edocumentmng.t_log_blockchain_performance(consolidatedata);
                                }

                                //====================== test ===========================


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

                                // =================test ================================
                                //if (i.ToString() == "20")
                                //{
                                //    consolidatedata = Program_test.blockchain_documentspcial1(chain, "1.jpg", "aes");
                                //    Edocumentmng.t_log_blockchain_performance(consolidatedata);
                                //}
                                //else if (i.ToString() == "40")
                                //{
                                //    consolidatedata = Program_test.blockchain_documentspcial1(chain, "2.jpg", "aes");
                                //    Edocumentmng.t_log_blockchain_performance(consolidatedata);
                                //}
                                //else if (i.ToString() == "60")
                                //{
                                //    consolidatedata = Program_test.blockchain_documentspcial1(chain, "3.jpg", "aes");
                                //    Edocumentmng.t_log_blockchain_performance(consolidatedata);
                                //}
                                //else if (i.ToString() == "80")
                                //{
                                //   consolidatedata = Program_test.blockchain_documentspcial1(chain, "4.jpg", "aes");
                                //   Edocumentmng.t_log_blockchain_performance(consolidatedata);
                                //}
                                //else if (i.ToString() == "100")
                                //{
                                //    consolidatedata = Program_test.blockchain_documentspcial1(chain, "5.jpg", "aes");
                                //   Edocumentmng.t_log_blockchain_performance(consolidatedata);
                                //}

                                if (i.ToString() == countdata.ToString())
                                {
                                    var ins_consolidate = new Dictionary<object, object>();
                                    consolidatedata = Program_test.blockchain_documentspcial1(chain, "1.jpg", "aes");

                                    var test_data_result = JObject.Parse(consolidatedata);
                                    //newblock = chainflow.AddBlock(new Block(0, DateTime.Now, null, chain, test_data_result["content_identity"].ToString(), "", consolidatedata, "update", "hash"));
                                    ins_consolidate.Add("chain", chain);
                                    ins_consolidate.Add("valid", chainflow.IsValid());
                                    ins_consolidate.Add("encoding", test_data_result["encoding"].ToString());
                                    ins_consolidate.Add("sequence","");
                                    ins_consolidate.Add("block", chainflow.AddBlock(new Block(0, DateTime.Now, null, chain, test_data_result["content_identity"].ToString(), "", consolidatedata, "update", "hash")));
                                    ins_consolidate.Add("lastblock", chainflow.GetLatestBlock().PreviousHash);
                                    ins_consolidate.Add("file", test_data_result["file"].ToString());
                                    ins_consolidate.Add("dataspace", test_data_result["dataspace"].ToString());
                                    ins_consolidate.Add("content_size", test_data_result["content_size"].ToString());
                                    ins_consolidate.Add("hash_space", test_data_result["hash_space"].ToString());
                                    ins_consolidate.Add("content_identity", test_data_result["content_identity"].ToString());
                                    ins_consolidate.Add("encodeing_start", test_data_result["encodeing_start"].ToString());
                                    ins_consolidate.Add("encodeing_end", test_data_result["encodeing_end"].ToString());
                                    ins_consolidate.Add("encoding_avg", test_data_result["encoding_avg"].ToString());
                                    ins_consolidate.Add("block_start", test_data_result["block_start"].ToString());
                                    ins_consolidate.Add("block_end", test_data_result["block_end"].ToString());
                                    ins_consolidate.Add("block_avg", test_data_result["block_avg"].ToString());
                                    ins_consolidate.Add("remark1", DateTime.Now.ToString("yyyMMdd HH:mm:ss.ffffff"));

                                    Edocumentmng.t_log_blockchain_performance(JsonConvert.SerializeObject(ins_consolidate));


                                    //Edocumentmng.t_log_blockchain_performance(consolidatedata);
                                }
                                //====================== test ===========================



                                break;
                            default:

                                break;

                        }



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

        public static string blockchain_documentspcial2()
        {

            string chain = DateTime.Now.ToString("yyyMMdd_HH_mm_ss_") + "train_chain";
            Blockchain chainflow = new Blockchain(chain, "new");

            var consolidatedata = "";

            var chain_status = new Dictionary<object, object>();
            var newblock = "";
            var filename = "";
            var gen_block = "";
            gen_block = chainflow.AddBlock(new Block(0, DateTime.Now, null, chain, "firstblock", "", "firstblock", "new", "hash"));

           
            var gen_db = new Dictionary<object, object>();

            gen_db.Add("chain", chain);
            gen_db.Add("valid", "");
            gen_db.Add("encoding", "");
            gen_db.Add("sequence", "");
            gen_db.Add("block", gen_block);
            gen_db.Add("lastblock", "{}");
            gen_db.Add("file", "");
            gen_db.Add("dataspace", "");
            gen_db.Add("content_size", "");
            gen_db.Add("hash_space", "");
            gen_db.Add("content_identity", "");
            gen_db.Add("encodeing_start", "");
            gen_db.Add("encodeing_end", "");
            gen_db.Add("encoding_avg", "");
            gen_db.Add("block_start", "");
            gen_db.Add("block_end", "");
            gen_db.Add("block_avg", "");
            gen_db.Add("remark1", DateTime.Now.ToString("yyyMMdd HH:mm:ss.ffffff"));
            //ins_db.Add("remark2", "");

            Edocumentmng.t_log_blockchain_performance(JsonConvert.SerializeObject(gen_db));

            Stopwatch process_screen = new Stopwatch();
            process_screen.Start();


            int[] countlist = { 10,100,1000,10000 };
            foreach (int countdata in countlist)
            {

                int total = countdata;

                Console.WriteLine(" RUN : Start ==========> Count : " + total);

                object[] encodlist = {  "aes" };

                foreach (var encodeing in encodlist)
                {
                    string encode_type = encodeing.ToString();


                    for (int i = 1; i <= total; i++)
                    {
                        string default_env = "dev"; // --dev -- Evo_pc -- Evo_mini  -- aeautnp 

                        string path = "";

                        

                        if (i.ToString() == "1")
                        {
                            filename = "1.jpg";
                        }
                        else
                        {

                            filename = "2.jpg";
                        }



                        if (default_env == "Evo_pc")
                        {

                            path = "C:\\Users\\Evolution\\Desktop\\Methodology_Blockchain\\Appdata\\train\\" + filename;
                        }
                        if (default_env == "Evo_mini")
                        {
                            path = "C:\\Users\\Evolution\\Desktop\\Methodology_Blockchain\\Appdata\\train\\" + filename;
                        }
                        if (default_env == "aeautnp")
                        {
                            path = "/Users/tanaporn/Desktop/Methodology_Blockchain/Appdata/train/" + filename;
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
                        var ins_consolidate = new Dictionary<object, object>();

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
                                ins_db.Add("remark1", "train");
                                //ins_db.Add("remark2", "");

                                Edocumentmng.t_log_blockchain_performance(JsonConvert.SerializeObject(ins_db));

                                // =================test ================================
                                if (i.ToString() == "20")
                                {
                                    consolidatedata = Program_test.blockchain_documentspcial1(chain, "1.jpg", "md5");
                                    var test_data_result = JObject.Parse(consolidatedata);
                                    //newblock = chainflow.AddBlock(new Block(0, DateTime.Now, null, chain, test_data_result["content_identity"].ToString(), "", consolidatedata, "update", "hash"));
                                    ins_consolidate.Add("chain", chain);
                                    ins_consolidate.Add("valid", chainflow.IsValid());
                                    ins_consolidate.Add("encoding", test_data_result["encoding"].ToString());
                                    ins_consolidate.Add("sequence", total.ToString());
                                    ins_consolidate.Add("block", chainflow.AddBlock(new Block(0, DateTime.Now, null, chain, test_data_result["content_identity"].ToString(), "", consolidatedata, "update", "hash")));
                                    ins_consolidate.Add("lastblock", chainflow.GetLatestBlock().PreviousHash);
                                    ins_consolidate.Add("file", test_data_result["file"].ToString());
                                    ins_consolidate.Add("dataspace", test_data_result["dataspace"].ToString());
                                    ins_consolidate.Add("content_size", test_data_result["content_size"].ToString());
                                    ins_consolidate.Add("hash_space", test_data_result["hash_space"].ToString());
                                    ins_consolidate.Add("content_identity", test_data_result["content_identity"].ToString());
                                    ins_consolidate.Add("encodeing_start", test_data_result["encodeing_start"].ToString());
                                    ins_consolidate.Add("encodeing_end", test_data_result["encodeing_end"].ToString());
                                    ins_consolidate.Add("encoding_avg", test_data_result["encoding_avg"].ToString());
                                    ins_consolidate.Add("block_start", test_data_result["block_start"].ToString());
                                    ins_consolidate.Add("block_end", test_data_result["block_end"].ToString());
                                    ins_consolidate.Add("block_avg", test_data_result["block_avg"].ToString());
                                    ins_consolidate.Add("remark1", "test");

                                    Edocumentmng.t_log_blockchain_performance(JsonConvert.SerializeObject(ins_consolidate));
                                }
                                else if (i.ToString() == "40")
                                {
                                    consolidatedata = Program_test.blockchain_documentspcial1(chain, "2.jpg", "md5");
                                    var test_data_result = JObject.Parse(consolidatedata);
                                    newblock = chainflow.AddBlock(new Block(0, DateTime.Now, null, chain, test_data_result["content_identity"].ToString(), "", consolidatedata, "update", "hash"));
                                    ins_consolidate.Add("chain", chain);
                                    ins_consolidate.Add("valid", chainflow.IsValid());
                                    ins_consolidate.Add("encoding", test_data_result["encoding"].ToString());
                                    ins_consolidate.Add("sequence", total.ToString());
                                    ins_consolidate.Add("block", newblock);
                                    ins_consolidate.Add("lastblock", chainflow.GetLatestBlock().PreviousHash);
                                    ins_consolidate.Add("file", test_data_result["file"].ToString());
                                    ins_consolidate.Add("dataspace", test_data_result["dataspace"].ToString());
                                    ins_consolidate.Add("content_size", test_data_result["content_size"].ToString());
                                    ins_consolidate.Add("hash_space", test_data_result["hash_space"].ToString());
                                    ins_consolidate.Add("content_identity", test_data_result["content_identity"].ToString());
                                    ins_consolidate.Add("encodeing_start", test_data_result["encodeing_start"].ToString());
                                    ins_consolidate.Add("encodeing_end", test_data_result["encodeing_end"].ToString());
                                    ins_consolidate.Add("encoding_avg", test_data_result["encoding_avg"].ToString());
                                    ins_consolidate.Add("block_start", test_data_result["block_start"].ToString());
                                    ins_consolidate.Add("block_end", test_data_result["block_end"].ToString());
                                    ins_consolidate.Add("block_avg", test_data_result["block_avg"].ToString());
                                    ins_consolidate.Add("remark1", "test");

                                    Edocumentmng.t_log_blockchain_performance(JsonConvert.SerializeObject(ins_consolidate));
                                }
                                else if (i.ToString() == "60")
                                {
                                    consolidatedata = Program_test.blockchain_documentspcial1(chain, "3.jpg", "md5");
                                    var test_data_result = JObject.Parse(consolidatedata);
                                    newblock = chainflow.AddBlock(new Block(0, DateTime.Now, null, chain, test_data_result["content_identity"].ToString(), "", consolidatedata, "update", "hash"));
                                    ins_consolidate.Add("chain", chain);
                                    ins_consolidate.Add("valid", chainflow.IsValid());
                                    ins_consolidate.Add("encoding", test_data_result["encoding"].ToString());
                                    ins_consolidate.Add("sequence", total.ToString());
                                    ins_consolidate.Add("block", newblock);
                                    ins_consolidate.Add("lastblock", chainflow.GetLatestBlock().PreviousHash);
                                    ins_consolidate.Add("file", test_data_result["file"].ToString());
                                    ins_consolidate.Add("dataspace", test_data_result["dataspace"].ToString());
                                    ins_consolidate.Add("content_size", test_data_result["content_size"].ToString());
                                    ins_consolidate.Add("hash_space", test_data_result["hash_space"].ToString());
                                    ins_consolidate.Add("content_identity", test_data_result["content_identity"].ToString());
                                    ins_consolidate.Add("encodeing_start", test_data_result["encodeing_start"].ToString());
                                    ins_consolidate.Add("encodeing_end", test_data_result["encodeing_end"].ToString());
                                    ins_consolidate.Add("encoding_avg", test_data_result["encoding_avg"].ToString());
                                    ins_consolidate.Add("block_start", test_data_result["block_start"].ToString());
                                    ins_consolidate.Add("block_end", test_data_result["block_end"].ToString());
                                    ins_consolidate.Add("block_avg", test_data_result["block_avg"].ToString());
                                    ins_consolidate.Add("remark1", "test");

                                    Edocumentmng.t_log_blockchain_performance(JsonConvert.SerializeObject(ins_consolidate));
                                }
                                else if (i.ToString() == "80")
                                {
                                    consolidatedata = Program_test.blockchain_documentspcial1(chain, "4.jpg", "md5");
                                    var test_data_result = JObject.Parse(consolidatedata);
                                    newblock = chainflow.AddBlock(new Block(0, DateTime.Now, null, chain, test_data_result["content_identity"].ToString(), "", consolidatedata, "update", "hash"));
                                    ins_consolidate.Add("chain", chain);
                                    ins_consolidate.Add("valid", chainflow.IsValid());
                                    ins_consolidate.Add("encoding", test_data_result["encoding"].ToString());
                                    ins_consolidate.Add("sequence", total.ToString());
                                    ins_consolidate.Add("block", newblock);
                                    ins_consolidate.Add("lastblock", chainflow.GetLatestBlock().PreviousHash);
                                    ins_consolidate.Add("file", test_data_result["file"].ToString());
                                    ins_consolidate.Add("dataspace", test_data_result["dataspace"].ToString());
                                    ins_consolidate.Add("content_size", test_data_result["content_size"].ToString());
                                    ins_consolidate.Add("hash_space", test_data_result["hash_space"].ToString());
                                    ins_consolidate.Add("content_identity", test_data_result["content_identity"].ToString());
                                    ins_consolidate.Add("encodeing_start", test_data_result["encodeing_start"].ToString());
                                    ins_consolidate.Add("encodeing_end", test_data_result["encodeing_end"].ToString());
                                    ins_consolidate.Add("encoding_avg", test_data_result["encoding_avg"].ToString());
                                    ins_consolidate.Add("block_start", test_data_result["block_start"].ToString());
                                    ins_consolidate.Add("block_end", test_data_result["block_end"].ToString());
                                    ins_consolidate.Add("block_avg", test_data_result["block_avg"].ToString());
                                    ins_consolidate.Add("remark1", "test");

                                    Edocumentmng.t_log_blockchain_performance(JsonConvert.SerializeObject(ins_consolidate));
                                }
                                else if (i.ToString() == "100")
                                {
                                    consolidatedata = Program_test.blockchain_documentspcial1(chain, "5.jpg", "md5");
                                    var test_data_result = JObject.Parse(consolidatedata);
                                    newblock = chainflow.AddBlock(new Block(0, DateTime.Now, null, chain, test_data_result["content_identity"].ToString(), "", consolidatedata, "update", "hash"));
                                    ins_consolidate.Add("chain", chain);
                                    ins_consolidate.Add("valid", chainflow.IsValid());
                                    ins_consolidate.Add("encoding", test_data_result["encoding"].ToString());
                                    ins_consolidate.Add("sequence", total.ToString());
                                    ins_consolidate.Add("block", newblock);
                                    ins_consolidate.Add("lastblock", chainflow.GetLatestBlock().PreviousHash);
                                    ins_consolidate.Add("file", test_data_result["file"].ToString());
                                    ins_consolidate.Add("dataspace", test_data_result["dataspace"].ToString());
                                    ins_consolidate.Add("content_size", test_data_result["content_size"].ToString());
                                    ins_consolidate.Add("hash_space", test_data_result["hash_space"].ToString());
                                    ins_consolidate.Add("content_identity", test_data_result["content_identity"].ToString());
                                    ins_consolidate.Add("encodeing_start", test_data_result["encodeing_start"].ToString());
                                    ins_consolidate.Add("encodeing_end", test_data_result["encodeing_end"].ToString());
                                    ins_consolidate.Add("encoding_avg", test_data_result["encoding_avg"].ToString());
                                    ins_consolidate.Add("block_start", test_data_result["block_start"].ToString());
                                    ins_consolidate.Add("block_end", test_data_result["block_end"].ToString());
                                    ins_consolidate.Add("block_avg", test_data_result["block_avg"].ToString());
                                    ins_consolidate.Add("remark1", "test");

                                    Edocumentmng.t_log_blockchain_performance(JsonConvert.SerializeObject(ins_consolidate));
                                }

                                //====================== test ===========================




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
                                ins_db.Add("remark1","train");
                                //ins_db.Add("remark2", "");

                                Edocumentmng.t_log_blockchain_performance(JsonConvert.SerializeObject(ins_db));

                                // =================test ================================
                                if (i.ToString() == "20")
                                {
                                    consolidatedata = Program_test.blockchain_documentspcial1(chain, "1.jpg", "sha");
                                    var test_data_result = JObject.Parse(consolidatedata);
                                    newblock = chainflow.AddBlock(new Block(0, DateTime.Now, null, chain, test_data_result["content_identity"].ToString(), "", consolidatedata, "update", "hash"));
                                    ins_consolidate.Add("chain", chain);
                                    ins_consolidate.Add("valid", chainflow.IsValid());
                                    ins_consolidate.Add("encoding", test_data_result["encoding"].ToString());
                                    ins_consolidate.Add("sequence", total.ToString());
                                    ins_consolidate.Add("block", newblock);
                                    ins_consolidate.Add("lastblock", chainflow.GetLatestBlock().PreviousHash);
                                    ins_consolidate.Add("file", test_data_result["file"].ToString());
                                    ins_consolidate.Add("dataspace", test_data_result["dataspace"].ToString());
                                    ins_consolidate.Add("content_size", test_data_result["content_size"].ToString());
                                    ins_consolidate.Add("hash_space", test_data_result["hash_space"].ToString());
                                    ins_consolidate.Add("content_identity", test_data_result["content_identity"].ToString());
                                    ins_consolidate.Add("encodeing_start", test_data_result["encodeing_start"].ToString());
                                    ins_consolidate.Add("encodeing_end", test_data_result["encodeing_end"].ToString());
                                    ins_consolidate.Add("encoding_avg", test_data_result["encoding_avg"].ToString());
                                    ins_consolidate.Add("block_start", test_data_result["block_start"].ToString());
                                    ins_consolidate.Add("block_end", test_data_result["block_end"].ToString());
                                    ins_consolidate.Add("block_avg", test_data_result["block_avg"].ToString());
                                    ins_consolidate.Add("remark1", "test");

                                    Edocumentmng.t_log_blockchain_performance(JsonConvert.SerializeObject(ins_consolidate));
                                }
                                else if (i.ToString() == "40")
                                {
                                    consolidatedata = Program_test.blockchain_documentspcial1(chain, "2.jpg", "sha");
                                    var test_data_result = JObject.Parse(consolidatedata);
                                    newblock = chainflow.AddBlock(new Block(0, DateTime.Now, null, chain, test_data_result["content_identity"].ToString(), "", consolidatedata, "update", "hash"));
                                    ins_consolidate.Add("chain", chain);
                                    ins_consolidate.Add("valid", chainflow.IsValid());
                                    ins_consolidate.Add("encoding", test_data_result["encoding"].ToString());
                                    ins_consolidate.Add("sequence", total.ToString());
                                    ins_consolidate.Add("block", newblock);
                                    ins_consolidate.Add("lastblock", chainflow.GetLatestBlock().PreviousHash);
                                    ins_consolidate.Add("file", test_data_result["file"].ToString());
                                    ins_consolidate.Add("dataspace", test_data_result["dataspace"].ToString());
                                    ins_consolidate.Add("content_size", test_data_result["content_size"].ToString());
                                    ins_consolidate.Add("hash_space", test_data_result["hash_space"].ToString());
                                    ins_consolidate.Add("content_identity", test_data_result["content_identity"].ToString());
                                    ins_consolidate.Add("encodeing_start", test_data_result["encodeing_start"].ToString());
                                    ins_consolidate.Add("encodeing_end", test_data_result["encodeing_end"].ToString());
                                    ins_consolidate.Add("encoding_avg", test_data_result["encoding_avg"].ToString());
                                    ins_consolidate.Add("block_start", test_data_result["block_start"].ToString());
                                    ins_consolidate.Add("block_end", test_data_result["block_end"].ToString());
                                    ins_consolidate.Add("block_avg", test_data_result["block_avg"].ToString());
                                    ins_consolidate.Add("remark1", "test");

                                    Edocumentmng.t_log_blockchain_performance(JsonConvert.SerializeObject(ins_consolidate));
                                }
                                else if (i.ToString() == "60")
                                {
                                    consolidatedata = Program_test.blockchain_documentspcial1(chain, "3.jpg", "sha");
                                    var test_data_result = JObject.Parse(consolidatedata);
                                    newblock = chainflow.AddBlock(new Block(0, DateTime.Now, null, chain, test_data_result["content_identity"].ToString(), "", consolidatedata, "update", "hash"));
                                    ins_consolidate.Add("chain", chain);
                                    ins_consolidate.Add("valid", chainflow.IsValid());
                                    ins_consolidate.Add("encoding", test_data_result["encoding"].ToString());
                                    ins_consolidate.Add("sequence", total.ToString());
                                    ins_consolidate.Add("block", newblock);
                                    ins_consolidate.Add("lastblock", chainflow.GetLatestBlock().PreviousHash);
                                    ins_consolidate.Add("file", test_data_result["file"].ToString());
                                    ins_consolidate.Add("dataspace", test_data_result["dataspace"].ToString());
                                    ins_consolidate.Add("content_size", test_data_result["content_size"].ToString());
                                    ins_consolidate.Add("hash_space", test_data_result["hash_space"].ToString());
                                    ins_consolidate.Add("content_identity", test_data_result["content_identity"].ToString());
                                    ins_consolidate.Add("encodeing_start", test_data_result["encodeing_start"].ToString());
                                    ins_consolidate.Add("encodeing_end", test_data_result["encodeing_end"].ToString());
                                    ins_consolidate.Add("encoding_avg", test_data_result["encoding_avg"].ToString());
                                    ins_consolidate.Add("block_start", test_data_result["block_start"].ToString());
                                    ins_consolidate.Add("block_end", test_data_result["block_end"].ToString());
                                    ins_consolidate.Add("block_avg", test_data_result["block_avg"].ToString());
                                    ins_consolidate.Add("remark1", "test");

                                    Edocumentmng.t_log_blockchain_performance(JsonConvert.SerializeObject(ins_consolidate));
                                }
                                else if (i.ToString() == "80")
                                {
                                    consolidatedata = Program_test.blockchain_documentspcial1(chain, "4.jpg", "sha");
                                    var test_data_result = JObject.Parse(consolidatedata);
                                    newblock = chainflow.AddBlock(new Block(0, DateTime.Now, null, chain, test_data_result["content_identity"].ToString(), "", consolidatedata, "update", "hash"));
                                    ins_consolidate.Add("chain", chain);
                                    ins_consolidate.Add("valid", chainflow.IsValid());
                                    ins_consolidate.Add("encoding", test_data_result["encoding"].ToString());
                                    ins_consolidate.Add("sequence", total.ToString());
                                    ins_consolidate.Add("block", newblock);
                                    ins_consolidate.Add("lastblock", chainflow.GetLatestBlock().PreviousHash);
                                    ins_consolidate.Add("file", test_data_result["file"].ToString());
                                    ins_consolidate.Add("dataspace", test_data_result["dataspace"].ToString());
                                    ins_consolidate.Add("content_size", test_data_result["content_size"].ToString());
                                    ins_consolidate.Add("hash_space", test_data_result["hash_space"].ToString());
                                    ins_consolidate.Add("content_identity", test_data_result["content_identity"].ToString());
                                    ins_consolidate.Add("encodeing_start", test_data_result["encodeing_start"].ToString());
                                    ins_consolidate.Add("encodeing_end", test_data_result["encodeing_end"].ToString());
                                    ins_consolidate.Add("encoding_avg", test_data_result["encoding_avg"].ToString());
                                    ins_consolidate.Add("block_start", test_data_result["block_start"].ToString());
                                    ins_consolidate.Add("block_end", test_data_result["block_end"].ToString());
                                    ins_consolidate.Add("block_avg", test_data_result["block_avg"].ToString());
                                    ins_consolidate.Add("remark1", "test");

                                    Edocumentmng.t_log_blockchain_performance(JsonConvert.SerializeObject(ins_consolidate));
                                }
                                else if (i.ToString() == "100")
                                {
                                    consolidatedata = Program_test.blockchain_documentspcial1(chain, "5.jpg", "sha");
                                    var test_data_result = JObject.Parse(consolidatedata);
                                    newblock = chainflow.AddBlock(new Block(0, DateTime.Now, null, chain, test_data_result["content_identity"].ToString(), "", consolidatedata, "update", "hash"));
                                    ins_consolidate.Add("chain", chain);
                                    ins_consolidate.Add("valid", chainflow.IsValid());
                                    ins_consolidate.Add("encoding", test_data_result["encoding"].ToString());
                                    ins_consolidate.Add("sequence", total.ToString());
                                    ins_consolidate.Add("block", newblock);
                                    ins_consolidate.Add("lastblock", chainflow.GetLatestBlock().PreviousHash);
                                    ins_consolidate.Add("file", test_data_result["file"].ToString());
                                    ins_consolidate.Add("dataspace", test_data_result["dataspace"].ToString());
                                    ins_consolidate.Add("content_size", test_data_result["content_size"].ToString());
                                    ins_consolidate.Add("hash_space", test_data_result["hash_space"].ToString());
                                    ins_consolidate.Add("content_identity", test_data_result["content_identity"].ToString());
                                    ins_consolidate.Add("encodeing_start", test_data_result["encodeing_start"].ToString());
                                    ins_consolidate.Add("encodeing_end", test_data_result["encodeing_end"].ToString());
                                    ins_consolidate.Add("encoding_avg", test_data_result["encoding_avg"].ToString());
                                    ins_consolidate.Add("block_start", test_data_result["block_start"].ToString());
                                    ins_consolidate.Add("block_end", test_data_result["block_end"].ToString());
                                    ins_consolidate.Add("block_avg", test_data_result["block_avg"].ToString());
                                    ins_consolidate.Add("remark1", "test");

                                    Edocumentmng.t_log_blockchain_performance(JsonConvert.SerializeObject(ins_consolidate));
                                }

                                //====================== test ===========================

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
                                ins_db.Add("remark1", "train");
                                //ins_db.Add("remark2", "");

                                Edocumentmng.t_log_blockchain_performance(JsonConvert.SerializeObject(ins_db));

                                // =================test ================================
                                if (i.ToString() == "20")
                                {
                                    consolidatedata = Program_test.blockchain_documentspcial1(chain, "1.jpg", "sha256");
                                    var test_data_result = JObject.Parse(consolidatedata);
                                    newblock = chainflow.AddBlock(new Block(0, DateTime.Now, null, chain, test_data_result["content_identity"].ToString(), "", consolidatedata, "update", "hash"));
                                    ins_consolidate.Add("chain", chain);
                                    ins_consolidate.Add("valid", chainflow.IsValid());
                                    ins_consolidate.Add("encoding", test_data_result["encoding"].ToString());
                                    ins_consolidate.Add("sequence", total.ToString());
                                    ins_consolidate.Add("block", newblock);
                                    ins_consolidate.Add("lastblock", chainflow.GetLatestBlock().PreviousHash);
                                    ins_consolidate.Add("file", test_data_result["file"].ToString());
                                    ins_consolidate.Add("dataspace", test_data_result["dataspace"].ToString());
                                    ins_consolidate.Add("content_size", test_data_result["content_size"].ToString());
                                    ins_consolidate.Add("hash_space", test_data_result["hash_space"].ToString());
                                    ins_consolidate.Add("content_identity", test_data_result["content_identity"].ToString());
                                    ins_consolidate.Add("encodeing_start", test_data_result["encodeing_start"].ToString());
                                    ins_consolidate.Add("encodeing_end", test_data_result["encodeing_end"].ToString());
                                    ins_consolidate.Add("encoding_avg", test_data_result["encoding_avg"].ToString());
                                    ins_consolidate.Add("block_start", test_data_result["block_start"].ToString());
                                    ins_consolidate.Add("block_end", test_data_result["block_end"].ToString());
                                    ins_consolidate.Add("block_avg", test_data_result["block_avg"].ToString());
                                    ins_consolidate.Add("remark1", "test");

                                    Edocumentmng.t_log_blockchain_performance(JsonConvert.SerializeObject(ins_consolidate));
                                }
                                else if (i.ToString() == "40")
                                {
                                    consolidatedata = Program_test.blockchain_documentspcial1(chain, "2.jpg", "sha256");
                                    var test_data_result = JObject.Parse(consolidatedata);
                                    newblock = chainflow.AddBlock(new Block(0, DateTime.Now, null, chain, test_data_result["content_identity"].ToString(), "", consolidatedata, "update", "hash"));
                                    ins_consolidate.Add("chain", chain);
                                    ins_consolidate.Add("valid", chainflow.IsValid());
                                    ins_consolidate.Add("encoding", test_data_result["encoding"].ToString());
                                    ins_consolidate.Add("sequence", total.ToString());
                                    ins_consolidate.Add("block", newblock);
                                    ins_consolidate.Add("lastblock", chainflow.GetLatestBlock().PreviousHash);
                                    ins_consolidate.Add("file", test_data_result["file"].ToString());
                                    ins_consolidate.Add("dataspace", test_data_result["dataspace"].ToString());
                                    ins_consolidate.Add("content_size", test_data_result["content_size"].ToString());
                                    ins_consolidate.Add("hash_space", test_data_result["hash_space"].ToString());
                                    ins_consolidate.Add("content_identity", test_data_result["content_identity"].ToString());
                                    ins_consolidate.Add("encodeing_start", test_data_result["encodeing_start"].ToString());
                                    ins_consolidate.Add("encodeing_end", test_data_result["encodeing_end"].ToString());
                                    ins_consolidate.Add("encoding_avg", test_data_result["encoding_avg"].ToString());
                                    ins_consolidate.Add("block_start", test_data_result["block_start"].ToString());
                                    ins_consolidate.Add("block_end", test_data_result["block_end"].ToString());
                                    ins_consolidate.Add("block_avg", test_data_result["block_avg"].ToString());
                                    ins_consolidate.Add("remark1", "test");

                                    Edocumentmng.t_log_blockchain_performance(JsonConvert.SerializeObject(ins_consolidate));
                                }
                                else if (i.ToString() == "60")
                                {
                                    consolidatedata = Program_test.blockchain_documentspcial1(chain, "3.jpg", "sha256");
                                    var test_data_result = JObject.Parse(consolidatedata);
                                    newblock = chainflow.AddBlock(new Block(0, DateTime.Now, null, chain, test_data_result["content_identity"].ToString(), "", consolidatedata, "update", "hash"));
                                    ins_consolidate.Add("chain", chain);
                                    ins_consolidate.Add("valid", chainflow.IsValid());
                                    ins_consolidate.Add("encoding", test_data_result["encoding"].ToString());
                                    ins_consolidate.Add("sequence", total.ToString());
                                    ins_consolidate.Add("block", newblock);
                                    ins_consolidate.Add("lastblock", chainflow.GetLatestBlock().PreviousHash);
                                    ins_consolidate.Add("file", test_data_result["file"].ToString());
                                    ins_consolidate.Add("dataspace", test_data_result["dataspace"].ToString());
                                    ins_consolidate.Add("content_size", test_data_result["content_size"].ToString());
                                    ins_consolidate.Add("hash_space", test_data_result["hash_space"].ToString());
                                    ins_consolidate.Add("content_identity", test_data_result["content_identity"].ToString());
                                    ins_consolidate.Add("encodeing_start", test_data_result["encodeing_start"].ToString());
                                    ins_consolidate.Add("encodeing_end", test_data_result["encodeing_end"].ToString());
                                    ins_consolidate.Add("encoding_avg", test_data_result["encoding_avg"].ToString());
                                    ins_consolidate.Add("block_start", test_data_result["block_start"].ToString());
                                    ins_consolidate.Add("block_end", test_data_result["block_end"].ToString());
                                    ins_consolidate.Add("block_avg", test_data_result["block_avg"].ToString());
                                    ins_consolidate.Add("remark1", "test");

                                    Edocumentmng.t_log_blockchain_performance(JsonConvert.SerializeObject(ins_consolidate));
                                }
                                else if (i.ToString() == "80")
                                {
                                    consolidatedata = Program_test.blockchain_documentspcial1(chain, "4.jpg", "sha256");
                                    var test_data_result = JObject.Parse(consolidatedata);
                                    newblock = chainflow.AddBlock(new Block(0, DateTime.Now, null, chain, test_data_result["content_identity"].ToString(), "", consolidatedata, "update", "hash"));
                                    ins_consolidate.Add("chain", chain);
                                    ins_consolidate.Add("valid", chainflow.IsValid());
                                    ins_consolidate.Add("encoding", test_data_result["encoding"].ToString());
                                    ins_consolidate.Add("sequence", total.ToString());
                                    ins_consolidate.Add("block", newblock);
                                    ins_consolidate.Add("lastblock", chainflow.GetLatestBlock().PreviousHash);
                                    ins_consolidate.Add("file", test_data_result["file"].ToString());
                                    ins_consolidate.Add("dataspace", test_data_result["dataspace"].ToString());
                                    ins_consolidate.Add("content_size", test_data_result["content_size"].ToString());
                                    ins_consolidate.Add("hash_space", test_data_result["hash_space"].ToString());
                                    ins_consolidate.Add("content_identity", test_data_result["content_identity"].ToString());
                                    ins_consolidate.Add("encodeing_start", test_data_result["encodeing_start"].ToString());
                                    ins_consolidate.Add("encodeing_end", test_data_result["encodeing_end"].ToString());
                                    ins_consolidate.Add("encoding_avg", test_data_result["encoding_avg"].ToString());
                                    ins_consolidate.Add("block_start", test_data_result["block_start"].ToString());
                                    ins_consolidate.Add("block_end", test_data_result["block_end"].ToString());
                                    ins_consolidate.Add("block_avg", test_data_result["block_avg"].ToString());
                                    ins_consolidate.Add("remark1", "test");

                                    Edocumentmng.t_log_blockchain_performance(JsonConvert.SerializeObject(ins_consolidate));
                                }
                                else if (i.ToString() == "100")
                                {
                                    consolidatedata = Program_test.blockchain_documentspcial1(chain, "5.jpg", "sha256");
                                    var test_data_result = JObject.Parse(consolidatedata);
                                    newblock = chainflow.AddBlock(new Block(0, DateTime.Now, null, chain, test_data_result["content_identity"].ToString(), "", consolidatedata, "update", "hash"));
                                    ins_consolidate.Add("chain", chain);
                                    ins_consolidate.Add("valid", chainflow.IsValid());
                                    ins_consolidate.Add("encoding", test_data_result["encoding"].ToString());
                                    ins_consolidate.Add("sequence", total.ToString());
                                    ins_consolidate.Add("block", newblock);
                                    ins_consolidate.Add("lastblock", chainflow.GetLatestBlock().PreviousHash);
                                    ins_consolidate.Add("file", test_data_result["file"].ToString());
                                    ins_consolidate.Add("dataspace", test_data_result["dataspace"].ToString());
                                    ins_consolidate.Add("content_size", test_data_result["content_size"].ToString());
                                    ins_consolidate.Add("hash_space", test_data_result["hash_space"].ToString());
                                    ins_consolidate.Add("content_identity", test_data_result["content_identity"].ToString());
                                    ins_consolidate.Add("encodeing_start", test_data_result["encodeing_start"].ToString());
                                    ins_consolidate.Add("encodeing_end", test_data_result["encodeing_end"].ToString());
                                    ins_consolidate.Add("encoding_avg", test_data_result["encoding_avg"].ToString());
                                    ins_consolidate.Add("block_start", test_data_result["block_start"].ToString());
                                    ins_consolidate.Add("block_end", test_data_result["block_end"].ToString());
                                    ins_consolidate.Add("block_avg", test_data_result["block_avg"].ToString());
                                    ins_consolidate.Add("remark1", "test");

                                    Edocumentmng.t_log_blockchain_performance(JsonConvert.SerializeObject(ins_consolidate));
                                }

                                //====================== test ===========================

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
                                ins_db.Add("remark1", "train");
                                //ins_db.Add("remark2", "");

                                Edocumentmng.t_log_blockchain_performance(JsonConvert.SerializeObject(ins_db));

                                // =================test ================================
                                if (i.ToString() == "20")
                                {
                                    consolidatedata = Program_test.blockchain_documentspcial1(chain, "1.jpg", "sha512");
                                    var test_data_result = JObject.Parse(consolidatedata);
                                    newblock = chainflow.AddBlock(new Block(0, DateTime.Now, null, chain, test_data_result["content_identity"].ToString(), "", consolidatedata, "update", "hash"));
                                    ins_consolidate.Add("chain", chain);
                                    ins_consolidate.Add("valid", chainflow.IsValid());
                                    ins_consolidate.Add("encoding", test_data_result["encoding"].ToString());
                                    ins_consolidate.Add("sequence", total.ToString());
                                    ins_consolidate.Add("block", newblock);
                                    ins_consolidate.Add("lastblock", chainflow.GetLatestBlock().PreviousHash);
                                    ins_consolidate.Add("file", test_data_result["file"].ToString());
                                    ins_consolidate.Add("dataspace", test_data_result["dataspace"].ToString());
                                    ins_consolidate.Add("content_size", test_data_result["content_size"].ToString());
                                    ins_consolidate.Add("hash_space", test_data_result["hash_space"].ToString());
                                    ins_consolidate.Add("content_identity", test_data_result["content_identity"].ToString());
                                    ins_consolidate.Add("encodeing_start", test_data_result["encodeing_start"].ToString());
                                    ins_consolidate.Add("encodeing_end", test_data_result["encodeing_end"].ToString());
                                    ins_consolidate.Add("encoding_avg", test_data_result["encoding_avg"].ToString());
                                    ins_consolidate.Add("block_start", test_data_result["block_start"].ToString());
                                    ins_consolidate.Add("block_end", test_data_result["block_end"].ToString());
                                    ins_consolidate.Add("block_avg", test_data_result["block_avg"].ToString());
                                    ins_consolidate.Add("remark1", "test");

                                    Edocumentmng.t_log_blockchain_performance(JsonConvert.SerializeObject(ins_consolidate));
                                }
                                else if (i.ToString() == "40")
                                {
                                    consolidatedata = Program_test.blockchain_documentspcial1(chain, "2.jpg", "sha512");
                                    var test_data_result = JObject.Parse(consolidatedata);
                                    newblock = chainflow.AddBlock(new Block(0, DateTime.Now, null, chain, test_data_result["content_identity"].ToString(), "", consolidatedata, "update", "hash"));
                                    ins_consolidate.Add("chain", chain);
                                    ins_consolidate.Add("valid", chainflow.IsValid());
                                    ins_consolidate.Add("encoding", test_data_result["encoding"].ToString());
                                    ins_consolidate.Add("sequence", total.ToString());
                                    ins_consolidate.Add("block", newblock);
                                    ins_consolidate.Add("lastblock", chainflow.GetLatestBlock().PreviousHash);
                                    ins_consolidate.Add("file", test_data_result["file"].ToString());
                                    ins_consolidate.Add("dataspace", test_data_result["dataspace"].ToString());
                                    ins_consolidate.Add("content_size", test_data_result["content_size"].ToString());
                                    ins_consolidate.Add("hash_space", test_data_result["hash_space"].ToString());
                                    ins_consolidate.Add("content_identity", test_data_result["content_identity"].ToString());
                                    ins_consolidate.Add("encodeing_start", test_data_result["encodeing_start"].ToString());
                                    ins_consolidate.Add("encodeing_end", test_data_result["encodeing_end"].ToString());
                                    ins_consolidate.Add("encoding_avg", test_data_result["encoding_avg"].ToString());
                                    ins_consolidate.Add("block_start", test_data_result["block_start"].ToString());
                                    ins_consolidate.Add("block_end", test_data_result["block_end"].ToString());
                                    ins_consolidate.Add("block_avg", test_data_result["block_avg"].ToString());
                                    ins_consolidate.Add("remark1", "test");

                                    Edocumentmng.t_log_blockchain_performance(JsonConvert.SerializeObject(ins_consolidate));
                                }
                                else if (i.ToString() == "60")
                                {
                                    consolidatedata = Program_test.blockchain_documentspcial1(chain, "3.jpg", "sha512");
                                    var test_data_result = JObject.Parse(consolidatedata);
                                    newblock = chainflow.AddBlock(new Block(0, DateTime.Now, null, chain, test_data_result["content_identity"].ToString(), "", consolidatedata, "update", "hash"));
                                    ins_consolidate.Add("chain", chain);
                                    ins_consolidate.Add("valid", chainflow.IsValid());
                                    ins_consolidate.Add("encoding", test_data_result["encoding"].ToString());
                                    ins_consolidate.Add("sequence", total.ToString());
                                    ins_consolidate.Add("block", newblock);
                                    ins_consolidate.Add("lastblock", chainflow.GetLatestBlock().PreviousHash);
                                    ins_consolidate.Add("file", test_data_result["file"].ToString());
                                    ins_consolidate.Add("dataspace", test_data_result["dataspace"].ToString());
                                    ins_consolidate.Add("content_size", test_data_result["content_size"].ToString());
                                    ins_consolidate.Add("hash_space", test_data_result["hash_space"].ToString());
                                    ins_consolidate.Add("content_identity", test_data_result["content_identity"].ToString());
                                    ins_consolidate.Add("encodeing_start", test_data_result["encodeing_start"].ToString());
                                    ins_consolidate.Add("encodeing_end", test_data_result["encodeing_end"].ToString());
                                    ins_consolidate.Add("encoding_avg", test_data_result["encoding_avg"].ToString());
                                    ins_consolidate.Add("block_start", test_data_result["block_start"].ToString());
                                    ins_consolidate.Add("block_end", test_data_result["block_end"].ToString());
                                    ins_consolidate.Add("block_avg", test_data_result["block_avg"].ToString());
                                    ins_consolidate.Add("remark1", "test");

                                    Edocumentmng.t_log_blockchain_performance(JsonConvert.SerializeObject(ins_consolidate));
                                }
                                else if (i.ToString() == "80")
                                {
                                    consolidatedata = Program_test.blockchain_documentspcial1(chain, "4.jpg", "sha512");
                                    var test_data_result = JObject.Parse(consolidatedata);
                                    newblock = chainflow.AddBlock(new Block(0, DateTime.Now, null, chain, test_data_result["content_identity"].ToString(), "", consolidatedata, "update", "hash"));
                                    ins_consolidate.Add("chain", chain);
                                    ins_consolidate.Add("valid", chainflow.IsValid());
                                    ins_consolidate.Add("encoding", test_data_result["encoding"].ToString());
                                    ins_consolidate.Add("sequence", total.ToString());
                                    ins_consolidate.Add("block", newblock);
                                    ins_consolidate.Add("lastblock", chainflow.GetLatestBlock().PreviousHash);
                                    ins_consolidate.Add("file", test_data_result["file"].ToString());
                                    ins_consolidate.Add("dataspace", test_data_result["dataspace"].ToString());
                                    ins_consolidate.Add("content_size", test_data_result["content_size"].ToString());
                                    ins_consolidate.Add("hash_space", test_data_result["hash_space"].ToString());
                                    ins_consolidate.Add("content_identity", test_data_result["content_identity"].ToString());
                                    ins_consolidate.Add("encodeing_start", test_data_result["encodeing_start"].ToString());
                                    ins_consolidate.Add("encodeing_end", test_data_result["encodeing_end"].ToString());
                                    ins_consolidate.Add("encoding_avg", test_data_result["encoding_avg"].ToString());
                                    ins_consolidate.Add("block_start", test_data_result["block_start"].ToString());
                                    ins_consolidate.Add("block_end", test_data_result["block_end"].ToString());
                                    ins_consolidate.Add("block_avg", test_data_result["block_avg"].ToString());
                                    ins_consolidate.Add("remark1", "test");

                                    Edocumentmng.t_log_blockchain_performance(JsonConvert.SerializeObject(ins_consolidate));
                                }
                                else if (i.ToString() == "100")
                                {
                                    consolidatedata = Program_test.blockchain_documentspcial1(chain, "5.jpg", "sha512");
                                    var test_data_result = JObject.Parse(consolidatedata);
                                    newblock = chainflow.AddBlock(new Block(0, DateTime.Now, null, chain, test_data_result["content_identity"].ToString(), "", consolidatedata, "update", "hash"));
                                    ins_consolidate.Add("chain", chain);
                                    ins_consolidate.Add("valid", chainflow.IsValid());
                                    ins_consolidate.Add("encoding", test_data_result["encoding"].ToString());
                                    ins_consolidate.Add("sequence", total.ToString());
                                    ins_consolidate.Add("block", newblock);
                                    ins_consolidate.Add("lastblock", chainflow.GetLatestBlock().PreviousHash);
                                    ins_consolidate.Add("file", test_data_result["file"].ToString());
                                    ins_consolidate.Add("dataspace", test_data_result["dataspace"].ToString());
                                    ins_consolidate.Add("content_size", test_data_result["content_size"].ToString());
                                    ins_consolidate.Add("hash_space", test_data_result["hash_space"].ToString());
                                    ins_consolidate.Add("content_identity", test_data_result["content_identity"].ToString());
                                    ins_consolidate.Add("encodeing_start", test_data_result["encodeing_start"].ToString());
                                    ins_consolidate.Add("encodeing_end", test_data_result["encodeing_end"].ToString());
                                    ins_consolidate.Add("encoding_avg", test_data_result["encoding_avg"].ToString());
                                    ins_consolidate.Add("block_start", test_data_result["block_start"].ToString());
                                    ins_consolidate.Add("block_end", test_data_result["block_end"].ToString());
                                    ins_consolidate.Add("block_avg", test_data_result["block_avg"].ToString());
                                    ins_consolidate.Add("remark1", "test");

                                    Edocumentmng.t_log_blockchain_performance(JsonConvert.SerializeObject(ins_consolidate));
                                }

                                //====================== test ===========================


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
                                ins_db.Add("remark1", "train");
                                //ins_db.Add("remark2", "");

                                Edocumentmng.t_log_blockchain_performance(JsonConvert.SerializeObject(ins_db));

                                // =================test ================================
                                if (i.ToString() == countdata.ToString())
                                {
                                    consolidatedata = Program_test.blockchain_documentspcial1(chain, "1.jpg", "aes");
                                    var test_data_result = JObject.Parse(consolidatedata);
                                    newblock = chainflow.AddBlock(new Block(0, DateTime.Now, null, chain, test_data_result["content_identity"].ToString(), "", consolidatedata, "update", "hash"));
                                    ins_consolidate.Add("chain", chain);
                                    ins_consolidate.Add("valid", chainflow.IsValid());
                                    ins_consolidate.Add("encoding", test_data_result["encoding"].ToString());
                                    ins_consolidate.Add("sequence", total.ToString());
                                    ins_consolidate.Add("block", newblock);
                                    ins_consolidate.Add("lastblock", chainflow.GetLatestBlock().PreviousHash);
                                    ins_consolidate.Add("file", test_data_result["file"].ToString());
                                    ins_consolidate.Add("dataspace", test_data_result["dataspace"].ToString());
                                    ins_consolidate.Add("content_size", test_data_result["content_size"].ToString());
                                    ins_consolidate.Add("hash_space", test_data_result["hash_space"].ToString());
                                    ins_consolidate.Add("content_identity", test_data_result["content_identity"].ToString());
                                    ins_consolidate.Add("encodeing_start", test_data_result["encodeing_start"].ToString());
                                    ins_consolidate.Add("encodeing_end", test_data_result["encodeing_end"].ToString());
                                    ins_consolidate.Add("encoding_avg", test_data_result["encoding_avg"].ToString());
                                    ins_consolidate.Add("block_start", test_data_result["block_start"].ToString());
                                    ins_consolidate.Add("block_end", test_data_result["block_end"].ToString());
                                    ins_consolidate.Add("block_avg", test_data_result["block_avg"].ToString());
                                    ins_consolidate.Add("remark1", "test");

                                    Edocumentmng.t_log_blockchain_performance(JsonConvert.SerializeObject(ins_consolidate));
                                }
                                
                                
                                
                               

                                //====================== test ===========================


                                break;
                            default:

                                break;

                        }



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
                    appdata = appRoot + "/Appdata/train/" + filename;
                    path = appdata;
                    break;
                case "WINDOWS":
                    //appRoot = apppath();
                    appRoot = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"));
                    appdata = appRoot + "\\Appdata\\train\\" + filename;
                    path = appdata;
                    break;
                case "OSX":
                    //appRoot = apppath();
                    appRoot = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"));
                    appdata = appRoot + "/Appdata/train/" + filename;
                    path = appdata;
                    break;

                default:
                    //appRoot = apppath();
                    appRoot = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"));
                    appdata = appRoot + "/Appdata/train/" + filename;
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
