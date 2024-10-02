using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG16
{
    public class Skill
    {
        public string SkillName { get; set; } // 스킬이름
        public string SkillDescription { get; set; } // 스킬설명
        public int IncreaseRate { get; set; } // 증가율
        public int UseMP { get; set; } // 소모마나
        public int TargetNumber { get; set; } // 타겟수
        public bool TargetRandom { get; set; } // 타겟 랜덤 여부 

        public Skill() { }

        public Skill(string skillName, string skillDescription, int increaseRate, int useMP, int targetNumber, bool targetRandom)
        {
            SkillName = skillName; // 스킬이름
            SkillDescription = skillDescription; // 스킬설명
            IncreaseRate = increaseRate; // 증가율
            UseMP = useMP; // 소모마나
            TargetNumber = targetNumber; // 타겟수
            TargetRandom = targetRandom; // 타겟 랜덤 여부
        }
    }
}
