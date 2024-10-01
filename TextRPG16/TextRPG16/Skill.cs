using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG16
{
    public class Skill
    {
        public string SkillName { get; set; }
        public string SkillDescription { get; set; }
        public int IncreaseRate { get; set; }
        public int UseMP { get; set; }

        public Skill() { }

        public Skill(string skillName, string skillDescription, int increaseRate, int useMP)
        {
            SkillName = skillName;
            SkillDescription = skillDescription;
            IncreaseRate = increaseRate;
            UseMP = useMP;
        }
    }
}
