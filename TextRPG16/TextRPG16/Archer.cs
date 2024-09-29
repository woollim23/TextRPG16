using System;

namespace TextRPG16
{
    class Archer : User
    {
        public Archer() // 생성자
        {
            UserClass = "궁수";
            HP = 100; // 초기 체력
            DefensPower = 10; // 초기 방어력
            AttackDamage = 15; // 초기 공격력

        }

    }
}