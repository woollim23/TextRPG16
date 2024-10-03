using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG16
{
    // 스테이지 클리어 보상 클래스
    public class Reward
    {
        public Reward() { }
        public void ItemReward(User user, Item item)
        {
            Random random = new Random();

            // 아이템 목록 인덱스를 랜덤으로 가져옴
            int index = random.Next(0, 7);
            if(item.item[index].buy == true)
            {
                // 아이템이 이미 있으면 그 가격의 골드로 주기
                int gold = (int)(item.item[index].price);
                Console.WriteLine("{0} ->  {1} Gold", item.item[index].name, gold);
                ConsoleSize.Color(ConsoleColor.DarkGray);
                Console.WriteLine("이미 소지한 아이템이므로 골드로 치환합니다.");
                Console.ResetColor();

                user.Gold += gold;
            }
            else
            {
                item.item[index].buy = true;
                Console.WriteLine("{0} - 1", item.item[index].name);
            }

        }

        public int GoldReward(User user, Stage stage)
        {
            int gold = 200;

            gold += (int)(gold * (stage.StageLevel - 1 * 0.5));

            user.Gold += gold;

            return gold;
        }

        public void PotionReward(User user, ConsumableItem consumableItem)
        {
            Random random = new Random();
            // 포션 목록 인덱스를 랜덤으로 가져옴
            int index = random.Next(0, consumableItem._potions.Count);
            consumableItem._potions[index].Quantity++;
            Console.WriteLine("{0} - 1", consumableItem._potions[index].ItemName);
        }
    }
}
