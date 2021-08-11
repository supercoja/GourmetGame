using System.Collections.Generic;

namespace GameGourmet
{
    internal class CommandFactory
    {
        readonly GameStore store;

        public CommandFactory(GameStore store)
        {
            this.store = store;
        }

        public ICommand Init()
        {
            return new InitCommand(store);
        }
        public ICommand Start()
        {
            return new StartCommand(store);
        }
      
        public ICommand SyntaxError()
        {
            return new SyntaxErrorCommand();
        }

        public ICommand UnknownCommand(string command)
        {
            return new UnknownCommand(command);
        }
        
        public ICommand Load()
        {
            return new LoadCommand(store);
        }

    }
}