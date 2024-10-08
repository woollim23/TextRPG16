using Newtonsoft.Json;

namespace TextRPG16
{
    public class GameManager
    {
        // 파일 경로
        public string filePath1 = "TextRPG16_User";
        public string filePath2 = "TextRPG16_Item";
        public string filePath3 = "TextRPG16_ConItem";

        // 로딩창 메소드
        public void LodingScreen()
        {
            AsciiArt.SparklingEffect();
            Console.Clear();
        }

        // 게임 플레이 메인 마을 창 메소드
        public void GamePlay(User user, Item gameItem, ConsumableItem consumableItem)
        {
            while (true)
            {
                Console.Clear();
                AsciiArt.DisplayHeadLine(0);
                Console.WriteLine($"스파르타 마을에 오신 {user.Name} 님 환영합니다.\n이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.\n");
                Console.WriteLine("1. 상태보기");
                Console.WriteLine("2. 인벤토리");
                Console.WriteLine("3. 상점");
                Console.WriteLine("4. 퀘스트");
                Console.WriteLine("5. 타워입장");
                Console.WriteLine("6. 휴식하기");
                Console.WriteLine("7. 게임저장");
                Console.WriteLine("0. 종료");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");
                
                int select = InputCheck.Check(0, 7);
                switch (select)
                {
                    case 0:
                        // 게임종료
                        GameSave(user, gameItem, consumableItem);
                        Console.WriteLine(AsciiArt._exitHeadline);
                        Environment.Exit(0);
                        break;
                    case 1:
                        // 상태창
                        user.State(user, gameItem);
                        break;
                    case 2:
                        // 인벤토리
                        Inventory inventory = new Inventory();
                        inventory.SeeInventory(user, gameItem);
                        break;
                    case 3:
                        // 상점이용
                        Store store = new Store();
                        store.UseStore(user, gameItem);
                        break;
                    case 4:
                        // 퀘스트
                        user.DisplayQuests();
                        break;
                    case 5:
                        // 던전입장
                        Stage stage = new Stage(user);
                        stage.StartStage(user, gameItem, consumableItem);
                        break;
                    case 6:
                        // 휴식하기
                        Recovery recovery = new Recovery();
                        recovery.UseRest(user);
                        break;
                    case 7:
                        // 게임 저장
                        GameSave(user, gameItem, consumableItem);
                        break;
                    default:
                        continue;
                }
            }
        }

        // 게임 데이터 저장 메소드
        public void GameSave(User user, Item gameItem, ConsumableItem consumableItem)
        {
            Console.Clear();

            string jsonData1 = JsonConvert.SerializeObject(user, Formatting.Indented);
            File.WriteAllText(filePath1, jsonData1);

            string jsonData2 = JsonConvert.SerializeObject(gameItem, Formatting.Indented);
            File.WriteAllText(filePath2, jsonData2);

            string jsonData3 = JsonConvert.SerializeObject(consumableItem, Formatting.Indented);
            File.WriteAllText(filePath3, jsonData3);

            Console.WriteLine(AsciiArt._saveHeadline);
            Thread.Sleep(1000);
            Console.Clear();
        }
    }
}

