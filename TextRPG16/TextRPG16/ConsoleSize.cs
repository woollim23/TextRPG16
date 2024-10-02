using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG16
{
    public static class ConsoleSize
    {
        // 콘솔 창 크기 설정
        // 높이



        // 콘솔 크기 고정
        // #pragma warning disable CA1416   // 방법 1. 경고 무시하기
        [SupportedOSPlatform("windows")]    // 방법 2. 호환 플랫폼 설정
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
