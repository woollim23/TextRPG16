namespace TextRPG16
{
    enum Monsters
    {
        Minion,
        CannonMinion,
        Voidling
    }
    public class Monster : ICharacter
    {
        public List<Monster> monsterList;
        // ------------------ ĳ���� �������̽� ���� ------------------
        string _name;
        int _level;
        string _tribe; // ����
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

        // �⺻ ������
        public Monster()
        {
            Name = "����";
            Level = 1;
            Tribe = "����";
            FullHP = 10;
            HP = FullHP;
            AttackDamage = 10;
        }

        public void AddMonsterList(Stage stage)
        {
            monsterList = new List<Monster>();

            for (int i = 0; i < 3; i++)
            {
                Random random = new Random(); // ���� ����
                int level = random.Next(1, stage.StageLevel + 3);

                switch(random.Next(0, 2))
                {
                    case 0:
                        Monster minion = new Minion(level);
                        monsterList.Add(minion);
                        break;
                    case 1:
                        Monster cannonMinion = new CannonMinion(level);
                        monsterList.Add(cannonMinion);
                        break;
                    case 2:
                        Monster voidling = new Voidling(level);
                        monsterList.Add(voidling);
                        break;
                }
            }
        }

        public void MonsterAttack(User user) // ���Ͱ� �����Ҷ�
        {
            Console.Clear();
            int tempUserHP = user.HP;
            int num = (int)Math.Round(((double)AttackDamage / 100 * 10), 0); // ������

            Random random = new Random();
            int resultDamage = random.Next((int)AttackDamage - num, (int)AttackDamage + num);

            user.TakeDamage(resultDamage);

            Console.WriteLine($"Battle!!");
            Console.WriteLine();
            Console.WriteLine($"{Name} �� ����!");
            Console.WriteLine($"Lv.{user.Level} {user.Name}��(��) ������ϴ�!. [������ : {resultDamage}]");
            Console.WriteLine();
            Console.WriteLine($"Lv.{user.Level} {user.Name}");
            Console.Write($"HP {tempUserHP} -> ");

            if (user.IsDead)
            {
                Console.WriteLine("Dead");
            }
            else
            {
                Console.WriteLine(user.HP);
            }
            Console.WriteLine();
            Console.WriteLine("0. ����");
            Console.WriteLine();
            Console.Write(">> ");
            while (InputCheck.Check(0, 0) != 0)
            {
                Console.Write(">> ");
            }

            if (user.IsDead)
            {
                Stage stage = new Stage();
                stage.StageLose(user);
            }
        }

        public void TakeDamage(int damage)
        {
            HP -= damage;
        }
    }
    class Minion : Monster
    {
        public Minion(int Level)
        {
            this.Level = Level;
            this.Name = "�̴Ͼ�";
            this.FullHP = 10* Level;
            this.HP = this.FullHP;
            this.AttackDamage = 2 * Level;
        }
    }

    class CannonMinion : Monster
    {
        public CannonMinion(int Level)
        {
            this.Level = Level;
            this.Name = "���� �̴Ͼ�";
            this.FullHP = 15 * Level;
            this.HP = this.FullHP;
            this.AttackDamage = 4 * Level;
        }
    }

    class Voidling : Monster
    {

        public Voidling(int Level)
        {
            this.Level = Level;
            this.Name = "������";
            this.FullHP = 17 * Level;
            this.HP = this.FullHP;
            this.AttackDamage = 5 * Level;
        }
    }
}
