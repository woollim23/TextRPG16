using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG16
{
    public class Recovery
    {
        public Recovery() 
        {
            
        }

        public void Rest(User user)
        {
            while(user.HP < user.FullHP || user.MP < user.FullMP)
            {
                user.HP++;
                user.MP++;
                Console.WriteLine($"회복중입니다. 현재 체력:{user.HP} 현재 마나:{user.MP}");
                if(user.HP == user.FullHP && user.MP == user.FullMP)
                    break;
            }
            Console.Clear();
            Console.WriteLine("회복이 완료되었습니다");
        }

    }
}
