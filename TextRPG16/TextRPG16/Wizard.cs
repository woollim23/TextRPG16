﻿using System;

namespace TextRPG16
{
    class Wizard : User
    {
        public Wizard() // 생성자
        {
            UserClass = "마법사";
            HP = 100; // 초기 체력
            AttackDamage = 20; // 초기 공격력

        }

        // 데미지 처리 메서드
        public void TakeDamage(int damage)
        {
            HP -= damage; // 데미지만큼 체력 감소

            if (IsDead) Console.WriteLine($"{Name}이(가) 죽었습니다.");
            else Console.WriteLine($"{Name}이(가) {damage}의 데미지를 받았습니다. 남은 체력: {HP}");
        }

    }
}
