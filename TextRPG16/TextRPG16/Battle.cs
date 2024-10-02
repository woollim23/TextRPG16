using System;
using System.Collections.Generic;
using System.Xml.Linq;

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


            int tempMonsterHP = monster.HP; // 현재 몬스터 HP
            Console.WriteLine($"Battle!!");
            Console.WriteLine();
            Console.WriteLine($"{user.Name} 의 공격!");
            Console.WriteLine($"Lv.{monster.Level} {monster.Name}을(를) 맞췄습니다!. [데미지 : {resultDamage}]");
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