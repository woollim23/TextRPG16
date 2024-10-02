namespace TextRPG16
{
    public static class Battle
    {
        // 유저 스킬 선택 창
        // 0. 스킬1 선택
        // 1. 스킬2 선택

        // 유저 스킬 선택 결과창
        // {""}스킬 발동!
        // 스킬을 사용하여, 몬스터에게 ~를 합니다.
        

        // 유저 스킬 공격 결과창
        public static void SkillAttckResult(User user, Monster monster, int resultDamage, int monsterIndex)
        {
            //Random random = new Random();
            //int num = random.Next(1, 101); // 1 ~ 100
            //if (num >= 1 && num <= 60) // 1 ~ 60 -> 60% 
            //{
                int tempMonsterHP = monster.monsterList[monsterIndex].HP; // 현재 몬스터 HP

                monster.monsterList[monsterIndex].HP -= resultDamage;

                Console.WriteLine($"Battle!!");
                Console.WriteLine();
                Console.WriteLine($"{user.Name} 의 공격!");
                Console.WriteLine($"Lv.{monster.monsterList[monsterIndex].Level} {monster.monsterList[monsterIndex].Name}을(를) 맞췄습니다!. [데미지 : {resultDamage}] ");
                Console.WriteLine();
                Console.WriteLine($"Lv.{monster.monsterList[monsterIndex].Level} {monster.monsterList[monsterIndex].Name}");
                Console.Write($"HP {tempMonsterHP} -> ");

                if (monster.IsDead || monster.monsterList[monsterIndex].HP < 0)
                {
                    Console.WriteLine("Dead");
                    user.MonsterCount[monsterIndex]++;
                    user.AddKillCount();
                }
                else
                {
                    Console.WriteLine(monster.monsterList[monsterIndex].HP);
                }
                Console.WriteLine();
            
            //}
            //else if ()// 60 ~ 80 -> 20% 치명타는 resultDamage * 1.5
            //{ }
            //else // 80 ~ 100 -> 20% 회피는 resultDamage = 0;
            //{ }

        }


        public static void SkillRandomAttackResult(User user, Monster monster, int resultDamage)
        {
            Console.Clear();
            int randomTemp = -1;
            int count = 0;
            while(count != 2)
            {
                Random random = new Random();
                int index = random.Next(0, monster.monsterList.Count);

                if(index != randomTemp)
                {
                    Battle.SkillAttckResult(user, monster, resultDamage, index);
                    randomTemp = index;
                    count++;
                }
            }
        }
    }
}