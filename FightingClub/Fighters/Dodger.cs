using System;
using System.Collections.Generic;
using System.Text;

namespace FightingClub.Fighters
{
    public class Dodger : Fighter
    {
        public Dodger(string name = "имя должен выбрать игрок") : base(
            name,
            "Изворотливый ловкач",
            "Ловкость рук - Есть 25% шанс запутать противника и незаметно ударить второй рукой. Такой удар считается критическим попаданием (х3)",
            3, 4, 3)
        {

        }

        public override int useUltimateSkill()
        {
            var random = new Random();
            int chance = random.Next(1, 101);
            if (chance <= 25)
            {
                int totalDamage = Damage * 3;
                Console.WriteLine($"{Name} изловчился и ударил второй рукой! Этот удар оказался критическим и нанес {totalDamage} урона");
                return totalDamage;
            }
            return 0;
        }
    }
}
