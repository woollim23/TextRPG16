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

        public List<ConsumableItem> _potions = null!; // 포션 리스트

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
            _potions.Add(new ConsumableItem("하급 HP포션", "HP", 25, "초급 연금술사가  조금 성공한 회복 물약입니다", 3));
            _potions.Add(new ConsumableItem("하급 MP포션", "MP", 25, "초급 연금술사가  조금 성공한 마나 물약입니다", 3));
            _potions.Add(new ConsumableItem("중급 HP포션", "HP", 50, "초급 연금술사가  절반이상 성공한 회복 물약입니다", 1));
            _potions.Add(new ConsumableItem("중급 MP포션", "MP", 50, "초급 연금술사가  절반이상 성공한 마나 물약입니다", 1));
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
                for (int i = 0; i < _potions.Count; i++)
                { // 아이템 수량을 변수로 지정해서 값을 지정하게 하는거 추가
                  // 아래 코드 주석은 추후 팀원들과 상의하고 판단할것
                    if (_potions[i].Quantity > 0)
                    {
                        Console.WriteLine($"- {i + 1} {_potions[i].ItemName} | 아이템 효과:{_potions[i].ItemType} {_potions[i].ItemEffectNum}% | 수량: {_potions[i].Quantity} 개");
                    }
                    else
                    {
                        ConsoleSize.Color(ConsoleColor.DarkGray);
                        Console.WriteLine($"- {i + 1} {_potions[i].ItemName} | 아이템 효과:{_potions[i].ItemType} {_potions[i].ItemEffectNum}% | 수량: {_potions[i].Quantity} 개");
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
                Console.WriteLine("[내정보]");
                Console.WriteLine($"Lv. {user.Level} {user.Name} ({user.UserClass})");
                Console.WriteLine($"HP {user.HP}/{user.FullHP}");
                Console.WriteLine($"MP {user.MP}/{user.FullMP}");
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
                if (user.HP == user.FullHP)
                {
                    Console.WriteLine("회복할 체력이 없습니다.");
                }
                else
                {
                    healUp = (int)Math.Round((double)user.FullHP / 100 * _potions[index].ItemEffectNum);

                    //// 이프문으로 최대 체력 넘나 검사
                    if ((healUp + user.HP) > user.FullHP)
                    {
                        healUp -= ((healUp + user.HP) - user.FullHP);
                    }
                    Console.WriteLine("HP가 {0} 회복합니다.", healUp);

                    user.HP += healUp;
                    // 포션 갯수 줄이기
                    _potions[index].Quantity--;
                }
            }
            else if (_potions[index].ItemType == "MP")
            {
                if (user.MP == user.FullMP)
                {
                    Console.WriteLine("회복할 마나가 없습니다.");
                }
                else
                {
                    healUp = (int)Math.Round((double)user.FullMP / 100 * _potions[index].ItemEffectNum);

                    if ((healUp + user.MP) > user.FullMP)
                    {
                        healUp -= ((healUp + user.MP) - user.FullMP);
                    }

                    Console.WriteLine("MP가 {0} 회복합니다.", healUp);

                    user.MP += healUp;
                    // 포션 갯수 줄이기
                    _potions[index].Quantity--;
                }
            }

            Thread.Sleep(800);
        }
    }
}


