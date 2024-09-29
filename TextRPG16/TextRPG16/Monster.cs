using System.Threading;

namespace TextRPG16
{

    public class Monster : ICharacter
    {
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

        // 기본 생성자
        public Monster()
        {
            Name = "없음";
            Level = 1;
            Tribe = "몬스터";
            FullHP = 100;
            HP = FullHP;
            AttackDamage = 100;
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

            if(user.IsDead)
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
    class Dookie : Monster
    {
        public Dookie()
        {
            this.Name = "두키";
            this.Level = 1;
            this.HP = 10;
            this.FullHP = 10;
            this.AttackDamage = 2;
        }

        public Dookie(int level)
        {
            this.Name = "두키";
            this.Level = level;
            this.HP = 10;
            this.FullHP = 10;
            this.AttackDamage = 2;
        }
    }

    class Slime : Monster
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

    class Dragon : Monster
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
