namespace TextRPG16
{
    public class User : ICharacter, IUser
    {
        // ------------------ 캐릭터 인터페이스 공통 ------------------
        string _name; // 이름  // - 자식도 수정가능
        int _level;
        string _tribe; // 종족
        int _HP; // 현재 피통
        int _fullHP; // 최대피통
        int _attackDamage; // 공격력
        bool _isDead; // 생존여부

        // 캐릭터 인터페이스 필드의 프로퍼티들
        public String Name { get { return _name; } protected set { _name = value; } }
        public int Level { get { return _level; } private set { _level = value; } } // 레벨
        public String Tribe { get { return _tribe; } private set { _tribe = value; } }
        public int HP { get { return _HP; } protected set { _HP = value; } }
        public int FullHP { get { return _fullHP; }  protected set { _fullHP = value; } }
        public int AttackDamage { get { return _attackDamage; } protected set { _attackDamage = value; } }
        public bool IsDead { get { return _isDead; } private set { _isDead = value; } }

        public void TakeDamage(int damage)
        {

        }

        // ------------------ 유저 인터페이스 공통 ------------------
        protected string _userClass; // 직업
        int _defensPower; // 방어력
        int _gold; // 골드
        int _clearCount; // 던전 클리어 횟수
        int _equipArmorStatusNum; // 장착 갑옷 상태수치
        int _equipWeaponStatusNum; // 장착 갑옥 상태수치
        int _MP; // 현재 MP
        int _fullMP; // 최대 MP
        int _EXP; // 현재 EXP
        int _fullEXP; // 최대 EXP -> 레벨이 오를 때마다 증가하도록
        // 유저 인터페이스 필드의 프로퍼티들
        public string UserClass { get { return _userClass; } protected set { _userClass = value; } } // 직업
        public int DefensPower { get { return _defensPower; } private set { _defensPower = value; } } // 방어력
        public int Gold { get { return _gold; } private set { _gold = value; } } // 골드
        public int ClearCount { get { return _clearCount; } private set { _clearCount = value; } } // 던전 클리어 횟수
        public int EquipArmorStatusNum { get { return _equipArmorStatusNum; } protected set { _equipArmorStatusNum = value; } } // 장착 갑옷 상태수치
        public int EquipWeaponStatusNum { get { return _equipWeaponStatusNum; } protected set { _equipWeaponStatusNum = value; } } // 장착 갑옷 상태수치
        public int MP { get { return _MP; } protected set { _MP = value; } } // 현재 MP
        public int FullMP { get { return _fullMP; } protected set { _fullMP = value; } } // 최대 MP
        public int EXP { get { return _EXP; } protected set { _EXP = value; } } // 현재 EXP
        public int FullEXP { get { return _fullEXP; } protected set { _fullEXP = value; } }  // 최대 EXP -> 레벨이 오를 때마다 증가하도록

        // ------------------ 유저 고유 ------------------
        //public event AttackHandle OnAttack; // 공격 델리게이트 트리거
        public void UserAttack(int Attack) // 유저가 공격할때
        {
            //OnAttack?.Invoke(Attack); // 공격 델리게이트 트리거 - 몬스터의 TakeDamage와 묶임
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

        public User()
        {
            this.Name = "홍길동";
            this.Level = 1;
            this.Tribe = "인간";
            this.HP = 100;
            this.FullHP = 100;
            this.AttackDamage = 10;
            this.IsDead = false;

            this.UserClass = "없음";
            this.DefensPower = 10;
            this.Gold = 1500;
            this.ClearCount = 0;

            this.EquipArmorStatusNum = 0; // 장착 갑옷 상태수치
            this.EquipWeaponStatusNum = 0; // 장착 갑옷 상태수치

            this.MP = 100;
            this.FullMP = 100;
            this.EXP = 100;
            this.FullEXP = 100;
        }
    }
}