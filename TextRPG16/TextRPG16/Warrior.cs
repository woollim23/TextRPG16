using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TextRPG16
{
    public class Warrior : User
    {
        public Warrior(User user) // 생성자
        {
            user.UserClass = "전사";
            user.FullHP = 100; // 초기 체력
            user.HP = user.FullHP; // 현재 체력
            user.FullMP = 50; // 초기 마나
            user.MP = user.FullMP; // 초기 마나
            user.DefensPower = 80; // 초기 방어력
            user.AttackDamage = 20; // 초기 공격력
        }
    }
}
