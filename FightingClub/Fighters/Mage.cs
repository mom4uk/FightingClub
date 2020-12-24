using System;
using System.Collections.Generic;
using System.Text;

namespace FightingClub.Fighters
{
    public class Mage : Fighter
    {
        public Mage(string name = "имя должен выбрать игрок") : base(
            name,
            "Могущественный маг",
            "Концентрация - Ничто не способно вывести мага из равновесия. Маг на секунду концентрируется и пускает в противника огненный шар на 1-60 урона.",
            2, 3, 5)
        {
        }
        public override int useUltimateSkill()
        {
            var random = new Random();
            int totalDamage = random.Next(1, 61);
            Console.WriteLine($"{Name} на секунду концентрируется и пускает в противника огненный шар на {totalDamage} урона");
            return totalDamage;
        }
    }
}
