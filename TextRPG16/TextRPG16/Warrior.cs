using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG16
{
    public class Warrior : User
    {
        public Warrior(User user) // 생성자
        {
            user.UserClass = "전사";
            user.FullHP = 100; // 초기 체력
            user.HP = FullHP; // 현재 체력
            user.FullMP = 50; // 초기 마나
            user.MP = FullMP; // 초기 마나
            user.DefensPower = 80; // 초기 방어력
            user.AttackDamage = 20; // 초기 공격력

            SkillList = new List<Skill>();
            AddSkill();
        }
        public void AddSkill()
        {
            SkillList.Add(new Skill("처형", "적에게 강한 데미지를 줍니다.", 50, 44, 1, false));
            SkillList.Add(new Skill("슬래쉬", "랜덤으로 적 2명에게 데미지를 줍니다.", 50, 28, 2, true));
        }

        public int WarriorSkill1_Execute(User user, Monster monster)
        {
            // 공격력*스킬 계수 = 스킬 데미지
            float tempAttackDamage = user.AttackDamage * (user.SkillList[0].IncreaseRate);

            // 오차값을 10%로 계산
            float num = tempAttackDamage * 0.1f;

            //랜덤한 데미지를 구할 때 범위를 실수형으로 설정  // 공격력이 10이면, 9 ~ 11
            Random random = new Random();
            float resultDamage = (float)(random.NextDouble() * ((tempAttackDamage + num) - (tempAttackDamage - num)) + (tempAttackDamage - num));

            // 최종 데미지를 몬스터에게 전달 (반올림해서)
            //monster.TakeDamage(((int)resultDamage)); // 최종 대미지를 몬스터한테전달

            return (int)resultDamage;
        }
    }

    
}
