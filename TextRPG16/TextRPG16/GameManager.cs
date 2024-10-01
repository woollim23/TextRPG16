namespace TextRPG16
{
    public class GameManager
    {
        // ���� ���
        public string filePath1 = "TextRPG_Reform_User";
        public string filePath2 = "TextRPG_Reform_Item";

        // �ε�â �޼ҵ�
        public void LodingScreen()
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("|                                    |");
            Console.WriteLine("|             Wellcome!!             |");
            Console.WriteLine("|          Sparta  TextRPG           |");
            Console.WriteLine("|                                    |");
            Console.WriteLine("--------------------------------------");

            Thread.Sleep(1200);
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
            user.InputName(Console.ReadLine());

            user.ChoiceUserClass(user);
        }

        public void GamePlay(User user, Item gameItem)
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine($"���ĸ�Ÿ ������ ���� {user.Name} �� ȯ���մϴ�.\n�̰����� �������� ���� �� Ȱ���� �� �� �ֽ��ϴ�.\n");
                Console.WriteLine("1. ���º���");
                Console.WriteLine("2. �κ��丮");
                Console.WriteLine("3. ����");
                Console.WriteLine("4. ����Ʈ");
                Console.WriteLine("5. Ÿ������");
                Console.WriteLine("6. ��������");
                Console.WriteLine("0. ����");
                Console.WriteLine();
                Console.WriteLine("���Ͻô� �ൿ�� �Է����ּ���.");
                Console.Write(">> ");

                int select = InputCheck.Check(0, 6);
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
                        break;
                    case 5:
                        // ��������
                        Stage stage = new Stage();
                        stage.StartStage(user, gameItem);
                        break;
                    case 6:
                        // ��������
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

            //string jsonData1 = JsonConvert.SerializeObject(user, Formatting.Indented);
            //File.WriteAllText(filePath1, jsonData1);

            //string jsonData2 = JsonConvert.SerializeObject(gameItem, Formatting.Indented);
            //File.WriteAllText(filePath2, jsonData2);

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