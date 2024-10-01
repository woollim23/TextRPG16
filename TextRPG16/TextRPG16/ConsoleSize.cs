using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG16
{
    public class ConsoleSize
    {
        // 콘솔 창 크기 설정
        int width = 80;  // 너비
        int height = 40; // 높이



        // 콘솔 크기 고정
        public void ConsoleSetSize(int width, int height)
        {
            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height); // 버퍼 크기도 동일하게 설정

        }
    }
}
