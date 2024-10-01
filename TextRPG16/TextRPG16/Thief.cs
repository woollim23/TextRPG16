using System;

namespace TextRPG16
{
    class Thief : User
    {
        public Thief() // 생성자
        {
            UserClass = "도적";
            FullHP = 100; // 초기 체력
            HP = 100; // 초기 체력
            FullMP = 200; // 초기 마나
            MP = FullMP; // 초기 마나
            DefensPower = 40; // 초기 방어력
            AttackDamage = 12; // 초기 공격력
        }

    }
}