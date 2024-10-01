using System;

namespace TextRPG16
{
    class Priest : User
    {
        public Priest() // 생성자
        {
            UserClass = "성직자";
            FullHP = 100; // 초기 체력
            HP = 100; // 초기 체력
            FullMP = 300; // 초기 마나
            MP = FullMP; // 초기 마나
            DefensPower = 90; // 초기 방어력
            AttackDamage = 5; // 초기 공격력
        }

    }
}