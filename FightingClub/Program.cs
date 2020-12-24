using System;
using FightingClub.Fighters;

namespace FightingClub
{
    class Program
    {
        static void Main()
        {
            PrintMenu();
        }

        static void PrintMenu()
        {
                Console.Clear();
                Console.WriteLine("ИГРА БОЙЦОВСКИЙ КЛУБ");
                Console.WriteLine("1 - Начать игру");
                Console.WriteLine("2 - Правила");
                Console.WriteLine("3 - Выход");
                string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Game game = new Game();
                    game.startGame();
                    break;
                case "2":
                    printRules();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine($"Error in printMenu option =  {option}");
                    break;
            }
            PrintMenu();
        }
         static void printRules()
        {
            Console.Clear();
            Console.WriteLine("У каждого бойца есть три зарактеристики - сила, ловкость и выносливость. \n" +
                              "Сила влияет на наносимый урон, ловкость влияет на шанс увернуться от удара противника, выносливость влияет на количество здоровья. \n" +
                              "Такжу у каждого бойца есть особое умение, которое он использует в бою." +
                              string.Format($"Перед началом боя игроки выбирают себе бойцов и распределяют {Constrants.pointsNumber} очков умений. ") +
                              string.Format($"+1 силы = +{Constrants.damageMultiplier} урона, +1 ловкости = + {Constrants.dodgeMultiplier}% увернуться от удара, +1 живучести = + {Constrants.hpMultiplier} HP.") +
                              "Бой состоит из раундов. В каждом раунде бойцы наносят друг другу прямые повреждения и один раз используют ультимативную способность" +
                              "Количество раундов зависит от очков жизней бойцов. Как только у кого-нибудь из бойцов заканчиваются жизни бой заканчивается.");
            new Warrior().getStats();
            new Dodger().getStats();
            new Mage().getStats();
            Console.ReadLine();
        }
    }
}
