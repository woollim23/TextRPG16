using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG16
{
    public class Stage
    {
        ICharacter player; // 플레이어
        ICharacter monster; // 몬스터

        // 이벤트 델리게이트 정의
        public delegate void GameEvent(ICharacter character);
        public event GameEvent OnCharacterDeath; // 캐릭터가 죽었을 때 발생하는 이벤트

        // 스테이지 시작 메서드
        public void Start()
        {
            Console.WriteLine($"스테이지 시작! 플레이어 정보: 체력({player.HP}), 공격력({player.AttackDamage})");
            Console.WriteLine($"몬스터 정보: 이름({monster.Name}), 체력({monster.HP}), 공격력({monster.AttackDamage})");
            Console.WriteLine("----------------------------------------------------");

            while (!player.IsDead && !monster.IsDead) // 플레이어나 몬스터가 죽을 때까지 반복
            {
                // 플레이어의 턴
                Console.WriteLine($"{player.Name}의 턴!");
                monster.TakeDamage(player.AttackDamage);
                Console.WriteLine();
                Thread.Sleep(1000);  // 턴 사이에 1초 대기

                if (monster.IsDead) break;  // 몬스터가 죽었다면 턴 종료

                // 몬스터의 턴
                Console.WriteLine($"{monster.Name}의 턴!");
                player.TakeDamage(monster.AttackDamage);
                Console.WriteLine();
                Thread.Sleep(1000);  // 턴 사이에 1초 대기
            }

            // 플레이어나 몬스터가 죽었을 때 이벤트 호출
            if (player.IsDead)
            {
                OnCharacterDeath?.Invoke(player);
            }
            else if (monster.IsDead)
            {
                OnCharacterDeath?.Invoke(monster);
            }
        }

        // 스테이지 클리어 메서드
        private void StageClear(ICharacter character)
        {
            if (character is Monster)
            {
                Console.WriteLine($"스테이지 클리어! {character.Name}를 물리쳤습니다!");

               

                player.HP = 100; // 각 스테이지마다 체력 회복
            }
            else
            {
                Console.WriteLine("게임 오버! 패배했습니다...");
            }
        }
    }
}
