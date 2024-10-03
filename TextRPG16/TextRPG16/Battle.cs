using System;

namespace TextRPG16
{
    public class Battle
    {
        public void NextScreenButton()
        {
            Console.WriteLine();
            Console.WriteLine("0. ����");
            Console.WriteLine();
            Console.Write(">> ");
            while (InputCheck.Check(0, 0) != 0)
            {
                Console.Write(">> ");
            }
        }
        // ġ��Ÿ / ȸ�� / ���
        public int DamageLuckyCalculation(int resultDamage)
        {
            Random random = new Random();
            int num = random.Next(1, 101);

            if (num > 60 && num <= 80) // 60 ~ 80 �̸� 1.5�� ġ�� ����
                return (int)(resultDamage * 1.5);
            else if (num > 80 && num <= 100) // 80 ~ 100 �̸� ȸ��
                return -1;
            else // �� �� �Ϲ� ����
                return resultDamage;
        }

        // ----------------- ���� ���� -------------------
        // ���� �Ϲ� ����
        public int UserAttack(User user, Monster monster, int attackDamage)
        {
            // �������� 10%�� ���
            float num = attackDamage * 0.1f;

            Random random = new Random();
            float resultDamage = (float)(random.NextDouble() * ((attackDamage + num) - (attackDamage - num)) + (attackDamage - num));

            return (int)resultDamage;
        }
        // ���� ��ų��
        public int WarriorSkill2_Execute(User user, Monster monster, int attackDamage)
        {
            if (user.MP < 20)
            {
                Console.WriteLine("������ �����ؼ� ��ų�� ��� �� �� �����ϴ�.");
                Thread.Sleep(1000);
                return -5;
            }

            Console.WriteLine("ó�� ��ų ���! ���� �� 1���� �������� ���մϴ�.");

            // ���ݷ�*��ų ��� = ��ų ������
            int tempAttackDamage = attackDamage * 2;

            // �������� 10%�� ���
            float num = tempAttackDamage * 0.1f;

            //������ �������� ���� �� ������ �Ǽ������� ����  // ���ݷ��� 10�̸�, 9 ~ 11
            Random random = new Random();
            float resultDamage = (float)(random.NextDouble() * ((tempAttackDamage + num) - (tempAttackDamage - num)) + (tempAttackDamage - num));

            user.MP -= 20;

            Thread.Sleep(1000);
            return (int)resultDamage;
        }
        public int WarriorSkill3_Slash(User user, Monster monster, int attackDamage)
        {
            if (user.MP < 30)
            {
                Console.WriteLine("������ �����ؼ� ��ų�� ��� �� �� �����ϴ�.");
                Thread.Sleep(1000);
                return -5;
            }

            Console.WriteLine("������ ��ų ���! ������ �� 2���� �������� ���մϴ�.");

            // ���ݷ� * ��ų ��� = ��ų ������
            float tempAttackDamage = attackDamage * (1.5f);

            // �������� 10%�� ���
            float num = tempAttackDamage * 0.1f;

            // ������ �������� ���� �� ������ �Ǽ������� ���� // ���ݷ��� 10�̸�, 9 ~ 11
            Random random = new Random();
            float resultDamage = (float)(random.NextDouble() * ((tempAttackDamage + num) - (tempAttackDamage - num)) + (tempAttackDamage - num));

            /*
            //// �̹� ������ ���� �����ϱ� ���� ����Ʈ
            //List<int> attackedTargets = new List<int>();

            //// �� 2���� ���Ϳ��� �������� ����
            //for (int i = 0; i < 2; i++)
            //{
            //    int randomIndex;

            //    // �ߺ����� �ʴ� ���͸� �����ϱ� ���� ����
            //    do
            //    {
            //        randomIndex = random.Next(0, monster.monsterList.Count);
            //    }
            //    while (attackedTargets.Contains(randomIndex) || monster.monsterList[randomIndex].IsDead); // �ߺ� üũ �� ����� ���� ����

            //    attackedTargets.Add(randomIndex); // ������ ���� �ε����� ���

            //    // ���� �������� ���Ϳ��� ���� (�ݿø��ؼ�)
            //    int finalDamage = (int)resultDamage;
            //    monster.monsterList[randomIndex].TakeDamage(finalDamage);

            //    // ��� ���
            //    Console.WriteLine($"�������� ���õ� �� {monster.monsterList[randomIndex].Name}���� {finalDamage} ������� �������ϴ�.");
            //}
            */

            user.MP -= 30;

            Thread.Sleep(1000);
            return (int)resultDamage;
        }
        public int WizardSkill2_Fireball(User user, Monster monster, int attackDamage)
        {
            if (user.MP < 80)
            {
                Console.WriteLine("������ �����ؼ� ��ų�� ��� �� �� �����ϴ�.");
                Thread.Sleep(1000);
                return -5;
            }

            Console.WriteLine("���̾ ��ų ���! ���������� �մϴ�.");

            // ���ݷ� * ��ų ��� = ��ų ������
            float tempAttackDamage = attackDamage * (2);

            // �������� 10%�� ���
            float num = tempAttackDamage * 0.1f;

            // ������ �������� ���� �� ������ �Ǽ������� ���� // ���ݷ��� 10�̸�, 9 ~ 11
            Random random = new Random();
            float resultDamage = (float)(random.NextDouble() * ((tempAttackDamage + num) - (tempAttackDamage - num)) + (tempAttackDamage - num));

            /*
            // Ÿ�� ���Ϳ��� Ǯ ������ ����
            //monster.monsterList[targetIndex].TakeDamage(skillDamage);
            //Console.WriteLine($"Ÿ�ٵ� ������ {monster.monsterList[targetIndex].Name}���� {skillDamage} ������� �������ϴ�."); // tagetIndex, skillDamage

            // �ֺ� ���Ϳ��� 1/3 ������ ����
            //for (int i = 0; i < monster.monsterList.Count; i++)
            //{
            //    if (i != targetIndex && !monster.monsterList[i].IsDead)
            //    {
            //        int splashDamage = skillDamage / 3;
            //        monster.monsterList[i].TakeDamage(splashDamage);
            //        Console.WriteLine($"�ֺ� �� {monster.monsterList[i].Name}���� {splashDamage} ������� �������ϴ�."); // i, splahDamage
            //    }
            //}
            */
            user.MP -= 80;

            Thread.Sleep(1000);
            return (int)resultDamage;
        }
        public int WizardSkill3_ManaShield(User user, Monster monster)
        {
            if (user.MP < 30)
            {
                Console.WriteLine("������ �����ؼ� ��ų�� ��� �� �� �����ϴ�.");
                Thread.Sleep(1000);
                return -5;
            }
            user.MP -= 30;
            Console.WriteLine("�����ǵ� ���! �����ǵ带 �����մϴ�.");
            Thread.Sleep(1000);
            return 0;
        }

        // ���� ���� ��� ����
        public void SkillAttckResult(User user, Monster monster, int resultDamage)
        {
            int tempMonsterHP = monster.HP; // ���� ���� ü�� ����
            int tempResultDamage = resultDamage; // ���� ���� ������ ����

            ConsoleSize.Color(ConsoleColor.Blue);
            Console.WriteLine($"{user.Name} �� ����!");
            Console.ResetColor();

            resultDamage = DamageLuckyCalculation(resultDamage); // ġ��Ÿ / ȸ�� / �Ϲݰ��� ��� �Լ�

            if (monster.IsDead)
            {
                Console.Write($"Lv.{monster.Level} {monster.Name}��(��) �̹� ���� �����Դϴ�..\n");
            }
            else if (resultDamage > 0)
            {
                monster.TakeDamage(resultDamage);
                Console.Write($"Lv.{monster.Level} {monster.Name}��(��) ������ϴ�!. [������ : {resultDamage}] ");
                if (tempResultDamage < resultDamage)
                {
                    ConsoleSize.Color(ConsoleColor.Red);
                    Console.Write("- ġ��Ÿ ����!!\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write("\n");
                }
                // �� ���� ���
                Console.WriteLine();
                Console.WriteLine($"Lv.{monster.Level} {monster.Name}");
                Console.Write($"HP {tempMonsterHP} -> ");
                if (monster.IsDead)
                {
                    user.AddKillCount();
                    Console.WriteLine("Dead");
                }
                else
                {
                    Console.WriteLine(monster.HP);
                }
            }
            else // ȸ���� ���
            {
                Console.Write($"Lv.{monster.Level} {monster.Name}��(��) ���������� �ƹ��ϵ� �Ͼ�� �ʾҽ��ϴ�..\n");
            }

            Console.WriteLine();
        }
        // ���� ���� ��ų ���� ��� â
        public void SkillRandomAttackResult(User user, Monster monster, int resultDamage)
        {
            Console.Clear();

            // ����ִ� ���� ����Ʈ ����
            List<Monster> aliveMonsters = monster.monsterList.Where(m => !m.IsDead).ToList();

            Random random = new Random();

            // ����ִ� ���Ͱ� 1������ �� 1������ ����
            if (aliveMonsters.Count == 1)
            {
                Monster target = aliveMonsters[0];
                SkillAttckResult(user, target, resultDamage); // 1������ ����
            }
            else
            {
                // 2���� �������� ���� (�ߺ����� �ʵ���)
                List<Monster> randomTargets = aliveMonsters.OrderBy(x => random.Next()).Take(2).ToList();

                // ���õ� ���� 2���� ����
                foreach (var target in randomTargets)
                {
                    SkillAttckResult(user, target, resultDamage);
                }
            }


            NextScreenButton();
        }
        public static void SkillRandomAttackResult2(User user, Monster monster, int resultDamage)
        {
            Console.Clear();
            int randomTemp = -1;
            int count = 0;
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
                    //user.MonsterCount[monsterIndex]++; // ���� ī��Ʈ ����
                    user.AddKillCount();
                }
                else
                {
                    Console.WriteLine(monster.HP); // ���� HP ���
                }
            }
            else
            {
                Console.WriteLine("������ ȸ�ǵǾ����ϴ�!");
            }


        }

        // ----------------- ���� ���� -------------------
        // ���� ����
        public int MonsterAttack(User user, Monster monster)
        {
            int num = (int)Math.Round(((double)monster.AttackDamage / 100 * 10), 0); // ������

            Random random = new Random();
            int resultDamage = random.Next((int)monster.AttackDamage - num, (int)monster.AttackDamage + num);

            return resultDamage;
        }
        // ���� ���� ��� â
        public void MonsterAttackResultScreen(User user, Monster monster, int resultDamage)
        {
            Console.Clear();
            int tempUserHP = user.HP; // ���� ���� ���� ü�� ����
            int tempResultDamage = resultDamage; // ���� ���� ���� ������ ����

            ConsoleSize.Color(ConsoleColor.DarkYellow);
            Console.WriteLine($"{monster.Name} �� ����!");
            Console.ResetColor();

            resultDamage = DamageLuckyCalculation(resultDamage); // ġ��Ÿ / ȸ�� / �Ϲݰ��� ��� �Լ�

            if (resultDamage > 0)
            {
                user.TakeDamage(resultDamage);
                Console.Write($"Lv.{user.Level} {user.Name}��(��) ������ϴ�!. [������ : {resultDamage}] ");
                if (tempResultDamage < resultDamage)
                {
                    ConsoleSize.Color(ConsoleColor.Red);
                    Console.Write("- ġ��Ÿ ����!!\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write("\n");
                }
                // �� ���� ���
                Console.WriteLine();
                Console.WriteLine($"Lv.{user.Level} {user.Name}");
                Console.Write($"HP {tempUserHP} -> ");
                if (user.IsDead)
                {
                    Console.WriteLine("Dead");
                }
                else
                {
                    Console.WriteLine(user.HP);
                }
            }
            else // ȸ���� ���
            {
                Console.Write($"Lv.{user.Level} {user.Name}��(��) ���������� �ƹ��ϵ� �Ͼ�� �ʾҽ��ϴ�..");
            }
            Console.WriteLine();
            NextScreenButton();
        }
        // ���� �ǵ� ���� ��� â
        // ���� ���� ��� â
        public void ShieldMonsterAttackResultScreen(User user, Monster monster, int resultDamage)
        {
            Console.Clear();
            int tempUserMP = user.MP; // ���� ���� ���� ü�� ����
            int tempResultDamage = resultDamage; // ���� ���� ���� ������ ����

            ConsoleSize.Color(ConsoleColor.DarkYellow);
            Console.WriteLine($"{monster.Name} �� ����!");
            Console.ResetColor();

            resultDamage = DamageLuckyCalculation(resultDamage); // ġ��Ÿ / ȸ�� / �Ϲݰ��� ��� �Լ�

            if (resultDamage > 0)
            {
                Console.Write($"Lv.{user.Level} {user.Name}��(��) ������ϴ�!. [������ : {resultDamage}] ");
                if (tempResultDamage < resultDamage)
                {
                    ConsoleSize.Color(ConsoleColor.Red);
                    Console.Write("- ġ��Ÿ ����!!\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write("\n");
                }
                // �� ���� ���
                Console.WriteLine();
                Console.WriteLine($"Lv.{user.Level} {user.Name}");
                Console.Write($"MP {tempUserMP} -> ");
                if (tempUserMP < resultDamage)
                {
                    Console.Write("0\n");
                    int tempUserHP = user.HP;
                    
                    user.MP = 0;
                    user.TakeDamage(resultDamage - tempUserMP);
                    Console.WriteLine($"HP {tempUserHP} -> ");

                    if (user.IsDead)
                    {
                        Console.WriteLine("Dead");
                    }
                    else
                    {
                        Console.WriteLine(user.HP);
                    }
                }
                else
                {
                    user.MP -= resultDamage;
                    Console.WriteLine(user.MP);
                }

            }
            else // ȸ���� ���
            {
                Console.Write($"Lv.{user.Level} {user.Name}��(��) ���������� �ƹ��ϵ� �Ͼ�� �ʾҽ��ϴ�..");
            }
            Console.WriteLine();
            NextScreenButton();
        }
    }
}


