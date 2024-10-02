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
            user.HP = FullHP; // 초기 체력
            user.FullMP = 300; // 초기 마나
            user.MP = FullMP; // 초기 마나
            user.DefensPower = 0; // 초기 방어력
            user.AttackDamage = 35; // 초기 공격력

            SkillList = new List<Skill>();
            AddSkill();
        }

        public void AddSkill()
        {
            SkillList.Add(new Skill("파이어볼", "타겟된 적과 주변의 적에게 데미지를 줍니다.", 80, 80, 3, true));
        }

        public int WizardSkill1(int attackDamage)
        {
            Console.WriteLine("파이어볼 스킬 사용!");
            int skillDamage = (int)(attackDamage * 10);

            return skillDamage;
        }
    }
}
