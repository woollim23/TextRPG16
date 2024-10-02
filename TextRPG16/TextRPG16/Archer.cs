using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG16
{
    public class Archer : User
    {
        public Archer(User user) // 생성자
        {
            user.UserClass = "궁수";
            user.FullHP = 100; // 초기 체력
            user.HP = FullHP; // 초기 체력
            user.FullMP = 200; // 초기 마나
            user.MP = FullMP; // 초기 마나
            user.DefensPower = 40; // 초기 방어력
            user.AttackDamage = 12; // 초기 공격력
        }

        public int ArcherSkill(int attackDamage)
        {
            int skillDamage = 0;

            return skillDamage;
        }
    }
}
