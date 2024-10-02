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
            SkillList.Add(new Skill("처형", "적에게 강한 데미지를 줍니다.", 2, 25));
        }

        public int WarriorSkill(int attackDamage)
        {
            Random random = new Random();
            int count = random.Next(1, 3); // 1 or 2

            int skillDamage = 0;

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(""); // 카운트 수 만큼 대사!
            }

            return skillDamage * count;
        }

    }
}
