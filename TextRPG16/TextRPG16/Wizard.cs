﻿using System;

namespace TextRPG16
{
    class Wizard : User
    {
        public Wizard() // 생성자
        {
            UserClass = "마법사";
            FullHP = 100; // 초기 체력
            HP = 100; // 초기 체력
            FullMP = 300; // 초기 마나
            MP = FullMP; // 초기 마나
            DefensPower = 0; // 초기 방어력
            AttackDamage = 35; // 초기 공격력

        }

    }
}
