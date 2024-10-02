namespace TextRPG16
{
    public static class Battle
    {
        // ���� ��ų ���� ���â
        public static void SkillAttckResult(User user, Monster monster, int resultDamage, int monsterIndex)
        {


            int tempMonsterHP = monster.HP; // ���� ���� HP
            Console.WriteLine($"Battle!!");
            Console.WriteLine();
            Console.WriteLine($"{user.Name} �� ����!");
            Console.WriteLine($"Lv.{monster.Level} {monster.Name}��(��) ������ϴ�!. [������ : {resultDamage}]");
            Console.WriteLine();
            Console.WriteLine($"Lv.{monster.Level} {monster.Name}");
            Console.Write($"HP {tempMonsterHP} -> ");

            if (monster.IsDead)
            {
                Console.WriteLine("Dead");
                user.MonsterCount[monsterIndex]++;
                user.AddKillCount();
            }
            else
            {
                Console.WriteLine(monster.HP);
            }
            Console.WriteLine();

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