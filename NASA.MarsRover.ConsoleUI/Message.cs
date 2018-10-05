using System;
using System.Collections.Generic;
using System.Text;

namespace NASA.MarsRover.ConsoleUI {
    public static class Message {
        
        public static void Info(string message) {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Success(string message) {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Animation();
            Console.WriteLine(message);
            Animation();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Black;
            
        }

        public static void Animation() {
            for (int i = 0; i < 100; i++) {
                Console.Write("-");
                System.Threading.Thread.Sleep(3);
            }
            Console.WriteLine();
        }

        public static void Error(string message) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Warning(string message) {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
