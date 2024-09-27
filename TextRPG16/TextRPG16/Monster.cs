namespace TextRPG16
{

    class Monster : ICharacter
    {
        List<Monster> monsters;

        // ------------------ ĳ���� �������̽� ���� ------------------
        string _name = null;
        int _level;
        string _tribe = "Monster"; // ����
        int _HP; // ü��
        int _fullHP; // �ִ� ü��
        int _attackDamage; // ���ݷ�

        public String Name { get { return _name; } protected set { _name = value; } }
        public int Level { get { return _level; } set { _level = value; } } // ����
        public String Tribe { get { return _tribe; } private set { _tribe = value; } }
        public int HP { get { return _HP; } set { _HP = value; } }
        public int FullHP { get { return _fullHP; } set { _fullHP = value; } }
        public int AttackDamage { get { return _attackDamage; } set { _attackDamage = value; } }
        public bool IsDead => HP <= 0;

        public void TakeDamage(int damage)
        {
            HP -= damage;
            if(IsDead)
            {
                Console.WriteLine($"{Name}��(��) �׾����ϴ�.");
            }
            else
            {
                Console.WriteLine($"{Name}��(��) {damage}�� �������� �޾ҽ��ϴ�. ���� ü��: {HP}");
            }
        }

        public Monster()
        {
            Name = "����";
            Level = 1;
            HP = 100;
            FullHP = 100;
            AttackDamage = 100;
        }

    }
    class Dookie : Monster
    {
        public Dookie()
        {
            this.Name = "��Ű";
            this.FullHP = 10;
            this.Level = 1;
            this.HP = 100;
            this.FullHP = 100;
            this.AttackDamage = 0;
        }

        public Dookie(int level)
        {
            this.Name = "��Ű";
            this.Level = level;
            //this.HP = 100;
            //this.FullHP = 100;
            this.AttackDamage = 0;
        }
    }

    class Slime : Monster
    {
        public Slime()
        {
            this.Name = "������";
            this.Level = 1;
            this.HP = 20;
            this.FullHP = 20;
            this.AttackDamage = 3;
        }

        public Slime(int level)
        {
            this.Name = "������";
            this.Level = level;
            //this.HP = 20;
            //this.FullHP = 20;
            //this.AttackDamage = 3;

        }
    }

    class Leejinho : Monster
    {
        public Leejinho()
        {
            this.Name = "����ȣ";
            this.Level = 1;
            this.HP = 40;
            this.FullHP = 40;
            this.AttackDamage = 12;
        }

        public Leejinho(int level)
        {
            this.Name = "����ȣ";
            this.Level = level;
            //this.HP = 40;
            //this.FullHP = 40;
            //this.AttackDamage = 12;

        }
    }

    class Dragon : Monster
    {

        public Dragon()
        {
            this.Name = "�巡��";
            this.Level = 1;
            this.HP = 75;
            this.FullHP = 75;
            this.AttackDamage = 25;
        }

        public Dragon(int level)
        {
            this.Name = "�巡��";
            this.Level = level;
            //this.HP = 75;
            //this.FullHP = 75;
            //this.AttackDamage = 25;
        }
    }
}
