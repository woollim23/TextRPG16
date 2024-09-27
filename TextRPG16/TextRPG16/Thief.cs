using System;

namespace TextRPG16
{
    class Thief : User
    {
        public Thief() // 생성자
        {
            UserClass = "도적";
            HP = 100; // 초기 체력
            DefensPower = 10; // 초기 방어력
            AttackDamage = 15; // 초기 공격력

        }

    }
}