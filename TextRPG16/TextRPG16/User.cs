namespace TextRPG16
{
    public class User : ICharacter, IUser
    {
        // ------------------ 캐릭터 인터페이스 공통 ------------------
        string _name = null!; // 이름  // - 자식도 수정가능
        int _level;
        string _tribe = null!; // 종족
        int _HP; // 현재 피통
        int _fullHP; // 최대피통
        int _attackDamage; // 공격력

        // 캐릭터 인터페이스 필드의 프로퍼티들
        public String Name { get { return _name; } protected set { _name = value; } }
        public int Level { get { return _level; } set { _level = value; } } // 레벨
        public String Tribe { get { return _tribe; } private set { _tribe = value; } }
        public int HP { get { return _HP; } set { _HP = value; } }
        public int FullHP { get { return _fullHP; } set { _fullHP = value; } }
        public int AttackDamage { get { return _attackDamage; } set { _attackDamage = value; } }
        public bool IsDead => HP <= 0;

        public void TakeDamage(int damage)
        {
            HP -= damage;
        }

        // ------------------ 유저 인터페이스 공통 ------------------
        protected string _userClass; // 직업
        int _defensPower; // 방어력
        int _gold; // 골드
        int _clearCount; // 던전 클리어 횟수
        int _equipArmorStatusNum; // 장착 갑옷 상태수치
        int _equipWeaponStatusNum; // 장착 갑옷 상태수치
        int _MP; // 현재 MP
        int _fullMP; // 최대 MP
        int _EXP; // 현재 EXP
        int _fullEXP; // 최대 EXP -> 레벨이 오를 때마다 증가하도록
        // 유저 인터페이스 필드의 프로퍼티들
        public string UserClass { get { return _userClass; } set { _userClass = value; } } // 직업
        public int DefensPower { get { return _defensPower; } set { _defensPower = value; } } // 방어력
        public int Gold { get { return _gold; } set { _gold = value; } } // 골드
        public int ClearCount { get { return _clearCount; } set { _clearCount = value; } } // 던전 클리어 횟수
        public int EquipArmorStatusNum { get { return _equipArmorStatusNum; } set { _equipArmorStatusNum = value; } } // 장착 갑옷 상태수치
        public int EquipWeaponStatusNum { get { return _equipWeaponStatusNum; } set { _equipWeaponStatusNum = value; } } // 장착 갑옷 상태수치
        public int MP { get { return _MP; } set { _MP = value; } } // 현재 MP
        public int FullMP { get { return _fullMP; } set { _fullMP = value; } } // 최대 MP
        public int EXP { get { return _EXP; } set { _EXP = value; } } // 현재 EXP
        public int FullEXP { get { return _fullEXP; } set { _fullEXP = value; } }  // 최대 EXP -> 레벨이 오를 때마다 증가하도록

        // ------------------ 플레이어 고유 ------------------
        public int[] MonsterCount; // 몬스터 잡은 수 배열
        // 기본 생성자
        public User()
        {
            this.Name = "홍길동";
            this.Level = 1;
            this.Tribe = "인간";
            this.HP = 100;
            this.FullHP = 100;
            this.AttackDamage = 10;

            this.UserClass = "없음";
            this.DefensPower = 10;
            this.Gold = 1500;
            this.ClearCount = 0;

            this.EquipArmorStatusNum = 0; // 장착 갑옷 상태수치
            this.EquipWeaponStatusNum = 0; // 장착 갑옷 상태수치

            this.MP = 100;
            this.FullMP = 100;
            this.EXP = 0;
            this.FullEXP = 10;

            MonsterCount = new int[Enum.GetValues(typeof(Monsters)).Length]; // 이넘에 저장된 몬스터 갯수 만큼 배열 크기 설정
        }


        public void UserAttack(Monster monster, int index) // 유저가 공격할때
        {
            Console.Clear();
            int tempMonsterHP = monster.HP;
            int num = (int)Math.Round(((double)AttackDamage / 100 * 10), 0); // 오차값

            Random random = new Random();
            int resultDamage = random.Next((int)AttackDamage - num, (int)AttackDamage + num);

            monster.TakeDamage(resultDamage);

            Console.WriteLine($"Battle!!");
            Console.WriteLine();
            Console.WriteLine($"{Name} 의 공격!");
            Console.WriteLine($"Lv.{monster.Level} {monster.Name}을(를) 맞췄습니다!. [데미지 : {resultDamage}]");
            Console.WriteLine();
            Console.WriteLine($"Lv.{monster.Level} {monster.Name}");
            Console.Write($"HP {tempMonsterHP} -> ");

            if (monster.IsDead)
            {
                Console.WriteLine("Dead");
                MonsterCount[index]++;
            }
            else
            {
                Console.WriteLine(monster.HP);
            }
            Console.WriteLine();
            Console.WriteLine("0. 다음");
            Console.WriteLine();
            Console.Write(">> ");
            while (InputCheck.Check(0, 0) != 0)
            {
                Console.Write(">> ");
            }
        }

        public void LevelUp(User user, int expSum)
        {
            int tempLevel = user.Level; // 이전 레벨 저장
            user.EXP += expSum;

            if (user.FullEXP <= user.EXP)
            {
                user.Level++;
                user.EXP -= user.FullEXP; // 남은 경험치 이관
                user.FullEXP = 20 + (tempLevel * 5);

                Console.WriteLine($" -> Lv.{user.Level}");
            }
            else
            {
                Console.Write("\n");
            }
        }

        // 유저 이름 입력 메소드
        public void InputName(string inputName)
        {
            this.Name = inputName;
        }

        // 유저 클래스(직업) 입력 메소드
        public void InputUserClass(string inputUserClass)
        {
            this.UserClass = inputUserClass;
        }

        // 유저 방어구 방어력 입력 메소드
        public void InputEquipArmorStatusNum(int equipArmorStatusNum)
        {
            this.EquipArmorStatusNum = equipArmorStatusNum;
        }

        // 유저 무기 공격력 입력 메소드
        public void InputEquipWeaponStatusNum(int equipWeaponStatusNum)
        {
            this.EquipWeaponStatusNum = equipWeaponStatusNum;
        }

        // 상태창 메소드
        public void State(User user)
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();

                Console.WriteLine("[상태보기]");
                Console.WriteLine("캐릭터의 정보가 표시됩니다.");
                Console.WriteLine();
                Console.WriteLine("레  벨 : {0} Lv", user.Level);
                Console.WriteLine("직  업 : {0}", user.UserClass);
                Console.WriteLine("방어력 : {0} (+ {1})", user.DefensPower, user.EquipArmorStatusNum);
                Console.WriteLine("공격력 : {0} (+ {1})", user.AttackDamage, user.EquipWeaponStatusNum);
                Console.WriteLine("체  력 : {0}", user.HP);
                Console.WriteLine("골  드 : {0} G", user.Gold);
                Console.WriteLine();
                Console.WriteLine("0. 나가기");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                int select = InputCheck.Check(0, 0);

                switch (select)
                {
                    case 0:
                        exit = true;
                        break;
                    default:
                        continue;
                }
            }
        }

        // 캐릭터선택창 메소드
        public void ChoiceUserClass(User user)
        {
            // ---------------- 캐릭터 직업 선택 -------------------
            while (true)
            {
                Console.Clear();
                Console.WriteLine("[직업 선택]");
                // 직업 선택
                Console.WriteLine("직업을 선택해주세요.(해당 번호 입력)");
                Console.WriteLine();
                Console.WriteLine("1. 전사");
                Console.WriteLine("2. 마법사");
                Console.WriteLine();
                Console.Write(">> ");

                int select = InputCheck.Check(1, 2);
                switch (select)
                {
                    case 1:
                        user.UserClass = "전사";
                        user = new Warrior();
                        break;
                    case 2:
                        user.UserClass = "마법사";
                        user = new Wizard();
                        break;
                    default:
                        break;
                }

                if (select != -1) break;
            }
        }
    }
    class Wizard : User
    {
        public Wizard() // 생성자
        {
            UserClass = "마법사";
            FullHP = 100; // 초기 체력
            HP = FullHP; // 초기 체력
            FullMP = 300; // 초기 마나
            MP = FullMP; // 초기 마나
            DefensPower = 0; // 초기 방어력
            AttackDamage = 35; // 초기 공격력
        }

    }
    class Warrior : User
    {
        public Warrior() // 생성자
        {
            UserClass = "전사";
            FullHP = 100; // 초기 체력
            HP = FullHP; // 현재 체력
            FullMP = 100; // 초기 마나
            MP = FullMP; // 초기 마나
            DefensPower = 80; // 초기 방어력
            AttackDamage = 20; // 초기 공격력
        }

    }
    class Thief : User
    {
        public Thief() // 생성자
        {
            UserClass = "도적";
            FullHP = 100; // 초기 체력
            HP = FullHP; // 초기 체력
            FullMP = 200; // 초기 마나
            MP = FullMP; // 초기 마나
            DefensPower = 40; // 초기 방어력
            AttackDamage = 12; // 초기 공격력
        }

    }
    class Preist : User
    {
        public Preist() // 생성자
        {
            UserClass = "성직자";
            FullHP = 100; // 초기 체력
            HP = FullHP; // 초기 체력
            FullMP = 300; // 초기 마나
            MP = FullMP; // 초기 마나
            DefensPower = 90; // 초기 방어력
            AttackDamage = 5; // 초기 공격력
        }

    }
    class Archer : User
    {
        public Archer() // 생성자
        {
            UserClass = "궁수";
            FullHP = 100; // 초기 체력
            HP = FullHP; // 초기 체력
            FullMP = 200; // 초기 마나
            MP = FullMP; // 초기 마나
            DefensPower = 40; // 초기 방어력
            AttackDamage = 12; // 초기 공격력
        }

    }
}
