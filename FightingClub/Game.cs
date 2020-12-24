using System;
using FightingClub.Fighters;

namespace FightingClub
{
    class Game
    {
        private Random random;
        private FightState fightState;
        
        private Fighter player1;
        private Fighter player2;

        public Game()
        {
            random = new Random();
            fightState = FightState.NextRound;
        }

        public void startGame()
        {
            Console.Clear();
            Console.WriteLine("ИГРОК 1 СОЗДАЕТ БОЙЦА:");
            player1 = CreateFighter();
            Console.Clear();
            Console.WriteLine("ИГРОК 2 СОЗДАЕТ БОЙЦА:"); 
            player2  = CreateFighter();
            Console.Clear();
            startFight();
        }

        private Fighter CreateFighter()
        {
            Fighter fighter;
            int points = Constrants.pointsNumber;
            
            Console.WriteLine("Назовите своего бойца:");
            string name = Console.ReadLine();

            Console.WriteLine("\nВыберите класс героя:\n1: Воин\n2: Ловкач\n3: Маг");
            string fighterType = Console.ReadLine();
            
            switch (fighterType)
            {
                case "1":
                    fighter = new Warrior(name);
                    break;
                case "2":
                    fighter = new Dodger(name);
                    break;
                default:
                    fighter = new Mage(name);
                    break;
            }

            while (points > 0)
            {
                Console.Clear();
                fighter.getStats();
                Console.WriteLine("Распределите очки умений среди характеристик персонажа:");
                Console.WriteLine($"+1 Силы:      + {Constrants.damageMultiplier} к урону");
                Console.WriteLine($"+1 Ловкости:  + {Constrants.dodgeMultiplier} % увернуться от атаки");
                Console.WriteLine($"+1 Живучести: + {Constrants.hpMultiplier} HP");
                Console.WriteLine();
                Console.WriteLine($"Осталось очков умений {points}");
                Console.WriteLine("1: +1 Силы");
                Console.WriteLine("2: +1 Ловкости");
                Console.WriteLine("3: +1 Живучести");
                switch (Console.ReadLine())
                {
                    case "1":
                        fighter.Strangth += 1;
                        break;
                    case "2":
                        fighter.Agility += 1;
                        break;
                    default:
                        fighter.Vitality += 1;
                        break;
                }
                points -= 1;
            }

            fighter.IsDead += () => fightState = FightState.Stop;
            return fighter;
        }

        private void startFight()
        {
            for (int i = 3; i > 0; i -= 1)
            {
                Console.Clear();
                Console.WriteLine($"{i}...");
                Console.ReadLine();
            }

            int round = 1;
            while (fightState == FightState.NextRound)
            {
                Console.Clear();
                Console.WriteLine($"Раунд{round}");
                Console.WriteLine();
                CalulateKick(player1, player2);
                CalulateKick(player2, player1);
                Console.WriteLine();
                Console.WriteLine("Игрок 1");
                Console.WriteLine();
                player1.getStats();
                Console.WriteLine();
                Console.WriteLine("Игрок 2");
                Console.WriteLine();
                player2.getStats();
                
                Console.ReadLine();

                round += 1;
            }
            Console.WriteLine("БОЙ ЗАКОНЧЕН");
            Console.ReadLine();
        }

        private void CalulateKick(Fighter agressor, Fighter victim)
        {
            if (victim.ChanceToDodge > random.Next(1, 101))
            {
                Console.WriteLine($"{agressor.Name} хотел ударить, но противник увернулся от удара!");
            }
            else
            {
                victim.HP -= agressor.Kick();
                victim.HP -= agressor.useUltimateSkill();
            }
        }
    }
}
