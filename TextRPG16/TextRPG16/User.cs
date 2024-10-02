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
        protected string _userClass = null!; // 직업
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

        // ------------------ 기본 생성자 ------------------ 
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
            BestStageLevel = 1;

            quests = new List<Quest>();
            AddQuest();
            SkillList = new Skill[2];
        }

        // ------------------ 플레이어 전투 관련 ------------------
        public int[] MonsterCount; // 몬스터 잡은 수 배열
        public int BestStageLevel; // 최고 스테이지 레벨 

        public Skill[] SkillList;

        public void AddSkill()
        {
            if (UserClass == "마법사")
            {
                SkillList[0] = new Skill("파이어볼", "타겟된 적과 주변의 적에게 데미지를 줍니다.", 80, 80, 3, true);
            }
            else if (UserClass =="전사")
            {
                SkillList[0] = new Skill("처형", "적에게 강한 데미지를 줍니다.", 50, 44, 1, false);
                SkillList[1] = new Skill("슬래쉬", "랜덤으로 적 2명에게 데미지를 줍니다.", 50, 28, 2, true);
           }
        }

        public int WarriorSkill1_Execute(User user, Monster monster)
        {
            // 공격력*스킬 계수 = 스킬 데미지
            float tempAttackDamage = user.AttackDamage * (user.SkillList[0].IncreaseRate);

            // 오차값을 10%로 계산
            float num = tempAttackDamage * 0.1f;

            //랜덤한 데미지를 구할 때 범위를 실수형으로 설정  // 공격력이 10이면, 9 ~ 11
            Random random = new Random();
            float resultDamage = (float)(random.NextDouble() * ((tempAttackDamage + num) - (tempAttackDamage - num)) + (tempAttackDamage - num));

            // 최종 데미지를 몬스터에게 전달 (반올림해서)
            //monster.TakeDamage(((int)resultDamage)); // 최종 대미지를 몬스터한테전달

            return (int)resultDamage;
        }

        public int WizardSkill1_Fireball(User user, Monster monster, int targetIndex)
        {
            Console.WriteLine("파이어볼 스킬 사용!");
            int skillDamage = (int)(user.AttackDamage * 10);

            // 타겟 몬스터에게 풀 데미지 적용
            monster.monsterList[targetIndex].TakeDamage(skillDamage);
            Console.WriteLine($"타겟된 적에게 {monster.monsterList[targetIndex].Name}에게 {skillDamage} 대미지를 입혔습니다."); // tagetIndex, skillDamage

            // 주변 몬스터에게 1/3 데미지 적용
            for (int i = 0; i < monster.monsterList.Count; i++)
            {
                if (i != targetIndex && !monster.monsterList[i].IsDead)
                {
                    int splashDamage = skillDamage / 3;
                    monster.monsterList[i].TakeDamage(splashDamage);
                    Console.WriteLine($"주변 적 {monster.monsterList[i].Name}에게 {splashDamage} 대미지를 입혔습니다."); // i, splahDamage
                }
            }
            return skillDamage;
        }

        // ------------------- 퀘스트 관련 -------------------
        List<Quest> quests;
        public void AddQuest()
        {
            quests.Add(new Quest(2, "마을을 위협하는 몬스터 처치",
            "이봐! 마을 근처에 몬스터들이 너무 많아졌다고 생각하지 않나? 마을 주민들의 안전을 위해서라도 저것들 수를 좀 줄여야 한다고! 모험가인 자네가 좀 처치해주게!",
            500));

            quests.Add(new Quest(0, "장비를 장착해보자",
                "새로운 장비를 착용하여 힘을 높여보세요.",
                100));

            quests.Add(new Quest(1, "더욱 더 강해지기!",
                "훈련을 통해 강해지세요!",
                300));
        }

        public int QuestCnt() { return quests.Count; }

        public void TakeEquip()
        {
            foreach (Quest quest in quests)
            {
                if (quest.GetType() == 0)
                {
                    quest.isEquip = true;
                }
            }
        }

        public void AddKillCount()
        {
            foreach (Quest quest in quests)
            {
                if (quest.totalMob != Constants.MAX)
                {
                    quest.mobCnt += 1;
                }
            }
        }

        public void DisplayQuests()
        {
            while (true)
            {
                Console.Clear();

                for (int i = 0; i < quests.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {quests[i].name} (진행 상태: {(quests[i].isClear ? "완료" : quests[i].isAccept ? "수락" : "대기")})");
                }
                Console.WriteLine();
                Console.WriteLine("0. 나가기");
                Console.WriteLine();
                Console.WriteLine("원하시는 퀘스트를 선택해주세요.");
                Console.WriteLine(">>> ");

                int selectNum = InputCheck.Check(0, QuestCnt());
                if (selectNum == 0)
                {
                    break;
                }
                else
                {
                    Quest selectedQuest = quests[selectNum - 1];
                    if (selectedQuest.DisplayQuest() == 1)
                    {
                        Gold += selectedQuest.goldAmends;
                        quests.Remove(selectedQuest);
                    }
                }
            }
        }

        public void UserAttack(Monster monster, int index, Item item) // 유저가 공격할때
        {
            Console.Clear();
            int tempMonsterHP = monster.HP; // 현재 몬스터 HP
            //////
            int num = (int)Math.Round(((double)AttackDamage / 100 * 10), 0); // 유저의 공격력 10퍼센트 오차값 저장

            Random random = new Random();
            int resultDamage = random.Next((int)AttackDamage - num, (int)AttackDamage + num + 1); // 공격력이 10이면, 9 ~ 11

            monster.TakeDamage(resultDamage); // 최종 대미지를 몬스터한테전달, 
            /////
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
                AddKillCount();
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

        // ------------------- 유저 관리 관련 ------------------- 
        // 캐릭터선택창 메소드
        public void ChoiceUserClass(User user)
        {
            // ---------------- 캐릭터 직업 선택 -------------------
            Console.Clear();
            Console.WriteLine("[직업 선택]");
            // 직업 선택
            Console.WriteLine("직업을 선택해주세요.(해당 번호 입력)");
            Console.WriteLine();
            Console.WriteLine("1. 전사");
            Console.WriteLine("2. 마법사");
            Console.WriteLine();
            Console.Write(">> ");

            int select = InputCheck.Check(1, 3);
            switch (select)
            {
                case 1:
                    user = new Warrior(user);
                    user.AddSkill();
                    break;
                case 2:
                    user = new Wizard(user);
                    user.AddSkill();
                    break;
                default:
                    break;
            }
        }
        public void LevelUp(User user, int expSum)
        {
            int tempLevel = user.Level; // 이전 레벨 저장
            user.EXP += expSum;

            if (user.FullEXP <= user.EXP)
            {
                Quest quest = null!;
                foreach (Quest q in quests)
                {
                    if (q.lvUp != Constants.MAX)
                    {
                        quest = q;
                    }
                }

                quest.lvUp -= 1;
                user.Level++;
                user.EXP -= user.FullEXP; // 남은 경험치 이관
                user.FullEXP = 20 + (tempLevel * 5);
                UserLevelUpStatus(user);

                Console.WriteLine($" -> Lv.{user.Level}");
            }
            else
            {
                Console.Write("\n");
            }
        }

        // 스테이터스 증가량
        private void UserLevelUpStatus(User user)
        {

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
        public void State(User user, Item item)
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();

                Console.WriteLine("[상태보기]");
                Console.WriteLine("캐릭터의 정보가 표시됩니다.");
                Console.WriteLine();
                Console.WriteLine("레  벨 : {0} Lv", user.Level);
                Console.WriteLine("경험치 : {0} / {1} EXP", user.EXP, user.FullEXP);
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
    }
}