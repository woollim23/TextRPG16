namespace TextRPG16
{
    public enum Monsters
    {
        Minion,
        CannonMinion,
        Voidling
    }
    public class Monster : ICharacter
    {
        public List<Monster> monsterList = null!;
        // ------------------ ĳ���� �������̽� ���� ------------------
        string _name = null!;
        int _level;
        string _tribe = null!; // ����
        int _HP; // ü��
        int _fullHP; // �ִ� ü��
        int _attackDamage; // ���ݷ�
        int _monsterEXP; // ���� óġ�� �ִ� ����ġ

        public String Name { get { return _name; } protected set { _name = value; } }
        public int Level { get { return _level; } set { _level = value; } } // ����
        public String Tribe { get { return _tribe; } private set { _tribe = value; } }
        public int HP { get { return _HP; } set { _HP = value; } }
        public int FullHP { get { return _fullHP; } set { _fullHP = value; } }
        public int AttackDamage { get { return _attackDamage; } set { _attackDamage = value; } }
        public int MonsterEXP { get { return _monsterEXP; } set { _monsterEXP = value; } }
        public bool IsDead => HP <= 0;
        // ------------------ ���� ���� ------------------
        public int Index { get; set; } // enum �ε���

        // �⺻ ������
        public Monster()
        {
            Name = "����";
            Level = 1;
            Tribe = "����";
            FullHP = 10;
            HP = FullHP;
            AttackDamage = 10;
            MonsterEXP = 2;
            Index = -1;
        }

        // ���͸���Ʈ ��ü ����(�������� ������ ���� �� ���� ���� ����)
        public void AddMonsterList(Stage stage)
        {
            monsterList = new List<Monster>();

            for (int i = 0; i < 3; i++)
            {
                int monsterCount = Enum.GetValues(typeof(Monsters)).Length; // enum�� �ִ� ���� �ִ� ����

                Random random = new Random(); // ����
                int level = random.Next(stage.StageLevel, stage.StageLevel + 2); // �������� ���� ����

                // enum �ȿ� �ִ� ���͸� �������� �����Ѵ�
                switch ((Monsters)random.Next(0, monsterCount))
                {
                    case Monsters.Minion:
                        Monster minion = new Minion(level);
                        monsterList.Add(minion);
                        break;
                    case Monsters.CannonMinion:
                        Monster cannonMinion = new CannonMinion(level);
                        monsterList.Add(cannonMinion);
                        break;
                    case Monsters.Voidling:
                        Monster voidling = new Voidling(level);
                        monsterList.Add(voidling);
                        break;
                }
            }
        }

        public void TakeDamage(int damage)
        {
            // ȸ��/ ġ��Ÿ / �ƹ�x
            HP -= damage;
        }

        // ���� �������� �������ͽ� ������
        protected int MonsterLevelUpStatus(int level, int insert)
        {
            // ������ 0.3 �� ���
            return insert + (int)(Math.Round(((double)insert * (level * 0.3))));
        }

        // ���Ͱ� �������� �ִ� ����ġ ������
        protected int MonsterLevelUpEXP(int level, int insert)
        {
            // ������ 0.3 �� ���
            return insert + (int)(Math.Round(((double)insert * (level * 0.3))));
        }
    }
    class Minion : Monster
    {
        public Minion(int Level)
        {
            this.Level = Level;
            this.Name = "�̴Ͼ�";
            this.FullHP = MonsterLevelUpStatus(Level, FullHP);
            this.HP = this.FullHP;
            this.AttackDamage = MonsterLevelUpStatus(Level, AttackDamage);
            this.MonsterEXP = MonsterLevelUpEXP(Level, MonsterEXP);
            this.Index = 0;
        }
    }

    class CannonMinion : Monster
    {
        public CannonMinion(int Level)
        {
            this.Level = Level;
            this.Name = "���� �̴Ͼ�";
            this.FullHP = 5 + MonsterLevelUpStatus(Level, FullHP);
            this.HP = this.FullHP;
            this.AttackDamage = 5 + MonsterLevelUpStatus(Level, AttackDamage);
            this.MonsterEXP = MonsterLevelUpEXP(Level, MonsterEXP);
            this.Index = 1;
        }
    }

    class Voidling : Monster
    {
        public Voidling(int Level)
        {
            this.Level = Level;
            this.Name = "������";
            this.FullHP = 10 + MonsterLevelUpStatus(Level, FullHP);
            this.HP = this.FullHP;
            this.AttackDamage = 7 + MonsterLevelUpStatus(Level, AttackDamage);
            this.MonsterEXP = MonsterLevelUpEXP(Level, MonsterEXP);
            this.Index = 2;
        }
    }
}
