using System.Collections.Generic;
using System.IO;

namespace GameGourmet
{
    

    internal class InitCommand : Command
    {
        public InitCommand(GameStore store)
            : base(Commands.Init, store)
        {
        }

        public override BSTNode<Plate> Execute()
        {
            return null;
            // return new List<Contact> { Store.Add(CommandArgParser.ContactFromArgs(Args)) };
        }

        public override string Notify()
        {
            return "Pense em um prato que gosta:";
        }
    }
    internal class StartCommand : Command
    {
        public StartCommand(GameStore store)
            : base(Commands.Start, store)
        {
        }
        public override string Notify()
        {
            return "Pense em um prato que gosta";
        }
        public override BSTNode<Plate> Execute()
        {
            return null;
            // return new List<Contact> { Store.Add(CommandArgParser.ContactFromArgs(Args)) };
        }
    }

   
    
    internal class LoadCommand : Command
    {
        public override string Notify()
        {
            return "Pense em um prato que gosta";
        }
        internal LoadCommand(GameStore store)
            : base(Commands.Load,  store)
        {
        }

        public override BSTNode<Plate> Execute()
        {
//            List<Contact> result = new List<Contact>(0);
            return null;
        }
    }
    
    internal class SyntaxErrorCommand : ICommand
    {
       
        public string Verb => Commands.Error;

        public IReadOnlyDictionary<string, string> Args => new Dictionary<string, string>(0);

        public BSTNode<Plate> Execute()
        {
            return null;
            //    return new List<Contact>(0);
        }

        public string Notify()
        {
            return "Pense em um prato que gosta";
        }
    }

    internal class UnknownCommand : ICommand
    {
        public string Verb => Commands.Error;

        public IReadOnlyDictionary<string, string> Args => new Dictionary<string, string>(0);

        private string Command { get; }

        public UnknownCommand(string command)
        {
            this.Command = command;
        }

        public BSTNode<Plate> Execute()
        {
            return null;
            Log.Error("Unknown command: {0}", this.Command);
//            return new List<Contact>(0);
        }
        
        public  string Notify()
        {
            return "Pense em um prato que gosta";
        }
    }


    internal class QuitCommand : ICommand
    {
        public string Verb => Commands.Quit;

        public IReadOnlyDictionary<string, string> Args => new Dictionary<string, string>(0);

        public BSTNode<Plate> Execute()
        {
            return null;
            //   return new List<Contact>(0);
        }
        public  string Notify()
        {
            return "Pense em um prato que gosta";
        }
    }
}