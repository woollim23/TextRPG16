using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using System.Xml;

namespace TextRPG16
{
    public class GameManager
    {
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

        public void GamePlay(User user, Item item)
        {
            GameManager gameManager = new GameManager();
            Inventory inventory = new Inventory();
            Store store = new Store();

            while (true)
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

                int select = InputCheck.Check(0, 6);
                switch (select)
                {
                    case 0:
                        // 게임종료
                        gameManager.GameSave(user, item);
                        Console.WriteLine("--------------------------------------");
                        Console.WriteLine("|                                    |");
                        Console.WriteLine("|     플레이 해주셔서 감사합니다!    |");
                        Console.WriteLine("|                                    |");
                        Console.WriteLine("--------------------------------------");
                        Environment.Exit(0);
                        break;
                    case 1:
                        // 상태창
                        user.State(user);
                        break;
                    case 2:
                        // 인벤토리
                        inventory.SeeInventory(user, item);
                        break;
                    case 3:
                        // 상점이용
                        store.UseStore(user, item);
                        break;
                    case 4:
                        // 던전입장
                        
                        break;
                    case 5:
                        // 휴식이용
                        
                        break;
                    case 6:
                        // 게임저장
                        gameManager.GameSave(user, item);
                        break;
                    default:
                        continue;
                }
            }
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
}

