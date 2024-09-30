using System;

namespace TextRPG16
{
    class Quest
    {
        enum QuestType { Equip, Growth, Hunt };

        QuestType qType;
        string name = null!;
        string context = null!;

        public bool isEquip = false;

        public int lvUp = Constants.MAX;

        public string mobName = null!;
        public int totalMob = Constants.MAX;
        public int mobCnt = 0;

        bool isAccept = false;
        bool isClear = false;

        int goldAmends = 0;
        Item itemAmends = null!;

        public Quest(int questType, string name, string context, int goldAmends, Item itemAmends)
        {
            this.name = name;
            this.context = context;

            this.goldAmends = goldAmends;
            this.itemAmends = itemAmends;

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
                    //mobName = null;
                    totalMob = random.Next(3, 8);
                    break;
            }

            this.goldAmends = goldAmends;
        }

        public void AddQuest()
        {
            List<Quest> quests = new List<Quest>();
            quests.Add(new Quest(2, "마을을 위협하는 미니언 처치", "이봐! 마을 근처에 미니언들이 너무 많아졌다고 생각하지 않나?\r\n마을주민들의 안전을 위해서라도 저것들 수를 좀 줄여야 한다고!\r\n모험가인 자네가 좀 처치해주게!", 300, null!));
            quests.Add(new Quest(1, "장비를 장착해보자!", "무기 또는 방어구 장비 1개 이상 장착하여 공격력과 방어력을 상승시켜보자!", 100, null!));
            quests.Add(new Quest(0, "더욱 더 강해지기!", "전투력을 증가시키기 위해 레벨업을 달성해보자!", 200, null!));
        }

        public void IsCleared()
        {
            if(isEquip || lvUp == 0 || mobCnt == totalMob)
            {
                isClear = true;
            }
        }

        public void DisplayQuest()
        {
            IsCleared();

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
                    Console.WriteLine($"- {mobName} {totalMob}마리 처치 ({mobCnt}/{totalMob})");
                    break;
            }

            // 클리어 보상
            Console.WriteLine("- 보상 -");                // - 보상 - 
            Console.Write($"{itemAmends}, {goldAmends}"); // 쓸만한 방패 x 1
                                                          // 5G
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

            Console.WriteLine("원하시는 행동을 입력해주세요");
            Console.Write(">>> ");

            int select = InputCheck.Check(1, 2);
            if (!isAccept && select == 1)
            {
                isAccept = true;
            }
            else if(isAccept && select == 1)
            {
                isAccept = false;
            }
            else if(isAccept && isClear && select == 1)
            {
                // 보상 받기
            }
        }
    }
}
