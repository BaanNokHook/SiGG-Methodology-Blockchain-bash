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
    class Program
    {
     


        static void Main(string[] args)
        {
           
            screen_main();
          
        }

        public static void screen_main()
        {
            Console.Clear();

            Console.WriteLine("=================== Methodology Blockchain Product =======================");
            Console.WriteLine("=================== Auther Tanaporn chalowchon [6007011859551]  ===============");
    
            DateTime dat = DateTime.Now;
            Console.WriteLine("The time: {0:d} at {0:t}", dat);
            //set_screen();
            control_module();

        }
        private static void control_module()
        {

            Char dis_play_select = GetKeyPress("Please Input Senario \n" +
              "    A [Main Program]\n" +
           
              //----------------------------------------------------------
              "    1 [Senario  small ]\n" +
              "    2 [Senario  medium ]\n" +
              "    3 [Senario  large ]\n" +

              "    4 [Senario 100000  small ]\n" +
              "    5 [Senario 100000 medium ]\n" +
              "    6 [Senario 100000 large ]\n" +

              "    7 [Senario train-test Index ]\n" +
              "    8 [Senario train-test Chain ]\n" +
           





              //----------------------------------------------------------
              "    I [Initial DB]\n" +
              "    O [Clear DB]\n" +
              "    X [Exit]\n" +
              "[Input]-->: ",
                                          new Char[] { 'A', 'I', 'D', 'O', 'X', '1', '2', '3', '4', '5','6','7','8','J','K' });
            switch (dis_play_select)
            {
                case 'A':
                case 'a':
                    screen_main();
                    break;
                //----------------------------------------------------------
                case '1':

                    Programdata.blockchain_document("small.jpg");
                    clear_console();

                    break;
                case '2':
                    Programdata.blockchain_document("medium.jpg");
                    clear_console();
                    break;
                case '3':
                    Programdata.blockchain_document("large.jpg");
                    clear_console();
                    break;

                case '4':

                    Programdata.blockchain_documentsp("small.jpg");
                    clear_console();

                    break;
                case '5':
                    Programdata.blockchain_documentsp("medium.jpg");
                    clear_console();
                    break;
                case '6':
                    Programdata.blockchain_documentsp("large.jpg");
                    clear_console();
                    break;


                case '7':
                    Program_train2.blockchain_documentspcial1();
                    clear_console();
                    break;

                case '8':
                    Program_train2.blockchain_documentspcial2();
                    clear_console();
                    break;

              
                //--------------------------------------------------------------------blockchain_documentspcial1


                case 'O':
                case 'o':

                    Edocumentmng.clear_t_log_blockchain_performance();

                    clear_console();
                    break;

                case 'X':
                case 'x':
                    exits_program();
                    break;

                default:
                    Console.WriteLine(" Default");
                    break;
            }
        }



      

        public static void clear_console()
        {
            Console.Clear();
            control_module();
        }
        private static Char GetKeyPress(String msg, Char[] validChars)
        {
            ConsoleKeyInfo keyPressed;
            bool valid = false;
            Console.WriteLine();
            do
            {
                Console.Write(msg);
                keyPressed = Console.ReadKey();
                Console.WriteLine();
                if (Array.Exists(validChars, ch => ch.Equals(Char.ToUpper(keyPressed.KeyChar))))
                    valid = true;
            } while (!valid);
            return keyPressed.KeyChar;
        }
        private static void exits_program()
        {
            Console.Clear();
            DateTime dat = DateTime.Now;
            System.Threading.Thread.Sleep(1000);

            Console.WriteLine("End Program" + "{0:d} at {0:t}", dat);
            System.Threading.Thread.Sleep(1000);
            System.Environment.Exit(-1);


        }



    }
}
