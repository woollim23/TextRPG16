namespace TextRPG16
{
    public interface ICharacter
    {
        // 몬스터랑 유저 둘다 쓰는 공통 인터페이스
        public String Name { get; } // 이름
        public int Level { get; } // 레벨
        public String Tribe { get; } // 종족 
        public int HP { get; set; } // 현재 피통
        public int FullHP { get; } // 최대 피통
        public int AttackDamage { get; } // 공격력
        public bool IsDead { get; } // 생존여부
        public void TakeDamage(int damage); // HP 차감 함수
    }
}
