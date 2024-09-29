using System.Xml.Linq;

namespace TextRPG16
{
    class Battle
    {
        public void Attack(ICharacter attacker, ICharacter deffenser) // �����Ҷ�
        {
            Console.Clear();
            int tempMonsterHP = deffenser.HP;
            int num = (int)Math.Round(((double)attacker.AttackDamage / 100 * 10), 0); // ������

            Random random = new Random();
            int resultDamage = random.Next((int)attacker.AttackDamage - num, (int)attacker.AttackDamage + num);

            deffenser.TakeDamage(resultDamage);

            Console.WriteLine($"Battle!!");
            Console.WriteLine();
            Console.WriteLine($"{attacker.Name} �� ����!");
            Console.WriteLine($"Lv.{deffenser.Level} {deffenser.Name}��(��) ������ϴ�!. [������ : {resultDamage}]");
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
            Console.WriteLine("0. ����");
            Console.WriteLine();

            while (InputCheck.Check(0, 0) == 0)
            {
                Console.Write(">> ");
            }
        }
    }
}