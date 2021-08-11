﻿using System;

namespace GameGourmet
{
    class Program
    {
        

        static void Main(string[] args)
        {
            GameStore gameStore = new GameStore();
            var root = gameStore.StartGame();
            while (true)
            {
                Console.WriteLine("Pense em um prato que goste:");
                var answer = gameStore.GetAnswer("Digite qualquer tecla para continuar ou Q para encerrar");
                if (answer.Equals("Q"))
                {
                    break;
                }
                gameStore.LookUp(root);
                
            }
            //GameStore store = new  GameStore();
            //Repl repl = new Repl(Console.In, Console.Out, store);

            //repl.Run();
            Console.WriteLine("Programa encerrado!");
        }
    }
}