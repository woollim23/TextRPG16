namespace TextRPG16
{        //소모성 아이템 클래스

    // 회복 시스템 구현


    public class ConsumableItem : IConsumableItem
    {

        public string ItemName { get; set; } // 아이템 이름
        public string ItemType { get; set; } // 아이템 종류
        public string ItemEffect { get; set; } // 아이템 효과
        public int ItemEffectNum { get; set; } // 아이템 효과 수치                                   
        public string ItemEffectInform { get; set; } // 아이템 효과 설명
        public int Stack {  get; set; } // 소모품 아이템 수량
        

        public ConsumableItem()
        {
            ItemName = "void";
            ItemType = "void";
            ItemEffect = "void";
            ItemEffectNum = 0;
            ItemEffectInform = "void";
            Stack = Stack = 0;
           
        }

        public ConsumableItem(string _itemName, string _itemType, string _itemEffect, int _itemEffectNum, string _itemEffectInform)
        {
            ItemName = _itemName;
            ItemType = _itemType;
            ItemEffect = _itemEffect;
            ItemEffectNum = _itemEffectNum;
            ItemEffectInform = _itemEffectInform;
            
        }

        List<ConsumableItem> potions = new List<ConsumableItem>();

        public void PotionList(User user)
        {
            
            potions.Add(new ConsumableItem($"하급HP포션", "HP", "HP 회복", (user.HP * 25) + user.HP, "견습 연금술사가 몸에 좋은 붉은 약초를 달여 만든 포션입니다"));
            potions.Add(new ConsumableItem($"하급MP포션", "MP", "MP 회복", (user.MP * 25) + user.MP, "견습 연금술사가 몸에 좋은 푸른 약초를 달여 만든 포션입니다"));



        }
        /*
        // 포션 먹는 건 캐릭터 클래스에서 
        public void PotionDrinking(User user)
        {
            if (ItemType == "HP")
            {
                user.HP += (user.HP / 100) * 25;
            }
            else if(ItemType == "MP")
            {

            }

        }*/

    }
}

