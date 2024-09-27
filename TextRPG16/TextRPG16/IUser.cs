using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG16
{
    internal interface IUser
    {
        public string UserClass { get; } // 직업
        public int DefensPower { get; } // 방어력
        public int Gold { get; } // 골드
        public int ClearCount { get; } // 던전 클리어 횟수
        public int EquipArmorStatusNum { get; } // 장착 갑옷 상태수치
        public int EquipWeaponStatusNum { get; } // 장착 무기 상태수치
        public int MP { get; } // 현재 MP
        public int FullMP { get; } // 최대 MP
        public int EXP { get; } // 현재 EXP
        public int FullEXP { get; }  // 최대 EXP -> 레벨이 오를 때마다 증가하도록
    }
}
