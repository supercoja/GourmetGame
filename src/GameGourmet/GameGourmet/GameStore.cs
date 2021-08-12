using System;

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

        private BSTNode<Plate> AddNewRoot(BSTNode<Plate> root, string message)
        {
            var newNode = GetNewPlate(message);
            return newNode;
        }

        private static BSTNode<Plate> GetNewPlate(string message)
        {
            Console.WriteLine(message);
            string name;
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
            string answer;
            while (true)
            {
                Console.Clear();
                answer = GetAnswer($"O prato que você escolheu é {node.Data} ?");
                if ((!answer.Contains("S") && !answer.Contains("N")) || answer.Equals("ENTER"))
                {
                    Console.WriteLine("Resposta Inválida! Digite S para Sim ou N para Não.");
                }
                else
                {
                    break;
                }
            }
            if (node.HasChildrens())
            {
                this.LookUp(answer.Equals("S")
                    ? node.Right
                    : node.Left);
            }
            else
            {
                if (answer.Equals("S"))
                {
                    if (!node.HasChildrens())
                    {
                        Console.WriteLine("Acertei!");
                        Console.WriteLine();
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
            else if (nodeParent.Right == null)
            {
                var newParent = nodeParent.Parent;
                newParent.UpdateLeftNode(lastChild);
                root.UpdateParentNode(newChild);
                newChild.UpdateParentNode(lastChild);
                lastChild.UpdateParentNode(newParent);
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
            else if (nodeParent.Left == null)
            {
                var newParent = nodeParent.Parent;
                newParent.UpdateLeftNode(lastChild);
                root.UpdateParentNode(newChild);
                newChild.UpdateParentNode(lastChild);
                lastChild.UpdateParentNode(newParent);
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
                Console.WriteLine("");
                Console.WriteLine("");
            }
            catch (Exception)
            {
                Console.WriteLine("Resposta Inválida!");
            }

            return answer;
        }
    }
}