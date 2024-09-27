namespace TextRPG16
{        //소모성 아이템 클래스

    // 회복 시스템 구현


    public class ConsumableItem : IConsumableItem
    {

        public string ItemName { get; set; } // 아이템 이름
        public string ItemType { get; set; } // 아이템 종류
        public int ItemEffectNum { get; set; } // 아이템 효과 수치                                   
        public string ItemEffectInform { get; set; } // 아이템 효과 설명
        public int Stack { get; set; } // 소모성 아이템 수량





        public ConsumableItem()
        {
            ItemName = "void";
            ItemType = "void";

            ItemEffectNum = 0;
            ItemEffectInform = "void";


        }

        public ConsumableItem(string _itemName, string _itemType, int _itemEffectNum, string _itemEffectInform)
        {
            ItemName = _itemName;
            ItemType = _itemType;

            ItemEffectNum = _itemEffectNum;
            ItemEffectInform = _itemEffectInform;

        }

        List<ConsumableItem> _potions = new List<ConsumableItem>();

        public void PotionList(User user)
        {


            _potions.Add(new ConsumableItem($"하급 HP포션", "HP", 25, "초급 연금술사가  절반이상 성공한 회복 물약입니다"));
            _potions.Add(new ConsumableItem($"하급 MP포션", "MP", 25, "초급 연금술사가  절반이상 성공한 마나 물약입니다"));
            // 포션수치 곱하기

            var stackCounts = _potions.GroupBy(item => item)
                .Select(group => new { Item = group.Key, Count = group.Count() });

            foreach (var item in stackCounts)
            {
                Console.WriteLine($"potion: {item.Item},count:{item.Count}");


                //foreach (ConsumableItem item in _potions)
                //{
                //    int count = 0;
                //    if (item.Stack > 0)
                //    {
                //        count++;
                //        item.Stack = count;
                //        Console.WriteLine($"{count}{item.ItemName}: 보유 개수: {item.Stack} 회복량: {item.ItemType}{item.ItemEffectNum}%");
                //    }
                //}
            }

        }



            public void PotionDrinking(User user)
            {
                if (ItemType == "HP")
                {
                    user.HP = user.HP / 100 * this.ItemEffectNum;
                }
                else
                {
                    user.MP = user.MP / 100 * this.ItemEffectNum;
                }
            }
            



               


            








        
    }
}


