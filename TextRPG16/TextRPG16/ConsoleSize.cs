using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG16
{
    public static class ConsoleSize
    {
        // 콘솔 창 크기 설정
         // 높이



        // 콘솔 크기 고정
        public static void ConsoleSetSize(int width, int height)
        {
             width = 80;  // 너비
             height = 40;

            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height); // 버퍼 크기도 동일하게 설정
           
            
        }

        public static void Color(ConsoleColor fontColor)
        {
            Console.ForegroundColor = fontColor;
            

        }
    }

}
