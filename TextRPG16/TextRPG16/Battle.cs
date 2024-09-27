namespace TextRPG16
{
    class Battle
    {
        List<Slime> slimes = null!;
        List<Leejinho> leejinhoes = null!;
        List<Dragon> dragons = null!;

        Random random  = new Random();
        public Battle(int playerLevel)
        {
            int dragonLevel = random.Next(playerLevel, playerLevel + 2);
            if(random.Next(0, 100) < 20)
            {
                dragons.Add(new Dragon(dragonLevel));
            }

            int jinhoLevel = random.Next(playerLevel, playerLevel + 3);
            if (random.Next(0, 100) < 50)
            {
                leejinhoes.Add(new Leejinho(jinhoLevel));
            }

            int mobCnt = 0;
            int slimeLevel = random.Next(playerLevel, playerLevel + 5);
            foreach (Dragon dragon in dragons)
            {
                mobCnt++;
            }
            foreach(Leejinho leejinho in leejinhoes)
            {
                mobCnt++;
            }

            for(int i = 0; i < 3-mobCnt; i++)
            {
                slimes.Add(new Slime(slimeLevel));
            }


        }

    }
}