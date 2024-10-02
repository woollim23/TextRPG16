using System;
using System.Collections.Generic;
using System.Xml.Linq;

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


        public static void SkillRandomAttackResult(User user, Monster monster, int skillNumber, int resultDamage)
        {
            Console.Clear();
            if (user.SkillList[skillNumber].TargetNumber == 3)
            {
                for (int i = 0; i < monster.monsterList.Count; i++)
                {
                    Battle.SkillAttckResult(user, monster, resultDamage, i);
                }
            }
            else
            {
                int randomTemp = 0;
                for (int i = 0; i < user.SkillList[skillNumber].TargetNumber; i++)
                {
                    Random random = new Random();
                    int index = random.Next(0, monster.monsterList.Count);
                    Battle.SkillAttckResult(user, monster, resultDamage, index);
                }
            }
        }
    }
}