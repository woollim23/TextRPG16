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
        public int Level { get { return _level; } protected set { _level = value; } } // 레벨
        public String Tribe { get { return _tribe; } private set { _tribe = value; } }
        public int HP { get { return _HP; } set { _HP = value; } }
        public int FullHP { get { return _fullHP; } set { _fullHP = value; } }
        public int AttackDamage { get { return _attackDamage; } set { _attackDamage = value; } }
        public bool IsDead { get { return _isDead; } set { _isDead = value; } }

        public void TakeDamage(int damage)
        {

        }

    class Dookie: Monster
    {
        public Dookie()
        {
            this.Name = "두키";
            this.FullHP = 10;
            this.Level = 1;
            this.HP = 100;
            this.FullHP = 100;
            this.AttackDamage = 0;
        }

        public Dookie(int level)
        {
            this.Name = "두키";
            this.Level = level;
            //this.HP = 100;
            //this.FullHP = 100;
            this.AttackDamage = 0;
        }
    }

    class Slime: Monster
    {
        public Slime()
        {
            this.Name = "슬라임";
            this.Level = 1;
            this.HP = 20;
            this.FullHP = 20;
            this.AttackDamage = 3;
        }

        public Slime(int level)
        {
            this.Name = "슬라임";
            this.Level = level;
            //this.HP = 20;
            //this.FullHP = 20;
            //this.AttackDamage = 3;

        }
    }

    class Leejinho: Monster
    {
        public Leejinho()
        {
            this.Name = "이진호";
            this.Level = 1;
            this.HP= 40;
            this.FullHP = 40;
            this.AttackDamage = 12;
        }

        public Leejinho(int level)
        {
            this.Name = "이진호";
            this.Level = level;
            //this.HP = 40;
            //this.FullHP = 40;
            //this.AttackDamage = 12;

        }
    }

    class Dragon: Monster
    {

        public Dragon()
        {
            this.Name = "드래곤";
            this.Level = 1;
            this.HP = 75;
            this.FullHP = 75;
            this.AttackDamage = 25;
        }

        public Dragon(int level)
        {
            this.Name = "드래곤";
            this.Level = level;
            //this.HP = 75;
            //this.FullHP = 75;
            //this.AttackDamage = 25;
        }
    }
}
