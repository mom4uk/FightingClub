using System;
using System.Collections.Generic;
using System.Text;

namespace FightingClub.Fighters
{
    public class Warrior : Fighter
    {
        public Warrior(string name = "имя должен выбрать игрок") : base(
            name, 
            "Безжалостный воин",
            "Ярость = Боль делает воина только сильнее. После удара воин впадает в ярость и трижды бьет противника щитом. Урон каждого удара равен показателю силы.",
            5, 0, 5)
        {

        }

        public override int useUltimateSkill()
        {
            int totalDamage = Strangth * 3;
            Console.WriteLine($"{Name} впадает в ярость! Он трижды бьет щитом и наносит {totalDamage} урона");
            return totalDamage;
        }
    }
}
