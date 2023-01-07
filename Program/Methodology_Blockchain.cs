using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Newtonsoft.Json;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Methodology_Blockchain_bash
{
    public class Methodology_Blockchain
    {
        Logmodel log = new Logmodel();


        // GET: /<controller>/

        public static string calltest() {

            return "calltest : " + DateTime.Now.ToString();
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


        public static string fileinpath(string filename) {

            var osprocess = GetOsPlatform();

            var appRoot = "";
            string appdata = "";
            string path = "";

            switch (osprocess)
            {
                case "LINUX":
                     appRoot = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"));
                     appdata = appRoot + "Appdata/" + filename;
                     path = appdata;
                    break;
                case "WINDOWS":
                     appRoot = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"));
                     appdata = appRoot + "\\Appdata\\" + filename;
                     path = appdata;
                    break;
                case "OSX":
                     appRoot = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"));
                     appdata = appRoot + "Appdata/" + filename;
                     path = appdata;
                    break;
              
                default:
                     appRoot = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"));
                     appdata = appRoot + "Appdata/" + filename;
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



        public static string UploadFile(string filename)
        {
            string base64String = "";

            string path = fileinpath(filename);

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
            var result  =    Edocumentmng.insertDocument("ite_Methodlogy_Blockchain", base64String, filename, "Loadtest", "");

            return "Upload Success : " + DateTime.Now.ToString("yyyMMdd HH:mm:ss"+result);
        }


        public static string document(string filename ,string encode_type)
        {
            string path = fileinpath(filename);

            Logmodel log = new Logmodel();
            string base64String = "";
            //string path = "";
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
         


            string systemDate = DateTime.Now.ToString(" yyyMMdd HH:mm:ss.ffffff");
           

            switch (encode_type) {
                case "md5":
                    hash = encode.md5(base64String);
                    break;
                case "sha":
                    hash = encode.sha(base64String);
                    break;
                case "sha256":
                    hash = encode.sha256(base64String);
                    break;
                case "sha512":
                    hash = encode.sha512(base64String);
                    break;
                case "aes":
                    hash =  encode.encode_aes("encrypt", base64String);
                    break;
                default:

                    break;

            }

            string compareDate = DateTime.Now.ToString("yyyMMdd HH:mm:ss.ffffff");
            var start_t = systemDate.Split('.');
            var end_t = compareDate.Split('.');
            int avg = (System.Convert.ToInt32(end_t[1]) - System.Convert.ToInt32(start_t[1]));
            //Edocumentmng.insertDocument("ite_Methodlogy_Blockchain", base64String, "", encode_type, hash);
            //Edocumentmng.t_log_performance("ite_Methodlogy_Blockchain", "", encode_type, systemDate.ToString(), compareDate.ToString(), "", "", avg, hash);
            string response = "Tiger Upload Compelete";

           // log.info("End ======================Tiger Upload=====================");
            return response;
        }

       
        public static string blockchain_document(string filename,string encode_type,string phase)
        {
            
            string path = fileinpath(filename);

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
            var chain_status = new Dictionary<object, object>();



            Stopwatch encodetime = new Stopwatch();
            Stopwatch blockchaintime = new Stopwatch();


            string start_encodetime = "";
            string end_encodetime = "";

            string start_blockchaintime = "";
            string end_blockchaintime = "";


            if (phase == "1")
            {
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

                            Console.WriteLine(" RUN : blockchain_document transction_detail :  " + JsonConvert.SerializeObject(transction_detail));


                            var param = new Dictionary<object, object>();
                            param.Add("chain", filename);
                            param.Add("identity", Blockchain_model.identity_value(hash.ToString()));
                            param.Add("data", base64String);
                            param.Add("description", JsonConvert.SerializeObject(transction_detail));

                          

                            chain_status = Blockchain_model.blockchain_edocument(JsonConvert.SerializeObject(param));




                            chain_status.Add("filename", filename);
                            chain_status.Add("filesize", filesize.ToString());
                            chain_status.Add("content_size", base64String.Length);
                            chain_status.Add("content_identity", Blockchain_model.identity_value(hash.ToString()));
                            chain_status.Add("hash_size", hash.Length) ;
                            chain_status.Add("modifydate", DateTime.Now.ToString(" yyyMMdd HH:mm:ss"));

                            //Console.WriteLine(" RUN : blockchain_document md5 :  "+JsonConvert.SerializeObject(chain_status));


                        }
                        end_blockchaintime = DateTime.Now.ToString(" yyyMMdd HH:mm:ss.ffffff");
                        blockchaintime.Stop();
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


                            var param = new Dictionary<object, object>();
                            param.Add("chain", filename);
                            param.Add("identity", Blockchain_model.identity_value(hash.ToString()));
                            param.Add("data", base64String);
                            param.Add("description", JsonConvert.SerializeObject(transction_detail));



                            chain_status = Blockchain_model.blockchain_edocument(JsonConvert.SerializeObject(param));





                            chain_status.Add("filename", filename);
                            chain_status.Add("filesize", filesize.ToString());
                            chain_status.Add("content_size", base64String.Length);
                            chain_status.Add("content_identity", Blockchain_model.identity_value(hash.ToString()));
                            chain_status.Add("hash_size", hash.Length);
                            chain_status.Add("modifydate", DateTime.Now.ToString(" yyyMMdd HH:mm:ss"));
                        }
                        end_blockchaintime = DateTime.Now.ToString(" yyyMMdd HH:mm:ss.ffffff");
                        blockchaintime.Stop();
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


                            var param = new Dictionary<object, object>();
                            param.Add("chain", filename);
                            param.Add("identity", Blockchain_model.identity_value(hash.ToString()));
                            param.Add("data", base64String);
                            param.Add("description", JsonConvert.SerializeObject(transction_detail));




                            chain_status = Blockchain_model.blockchain_edocument(JsonConvert.SerializeObject(param));




                            chain_status.Add("filename", filename);
                            chain_status.Add("filesize", filesize.ToString());
                            chain_status.Add("content_size", base64String.Length);
                            chain_status.Add("content_identity", Blockchain_model.identity_value(hash.ToString()));
                            chain_status.Add("hash_size", hash.Length);
                            chain_status.Add("modifydate", DateTime.Now.ToString(" yyyMMdd HH:mm:ss"));
                        }
                        end_blockchaintime = DateTime.Now.ToString(" yyyMMdd HH:mm:ss.ffffff");
                        blockchaintime.Stop();
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


                            var param = new Dictionary<object, object>();
                            param.Add("chain", filename);
                            param.Add("identity", Blockchain_model.identity_value(hash.ToString()));
                            param.Add("data", base64String);
                            param.Add("description", JsonConvert.SerializeObject(transction_detail));




                            chain_status = Blockchain_model.blockchain_edocument(JsonConvert.SerializeObject(param));




                            chain_status.Add("filename", filename);
                            chain_status.Add("filesize", filesize.ToString());
                            chain_status.Add("content_size", base64String.Length);
                            chain_status.Add("content_identity", Blockchain_model.identity_value(hash.ToString()));
                            chain_status.Add("hash_size", hash.Length);
                            chain_status.Add("modifydate", DateTime.Now.ToString(" yyyMMdd HH:mm:ss"));
                        }
                        end_blockchaintime = DateTime.Now.ToString(" yyyMMdd HH:mm:ss.ffffff");
                        blockchaintime.Stop();
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


                            var param = new Dictionary<object, object>();
                            param.Add("chain", filename);
                            param.Add("identity", Blockchain_model.identity_value(hash.ToString()));
                            param.Add("data", base64String);
                            param.Add("description", JsonConvert.SerializeObject(transction_detail));

                            chain_status = Blockchain_model.blockchain_edocument(JsonConvert.SerializeObject(param));
                            chain_status.Add("filename", filename);
                            chain_status.Add("filesize", filesize.ToString());
                            chain_status.Add("content_size", base64String.Length);
                            chain_status.Add("content_identity", Blockchain_model.identity_value(hash.ToString()));
                            chain_status.Add("hash_size", hash.Length);
                            chain_status.Add("modifydate", DateTime.Now.ToString(" yyyMMdd HH:mm:ss"));
                        }
                        end_blockchaintime = DateTime.Now.ToString(" yyyMMdd HH:mm:ss.ffffff");
                        blockchaintime.Stop();
                        break;
                    default:

                        break;

                }

            }

            var start_t = start_encodetime.Split('.');
            var end_t = end_encodetime.Split('.');

            var start_b = start_blockchaintime.Split('.');
            var end_b = end_blockchaintime.Split('.');

            var avg = encodetime.Elapsed.TotalMilliseconds;
            var avg_blockchain = blockchaintime.Elapsed.TotalMilliseconds;


            //int avg = (System.Convert.ToInt32(end_t[1]) - System.Convert.ToInt32(start_t[1]));
            //int avg_blockchain = (System.Convert.ToInt32(end_b[1]) - System.Convert.ToInt32(start_b[1]));


           // Edocumentmng.insertDocument("ite_Methodlogy_Blockchain", base64String, filename, encode_type, hash);
           // Edocumentmng.t_log_performance("ite_Methodlogy_Blockchain", filename, encode_type, start_encodetime.ToString(), end_encodetime.ToString(), "", filesize.ToString(), avg, hash);
           // Edocumentmng.t_log_blockchain_performance("ite_Methodlogy_Blockchain", filename, encode_type, start_encodetime.ToString(), end_encodetime.ToString(), "", filesize.ToString(), avg, start_blockchaintime.ToString(), end_blockchaintime.ToString(), avg_blockchain, filename, filesize.ToString(), base64String.Length.ToString(), Blockchain_model.identity_value(hash.ToString()), hash.Length.ToString(), hash);

           
            string response = JsonConvert.SerializeObject(chain_status);

           // log.info("End ======================Tiger Upload=====================");
            return response;
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
