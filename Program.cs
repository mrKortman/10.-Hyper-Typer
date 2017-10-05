using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _10.Hyper_Typer
{
    /***
     * HYPER TYPER
     * 
     * Dit programma laad een woord op het scherm welke van rechts naar links beweegt
     * en het is de bedoeling dat je dit woord zo snel mogelijk weg typed voor het de 
     * break line bereikt, ieder character wat op tijd wordt weggetyped geeft je een punt
     * ieder character dat tegen de break line aan komt reduceert een punt.
     * 
     * NOTE : Dit programma is nog niet afgerond!!
     */
    class Program
    {
        //private ConsoleKeyInfo cki = new ConsoleKeyInfo();
        public static bool Terminate = false;
        public static string CurrentKey = String.Empty;

        static void Main(string[] args)
        {
            var tHold = Task.Run(() => Console.ReadKey(true));
            Thread ConsoleKeyListener = new Thread(new ThreadStart(ListerKeyBoardEvent));
            ConsoleKeyListener.Start();

            do
            {
                Console.CursorVisible = false;
                
                Program.WriteGUI();
                Program.ListerKeyBoardEvent();
            }
            while (true);
        }

        static void WriteGUI()
        {
            Console.Clear();
            Console.WindowHeight = 22;
            Console.WindowWidth = 130;
            string strHorizontalBar = Program.CreateFiller("═");
            string strHorizontalSpacer = Program.CreateFiller(" ");
            string strHeaderTitle = Program.CreateFiller(" ", "HYPER TYPER");
            string[] strGUIContent = new string[20];

            strGUIContent[0] = Program.CreateLine("╔", strHorizontalBar, "╗");
            strGUIContent[1] = Program.CreateLine("║", strHeaderTitle, "║");
            strGUIContent[2] = Program.CreateLine("╠", strHorizontalBar, "╣");

            for(int i = 3; i < 20; i++)
            {
                strGUIContent[i] = Program.CreateLine("║", strHorizontalSpacer, "║");
            }

            strGUIContent[19] = Program.CreateLine("╚", strHorizontalBar, "╝");

            foreach (string strRule in strGUIContent)
            {
                Console.WriteLine(strRule);
            }

            Console.WriteLine("CurrentKey key : " + Program.CurrentKey);
            
            //Console.ReadLine();
        }

        public static string CreateLine(string prepend = "", string content = "", string append = "")
        {
            string strResult = string.Empty;

            if (prepend != "")
            {
                strResult = " " + prepend;
            }

            if (content != null)
            {
                strResult += content;
            }

            if (append != "")
            {
                strResult += append;
            }

            return (strResult);
        }

        public static string CreateFiller(string filler, string content = "")
        {
            string strHorizontalBar = string.Empty;

            if (content == "")
            {
                for (int i = 0; i < Console.WindowWidth - 4; i++)
                {
                    strHorizontalBar += filler;
                }
            }
            else
            {
                int sideCounter = ((Console.WindowWidth - 4) / 2) - (content.Length / 2);

                for (int i = 0; i < sideCounter -1; i++)
                {
                    strHorizontalBar += filler;
                }

                strHorizontalBar += content;

                for (int i = 0; i < sideCounter; i++)
                {
                    strHorizontalBar += filler;
                }
            }
                return (strHorizontalBar);
        }

        public static void ListerKeyBoardEvent()
        {
            //do
            //{
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Escape:
                    {
                        Program.CurrentKey = "ESC";
                    }
                    break;
                    case ConsoleKey.A:
                    {
                        Program.CurrentKey = "A";
                    }
                    break;
                    case ConsoleKey.B:
                    {
                        Program.CurrentKey = "B";
                    }
                    break;
                }
                
            //} while (true);
        }
    }
}
            
