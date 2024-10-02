using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG16
{
    public class Wizard : User
    {
        public Wizard(User user) // 생성자
        {
            user.UserClass = "마법사";
            user.FullHP = 100; // 초기 체력
            user.HP = user.FullHP; // 초기 체력
            user.FullMP = 300; // 초기 마나
            user.MP = user.FullMP; // 초기 마나
            user.DefensPower = 0; // 초기 방어력
            user.AttackDamage = 35; // 초기 공격력
            SkillList = new List<Skill>();
            AddSkill();
        }

        public void AddSkill()
        {
            SkillList.Add(new Skill("파이어볼", "타겟된 적과 주변의 적에게 대미지를 줍니다.", 80, 80, 3, true));
        }

        public int WizardSkill1_Fireball(User user, Monster monster, int targetIndex)
        {
            Console.WriteLine("파이어볼 스킬 사용!");
            int skillDamage = (int)(user.AttackDamage * 10);

            // 타겟 몬스터에게 풀 데미지 적용
            monster.monsterList[targetIndex].TakeDamage(skillDamage);
            Console.WriteLine($"타겟된 적에게 {monster.monsterList[targetIndex].Name}에게 {skillDamage} 대미지를 입혔습니다."); // tagetIndex, skillDamage

            // 주변 몬스터에게 1/3 데미지 적용
            for (int i = 0; i < monster.monsterList.Count; i++)
            {
                if (i != targetIndex && !monster.monsterList[i].IsDead)
                {
                    int splashDamage = skillDamage / 3;
                    monster.monsterList[i].TakeDamage(splashDamage);
                    Console.WriteLine($"주변 적 {monster.monsterList[i].Name}에게 {splashDamage} 대미지를 입혔습니다."); // i, splahDamage
                }
            }
            return skillDamage;
        }
        
    }
}
