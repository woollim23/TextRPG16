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
        // ------------------ 캐릭터 인터페이스 공통 ------------------
        string _name = null!;
        int _level;
        string _tribe = null!; // 몬스터
        int _HP; // 체력
        int _fullHP; // 최대 체력
        int _attackDamage; // 공격력
        int _monsterEXP; // 몬스터 처치시 주는 경험치

        public String Name { get { return _name; } protected set { _name = value; } }
        public int Level { get { return _level; } set { _level = value; } } // 레벨
        public String Tribe { get { return _tribe; } private set { _tribe = value; } }
        public int HP { get { return _HP; } set { _HP = value; } }
        public int FullHP { get { return _fullHP; } set { _fullHP = value; } }
        public int AttackDamage { get { return _attackDamage; } set { _attackDamage = value; } }
        public int MonsterEXP { get { return _monsterEXP; } set { _monsterEXP = value; } }
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
            MonsterEXP = 2;
            Index = -1;
        }

        // 몬스터리스트 객체 생성(스테이지 레벨에 맞춰 더 강한 몬스터 출현)
        public void AddMonsterList(Stage stage)
        {
            monsterList = new List<Monster>();

            for (int i = 0; i < 3; i++)
            {
                int monsterCount = Enum.GetValues(typeof(Monsters)).Length; // enum에 있는 몬스터 최대 갯수

                Random random = new Random(); // 랜덤
                int level = random.Next(stage.StageLevel, stage.StageLevel + 2); // 랜덤으로 레벨 지정

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

        public void TakeDamage(int damage)
        {
            // 회피/ 치명타 / 아무x
            HP -= damage;
        }

        // 몬스터 레벨업시 스테이터스 증가율
        protected int MonsterLevelUpStatus(int level, int insert)
        {
            // 레벨당 0.3 씩 계산
            return insert + (int)(Math.Round(((double)insert * (level * 0.3))));
        }

        // 몬스터가 레벨업시 주는 경험치 증가율
        protected int MonsterLevelUpEXP(int level, int insert)
        {
            // 레벨당 0.3 씩 계산
            return insert + (int)(Math.Round(((double)insert * (level * 0.3))));
        }
    }
    class Minion : Monster
    {
        public Minion(int Level)
        {
            this.Level = Level;
            this.Name = "미니언";
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
            this.Name = "대포 미니언";
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
            this.Name = "공허충";
            this.FullHP = 10 + MonsterLevelUpStatus(Level, FullHP);
            this.HP = this.FullHP;
            this.AttackDamage = 7 + MonsterLevelUpStatus(Level, AttackDamage);
            this.MonsterEXP = MonsterLevelUpEXP(Level, MonsterEXP);
            this.Index = 2;
        }
    }
}
