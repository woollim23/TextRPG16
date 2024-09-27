namespace TextRPG16
{
    class Monster : ICharacter{
        // ------------------ 캐릭터 인터페이스 공통 ------------------
        string _name = null!; // 이름  // - 자식도 수정가능
        int _level;
        string _tribe = "Monster"; // 종족
        int _HP; // 현재 피통
        int _fullHP; // 최대피통
        int _attackDamage; // 공격력
        bool _isDead = false; // 생존여부

        public String Name { get { return _name; } protected set { _name = value; } }
        public int Level { get { return _level; } private set { _level = value; } } // 레벨
        public String Tribe { get { return _tribe; } private set { _tribe = value; } }
        public int HP { get { return _HP; } protected set { _HP = value; } }
        public int FullHP { get { return _fullHP; } protected set { _fullHP = value; } }
        public int AttackDamage { get { return _attackDamage; } protected set { _attackDamage = value; } }
        public bool IsDead { get { return _isDead; } private set { _isDead = value; } }

        public void TakeDamage(int damage)
        {

        }
    }

    class Dookie: Monster
    {
        public Dookie()
        {
            this.Name = "두키";
        }
    }

    class Slime: Monster
    {
        public Slime(int level)
        {
            this.Name = "슬라임";
        }
    }

    class Leejinho: Monster
    {
        public Leejinho(int level)
        {
            this.Name = "이진호";
        }
    }

    class Dragon: Monster
    {
        public Dragon(int level)
        {
            this.Name = "드래곤";
        }
    }
}
