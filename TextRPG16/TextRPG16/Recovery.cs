namespace TextRPG16
{
    public class Recovery
    {
        public Recovery()
        {
             soundManager = new SoundManager();
             asciiArt = new AsciiArt();
        }

        

        // 의도: 반복문과 출력문을 쓴 이유는 출력속도를 조절해서 회복 상황을 눈으로 확인 할수 있게 할려고...
        // 그러나 차후 팀원과 상의가 필요할듯...

        // 체력이랑 마나랑 별개의 통을 가지고 있으니까 조건에 따라 반복문을 나눈다

        // 마을에서 휴식하는것과 같은방식
        SoundManager soundManager;
        AsciiArt asciiArt;

        
        public void UseRest(User user)
        {
            Console.Clear();

            
            asciiArt.DisplayHeadLine(6);
            
            // 조건 1: HP와 MP가 모두 회복이 필요없는 상태
            if (user.HP == user.FullHP || user.MP == user.FullMP)
            {
                Console.WriteLine("휴식이 필요하지 않습니다");
                Thread.Sleep(1000);
                
            }
            // 조건 2: HP 또는 MP 회복이 필요한 경우
            else
            {
                Console.WriteLine("HP와 MP 회복중입니다...");
                while (user.HP < user.FullHP || user.MP < user.FullMP) // 하나라도 최대치가 아닐 경우
                {

                    
                    if (user.HP < user.FullHP)
                    {
                        user.HP++;
                    }
                    if (user.MP < user.FullMP)
                    {
                        user.MP++;
                    }

                    Console.WriteLine($"현재 체력: {user.HP} 현재 마나: {user.MP}");
                    Thread.Sleep(50);
                   
                }
                Console.WriteLine("회복이 완료되었습니다");
                soundManager.SoundEffectUseRest();
                
                
            }

            Thread.Sleep(1500);
            
            
        }

    }
}











