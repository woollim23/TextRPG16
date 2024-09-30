using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG16
{
    static class Constants
    {
        public const int MAX = 1000000;
    }

    internal class TextRPG16
    {
        // test
        static void Main(string[] args)
        {

            User user = new Warrior();

            //-----------------------------
            List<Quest> quests = new List<Quest>();
            quests.Add(new Quest(2, "마을을 위협하는 미니언 처치", "이봐! 마을 근처에 미니언들이 너무 많아졌다고 생각하지 않나?\r\n마을주민들의 안전을 위해서라도 저것들 수를 좀 줄여야 한다고!\r\n모험가인 자네가 좀 처치해주게!", 300, null!));
            quests.Add(new Quest(1, "장비를 장착해보자!", "무기 또는 방어구 장비 1개 이상 장착하여 공격력과 방어력을 상승시켜보자!", 100, null!));
            quests.Add(new Quest(0, "더욱 더 강해지기!", "전투력을 증가시키기 위해 레벨업을 달성해보자!", 200, null!));

            //-----------------------------
            Stage stage = new Stage();
            stage.StartStage(user);
            
            


        }
    }
}
