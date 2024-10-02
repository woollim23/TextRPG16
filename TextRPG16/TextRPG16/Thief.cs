using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG16
{
    public class Thief : User
    {
        public Thief(User user) // 생성자
        {
            user.UserClass = "도적";
            user.FullHP = 100; // 초기 체력
            user.HP = FullHP; // 초기 체력
            user.FullMP = 200; // 초기 마나
            user.MP = FullMP; // 초기 마나
            user.DefensPower = 40; // 초기 방어력
            user.AttackDamage = 12; // 초기 공격력
        }

        public int ThiefSkill(int attackDamage)
        {
            Random rand = new Random();
            int count = rand.Next(1, 3);

            int skillDamage = 0;

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(""); // 카운트 수만큼 대사
            }

            return skillDamage * count;
        }
    }
}
