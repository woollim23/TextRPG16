using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG16
{
    public class Wizard : User
    {
        public Wizard(User user) // 생성자
        {
            user.UserClass = "마법사";
            user.FullHP = 100; // 초기 체력
            user.HP = user.FullHP; // 초기 체력
            user.FullMP = 300; // 초기 마나
            user.MP = user.FullMP; // 초기 마나
            user.DefensPower = 0; // 초기 방어력
            user.AttackDamage = 35; // 초기 공격력
        }
    }
}
