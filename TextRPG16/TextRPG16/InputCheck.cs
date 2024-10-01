namespace TextRPG16
{
    static public class InputCheck
    {
        static public int Check(int start, int end)
        {
            int select = -1;
            while (true)
            {
                try
                {
                    select = int.Parse(Console.ReadLine()!);

                    if (select < start || select > end)
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        Console.Write(">> ");
                        continue;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.Write(">> ");
                    continue;
                }
                return select;
            }
        }
    }
}
