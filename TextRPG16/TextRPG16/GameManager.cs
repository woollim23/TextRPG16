using Newtonsoft.Json;

namespace TextRPG16
{
    public class GameManager
    {
        // ���� ���
        public string filePath1 = "TextRPG16_User";
        public string filePath2 = "TextRPG16_Item";
        public string filePath3 = "TextRPG16_ConItem";

        // �ε�â �޼ҵ�
        public void LodingScreen()
        {
            AsciiArt.SparklingEffect();
            Console.Clear();
        }

        // ����â �޼ҵ�
        public void StartScreen(User user)
        {
            // ------------------- ����â -------------------
            Console.WriteLine("[���� ����]");
            Console.WriteLine("Sparta TextRPG ������ ó�� �����մϴ�.");
            Console.WriteLine();
            // �г��� ����
            Console.WriteLine("ȯ���մϴ�. ���谡��!");
            Console.WriteLine("����Ͻ� �г����� �Է����ּ���.");
            Console.WriteLine();
            Console.Write(">> ");
            user.InputName(Console.ReadLine()!);

            user.ChoiceUserClass(user);
        }

        // ���� �÷��� ���� ���� â �޼ҵ�
        public void GamePlay(User user, Item gameItem, ConsumableItem consumableItem)
        {
            while (true)
            {
                Console.Clear();
                AsciiArt.DisplayHeadLine(0);
                Console.WriteLine($"���ĸ�Ÿ ������ ���� {user.Name} �� ȯ���մϴ�.\n�̰����� �������� ���� �� Ȱ���� �� �� �ֽ��ϴ�.\n");
                Console.WriteLine("1. ���º���");
                Console.WriteLine("2. �κ��丮");
                Console.WriteLine("3. ����");
                Console.WriteLine("4. ����Ʈ");
                Console.WriteLine("5. Ÿ������");
                Console.WriteLine("6. �޽��ϱ�");
                Console.WriteLine("7. ��������");
                Console.WriteLine("0. ����");
                Console.WriteLine();
                Console.WriteLine("���Ͻô� �ൿ�� �Է����ּ���.");
                Console.Write(">> ");

                int select = InputCheck.Check(0, 7);
                switch (select)
                {
                    case 0:
                        // ��������
                        GameSave(user, gameItem);
                        Console.WriteLine("--------------------------------------");
                        Console.WriteLine("|                                    |");
                        Console.WriteLine("|     �÷��� ���ּż� �����մϴ�!    |");
                        Console.WriteLine("|                                    |");
                        Console.WriteLine("--------------------------------------");
                        Environment.Exit(0);
                        break;
                    case 1:
                        // ����â
                        user.State(user, gameItem);
                        break;
                    case 2:
                        // �κ��丮
                        Inventory inventory = new Inventory();
                        inventory.SeeInventory(user, gameItem);
                        break;
                    case 3:
                        // �����̿�
                        Store store = new Store();
                        store.UseStore(user, gameItem);
                        break;
                    case 4:
                        // ����Ʈ
                        user.DisplayQuests();
                        break;
                    case 5:
                        // ��������
                        Stage stage = new Stage(user);
                        stage.StartStage(user, gameItem, consumableItem);
                        break;
                    case 6:
                        // �޽��ϱ�
                        Recovery recovery = new Recovery();
                        recovery.UseRest(user);
                        break;
                    case 7:
                        // ���� ����
                        GameSave(user, gameItem);
                        break;
                    default:
                        continue;
                }
            }
        }

        // ���� ������ ���� �޼ҵ�
        public void GameSave(User user, Item gameItem)
        {
            Console.Clear();

            string jsonData1 = JsonConvert.SerializeObject(user, Formatting.Indented);
            File.WriteAllText(filePath1, jsonData1);

            string jsonData2 = JsonConvert.SerializeObject(gameItem, Formatting.Indented);
            File.WriteAllText(filePath2, jsonData2);

            string jsonData3 = JsonConvert.SerializeObject(gameItem, Formatting.Indented);
            File.WriteAllText(filePath3, jsonData3);

            Console.WriteLine("--------------------------------------");
            Console.WriteLine("|                                    |");
            Console.WriteLine("|         �������� �Ϸ�!! ^0^/       |");
            Console.WriteLine("|                                    |");
            Console.WriteLine("--------------------------------------");
            Thread.Sleep(1000);
            Console.Clear();
        }
    }
}

