using System;
using System.Runtime.CompilerServices;

namespace GameGourmet
{
    public class GameStore
    {
        public BSTNode<Plate> StartGame()
        {
            var root = new BSTNode<Plate>(new Plate("massa"));
            var nodeLeft = new BSTNode<Plate>(new Plate("Bolo de Chocolate"));
            var nodeRight = new BSTNode<Plate>(new Plate("lasanha"));

            root.UpdateLeftNode(nodeLeft);
            root.UpdateRightNode(nodeRight);
            nodeLeft.UpdateParentNode(root);
            nodeRight.UpdateParentNode(root);

            return root;
        }

        public int Count { get;  set; }
        
        public BSTNode<Plate> AddNewRoot(BSTNode<Plate> root, string message)
        {
            var newNode = GetNewPlate(message);
            return newNode;
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
                    Console.WriteLine("Nome Inválido. Informe um novo prato!");
                }
                else
                {
                    break;
                }
            }

            return new BSTNode<Plate>(new Plate(name));
        }

        public void LookUp(BSTNode<Plate> node)
        {
            if (node == null)
            {
                Console.Write("Falecimento");
                return;
            }
            if (node.HasChildrens())
            {
                this.LookUp(GetAnswer($"O prato que você escolheu é {node.Data}").Equals("S")
                    ? node.Right
                    : node.Left);
            }
            else
            {
                if (GetAnswer($"O prato que você escolheu é {node.Data}").Equals("S"))
                {
                    if (!node.HasChildrens())
                    {
                        Console.WriteLine("Acertei!");
                    }
                    else
                    {
                        Console.WriteLine("Aertei =- sem filhos!"); 
                    }
                }
                else
                {
                    var newChild = AddNewRoot(node, "Qual prato você pensou?:");
                    var lastChild = AddNewRoot(newChild, $"{newChild.Data} é __________ mas {node.Data} não.");

                    RebalanceTree(node, newChild, lastChild);
                }
            }
        }

        static void RebalanceTree(BSTNode<Plate> root, BSTNode<Plate> newChild, BSTNode<Plate> lastChild)
        {
            var nodeParent = root.Parent;
            if (nodeParent.Right == root)
            {
                nodeParent.UpdateRightNode(lastChild);
                root.UpdateParentNode(newChild);
                newChild.UpdateParentNode(lastChild);
                lastChild.UpdateParentNode(nodeParent);
                lastChild.UpdateRightNode(newChild);
                lastChild.UpdateLeftNode(root);
            }
            else if (nodeParent.Left == root)
            {
                nodeParent.UpdateLeftNode(lastChild);
                root.UpdateParentNode(newChild);
                newChild.UpdateParentNode(lastChild);
                lastChild.UpdateParentNode(nodeParent);
                lastChild.UpdateRightNode(newChild);
                lastChild.UpdateLeftNode(root);
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
            catch (Exception)
            {
                Console.WriteLine("Resposta Inválida!");
            }

            return answer;
        }
        
        // public int GetTreeDepth()
        // {
        //     return this.GetTreeDepth(this.Root);
        // }
        //
        // private int GetTreeDepth(Node parent)
        // {
        //     return parent == null ? 0 : Math.Max(GetTreeDepth(parent.LeftNode), GetTreeDepth(parent.RightNode)) + 1;
        // }

        public void TraVersal(BSTNode<Plate> parent)
        {
            if (parent != null)
            {
                Count++;
                Console.WriteLine($"Current node: {parent.Data}");
                TraVersal(parent.Left);
                TraVersal(parent.Right);
            }
        }
    }
}