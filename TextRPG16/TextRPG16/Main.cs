namespace TextRPG16
{
    internal class TextRPG16
    {
        // test
        static void Main(string[] args)
        {
            // 객체생성
            GameManager gameManager = new GameManager();

            User user;
            Item item;

            // 로딩창
            gameManager.LodingScreen();


            // 객체 생성
            user = new User();
            item = new Item();
            item.AddItem();
            // 최초 시작창
            gameManager.StartScreen(user);


            // ------------------- 게임 플레이 -------------------
            gameManager.GamePlay(user, item);
        }
    }
}
