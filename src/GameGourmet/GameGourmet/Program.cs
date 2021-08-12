using System;

namespace GameGourmet
{
    class Program
    {
        static void Main(string[] args)
        {
            GameStore gameStore = new GameStore();
            var root = gameStore.StartGame();
Console.WriteLine("Begin:");
gameStore.Count = 0;
            gameStore.TraVersal(root);
            while (true)
            {
                
                Console.WriteLine("Pense em um prato que goste:");
                var answer = gameStore.GetAnswer("Digite qualquer tecla para continuar ou Q para encerrar");
                if (answer.Equals("Q"))
                {
                    break;
                }
                gameStore.LookUp(root);
                gameStore.Count = 0;
                gameStore.TraVersal(root);
                Console.WriteLine($"Quantos membros: {gameStore.Count}");
            }
            Console.WriteLine("Programa encerrado!");
        }
    }
}