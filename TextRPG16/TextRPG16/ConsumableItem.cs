﻿namespace TextRPG16
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

        List<ConsumableItem> _potions; // 포션 리스트

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
            while(true)
            {
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
                Console.WriteLine(">> ");

                int insert = InputCheck.Check(0, consumableItem._potions.Count);

                if (insert == 0)
                    break;


            }

        }

        // 포션 사용 함수
        public void UsePotion(User user, string _itemName)
        {
            // 어느 것이 적합한지 상의 할것

            var _itemUse = _potions.Find(_item => _item.ItemName.Equals(_itemName, StringComparison.OrdinalIgnoreCase));

            // 아이템의 존재여부 확인, 수량체크
            if (_itemUse != null && _itemUse.Quantity > 0)
            {
                if(ItemType == "HP")
                {
                    user.HP = user.HP / 100 * this.ItemEffectNum;
                }
                else if(ItemType == "MP")
                {
                    user.MP = user.MP / 100 * this.ItemEffectNum;
                }
            }
            else
            {
                Console.WriteLine($"{_itemUse.ItemName}을 가지고 있지 않습니다");
            }
            //기존의 코드는 밑에 주석

            //if (ItemType == "HP")
            //{
            //    user.HP = user.HP / 100 * this.ItemEffectNum;
            //}
            //else
            //{
            //    user.MP = user.MP / 100 * this.ItemEffectNum;
            //}
        }
    }
}


