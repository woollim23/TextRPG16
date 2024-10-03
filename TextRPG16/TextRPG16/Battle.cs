using System;

namespace TextRPG16
{
    public class Battle
    {
        public void NextScreenButton()
        {
            Console.WriteLine();
            Console.WriteLine("0. 다음");
            Console.WriteLine();
            Console.Write(">> ");
            while (InputCheck.Check(0, 0) != 0)
            {
                Console.Write(">> ");
            }
        }
        // 치명타 / 회피 / 계산
        public int DamageLuckyCalculation(int resultDamage)
        {
            Random random = new Random();
            int num = random.Next(1, 101);

            if (num > 60 && num <= 80) // 60 ~ 80 이면 1.5배 치명 공격
                return (int)(resultDamage * 1.5);
            else if (num > 80 && num <= 100) // 80 ~ 100 이면 회피
                return -1;
            else // 그 외 일반 공격
                return resultDamage;
        }

        // ----------------- 유저 전투 -------------------
        // 유저 일반 공격
        public int UserAttack(User user, Monster monster, int attackDamage)
        {
            // 오차값을 10%로 계산
            float num = attackDamage * 0.1f;

            Random random = new Random();
            float resultDamage = (float)(random.NextDouble() * ((attackDamage + num) - (attackDamage - num)) + (attackDamage - num));

            return (int)resultDamage;
        }
        // 유저 스킬들
        public int WarriorSkill2_Execute(User user, Monster monster, int attackDamage)
        {
            if (user.MP < 20)
            {
                Console.WriteLine("마나가 부족해서 스킬을 사용 할 수 없습니다.");
                Thread.Sleep(1000);
                return -5;
            }

            Console.WriteLine("처형 스킬 사용! 단일 적 1명에게 데미지를 가합니다.");

            // 공격력*스킬 계수 = 스킬 데미지
            int tempAttackDamage = attackDamage * 2;

            // 오차값을 10%로 계산
            float num = tempAttackDamage * 0.1f;

            //랜덤한 데미지를 구할 때 범위를 실수형으로 설정  // 공격력이 10이면, 9 ~ 11
            Random random = new Random();
            float resultDamage = (float)(random.NextDouble() * ((tempAttackDamage + num) - (tempAttackDamage - num)) + (tempAttackDamage - num));

            user.MP -= 20;

            Thread.Sleep(1000);
            return (int)resultDamage;
        }
        public int WarriorSkill3_Slash(User user, Monster monster, int attackDamage)
        {
            if (user.MP < 30)
            {
                Console.WriteLine("마나가 부족해서 스킬을 사용 할 수 없습니다.");
                Thread.Sleep(1000);
                return -5;
            }

            Console.WriteLine("슬래쉬 스킬 사용! 랜덤한 적 2명에게 데미지를 가합니다.");

            // 공격력 * 스킬 계수 = 스킬 데미지
            float tempAttackDamage = attackDamage * (1.5f);

            // 오차값을 10%로 계산
            float num = tempAttackDamage * 0.1f;

            // 랜덤한 데미지를 구할 때 범위를 실수형으로 설정 // 공격력이 10이면, 9 ~ 11
            Random random = new Random();
            float resultDamage = (float)(random.NextDouble() * ((tempAttackDamage + num) - (tempAttackDamage - num)) + (tempAttackDamage - num));

            /*
            //// 이미 공격한 적을 저장하기 위한 리스트
            //List<int> attackedTargets = new List<int>();

            //// 총 2명의 몬스터에게 데미지를 가함
            //for (int i = 0; i < 2; i++)
            //{
            //    int randomIndex;

            //    // 중복되지 않는 몬스터를 선택하기 위한 로직
            //    do
            //    {
            //        randomIndex = random.Next(0, monster.monsterList.Count);
            //    }
            //    while (attackedTargets.Contains(randomIndex) || monster.monsterList[randomIndex].IsDead); // 중복 체크 및 사망한 몬스터 제외

            //    attackedTargets.Add(randomIndex); // 공격한 적의 인덱스를 기록

            //    // 최종 데미지를 몬스터에게 전달 (반올림해서)
            //    int finalDamage = (int)resultDamage;
            //    monster.monsterList[randomIndex].TakeDamage(finalDamage);

            //    // 결과 출력
            //    Console.WriteLine($"랜덤으로 선택된 적 {monster.monsterList[randomIndex].Name}에게 {finalDamage} 대미지를 입혔습니다.");
            //}
            */

            user.MP -= 30;

            Thread.Sleep(1000);
            return (int)resultDamage;
        }
        public int WizardSkill2_Fireball(User user, Monster monster, int attackDamage)
        {
            if (user.MP < 80)
            {
                Console.WriteLine("마나가 부족해서 스킬을 사용 할 수 없습니다.");
                Thread.Sleep(1000);
                return -5;
            }

            Console.WriteLine("파이어볼 스킬 사용! 범위공격을 합니다.");

            // 공격력 * 스킬 계수 = 스킬 데미지
            float tempAttackDamage = attackDamage * (2);

            // 오차값을 10%로 계산
            float num = tempAttackDamage * 0.1f;

            // 랜덤한 데미지를 구할 때 범위를 실수형으로 설정 // 공격력이 10이면, 9 ~ 11
            Random random = new Random();
            float resultDamage = (float)(random.NextDouble() * ((tempAttackDamage + num) - (tempAttackDamage - num)) + (tempAttackDamage - num));

            /*
            // 타겟 몬스터에게 풀 데미지 적용
            //monster.monsterList[targetIndex].TakeDamage(skillDamage);
            //Console.WriteLine($"타겟된 적에게 {monster.monsterList[targetIndex].Name}에게 {skillDamage} 대미지를 입혔습니다."); // tagetIndex, skillDamage

            // 주변 몬스터에게 1/3 데미지 적용
            //for (int i = 0; i < monster.monsterList.Count; i++)
            //{
            //    if (i != targetIndex && !monster.monsterList[i].IsDead)
            //    {
            //        int splashDamage = skillDamage / 3;
            //        monster.monsterList[i].TakeDamage(splashDamage);
            //        Console.WriteLine($"주변 적 {monster.monsterList[i].Name}에게 {splashDamage} 대미지를 입혔습니다."); // i, splahDamage
            //    }
            //}
            */
            user.MP -= 80;

            Thread.Sleep(1000);
            return (int)resultDamage;
        }
        public int WizardSkill3_ManaShield(User user, Monster monster)
        {
            if (user.MP < 30)
            {
                Console.WriteLine("마나가 부족해서 스킬을 사용 할 수 없습니다.");
                Thread.Sleep(1000);
                return -5;
            }
            user.MP -= 30;
            Console.WriteLine("마나실드 사용! 마나실드를 전개합니다.");
            Thread.Sleep(1000);
            return 0;
        }

        // 유저 공격 결과 문구
        public void SkillAttckResult(User user, Monster monster, int resultDamage)
        {
            int tempMonsterHP = monster.HP; // 공격 이전 체력 저장
            int tempResultDamage = resultDamage; // 현재 공격 데미지 저장

            ConsoleSize.Color(ConsoleColor.Blue);
            Console.WriteLine($"{user.Name} 의 공격!");
            Console.ResetColor();

            resultDamage = DamageLuckyCalculation(resultDamage); // 치명타 / 회피 / 일반공격 계산 함수

            if (monster.IsDead)
            {
                Console.Write($"Lv.{monster.Level} {monster.Name}은(는) 이미 죽은 몬스터입니다..\n");
            }
            else if (resultDamage > 0)
            {
                monster.TakeDamage(resultDamage);
                Console.Write($"Lv.{monster.Level} {monster.Name}을(를) 맞췄습니다!. [데미지 : {resultDamage}] ");
                if (tempResultDamage < resultDamage)
                {
                    ConsoleSize.Color(ConsoleColor.Red);
                    Console.Write("- 치명타 공격!!\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write("\n");
                }
                // 피 차감 출력
                Console.WriteLine();
                Console.WriteLine($"Lv.{monster.Level} {monster.Name}");
                Console.Write($"HP {tempMonsterHP} -> ");
                if (monster.IsDead)
                {
                    user.AddKillCount();
                    Console.WriteLine("Dead");
                }
                else
                {
                    Console.WriteLine(monster.HP);
                }
            }
            else // 회피일 경우
            {
                Console.Write($"Lv.{monster.Level} {monster.Name}을(를) 공격했지만 아무일도 일어나지 않았습니다..\n");
            }

            Console.WriteLine();
        }
        // 유저 랜덤 스킬 공격 결과 창
        public void SkillRandomAttackResult(User user, Monster monster, int resultDamage)
        {
            Console.Clear();

            // 살아있는 몬스터 리스트 생성
            List<Monster> aliveMonsters = monster.monsterList.Where(m => !m.IsDead).ToList();

            Random random = new Random();

            // 살아있는 몬스터가 1마리면 그 1마리만 공격
            if (aliveMonsters.Count == 1)
            {
                Monster target = aliveMonsters[0];
                SkillAttckResult(user, target, resultDamage); // 1마리만 공격
            }
            else
            {
                // 2마리 랜덤으로 선택 (중복되지 않도록)
                List<Monster> randomTargets = aliveMonsters.OrderBy(x => random.Next()).Take(2).ToList();

                // 선택된 몬스터 2마리 공격
                foreach (var target in randomTargets)
                {
                    SkillAttckResult(user, target, resultDamage);
                }
            }


            NextScreenButton();
        }
        public static void SkillRandomAttackResult2(User user, Monster monster, int resultDamage)
        {
            Console.Clear();
            int randomTemp = -1;
            int count = 0;
            Random random = new Random();
            int num = random.Next(1, 101); // 1 ~ 100

            int finalDamage = resultDamage; // 최종 대미지 초기화
            string attackType = ""; // 공격 유형 메세지

            if (num >= 1 && num <= 60) // 1 ~ 60 -> 60% 
            {
                attackType = "일반 공격";
            }
            else if (num > 60 && num <= 80) // 61 ~ 80 -> 20% 치명타
            {
                finalDamage = (int)(resultDamage * 1.5); // 치명타는 1.5배 대미지
                attackType = "치명타 공격!!";
            }
            else // 81 ~ 100 -> 20% 회피
            {
                finalDamage = 0; // 회피 시 데미지는 0
                attackType = "회피 성공!!";
            }

            int tempMonsterHP = monster.HP; // 현재 몬스터 HP
            Console.WriteLine($"Battle!!");
            Console.WriteLine();
            Console.WriteLine($"{user.Name} 의 공격!");
            Console.WriteLine($"Lv.{monster.Level} {monster.Name}을(를) 맞췄습니다. [데미지 : {finalDamage}] - {attackType}");

            if (finalDamage > 0) // 데미지가 있을 때만 HP 변동
            {
                Console.WriteLine();
                Console.WriteLine($"Lv.{monster.Level} {monster.Name}");
                Console.Write($"HP {tempMonsterHP} -> ");

                monster.TakeDamage(finalDamage); // 몬스터에게 데미지 적용

                if (monster.IsDead)
                {
                    Console.WriteLine("Dead");
                    //user.MonsterCount[monsterIndex]++; // 몬스터 카운트 증가
                    user.AddKillCount();
                }
                else
                {
                    Console.WriteLine(monster.HP); // 남은 HP 출력
                }
            }
            else
            {
                Console.WriteLine("공격이 회피되었습니다!");
            }


        }

        // ----------------- 몬스터 전투 -------------------
        // 몬스터 공격
        public int MonsterAttack(User user, Monster monster)
        {
            int num = (int)Math.Round(((double)monster.AttackDamage / 100 * 10), 0); // 오차값

            Random random = new Random();
            int resultDamage = random.Next((int)monster.AttackDamage - num, (int)monster.AttackDamage + num);

            return resultDamage;
        }
        // 몬스터 공격 결과 창
        public void MonsterAttackResultScreen(User user, Monster monster, int resultDamage)
        {
            Console.Clear();
            int tempUserHP = user.HP; // 공격 이전 유저 체력 저장
            int tempResultDamage = resultDamage; // 현재 몬스터 공격 데미지 저장

            ConsoleSize.Color(ConsoleColor.DarkYellow);
            Console.WriteLine($"{monster.Name} 의 공격!");
            Console.ResetColor();

            resultDamage = DamageLuckyCalculation(resultDamage); // 치명타 / 회피 / 일반공격 계산 함수

            if (resultDamage > 0)
            {
                user.TakeDamage(resultDamage);
                Console.Write($"Lv.{user.Level} {user.Name}을(를) 맞췄습니다!. [데미지 : {resultDamage}] ");
                if (tempResultDamage < resultDamage)
                {
                    ConsoleSize.Color(ConsoleColor.Red);
                    Console.Write("- 치명타 공격!!\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write("\n");
                }
                // 피 차감 출력
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
            }
            else // 회피일 경우
            {
                Console.Write($"Lv.{user.Level} {user.Name}을(를) 공격했지만 아무일도 일어나지 않았습니다..");
            }
            Console.WriteLine();
            NextScreenButton();
        }
        // 마나 실드 공격 결과 창
        // 몬스터 공격 결과 창
        public void ShieldMonsterAttackResultScreen(User user, Monster monster, int resultDamage)
        {
            Console.Clear();
            int tempUserMP = user.MP; // 공격 이전 유저 체력 저장
            int tempResultDamage = resultDamage; // 현재 몬스터 공격 데미지 저장

            ConsoleSize.Color(ConsoleColor.DarkYellow);
            Console.WriteLine($"{monster.Name} 의 공격!");
            Console.ResetColor();

            resultDamage = DamageLuckyCalculation(resultDamage); // 치명타 / 회피 / 일반공격 계산 함수

            if (resultDamage > 0)
            {
                Console.Write($"Lv.{user.Level} {user.Name}을(를) 맞췄습니다!. [데미지 : {resultDamage}] ");
                if (tempResultDamage < resultDamage)
                {
                    ConsoleSize.Color(ConsoleColor.Red);
                    Console.Write("- 치명타 공격!!\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write("\n");
                }
                // 피 차감 출력
                Console.WriteLine();
                Console.WriteLine($"Lv.{user.Level} {user.Name}");
                Console.Write($"MP {tempUserMP} -> ");
                if (tempUserMP < resultDamage)
                {
                    Console.Write("0\n");
                    int tempUserHP = user.HP;
                    
                    user.MP = 0;
                    user.TakeDamage(resultDamage - tempUserMP);
                    Console.WriteLine($"HP {tempUserHP} -> ");

                    if (user.IsDead)
                    {
                        Console.WriteLine("Dead");
                    }
                    else
                    {
                        Console.WriteLine(user.HP);
                    }
                }
                else
                {
                    user.MP -= resultDamage;
                    Console.WriteLine(user.MP);
                }

            }
            else // 회피일 경우
            {
                Console.Write($"Lv.{user.Level} {user.Name}을(를) 공격했지만 아무일도 일어나지 않았습니다..");
            }
            Console.WriteLine();
            NextScreenButton();
        }
    }
}


