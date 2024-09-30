using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG16
{
    //List<Quest> quests = new List<Quest>();

    class Quest
    {
        enum QuestType { Equip, Growth, Hunt };
        string name = null!;
        string context = null!;
        
        bool equip = false;
        int lvUp = 0;
        int mobCnt = 0;
        bool isClear = false;

        Item amends = null!;

        public Quest()
        {

        }

        public int DisplayQuest()
        {
            Console.WriteLine("Quest!!!");
            Console.WriteLine();

            Console.WriteLine(name);
            Console.WriteLine();

            // 퀘스트 클리어 조건
            // 클리어 보상

            Console.WriteLine("1. 수락");
            Console.WriteLine("2. 거절");
            Console.WriteLine();

            Console.WriteLine("원하시는 행동을 입력해주세요");
            Console.Write(">>> ");
            return int.Parse(Console.ReadLine()!);
        }
    }
}
