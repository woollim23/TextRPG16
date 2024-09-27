using System;

namespace TextRPG16
{
    class Wizard : User
    {
        public Wizard() // 생성자
        {
            UserClass = "마법사";
            HP = 100; // 초기 체력
            DefensPower = 15; // 초기 방어력
            AttackDamage = 25; // 초기 공격력

        }

    }
}
