﻿using System;

namespace TextRPG16
{
    class Warrior : User
    {
        public Warrior() // 생성자
        {
            UserClass = "전사";
            HP = 100; // 초기 체력
            DefensPower = 30; // 초기 방어력
            AttackDamage = 20; // 초기 공격력

        }

    }
}