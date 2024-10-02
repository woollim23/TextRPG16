using System;
using System.Xml.Linq;

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
    }
}