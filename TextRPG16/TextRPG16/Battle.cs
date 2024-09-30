using System.Xml.Linq;

namespace TextRPG16
{
    class Battle
    {
        public void Attack(ICharacter attacker, ICharacter deffenser) // 공격할때
        {
            Console.Clear();
            int tempMonsterHP = deffenser.HP;
            int num = (int)Math.Round(((double)attacker.AttackDamage / 100 * 10), 0); // 오차값

            Random random = new Random();
            int resultDamage = random.Next((int)attacker.AttackDamage - num, (int)attacker.AttackDamage + num);

            deffenser.TakeDamage(resultDamage);

            Console.WriteLine($"Battle!!");
            Console.WriteLine();
            Console.WriteLine($"{attacker.Name} 의 공격!");
            Console.WriteLine($"Lv.{deffenser.Level} {deffenser.Name}을(를) 맞췄습니다!. [데미지 : {resultDamage}]");
            Console.WriteLine();
            Console.WriteLine($"Lv.{deffenser.Level} {deffenser.Name}");
            Console.Write($"HP {tempMonsterHP} -> ");

            if (deffenser.IsDead)
            {
                Console.WriteLine("Dead");
            }
            else
            {
                Console.WriteLine(deffenser.HP);
            }
            Console.WriteLine();
            Console.WriteLine("0. 다음");
            Console.WriteLine();

            while (InputCheck.Check(0, 0) == 0)
            {
                Console.Write(">> ");
            }
        }
    }
}