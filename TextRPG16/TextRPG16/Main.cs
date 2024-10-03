using Newtonsoft.Json;

namespace TextRPG16
{
    static class Constants
    {
        public const int MAX = 1000000;
    }

    internal class TextRPG16
    {
        // test
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
                user = new User();
                item = new Item();
                item.AddItem();
                consumableItem = new ConsumableItem();
                consumableItem.AddPotionList();

                // 최초 시작창
                gameManager.StartScreen(user);
            }
            // ------------------- 게임 플레이 -------------------
            gameManager.GamePlay(user, item, consumableItem);
        }
    }
}
