using System;

namespace GameGourmet
{
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


        public BSTNode<Plate> AddNewRoot(BSTNode<Plate> root, string message)
        {
            var newNode = GetNewPlate(message);
            if (newNode != null)
            {
                var previousNode = root.Parent;
                root.UpdateParentNode(newNode);
                if (previousNode != null)
                {
                    if (previousNode.Left == root)
                    {
                        previousNode.UpdateLeftNode(newNode);
                    }
                    else
                    {
                        previousNode.UpdateRightNode(newNode);
                    }
                }
                var childNode = GetNewPlate($"{newNode.Data} é __________ mas {root.Data} não.");
                if (childNode != null)
                {
                    var parentFirstNode = newNode.Parent;
                    newNode.UpdateParentNode(childNode);
                    if (parentFirstNode != null)
                    {
                        if (parentFirstNode.Left == newNode)
                        {
                            parentFirstNode.UpdateLeftNode(childNode);
                        }
                        else
                        {
                            parentFirstNode.UpdateRightNode(childNode);
                        }
                    }
                }

            }


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
                    Console.WriteLine("Informe um novo prato");
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
                }
                else
                {
                    var nodeParent = AddNewRoot(node, "Qual prato você pensou?:");
                  //  var lastChild = AddNewRoot(nodeParent, $"{nodeParent.Data} é __________ mas {node.Data} não.");
//                    node.Data;
                    //                       lastChild.UpdateParentNode(nodeParent);
                    // if (nodeParent.Left == null)
                    //     nodeParent.UpdateLeftNode(lastChild);
                   
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

        public void TraVersal(BSTNode<Plate> parent)
        {
            if (parent != null)
            {
                Console.WriteLine($"Current node: {parent.Data}");
                TraVersal(parent.Left);
                TraVersal(parent.Right);
            }
        }
    }
}