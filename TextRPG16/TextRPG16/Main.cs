using Newtonsoft.Json;

namespace TextRPG16
{
    static class Constants
    {
        public const int MAX = 1000000;
    }

    internal class TextRPG16
    {
        static void Main(string[] args)
        {
            // 객체생성
            GameManager gameManager = new GameManager();
            User user;
            Item item;
            ConsumableItem consumableItem;
            // 로딩창
            gameManager.LodingScreen(); // -> 위치 고민좀 해봐야할듯
            Console.Clear();

            if(File.Exists(gameManager.filePath1)) // 저장 파일이 있다면
            {
                // 저장 데이터 파일 경올 읽어오기
                string jsonData1 = File.ReadAllText(gameManager.filePath1); // 유저 정보
                string jsonData2 = File.ReadAllText(gameManager.filePath2); // 아이템 정보
                string jsonData3 = File.ReadAllText(gameManager.filePath3); // 회복 아이템 정보

                // 객체 생성, 데이터 불러오기
                user = JsonConvert.DeserializeObject<User>(jsonData1);
                item = JsonConvert.DeserializeObject<Item>(jsonData2);
                consumableItem = JsonConvert.DeserializeObject<ConsumableItem>(jsonData3);
            }
            else // 없다면
            {
                // 객체 생성
                item = new Item();
                item.AddItem();
                consumableItem = new ConsumableItem();
                consumableItem.AddPotionList();

                // ------------------- 시작창 -------------------
                Console.WriteLine("[계정 생성]");
                Console.WriteLine("Sparta TextRPG 게임을 처음 시작합니다.");
                Console.WriteLine();
                // 닉네임 설정
                Console.WriteLine("환영합니다. 모험가님!");
                Console.WriteLine("사용하실 닉네임을 입력해주세요.");
                Console.WriteLine();
                Console.Write(">> ");
                string userName = Console.ReadLine()!;

                // ---------------- 캐릭터 직업 선택 -------------------
                Console.Clear();
                Console.WriteLine("[직업 선택]");
                // 직업 선택
                Console.WriteLine("직업을 선택해주세요.(해당 번호 입력)");
                Console.WriteLine();
                Console.WriteLine("1. 전사");
                Console.WriteLine("2. 마법사");
                Console.WriteLine();
                Console.Write(">> ");

                int select = InputCheck.Check(1, 2);
                switch (select)
                {
                    case 1:
                        user = new Warrior();
                        break;
                    case 2:
                        user = new Wizard();
                        break;
                    default:
                        user = new Warrior();
                        break;
                }

                user.InputName(userName);

            }
            // ------------------- 게임 플레이 -------------------
            gameManager.GamePlay(user, item, consumableItem);
        }
    }
}
