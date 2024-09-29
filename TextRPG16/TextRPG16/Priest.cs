using System;

namespace TextRPG16
{
    class Priest : User
    {
        public Priest() // 생성자
        {
            UserClass = "성직자";
            HP = 100; // 초기 체력
            DefensPower = 60; // 초기 방어력
            AttackDamage = 10; // 초기 공격력

        }

    }
}