using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG16
{
    public class Thief : User
    {
        public Thief(User user) // 생성자
        {
            user.UserClass = "도적";
            user.FullHP = 100; // 초기 체력
            user.HP = FullHP; // 초기 체력
            user.FullMP = 200; // 초기 마나
            user.MP = FullMP; // 초기 마나
            user.DefensPower = 40; // 초기 방어력
            user.AttackDamage = 12; // 초기 공격력

            SkillList = new List<Skill>();
            AddSkill();
        }

        public void AddSkill()
        {
            SkillList.Add(new Skill("연타", "랜덤으로 최대 3명에게 데미지를 줍니다.", 80, 80, 3, true));

        public int ThiefSkill(int attackDamage)
        {
            Random rand = new Random();
            int count = rand.Next(1, 4);

            int skillDamage = 0;

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("하나!"); // 카운트 수만큼 대사
                Console.WriteLine("둘!"); // 카운트 수만큼 대사
                Console.WriteLine("셋!"); // 카운트 수만큼 대사
            }

            return skillDamage * count;
        }
    }
}
