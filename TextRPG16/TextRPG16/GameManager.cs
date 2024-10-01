namespace TextRPG16
{
    public class GameManager
    {
        public void GamePlay(User user, Item gameItem)
        {
            while (true)
            {



                {
                    case 0:
                        // 게임종료
                        //gameManager.GameSave(user, gameItem);
                        Console.WriteLine("--------------------------------------");
                        Console.WriteLine("|                                    |");
                        Console.WriteLine("|     플레이 해주셔서 감사합니다!    |");
                        Console.WriteLine("|                                    |");
                        Console.WriteLine("--------------------------------------");
                        Environment.Exit(0);
                        break;
                    case 1:


                        break;
                    case 2:

                        break;

                    case 3:
                        // 상점

                        break;
                    default:
                        continue;

                    }

                }
            }
        // 파일 경로
        public string filePath1 = "TextRPG_Reform_User";
        public string filePath2 = "TextRPG_Reform_Item";

        // 로딩창 메소드
        public void LodingScreen()
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("|                                    |");
            Console.WriteLine("|             Wellcome!!             |");
            Console.WriteLine("|          Sparta  TextRPG           |");
            Console.WriteLine("|                                    |");
            Console.WriteLine("--------------------------------------");

            Thread.Sleep(1200);
            Console.Clear();
        }

        // 시작창 메소드
        public void StartScreen(User user)
        {

            // ------------------- 시작창 -------------------
            Console.WriteLine("[계정 생성]");
            Console.WriteLine("Sparta TextRPG 게임을 처음 시작합니다.");
            Console.WriteLine();
            // 닉네임 설정
            Console.WriteLine("환영합니다. 모험가님!");
            Console.WriteLine("사용하실 닉네임을 입력해주세요.");
            Console.WriteLine();
            Console.Write(">> ");
            user.InputName(Console.ReadLine());

            user.ChoiceUserClass(user);
        }

        // 파일 경로
        public string filePath1 = "TextRPG_Reform_User";
        public string filePath2 = "TextRPG_Reform_Item";

        // 로딩창 메소드
        public void LodingScreen()
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("|                                    |");
            Console.WriteLine("|             Wellcome!!             |");
            Console.WriteLine("|          Sparta  TextRPG           |");
            Console.WriteLine("|                                    |");
            Console.WriteLine("--------------------------------------");

            Thread.Sleep(1200);
            Console.Clear();
        }

        // 시작창 메소드
        public void StartScreen(User user)
        {

            // ------------------- 시작창 -------------------
            Console.WriteLine("[계정 생성]");
            Console.WriteLine("Sparta TextRPG 게임을 처음 시작합니다.");
            Console.WriteLine();
            // 닉네임 설정
            Console.WriteLine("환영합니다. 모험가님!");
            Console.WriteLine("사용하실 닉네임을 입력해주세요.");
            Console.WriteLine();
            Console.Write(">> ");
            user.InputName(Console.ReadLine());

            user.ChoiceUserClass(user);
        }


        // 게임 데이터 저장 메소드
        public void GameSave(User user, Item gameItem)
        {
            Console.Clear();

            //string jsonData1 = JsonConvert.SerializeObject(user, Formatting.Indented);
            //File.WriteAllText(filePath1, jsonData1);

            //string jsonData2 = JsonConvert.SerializeObject(gameItem, Formatting.Indented);
            //File.WriteAllText(filePath2, jsonData2);

            Console.WriteLine("--------------------------------------");
            Console.WriteLine("|                                    |");
            Console.WriteLine("|         게임저장 완료!! ^0^/       |");
            Console.WriteLine("|                                    |");
            Console.WriteLine("--------------------------------------");
            Thread.Sleep(1000);
            Console.Clear();
        }
    }
    void DisplayMainUI();
    {
        Console.Clear();
        Console.WriteLine($"스파르타 마을에 오신 {user.Name} 님 환영합니다.\n이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.\n");
        Console.WriteLine("1. 상태보기");
        Console.WriteLine("2. 인벤토리");
        Console.WriteLine("3. 상점");
        Console.WriteLine("4. 던전입장");
        Console.WriteLine("5. 휴식하기");
        Console.WriteLine("6. 게임저장");
        Console.WriteLine("0. 종료");
        Console.WriteLine();
        Console.WriteLine("원하시는 행동을 입력해주세요.");
        Console.Write(">> ");

        int result = checkInput(1, 3);


switch (result)
{
    case 1:
        DisplayStatUI()
            break;

    case 2:
        DisplayInventoryUI()
            break;

    case 3:
        DisplayStoreUI()
            break;
}


    static void DisplayStatUI(0, 0);
    {
        // 상태창
        Console.Clear();
        Console.WriteLine("상태 보기");
        Console.WriteLine("캐릭터의 정보가 표시됩니다.");
        Console.WriteLine();
        Console.WriteLine("0. 나가기");
        Console.WriteLine();
        Console.WriteLine("원하시는 행동을 입력해주세요");

        int result = checkInput(0, 0);



}

    static void DisplayInventoryUI();
    {
        // 인벤토리
        Console.WriteLine("인벤토리");
        Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
        Console.WriteLine();
        Console.WriteLine("[아이템 목록]");
        Console.WriteLine();
        Console.WriteLine("1. 장착 관리");
        Console.WriteLine("0. 나가기");
        Console.WriteLine();
        Console.WriteLine("원하시는 행동을 입력해주세요.");
    }

    static void DisplayStoreUI();
    { 
        Console.WriteLine("상점");
        Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
        Console.WriteLine();
        Console.WriteLine("[아이템 목록]");
        Console.WriteLine();
        Console.WriteLine("[아이템 구매]");
        Console.WriteLine("1. 장착 관리");
        Console.WriteLine("0. 나가기");
        Console.WriteLine();
        Console.WriteLine("원하시는 행동을 입력해주세요.");

        int x = checkInput(1, 3);
    }

    static int checkInput(int min, int max)
    {

        int result;
        // Try.Parse()
        while (true)
        {
            // 1 2 3 10 20 osdasdda
            string input = Console.ReadLine();
            bool isNumber = int.TryParse(input. out result);
            result = int.Parse(input);
            if (isNumber)
            {
            if (result >= min && result <= max)
                return result;
            }
            Console.WriteLine("잘못된 입력입니다.");
        }
        
    }
}

