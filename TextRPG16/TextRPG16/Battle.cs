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
<<<<<<< Updated upstream


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
=======
            Random random = new Random();
            int num = random.Next(1, 101); // 1 ~ 100

            int finalDamage = resultDamage; // ���� ����� �ʱ�ȭ
            string attackType = ""; // ���� ���� �޼���

            if (num >= 1 && num <= 60) // 1 ~ 60 -> 60% 
            {
                attackType = "�Ϲ� ����";
            }
            else if (num > 60 && num <= 80) // 61 ~ 80 -> 20% ġ��Ÿ
            {
                finalDamage = (int)(resultDamage * 1.5); // ġ��Ÿ�� 1.5�� �����
                attackType = "ġ��Ÿ ����!!";
            }
            else // 81 ~ 100 -> 20% ȸ��
            {
                finalDamage = 0; // ȸ�� �� �������� 0
                attackType = "ȸ�� ����!!";
            }

            int tempMonsterHP = monster.HP; // ���� ���� HP
            Console.WriteLine($"Battle!!");
            Console.WriteLine();
            Console.WriteLine($"{user.Name} �� ����!");
            Console.WriteLine($"Lv.{monster.Level} {monster.Name}��(��) ������ϴ�. [������ : {finalDamage}] - {attackType}");

            if (finalDamage > 0) // �������� ���� ���� HP ����
            {
                Console.WriteLine();
                Console.WriteLine($"Lv.{monster.Level} {monster.Name}");
                Console.Write($"HP {tempMonsterHP} -> ");

                monster.TakeDamage(finalDamage); // ���Ϳ��� ������ ����

                if (monster.IsDead)
                {
                    Console.WriteLine("Dead");
                    user.MonsterCount[monsterIndex]++; // ���� ī��Ʈ ����
                    user.AddKillCount();
                }
                else
                {
                    Console.WriteLine(monster.HP); // ���� HP ���
                }
            }
            else
>>>>>>> Stashed changes
            {
                Console.WriteLine("������ ȸ�ǵǾ����ϴ�!");
            }


        }
    }
}
                

             