namespace TextRPG16
{
    public class Stage
    {
        int _stageLevel;

        public int StageLevel { get { return _stageLevel; } private set { _stageLevel = value; } }


        public Stage()
        {
            this.StageLevel = 1;
        }

        // 스테이지 시작 메서드
        public void StartStage(User user)
        {
            Monster monster = new Monster();
            monster.AddMonsterList(this);
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Battle!! - Stage {StageLevel}");
                Console.WriteLine();
                Console.WriteLine("[몬스터]");
                for (int i = 0; i < 3; i++)
                {
                    Console.Write($"Lv.{monster.monsterList[i].Level} {monster.monsterList[i].Name} ");
                    if (monster.monsterList[i].IsDead == false)
                        Console.WriteLine($"HP {monster.monsterList[i].HP}");
                    else
                        Console.WriteLine("Dead");
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("[내정보]");
                Console.WriteLine($"Lv. {user.Level} {user.Name} ({user.UserClass})");
                Console.WriteLine($"HP {user.HP}/{user.FullHP}");
                Console.WriteLine($"MP {user.MP}/{user.FullMP}");
                Console.WriteLine();

                Console.WriteLine("1. 공격");
                Console.WriteLine("0. 도망");
                Console.WriteLine();
                Console.Write(">> ");

                switch(InputCheck.Check(0, 1))
                {
                    case 0:
                        // 마을 가기
                        break;
                    case 1:
                        BattleStage(user, monster);
                        break;
                }
            }
        }

        // 스테이지 클리어 메서드
        public void StageClear(User user)
        {
            int expSum = 0;
            int expTemp = user.EXP; // 현재 경험치 저장
            Console.Clear();
            Console.WriteLine("Battle!! - Result");
            Console.WriteLine();
            Console.WriteLine("Victory");
            Console.WriteLine();
            Console.WriteLine($"{StageLevel++} 스테이지 클리어!");
            Console.WriteLine($"던전에서 몬스터 3마리를 잡았습니다."); // *** 마리수 표시 추가해야 함
            Console.WriteLine();

            Console.WriteLine("[캐릭터 정보]");
            Console.WriteLine($"{user.Name} ({user.UserClass})");
            Console.Write($"Lv.{user.Level}");
            user.LevelUp(user, expSum);
            Console.WriteLine($"HP {user.FullHP} -> {user.HP}");
            Console.WriteLine($"exp {expTemp} -> {expTemp + expSum}");
            Console.WriteLine();

            Console.WriteLine("[획득아이템 정보]");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("1. 계속 도전");
            Console.WriteLine("0. 나가기");

            user.HP = 100; // 체력 회복

            switch(InputCheck.Check(0, 1))
            {
                case 0:
                // 나가기(마을)
                case 1 :
                    StartStage(user);
                    break;
                default:
                    Console.WriteLine();
                    break;
            }
        }

        // 스테이지 실패 메서드
        public void StageLose(User user)
        {
            Console.Clear();
            Console.WriteLine("Battle!! - Result");
            Console.WriteLine();
            Console.WriteLine("You Lose");
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

        }

        // 공격 페이즈
        public void BattleStage(User user, Monster monster)
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine($"Battle!! - Stage {StageLevel}");
                Console.WriteLine();
                Console.WriteLine("[몬스터]");
                for (int i = 0; i < 3; i++)
                {
                    Console.Write($"{1 + i} Lv.{monster.monsterList[i].Level} {monster.monsterList[i].Name} ");
                    if (monster.monsterList[i].IsDead == false)
                        Console.WriteLine($"HP {monster.monsterList[i].HP}");
                    else
                        Console.WriteLine("Dead");
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
                Console.Write(">> ");

                int insult = InputCheck.Check(0, 3);

                if(monster.monsterList[insult - 1].IsDead == true)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(800);
                    continue;
                }

                switch (insult)
                {
                    case 0:
                        exit = true;
                        break;
                    case 1:
                    case 2:
                    case 3:
                        user.UserAttack(monster.monsterList[insult-1]);
                        for(int i = 0; i< 3; i++)
                        {
                            if (monster.monsterList[i].IsDead == false)
                            {
                                monster.monsterList[i].MonsterAttack(user);
                                break;
                            }
                            else if (i == 2)
                                StageClear(user);
                        }
                        exit = true;
                        break;
                }
            }
        }
    }
}
