using System;
using System.Threading;

namespace TextRPG16
{
    public class Stage
    {
        int _stageLevel;

        public int StageLevel { get { return _stageLevel; } private set { _stageLevel = value; } }

        public Stage(User user)
        {
            // 마지막에 도전 중이던 스테이지 레벨로 생성
            this.StageLevel = user.BestStageLevel;
        }

        // 스테이지 시작 메서드
        public void StartStage(User user, Item item, ConsumableItem consumableItem)
        {
            bool exit = false;
            Battle battle = new Battle();

            Monster monster = new Monster();
            // 스테이지 레벨을 받아서, 스테이지 레벨에 맞는 몬스터 객체 리스트 생성
            monster.AddMonsterList(this);

            while (!exit)
            {
                Console.Clear();
                AsciiArt.DisplayHeadLine(5);
                ConsoleSize.Color(ConsoleColor.Yellow);
                Console.WriteLine($"Battle!! - 타워 {StageLevel} 층");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("[몬스터]");
                // 몬스터 리스트 출력
                for (int i = 0; i < monster.monsterList.Count; i++)
                {
                    if (monster.monsterList[i].IsDead == false)
                    {
                        // 살아있는 몬스터
                        Console.WriteLine($"- Lv.{monster.monsterList[i].Level} {monster.monsterList[i].Name} HP {monster.monsterList[i].HP}");
                    }
                    else
                    {
                        // 죽어있는 몬스터
                        ConsoleSize.Color(ConsoleColor.DarkGray);
                        Console.WriteLine($"- Lv.{monster.monsterList[i].Level} {monster.monsterList[i].Name} Dead ");
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
                Console.WriteLine();
                // 내 정보 출력
                Console.WriteLine("[내정보]");
                Console.WriteLine($"Lv. {user.Level} {user.Name} ({user.UserClass})");
                Console.WriteLine($"HP {user.HP}/{user.FullHP}");
                Console.WriteLine($"MP {user.MP}/{user.FullMP}");
                Console.WriteLine();

                // 선택지
                Console.WriteLine("[선택지]");
                Console.WriteLine("1. 공  격 - MP 0  (단일공격)일반 공격으로 하나의 적을 공격합니다.");
                if (user.UserClass == "전사")
                {
                    Console.WriteLine($"2. 처  형 - MP 20  (단일공격)공격력 * 2 로 하나의 적을 공격합니다.");
                    Console.WriteLine($"3. 슬래시 - MP 30  (범위공격)공격력 * 1.5 로 적 2명을 랜덤으로 공격합니다.");
                }
                else if (user.UserClass == "마법사")
                {
                    Console.WriteLine($"2. 파이어볼 - MP 80  범위 공격합니다.(주변 대상에게는 공격력 1/3 을 적용)");
                    Console.WriteLine($"3. 마나실드 - MP 30  본인이 받는 데미지를 체력이 아닌, 마나로 소모합니다.");
                }
                Console.WriteLine("4. 회  복");
                Console.WriteLine("0. 도  망");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                int insert = InputCheck.Check(0, 4); // 선택 번호 저장
                int attackDamage = user.AttackDamage + user.EquipWeaponStatusNum; // 기본공격력 + 장비 공격력 저장

                // 번호 선택에 따른 처리작업
                if (insert == 0)
                    break;
                else if (insert == 4)
                {
                    consumableItem.UsePotionList(user, consumableItem); // 포션 사용
                    continue;
                }
                else
                {
                    if (insert == 3)
                    {
                        if (user.UserClass == "전사") // 랜덤 타겟 공격
                        {
                            attackDamage = battle.WarriorSkill3_Slash(user, monster, attackDamage);
                            if (attackDamage == -5)
                                continue;
                            battle.SkillRandomAttackResult(user, monster, attackDamage);
                        }
                        else
                        {
                            // 마법사 마나실드 사용
                            attackDamage = battle.WizardSkill3_ManaShield(user, monster);
                            if (attackDamage == -5)
                                continue;
                            ShieldMonsterAttackPhase(user, monster, item, consumableItem);
                            continue;
                        }
                    }
                    else
                    {
                        if (insert == 1)
                            attackDamage = battle.UserAttack(user, monster, attackDamage);
                        else if (user.UserClass == "전사")
                            attackDamage = battle.WarriorSkill2_Execute(user, monster, attackDamage);
                        else if (user.UserClass == "마법사")
                            attackDamage = battle.WizardSkill2_Fireball(user, monster, attackDamage);

                        if (attackDamage == -5)
                            continue;

                        StageMonsterChoice(user, monster, item, consumableItem, attackDamage, insert); // 공격할 몬스터 선택
                    }
                }
                if (attackDamage == -5)
                    continue;

                // 몬스터 공격 차례 & 클리어 여부 확인
                if (MonsterAttackPhase(user, monster, item, consumableItem))
                    exit = true;

                // 유저 생존 여부 체크 -> 죽으면 스테이지 실패창
                if (user.IsDead)
                {
                    StageLose(user, item, consumableItem);
                    exit = true;
                }

            }
        }
        // 스킬 페이즈2 - 공격할 몬스터 선택
        public void StageMonsterChoice(User user, Monster monster, Item item, ConsumableItem consumableItem, int resultDamage, int skillInsert)
        {
            Battle battle = new Battle();
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                AsciiArt.DisplayHeadLine(5);
                ConsoleSize.Color(ConsoleColor.Yellow);
                Console.WriteLine($"Battle!! - 타워 {StageLevel} 층");
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
                Console.WriteLine();
                Console.WriteLine("공격할 몬스터를 선택하세요.");
                Console.Write(">> ");

                int insert = InputCheck.Check(1, 3);
                int index = insert - 1;

                if (insert == 0)
                {
                    break;
                }
                // 인덱스 범위 검사 추가 (유효한 인덱스인지 확인)
                if (monster.monsterList[index].IsDead)
                {
                    Console.WriteLine("이미 죽은 몬스터입니다");
                    Thread.Sleep(800);
                    continue;
                }

                if(skillInsert == 2 && user.UserClass == "마법사")
                {
                    Console.Clear();
                    battle.SkillAttckResult(user, monster.monsterList[index], resultDamage);
                    for(int i = 0; i< monster.monsterList.Count; i++)
                    {
                        if(i != index && !monster.monsterList[i].IsDead)
                        {
                            battle.SkillAttckResult(user, monster.monsterList[i], resultDamage);
                        }
                    }
                }
                else
                {
                    Console.Clear();
                    battle.SkillAttckResult(user, monster.monsterList[index], resultDamage);
                }
                battle.NextScreenButton();
                break;
            }
        }

        // 몬스터 공격 차례
        public bool MonsterAttackPhase(User user, Monster monster, Item item, ConsumableItem consumableItem)
        {
            Battle battle = new Battle();
            // 몬스터 공격 차례
            for (int i = 0; i < 3; i++)
            {
                if (monster.monsterList[i].IsDead == false)
                {
                    // 몬스터 공격력 계산 함수
                    int MonsterResultDamage = battle.MonsterAttack(user, monster.monsterList[i]);
                    // 몬스터 공격 결과 화면
                    battle.MonsterAttackResultScreen(user, monster.monsterList[i], MonsterResultDamage);
                    return false;
                }
            }
            StageClear(user, item, monster, consumableItem);
            return true;
        }
        // 마나쉴드
        // 몬스터 공격 차례
        public bool ShieldMonsterAttackPhase(User user, Monster monster, Item item, ConsumableItem consumableItem)
        {
            Battle battle = new Battle();
            // 몬스터 공격 차례
            for (int i = 0; i < 3; i++)
            {
                if (monster.monsterList[i].IsDead == false)
                {
                    // 몬스터 공격력 계산 함수
                    int MonsterResultDamage = battle.MonsterAttack(user, monster.monsterList[i]);
                    // 몬스터 공격 결과 화면
                    battle.ShieldMonsterAttackResultScreen(user, monster.monsterList[i], MonsterResultDamage);
                    return false;
                }
            }
            StageClear(user, item, monster, consumableItem);
            return true;
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
            Console.WriteLine($"{StageLevel++} 층 클리어!");
            Console.WriteLine($"이번 층에서 몬스터 3마리를 잡았습니다."); // *** 마리수 표시 추가해야 함
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

            user.HP = user.FullHP; // 체력 회복
            user.MP = user.FullMP;
            user.BestStageLevel = StageLevel;

            if (InputCheck.Check(0, 1) == 1)
            {
                // 새로운 층 도전
                Stage stage = new Stage(user);
                stage.StartStage(user, item, consumableItem);
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
            user.HP = (user.FullHP / 2); // 절반의 체력 회복

            while (InputCheck.Check(0, 0) != 0)
            {
                Console.Write(">> ");
            }
        }
    }
}