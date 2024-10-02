namespace TextRPG16
{
    public static class Battle
    {
        // ���� ��ų ���� â
        // 0. ��ų1 ����
        // 1. ��ų2 ����

        // ���� ��ų ���� ���â
        // {""}��ų �ߵ�!
        // ��ų�� ����Ͽ�, ���Ϳ��� ~�� �մϴ�.
        

        // ���� ��ų ���� ���â
        public static void SkillAttckResult(User user, Monster monster, int resultDamage, int monsterIndex)
        {
            //Random random = new Random();
            //int num = random.Next(1, 101); // 1 ~ 100
            //if (num >= 1 && num <= 60) // 1 ~ 60 -> 60% 
            //{
                int tempMonsterHP = monster.monsterList[monsterIndex].HP; // ���� ���� HP

                monster.monsterList[monsterIndex].HP -= resultDamage;

                Console.WriteLine($"Battle!!");
                Console.WriteLine();
                Console.WriteLine($"{user.Name} �� ����!");
                Console.WriteLine($"Lv.{monster.monsterList[monsterIndex].Level} {monster.monsterList[monsterIndex].Name}��(��) ������ϴ�!. [������ : {resultDamage}] ");
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
            //else if ()// 60 ~ 80 -> 20% ġ��Ÿ�� resultDamage * 1.5
            //{ }
            //else // 80 ~ 100 -> 20% ȸ�Ǵ� resultDamage = 0;
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