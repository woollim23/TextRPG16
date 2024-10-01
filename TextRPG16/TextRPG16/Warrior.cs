using System;

namespace TextRPG16
{
    class Warrior : User
    {
        public Warrior() // 생성자
        {
            UserClass = "전사";
            FullHP = 100; // 초기 체력
            HP = FullHP; // 현재 체력
            FullMP = 100; // 초기 마나
            MP = FullMP; // 초기 마나
            DefensPower = 80; // 초기 방어력
            AttackDamage = 20; // 초기 공격력
        }

    }
}