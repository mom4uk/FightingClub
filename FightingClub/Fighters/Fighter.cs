using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace FightingClub
{
    public abstract class Fighter
    {
        public delegate void IsDeadDelegate();

        public event IsDeadDelegate IsDead;
        
        private string fighterClass { get; set; }
        public string Name { get; set; }

        private int strangth;
        public int Strangth
        {
            get { return strangth; } set
            {
                strangth = value;
                Damage = strangth * Constrants.damageMultiplier;

            }
        }

        private int agility;
        public int Agility
        {
            get { return agility; }
            set
            {
                agility = value;
                ChanceToDodge = agility * Constrants.dodgeMultiplier;
            }
        }

        private int vitality;
        public int Vitality
        {
            get { return vitality; }
            set
            {
                vitality = value;
                hp = vitality * Constrants.hpMultiplier;
            }
        }

        public int Damage { get; set; }
        public int ChanceToDodge { get; set; }
        private int hp;

        public int HP
        {
            get { return hp; }
            set
            {
                hp = value;
                if (hp < 0)
                {
                    hp = 0;
                    IsDead();
                }
            }
        }

        private string skillDescription { get; set; }

        protected Fighter(string name, string fighterDesc, string description, int strangth, int agility, int vitality)
        {
            Name = name;
            Strangth = strangth;
            Agility = agility;
            Vitality = vitality;
            fighterClass = fighterDesc;
            skillDescription = description;
        }
        public string getStats()
        {
            Console.WriteLine($"Имя:{Name}\n" +
                        $"Класс: {fighterClass}\n" +
                        $"Сила: {strangth}\t\tЛовкость:{agility}\t\tЖивучесть:{vitality}\n" +
                        $"Урон: {Damage}\t\tШанс увернуться:{ChanceToDodge}\t\tHP:{HP}\n" +
                        $"{skillDescription}\n\n");
            return "d";
        }

        public int Kick()
        {
            var random = new Random();
            int totalDamage = random.Next(Damage - 10, Damage + 10);
            Console.WriteLine($"{Name} ударил и нанаес {totalDamage} урона!");
            return totalDamage;
        }

        public abstract int useUltimateSkill();
    }
}
