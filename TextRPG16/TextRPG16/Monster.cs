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
        public List<Monster> monsterList;
        // ------------------ 캐릭터 인터페이스 공통 ------------------
        string _name;
        int _level;
        string _tribe; // 몬스터
        int _HP; // 체력
        int _fullHP; // 최대 체력
        int _attackDamage; // 공격력

        public String Name { get { return _name; } protected set { _name = value; } }
        public int Level { get { return _level; } set { _level = value; } } // 레벨
        public String Tribe { get { return _tribe; } private set { _tribe = value; } }
        public int HP { get { return _HP; } set { _HP = value; } }
        public int FullHP { get { return _fullHP; } set { _fullHP = value; } }
        public int AttackDamage { get { return _attackDamage; } set { _attackDamage = value; } }
        public bool IsDead => HP <= 0;
        // ------------------ 몬스터 전용 ------------------
        public int Index { get; set; } // enum 인덱스

        // 기본 생성자
        public Monster()
        {
            Name = "없음";
            Level = 1;
            Tribe = "몬스터";
            FullHP = 10;
            HP = FullHP;
            AttackDamage = 10;
            Index = -1;
        }

        public void AddMonsterList(Stage stage)
        {
            monsterList = new List<Monster>();

            for (int i = 0; i < 3; i++)
            {
                int monsterCount = Enum.GetValues(typeof(Monsters)).Length; // enum에 있는 몬스터 최대 갯수

                Random random = new Random(); // 랜덤
                int level = random.Next(1, stage.StageLevel + 3); // 랜덤으로 레벨 지정

                // enum 안에 있는 몬스터를 랜덤으로 지정한다
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

        public void MonsterAttack(User user) // 몬스터가 공격할때
        {
            Console.Clear();
            int tempUserHP = user.HP;
            int num = (int)Math.Round(((double)AttackDamage / 100 * 10), 0); // 오차값

            Random random = new Random();
            int resultDamage = random.Next((int)AttackDamage - num, (int)AttackDamage + num);

            user.TakeDamage(resultDamage);

            Console.WriteLine($"Battle!!");
            Console.WriteLine();
            Console.WriteLine($"{Name} 의 공격!");
            Console.WriteLine($"Lv.{user.Level} {user.Name}을(를) 맞췄습니다!. [데미지 : {resultDamage}]");
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
            Console.WriteLine("0. 다음");
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
            this.Name = "미니언";
            this.FullHP = 10 * Level;
            this.HP = this.FullHP;
            this.AttackDamage = 2 * Level;
            this.Index = 0;
        }
    }

    class CannonMinion : Monster
    {
        public CannonMinion(int Level)
        {
            this.Level = Level;
            this.Name = "대포 미니언";
            this.FullHP = 15 * Level;
            this.HP = this.FullHP;
            this.AttackDamage = 4 * Level;
            this.Index = 1;
        }
    }

    class Voidling : Monster
    {

        public Voidling(int Level)
        {
            this.Level = Level;
            this.Name = "공허충";
            this.FullHP = 17 * Level;
            this.HP = this.FullHP;
            this.AttackDamage = 5 * Level;
            this.Index = 2;
        }
    }
}
