namespace TextRPG16
{
    public class Stage
    {
        int _stageLevel;

        public int StageLevel { get { return _stageLevel; } private set { _stageLevel = value; } }

        public Stage(User user)
        {
            this.StageLevel = user.BestStageLevel;
        }

        // 스테이지 시작 메서드
        public void StartStage(User user, Item item, ConsumableItem consumableItem)
        {
            bool exit = false;
            Monster monster = new Monster();
            monster.AddMonsterList(this);
            do
            {
                Console.Clear();
                ConsoleSize.Color(ConsoleColor.Yellow);
                Console.WriteLine($"Battle!! - Stage {StageLevel}");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("[몬스터]");
                for (int i = 0; i < 3; i++)
                {

                    if (monster.monsterList[i].IsDead == false)
                    {
                        Console.WriteLine($"- Lv.{monster.monsterList[i].Level} {monster.monsterList[i].Name} HP {monster.monsterList[i].HP}");
                    }

                    else
                    {
                        ConsoleSize.Color(ConsoleColor.DarkGray);
                        Console.WriteLine($"- Lv.{monster.monsterList[i].Level} {monster.monsterList[i].Name} Dead ");
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("[내정보]");
                Console.WriteLine($"Lv. {user.Level} {user.Name} ({user.UserClass})");
                Console.WriteLine($"HP {user.HP}/{user.FullHP}");
                Console.WriteLine($"MP {user.MP}/{user.FullMP}");
                Console.WriteLine();

                Console.WriteLine("1. 공격");
                Console.WriteLine("2. 스킬");
                Console.WriteLine("3. 회복");
                Console.WriteLine("0. 도망");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                switch (InputCheck.Check(0, 2))
                {
                    case 0:
                        GameManager gameManager = new GameManager();
                        gameManager.GamePlay(user, item, consumableItem);
                        break;
                    case 1:
                        BattleStage(user, monster, item, consumableItem);
                        break;
                    case 2:
                        SkillStage(user, monster, item, consumableItem);
                        break;
                    case 3:
                        consumableItem.UsePotionList(user, consumableItem);
                        break;
                }
            } while (!exit);
        }

        // 공격 페이즈 - 공격할 몬스터 선택
        public void BattleStage(User user, Monster monster, Item item, ConsumableItem consumableItem)
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                ConsoleSize.Color(ConsoleColor.Yellow);
                Console.WriteLine($"Battle!! - Stage {StageLevel}");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("[몬스터]");
                for (int i = 0; i < 3; i++)
                {
                    if (monster.monsterList[i].IsDead == false)
                    {
                        Console.WriteLine($"{1 + i} Lv.{monster.monsterList[i].Level} {monster.monsterList[i].Name} HP {monster.monsterList[i].HP}");
                    }
                    else
                    {
                        ConsoleSize.Color(ConsoleColor.DarkGray);
                        Console.WriteLine($"{1 + i} Lv.{monster.monsterList[i].Level} {monster.monsterList[i].Name} Dead");
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("[내정보]");
                Console.WriteLine($"Lv. {user.Level} {user.Name} ({user.UserClass})");
                Console.WriteLine($"HP {user.HP}/{user.FullHP}");
                Console.WriteLine($"MP {user.MP}/{user.FullMP}");
                Console.WriteLine();

                Console.WriteLine("0. 취소");
                Console.WriteLine();
                Console.WriteLine("공격할 몬스터를 선택하세요.");
                Console.Write(">> ");

                int insert = InputCheck.Check(0, 3);

                if (insert == 0)
                {
                    break;
                }

                // 인덱스 범위 검사 추가 (유효한 인덱스인지 확인)
                if (monster.monsterList[insert - 1].IsDead)
                {
                    Console.WriteLine("이미 죽은 몬스터입니다");
                    Console.Write(">> ");
                    Thread.Sleep(800);
                    continue;
                }

                // 유효한 인덱스일 때 공격 처리
                user.UserAttack(monster.monsterList[insert - 1], monster.monsterList[insert - 1].Index, item);

                // ------------ 몬스터 공격 페이즈 ------------
                MonsterAttackPhase(user, monster, item, consumableItem);
            }
        }

        // 스킬 페이즈1 - 스킬 선택
        public void SkillStage(User user, Monster monster, Item item, ConsumableItem consumableItem)
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                ConsoleSize.Color(ConsoleColor.Yellow);
                Console.WriteLine($"Battle!! - Stage {StageLevel}");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("[몬스터]");
                for (int i = 0; i < 3; i++)
                {
                    if (monster.monsterList[i].IsDead == false)
                    {
                        Console.WriteLine($"- Lv.{monster.monsterList[i].Level} {monster.monsterList[i].Name} HP {monster.monsterList[i].HP}");
                    }
                    else
                    {
                        ConsoleSize.Color(ConsoleColor.DarkGray);
                        Console.WriteLine($"- Lv.{monster.monsterList[i].Level} {monster.monsterList[i].Name} Dead ");
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("[내정보]");
                Console.WriteLine($"Lv. {user.Level} {user.Name} ({user.UserClass})");
                Console.WriteLine($"HP {user.HP}/{user.FullHP}");
                Console.WriteLine($"MP {user.MP}/{user.FullMP}");
                Console.WriteLine();
                Console.WriteLine("[스킬]");
                for (int i = 0; i < user.SkillList.Count; i++)
                {
                    Console.WriteLine($"{1 + i}. {user.SkillList[i].SkillName} - MP {user.SkillList[i].UseMP}");
                    Console.WriteLine($"{user.SkillList[i].SkillDescription}");
                }
                Console.WriteLine("0. 취소");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                // ------------ 번호 선택 유효 검사 -------------
                int insert = InputCheck.Check(0, user.SkillList.Count);
                if (insert == 0)
                {
                    break;
                }

                // ------------ 유저가 선택한 스킬 작업 -------------
                // 유효한 인덱스일 때 공격 처리
                if (user.SkillList[insert - 1].IncreaseRate == -1)
                {
                    // 실드 스킬이나 회피스킬
                    // 도적 회피 스킬이라면 break를 써서 탈출하자
                    // 두신님이 작업한 스킬 함수 불러오기
                    // ------------ 몬스터 공격 페이즈 ------------
                    MonsterAttackPhase(user, monster, item, consumableItem);
                    break;
                }
                else
                {   // 공격스킬 
                    // 두신님이 작업한 스킬 함수 불러오기
                    int resultDamage = 0; // 불러와서 대미지 여기에 저장
                    if (user.SkillList[insert - 1].TargetRandom == false)
                    {
                        SkillStageMonsterChoice(user, monster, item, consumableItem, resultDamage);
                    }
                    else if (user.SkillList[insert - 1].TargetNumber == 3)
                    {
                        for (int i = 0; i < monster.monsterList.Count; i++)
                        {
                            Battle.SkillAttckResult(user, monster, resultDamage, i);
                        }
                    }
                    else
                    {
                        int randomTemp = 0;
                        for(int i = 0; i < user.SkillList[insert - 1].TargetNumber; i++)
                        {
                            Random random = new Random();
                            int index = random.Next(0, monster.monsterList.Count);
                            Battle.SkillAttckResult(user, monster, resultDamage, index);
                        }
                    }

                    Console.WriteLine();
                    Console.WriteLine("0. 다음");
                    Console.WriteLine();
                    Console.Write(">> ");
                    while (InputCheck.Check(0, 0) != 0)
                    {
                        Console.Write(">> ");
                    }
                    break;
                }
            }
        }

        // 스킬 페이즈2 - 공격할 몬스터 선택
        public void SkillStageMonsterChoice(User user, Monster monster, Item item, ConsumableItem consumableItem, int resultDamage)
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                ConsoleSize.Color(ConsoleColor.Yellow);
                Console.WriteLine($"Battle!! - Stage {StageLevel}");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("[몬스터]");
                for (int i = 0; i < 3; i++)
                {
                    if (monster.monsterList[i].IsDead == false)
                    {
                        Console.WriteLine($"{1 + i} Lv.{monster.monsterList[i].Level} {monster.monsterList[i].Name} HP {monster.monsterList[i].HP}");
                    }
                    else
                    {
                        ConsoleSize.Color(ConsoleColor.DarkGray);
                        Console.WriteLine($"{1 + i} Lv.{monster.monsterList[i].Level} {monster.monsterList[i].Name} Dead");
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("[내정보]");
                Console.WriteLine($"Lv. {user.Level} {user.Name} ({user.UserClass})");
                Console.WriteLine($"HP {user.HP}/{user.FullHP}");
                Console.WriteLine($"MP {user.MP}/{user.FullMP}");
                Console.WriteLine();

                Console.WriteLine("0. 취소");
                Console.WriteLine();
                Console.WriteLine("공격할 몬스터를 선택하세요.");
                Console.Write(">> ");

                int insert = InputCheck.Check(0, 3);

                if (insert == 0)
                {
                    break;
                }

                // 인덱스 범위 검사 추가 (유효한 인덱스인지 확인)
                if (monster.monsterList[insert - 1].IsDead)
                {
                    Console.WriteLine("이미 죽은 몬스터입니다");
                    Console.Write(">> ");
                    Thread.Sleep(800);
                    continue;
                }

                // 두신님의 스킬 공격 관련 연산 함수 -> result Damage 받기
                Battle.SkillAttckResult(user, monster, resultDamage, insert - 1);
                // 파이어볼에 대한 예외처리 추가


                Console.WriteLine();
                Console.WriteLine("0. 다음");
                Console.WriteLine();
                Console.Write(">> ");
                while (InputCheck.Check(0, 0) != 0)
                {
                    Console.Write(">> ");
                }

                // ------------ 몬스터 공격 페이즈 ------------
                MonsterAttackPhase(user, monster, item, consumableItem);
                break;
            }
        }

        public void MonsterAttackPhase(User user, Monster monster, Item item, ConsumableItem consumableItem)
        {
            for (int i = 0; i < 3; i++)
            {
                if (monster.monsterList[i].IsDead == false)
                {
                    monster.monsterList[i].MonsterAttack(user, item, consumableItem);
                    break;
                }
                else if (i == 2)
                    StageClear(user, item, monster, consumableItem);
            }
        }

        // 스테이지 클리어 메서드
        public void StageClear(User user, Item item, Monster monster, ConsumableItem consumableItem)
        {
            Reward reward = new Reward();

            int expSum = 0; // 몬스터가 준 경험치 합
            for (int i = 0; i < 3; i++)
            {
                expSum += monster.monsterList[i].MonsterEXP;
            }

            int expTemp = user.EXP; // 현재 경험치 저장
            Console.Clear();
            ConsoleSize.Color(ConsoleColor.Yellow);
            Console.WriteLine("Battle!! - Result");  // 글씨 노랑색으로 변경
            Console.ResetColor();
            Console.WriteLine();
            ConsoleSize.Color(ConsoleColor.Green);
            Console.WriteLine("Victory");              // 글씨 초록색으로 변경
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine($"{StageLevel++} 스테이지 클리어!");
            Console.WriteLine($"던전에서 몬스터 3마리를 잡았습니다."); // *** 마리수 표시 추가해야 함
            Console.WriteLine();

            Console.WriteLine("[캐릭터 정보]");
            Console.WriteLine($"{user.Name} ({user.UserClass})");
            Console.Write($"Lv.{user.Level}");
            user.LevelUp(user, expSum); // 레벨업 함수
            Console.WriteLine($"HP {user.FullHP} -> {user.HP}");
            Console.WriteLine($"exp {expTemp} -> {expTemp + expSum}");
            Console.WriteLine();

            Console.WriteLine("[획득아이템 정보]");
            Console.WriteLine("{0} Gold", reward.GoldReward(user, this));
            reward.PotionReward(user, consumableItem);
            reward.ItemReward(user, item); // 아이템 보상 추가
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("1. 계속 도전");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            user.HP = 100; // 체력 회복
            user.BestStageLevel = StageLevel;

            switch (InputCheck.Check(0, 1))
            {
                case 0:
                    GameManager gameManager = new GameManager();
                    gameManager.GamePlay(user, item, consumableItem);
                    break;
                case 1:
                    StartStage(user, item, consumableItem);
                    break;
                default:
                    Console.WriteLine();
                    break;
            }
        }

        // 스테이지 실패 메서드
        public void StageLose(User user, Item item, ConsumableItem consumableItem)
        {
            Console.Clear();
            ConsoleSize.Color(ConsoleColor.Yellow);
            Console.WriteLine("Battle!! - Result");
            Console.ResetColor();
            Console.WriteLine();
            ConsoleSize.Color(ConsoleColor.Red);
            Console.WriteLine("You Lose");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine($"Lv. {user.Level} {user.Name} ({user.UserClass})");
            Console.WriteLine($"HP {user.FullHP} -> 0");
            Console.WriteLine();
            Console.WriteLine("0. 마을에서 부활");
            Console.WriteLine();
            Console.Write(">> ");
            user.HP = user.FullHP; // 체력 회복

            while (InputCheck.Check(0, 0) != 0)
            {
                Console.Write(">> ");
            }

            GameManager gameManager = new GameManager();
            gameManager.GamePlay(user, item, consumableItem);
        }
    }
}