using System;

namespace GameGourmet
{

    public class Response
    {
        public string Result { get; private set; }
        public bool  Success { get; private set; }

        public Response(string result, bool success)
        {
            Result = result;
            Success = success;
        }
    }
    
    
    
    public class GameStore
    {
        public BSTNode<Plate> StartGame()
        {
            var root = new BSTNode<Plate>(new Plate("masssa"));
            var nodeLeft = new BSTNode<Plate>(new Plate("Bolo de Chocolate"));
            var nodeRight = new BSTNode<Plate>(new Plate("lasanha"));
            
            root.UpdateLeftNode(nodeLeft);
            root.UpdateRightNode(nodeRight);
            nodeLeft.UpdateParentNode(root);
            nodeRight.UpdateParentNode(root);

            return root;
        }
        
        
        public static void AddNewRoot(BSTNode<Plate> root)
        {
            var newNode = GetNewPlate("Qual prato você pensou?:");
            if (newNode != null)
            {
                var previousNode = root.Parent;
                root.UpdateParentNode(newNode);
                if (previousNode.Left == root)
                {
                    previousNode.UpdateLeftNode(newNode);
                }
                else
                {
                    previousNode.UpdateRightNode(newNode);
                }

//                if (newNode != null)
  //              {
                  var nodeChildren = GetNewPlate($"{newNode.Data} é __________ mas {root.Data} não.");
                  
    //            }
            }
        }
        
        public static BSTNode<Plate> GetNewPlate(string message)
        {
            Console.WriteLine(message);
            var name = string.Empty;
            while (true)
            {
                name = Console.ReadLine();
                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Informe um novo prato");
                }
                else
                {
                    break;
                }
            }

            return new BSTNode<Plate>(new Plate(name));
        }
        
        public void LookUp (BSTNode<Plate> node)
        {   
            if (node.HasChildrens())
            {
                this.LookUp(GetAnswer($"O prato que você escolheu é {node.Data}").Equals("S") ? node.Right : node.Left );
            }
            else
            {
                if (GetAnswer($"O prato que você escolheu é {node.Data}").Equals("S"))
                {
                    if (!node.HasChildrens())
                    {
                        Console.WriteLine("Acertei!");
                    }
                }
                else
                {
                    AddNewRoot(node);
                    
                }
            }
        }
        
        public string GetAnswer(string message)
        {
            var answer = string.Empty;
            Console.WriteLine(message);
            try
            {
                answer = Console.ReadKey().Key.ToString().ToUpper();
            }
            catch (Exception e)
            {
                Console.WriteLine("Resposta Inválida!");
            }

            return answer;
        }
    }
}