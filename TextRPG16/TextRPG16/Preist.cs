using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG16
{
    public class Preist : User
    {
        public Preist(User user) // 생성자
        {
            user.UserClass = "성직자";
            user.FullHP = 100; // 초기 체력
            user.HP = FullHP; // 초기 체력
            user.FullMP = 300; // 초기 마나
            user.MP = FullMP; // 초기 마나
            user.DefensPower = 90; // 초기 방어력
            user.AttackDamage = 5; // 초기 공격력
        }

        public int PreistSkill(int attackDamage)
        {
            int skillDamage = 0;

            return skillDamage;
        }

        public void PreistHeal(User user)
        {
            // 계산 식 추가
            user.HP += 30;
            // FullHP
        }
    }
}
