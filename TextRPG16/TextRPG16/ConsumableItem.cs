namespace TextRPG16
{        //소모성 아이템 클래스

    // 회복 시스템 구현


    public class ConsumableItem : IConsumableItem
    {

        public string ItemName { get; set; } // 아이템 이름
        public string ItemType { get; set; } // 아이템 종류
        public int ItemEffectNum { get; set; } // 아이템 효과 수치                                   
        public string ItemEffectInform { get; set; } // 아이템 효과 설명
        


        

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

        

        public void PotionList(User user)
        {
            List<ConsumableItem> _potions = new List<ConsumableItem>();

            _potions.Add(new ConsumableItem($"최하급 HP포션","배틀",(user.HP / 100) * 15,"견습 연금술사가 서툴게 만든 회복 물약입니다"));
           _potions.Add(new ConsumableItem($"최하급 MP포션","배틀",(user.MP / 100) * 15,"견습 연금술사가 서툴게 만든 마나 물약입니다"));
           _potions.Add(new ConsumableItem($"하급 HP포션","배틀", (user.HP / 100) * 25, "초급 연금술사가  절반이상 성공한 회복 물약입니다"));
           _potions.Add(new ConsumableItem($"하급 MP포션","배틀", (user.MP / 100) * 25, "초급 연금술사가  절반이상 성공한 마나 물약입니다"));
           _potions.Add(new ConsumableItem($"중급 HP포션","배틀", (user.HP / 100) * 50, "중급 연금술사가  완벽하게 성공한 회복 물약입니다"));
           _potions.Add(new ConsumableItem($"중급 MP포션","배틀", (user.MP / 100) * 50, "중급 연금술사가  완벽하게 성공한 마나 물약입니다"));
           _potions.Add(new ConsumableItem($"고급 HP포션","배틀", (user.HP / 100) * 70, "고급 연금술사가  드물게 성공한 완벽한 회복 물약입니다"));
           _potions.Add(new ConsumableItem($"고급 MP포션","배틀", (user.MP / 100) * 70, "고급 연금술사가 드물게 성공한 완벽한 마나 물약입니다"));

        }

       
        
        public void BattleItemList(User user)
        {
            List<ConsumableItem> _battleItem = new List<ConsumableItem>();
            _battleItem.Add(new ConsumableItem($"전사의 비약", "배틀", (user.AttackDamage / 100) * 15, "전투를 숭상하는 어느부족의 비법으로 조합된 비약이다 두려움을 없애준다"));
            _battleItem.Add(new ConsumableItem($"강철의 비약", "배틀", (user.FullHP / 100) * 25, "전투를 숭상하는 어느부족의 비법으로 조합된 비약이다 신체가 강건해진다"));

        }







       

    }
}

