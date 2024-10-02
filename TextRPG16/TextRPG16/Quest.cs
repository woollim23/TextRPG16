using System;
using System.Reflection.Metadata.Ecma335;

namespace TextRPG16
{
    class Quest
    {
        enum QuestType { Equip, Growth, Hunt };

        QuestType qType;
        public string name = null!;
        public string context = null!;

        public bool isEquip = false;

        public int lvUp = Constants.MAX;

        public int totalMob = Constants.MAX;
        public int mobCnt = 0;

        public bool isAccept = false;
        public bool isClear = false;

        public int goldAmends = 0;
        //Item itemAmends = null!;

        public Quest(int questType, string name, string context, int goldAmends)
        {
            this.name = name;
            this.context = context;

            this.goldAmends = goldAmends;
            // this.itemAmends = itemAmends;

            Random random = new Random();

            switch ((QuestType)questType)
            {
                case QuestType.Equip:
                    qType = QuestType.Equip;
                    break;
                case QuestType.Growth:
                    qType = QuestType.Growth;
                    lvUp = random.Next(1, 4);
                    break;
                case QuestType.Hunt:
                    qType = QuestType.Hunt;
                    totalMob = random.Next(3, 8);
                    break;
            }

            this.goldAmends = goldAmends;
        }

        public void IsCleared()
        {
            if(isEquip || lvUp == 0 || mobCnt >= totalMob)
            {
                isClear = true;
            }
        }

        public new int GetType()
        {
            return (int)qType;
        }

        public int DisplayQuest()
        {
            Random random = new Random();
            

            Console.Clear();

            Console.WriteLine("Quest!!!");  // Quest!!
            Console.WriteLine();

            Console.WriteLine(this.name); // 마을을 위협하는 미니언 처치
            Console.WriteLine();

            Console.WriteLine(this.context); // 이봐! 마을 근처에 미니언들이 너무 많아졌다고 생각하지 않나?
            Console.WriteLine();            //마을주민들의 안전을 위해서라도 저것들 수를 좀 줄여야 한다고!               //모험가인 자네가 좀 처치해주게!

            switch (qType)                  // - 미니언 5마리 처치 (0/5)
            {
                case QuestType.Equip:
                    Console.WriteLine($"- 장비 1개 이상 착용하기");
                    break;
                case QuestType.Growth:
                    Console.WriteLine($"- {lvUp} Lv 올리기");
                    break;
                case QuestType.Hunt:
                    Console.WriteLine($"- 몬스터 {totalMob}마리 처치 ({mobCnt}/{totalMob})");
                    break;
            }

            // 클리어 보상
            Console.WriteLine();
            Console.WriteLine("- 보상 -");    // - 보상 - 
            Console.WriteLine($"  {goldAmends} G");     // 5G
            Console.WriteLine();

            if (!isAccept)
            {
                Console.WriteLine("1. 퀘스트 수락");
                Console.WriteLine("2. 퀘스트 거절");
                Console.WriteLine();
            }
            else if (isAccept && !isClear)
            {
                Console.WriteLine("1. 퀘스트 포기하기");
                Console.WriteLine("2. 돌아가기");
                Console.WriteLine();
            }
            else if (isAccept && isClear)
            {
                Console.WriteLine("1. 퀘스트 보상받기");
                Console.WriteLine("2. 돌아가기");
                Console.WriteLine();
            }

            Console.WriteLine("0. 이전으로 돌아가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요");
            Console.Write(">>> ");

            int select = InputCheck.Check(0, 2);
            if (!isAccept && select == 1)
            {
                isAccept = true;
            }
            else if(isAccept && !isClear && select == 1)
            {
                isAccept = false;
                mobCnt = 0;
                lvUp = random.Next(1, 4);
            }
            else if(isAccept && isClear && select == 1)
            {
                return 1;
            }

            return 0;
        }
    }
}
