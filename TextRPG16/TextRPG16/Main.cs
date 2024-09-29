using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG16
{
    internal class TextRPG16
    {
        // test
        static void Main(string[] args)
        {

            User user = new Warrior();

            Console.WriteLine($"{user.UserClass}");
            //-----------------------------
            Stage stage = new Stage();
            stage.StartStage(user);
            
            


        }
    }
}
