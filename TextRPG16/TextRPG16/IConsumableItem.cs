using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG16
{
    interface IConsumableItem
    {
        public string ItemName { get; set; } // 아이템 이름
        public string ItemType { get; set; } // 아이템 종류
        public int ItemEffectNum { get; set; } // 아이템 효과 수치                                   
        public string ItemEffectInform { get; set; } // 아이템 효과 설명
    }
       
}
