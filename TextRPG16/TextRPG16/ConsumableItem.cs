namespace TextRPG16
{
    //소모성 아이템 클래스
    // 회복 시스템 구현
    public class ConsumableItem : IConsumableItem
    {
        public string ItemName { get; set; } // 아이템 이름
        public string ItemType { get; set; } // 아이템 종류
        public int ItemEffectNum { get; set; } // 아이템 효과 수치                                   
        public string ItemEffectInform { get; set; } // 아이템 효과 설명
        public int Quantity { get; set; } // 소모성 아이템 수량

        List<ConsumableItem> _potions = null!; // 포션 리스트

        // 기본 생성자
        public ConsumableItem()
        {
            ItemName = "void";
            ItemType = "void";
            ItemEffectNum = 0;
            ItemEffectInform = "void";
            Quantity = 0;
        }

        // 값 대입 생성자
        public ConsumableItem(string _itemName, string _itemType, int _itemEffectNum, string _itemEffectInform, int _qnantity)
        {
            ItemName = _itemName;
            ItemType = _itemType;
            ItemEffectNum = _itemEffectNum;
            ItemEffectInform = _itemEffectInform;
            Quantity = _qnantity;
        }

        public void AddPotionList()
        {
            _potions = new List<ConsumableItem>();
            _potions.Add(new ConsumableItem($"하급 HP포션", "HP", 25, "초급 연금술사가  조금 성공한 회복 물약입니다", 1));
            _potions.Add(new ConsumableItem($"하급 MP포션", "MP", 25, "초급 연금술사가  조금 성공한 마나 물약입니다", 1));
            _potions.Add(new ConsumableItem($"중급 HP포션", "HP", 50, "초급 연금술사가  절반이상 성공한 회복 물약입니다", 1));
        }

        // 소유 포션 리스트 창 & 회복포션 창
        public void UsePotionList(User user, ConsumableItem consumableItem)
        {
            bool exit = false;
            do
            {
                Console.Clear();
                Console.WriteLine("회복");
                Console.WriteLine("포션을 사용하면 HP 또는 MP를 회복 할 수 있습니다.");
                Console.WriteLine();
                Console.WriteLine("[포션목록]");
                Console.WriteLine();
                foreach (var items in _potions)
                {                                       // 아이템 수량을 변수로 지정해서 값을 지정하게 하는거 추가
                    int count = 0;                      // 아래 코드 주석은 추후 팀원들과 상의하고 판단할것
                    if (items.Quantity > 0)
                    {
                        count++;
                        Console.WriteLine($"- {count} {items.ItemName} | 아이템 효과:{items.ItemType} {items.ItemEffectNum}% | 수량: {items.Quantity} 개");
                    }
                }
                Console.WriteLine();
                Console.WriteLine("[현재 체력] : {0} / {1}", user.HP, user.FullHP);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("0. 취소");
                Console.WriteLine();
                Console.WriteLine("원하시는 포션을 선택하여 사용하세요.");
                Console.Write(">> ");

                int insert = InputCheck.Check(0, consumableItem._potions.Count);

                if (insert == 0)
                {
                    exit = true;
                }
                else
                {
                    if (_potions[insert - 1].Quantity < 1)
                    {
                        Console.WriteLine("수량이 없습니다. 다른 포션을 선택하세요.");
                        Thread.Sleep(800);
                    }
                    else
                    {
                        UsePotion(user, _potions, insert - 1);
                    }
                }
            } while (!exit);

        }

        // 포션 사용 함수
        public void UsePotion(User user, List<ConsumableItem> _potions, int index)
        {
            int healUp = 0;
            if (_potions[index].ItemType == "HP")
            {
                healUp  = (int)Math.Round((double)user.HP / 100 * this.ItemEffectNum);

                // 이프문으로 최대 체력 넘나 검사
                if ((healUp + user.HP) > user.FullHP)
                {
                    healUp = user.FullHP - (healUp + user.HP);
                }

                Console.WriteLine($"HP가 {0} 회복합니다.", healUp);

                user.HP += healUp;
            }
            else if (ItemType == "MP")
            {
                healUp  = (int)Math.Round((double)user.MP / 100 * this.ItemEffectNum);

                if ((healUp + user.MP) > user.FullMP)
                {
                    healUp = user.FullMP - (healUp + user.MP);
                }

                Console.WriteLine($"MP가 {0} 회복합니다.", healUp);

                user.MP += healUp;
            }
            Thread.Sleep(800);
        }
    }
}


