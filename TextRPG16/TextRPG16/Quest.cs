namespace TextRPG16
{
    //List<Quest> quests = new List<Quest>();

    class Quest
    {
        enum QuestType { Equip, Growth, Hunt };
        string name = null!;
        string context = null!;

        public bool isEquip = false;

        public int lvUp = 0;

        public string mobName = null!;
        public int totalMob = 0;
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
                    break;
                case QuestType.Growth:
                    lvUp = random.Next(1, 4);
                    break;
                case QuestType.Hunt:
                    //mobName = null;
                    totalMob = random.Next(3, 8);
                    break;
            }

            this.goldAmends = goldAmends;
        }

        public void DisplayQuest()
        {
            Console.WriteLine("Quest!!!");
            Console.WriteLine();

            Console.WriteLine(name);
            Console.WriteLine();

            Console.WriteLine(context);
            Console.WriteLine();

            // ex 퀘스트 클리어 조건
            Console.WriteLine($"ex) {mobName} {totalMob}마리 처치 ({mobCnt}/{totalMob})");

            // 클리어 보상
            Console.WriteLine("- 보상 -");
            Console.Write($"{itemAmends}, {goldAmends}");

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
