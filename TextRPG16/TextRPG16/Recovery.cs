namespace TextRPG16
{
    public class Recovery
    {
        public Recovery()
        {

        }

        public void Rest(User user)
        {
            while (user.HP < user.FullHP) { user.HP++; }  // 마을에서 휴식하는것과 같은방식
            while (user.MP < user.FullMP) { user.MP++; }  // 체력이랑 마나랑 별개의 통을 가지고 있으니까 반복문 두개로 나눔
            Console.WriteLine($"회복중입니다. 현재 체력:{user.HP} 현재 마나:{user.MP}");
            Console.Clear();
            Console.WriteLine("회복이 완료되었습니다");
        }
    }
}




