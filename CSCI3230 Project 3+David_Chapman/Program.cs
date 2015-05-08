using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI3230_Project_3_David_Chapman
{
    class Program
    {
        static void Main(string[] args)
        {
            //The Binary Tree structure
            BinaryTree BST = new BinaryTree();
            //Random number generator
            Random rand = new Random();
            //Array to hold the random numbers
            int[] myArray = new int[15];
            //Add random numbers to the array
            for (int i = 0; i < myArray.Length; i++) myArray[i] = rand.Next(1,100);
            //target is the number to be deleted from the tree
            int target = myArray[7];
            Console.WriteLine("First, we start with an array of random numbers:");
            //Print out the array
            for (int i = 0; i < myArray.Length; i++) Console.Write(myArray[i] + " ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Now, we will add the integers to the BST:");
            //Add each array item to the Binary Tree
            for (int i = 0; i < myArray.Length; i++) BST.addElement(myArray[i]);
            Console.WriteLine("The Inorder Traversal:");
            //Inorder traversal
            BST.inOrder(BST.ReturnRoot());
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("The Preorder Traversal:");
            //Preorder Traversal
            BST.preOrder(BST.ReturnRoot());
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("The Postorder Traversal:");
            //Postorder Traversal
            BST.postOrder(BST.ReturnRoot());
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Now we will remove " + target + " from the BST.");
            Console.WriteLine();
            //Remove target from the Binary Tree
            BST.removeElement(target);
            Console.WriteLine("The Inorder Traversal:");
            //Inorder traversal
            BST.inOrder(BST.ReturnRoot());
            Console.WriteLine();
            Console.WriteLine();
            //findMin
            Console.WriteLine("The minimum element is " + BST.findMin().num);
            Console.WriteLine();
            //findMax
            Console.WriteLine("The maximum element is " + BST.FindMax().num);
            Console.WriteLine();
            Console.WriteLine("Now we will remove the minimum element: ");
            Console.WriteLine();
            //removeMin
            BST.removeMin();
            Console.WriteLine();
            Console.WriteLine("The Inorder Traversal:");
            //Inorder Traversal
            BST.inOrder(BST.ReturnRoot());
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Now we will remove the maximum element: ");
            Console.WriteLine();
            //removeMax
            BST.removeMax();
            Console.WriteLine();
            Console.WriteLine("The Inorder Traversal:");
            //Inorder Traversal
            BST.inOrder(BST.ReturnRoot());
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("************************** Heap Implementation **************************");
            //Implementation of the Heap
            Heap myHeap = new Heap();
            Console.WriteLine("Now we will build a Heap from the array");
            //Ad elements from the array to the heap
            for (int i = 0; i < myArray.Length; i++) myHeap.addElement(myArray[i]);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Now, we will find the minimum value:");
            Console.WriteLine();
            //findMin
            Console.WriteLine("The minimum value is " + myHeap.findMin());
            Console.WriteLine();
            //findMax
            Console.WriteLine("Now, we will use heapSort to print out the integers in order:");
            Console.WriteLine();
            //heapSort removes minimum value from the list until the list is empty
            myHeap.heapSort();
            Console.WriteLine();
            Console.ReadLine();
        }
    }
    //Binary Tree Nodes
    public class Node
    {
        public int num;
        public Node leftChild;
        public Node rightChild;
    }
    public class BinaryTree
    {
        public Node root;
        //Binary Tree constructor
        public BinaryTree()
        {
            root = null;
        }
        //Return the root node of the tree
        public Node ReturnRoot()
        {
            return root;
        }
        //Adds elements to the tree
        public void addElement(int n)
        {
            Node newNode = new Node();
            newNode.num = n;
            //If the tree is empty
            if (root == null) root = newNode;
            else
            {
                //current will keep track of where we are in the tree
                Node current = root;
                //parent keeps track of currents parent node
                Node parent;
                while (true)
                {
                    parent = current;
                    //If the element is less than current, move left
                    if (n < current.num)
                    {
                        current = current.leftChild;
                        if (current == null)
                        {
                            parent.leftChild = newNode;
                            return;
                        }
                    }
                    //If the element is greater than current, move right
                    else
                    {
                        current = current.rightChild;
                        if (current == null)
                        {
                            parent.rightChild = newNode;
                            return;
                        }
                    }
                }
            }
        }
        //Tree traversals
        public void inOrder(Node Root)
        {
            if (Root != null)
            {
                inOrder(Root.leftChild);
                Console.Write(Root.num + " ");
                inOrder(Root.rightChild);
            }
            
        }
        public void preOrder(Node Root)
        {
            if (Root != null)
            {
                Console.Write(Root.num + " ");
                preOrder(Root.leftChild);
                preOrder(Root.rightChild);
            }
        }
        public void postOrder(Node Root)
        {
            if (Root != null)
            {
                postOrder(Root.leftChild);
                postOrder(Root.rightChild);
                Console.Write(Root.num + " ");
            }
        }
        //Remove element searches for and removes an element from the tree, maintaining the structure
        public void removeElement(int n)
        {
            Node current = root;
            //Target will be used to identify the node to be deleted
            Node target;
            Node parent = root;
            //lefRight will keep track of what side of the parent we are on
            string leftRight = "left";
            while (true)
            {
                //parent = current;
                //If element is greater than current, move right
                if (n > current.num)
                {
                    parent = current;
                    current = current.rightChild;
                    leftRight = "right";
                }
                //If element is less than current, move left
                else if (n < current.num)
                {
                    parent = current;
                    current = current.leftChild;
                    leftRight = "left";
                }
                //If the current is the node to be deleted
                else if (n == current.num)
                {
                    target = current;
                    //If the node is a leaf with no children
                    if (target.leftChild == null && target.rightChild == null)
                    {

                        if (leftRight == "left")
                        {
                            parent.leftChild = null;
                        }
                        else
                        {
                            parent.rightChild = null;
                        }
                        target = null;
                        return;
                    }
                    //If target node has no left child but has a left child
                    else if (target.leftChild == null && target.rightChild != null)
                    {
                        if (leftRight == "left")
                        {
                            parent.leftChild = target.rightChild;
                            target = null;
                        }
                        else
                        {
                            parent.rightChild = target.rightChild;
                            target = null;
                        }
                        return;
                    }
                    //If the target node has no right child but has a left child
                    else if (target.rightChild == null && target.leftChild != null)
                    {
                        if (leftRight == "left")
                        {
                            parent.leftChild = target.leftChild;
                            target = null;
                        }
                        else
                        {
                            parent.rightChild = target.leftChild;
                            target = null;
                        }
                        return;
                    }
                    //If the node to be deleted has both left and right children
                    else if (target.leftChild != null && target.rightChild != null)
                    {
                        current = target.leftChild;
                        leftRight = "left";
                        while (current.rightChild != null)
                        {
                            parent = current;
                            current = current.rightChild;
                            leftRight = "right";
                        }
                        target.num = current.num;
                        current = null;
                        if (leftRight == "left")
                        {
                            parent.leftChild = null;
                        }
                        else
                        {
                            parent.rightChild = null;
                        }
                        return;
                    }
                    else Console.WriteLine("Exception!  You have a problem with your program!!!");
                }
            }
                
        }
        //Return the minimum Node
        public Node findMin()
        {
            Node current;
            Node parent;
            if (root != null)
            {
                current = root;
                while (current.leftChild != null)
                {
                    parent = current;
                    current = current.leftChild;
                }
                return current;
            }
            else return root;
        }
        //Return the maximum Node
        public Node FindMax()
        {
            Node current;
            if (root != null)
            {
                current = root;
                while (current.rightChild != null)
                {
                    current = current.rightChild;
                }
                return current;
            }
            else return root;
        }
        //Remove the minimum element
        public void removeMin()
        {
            Node current;
            Node parent;
            if (root != null)
            {
                current = root;
                parent = current;
                while (current.leftChild != null)
                {
                    parent = current;
                    current = current.leftChild;
                }
                //Fix if current has a right child
                if (current.rightChild != null)
                {
                    parent.leftChild = current.rightChild;
                    current = null;
                }
                else 
                {
                    parent.leftChild = null;
                    current = null;
                }
                

            }

        }
        //Remove the maximum element
        public void removeMax()
        {
            Node current;
            Node parent;
            if (root != null)
            {
                current = root;
                parent = current;
                while (current.rightChild != null)
                {
                    parent = current;
                    current = current.rightChild;
                }
                //Fix for if current has a left child
                if (current.leftChild != null)
                {
                    parent.rightChild = current.leftChild;
                    current = null;
                }
                else
                {
                    parent.rightChild = null;
                    current = null;
                }
                

            }
        }
    }//End Binary Tree class


    public class Heap
    {
        //The list that will hold the heap
        public List<int> list = new List<int>();
        //Adds elements to the heap
        public void addElement(int n)
        {
            list.Add(n);
            int i = list.Count - 1;
            while (i > 0)
            {
                int j = (i + 1) / 2 - 1;
                int k = list[j];
                if (k.CompareTo(list[i]) < 0 || k.CompareTo(list[i]) == 0)
                {
                    break;
                }
                //Swap the values
                int temp = list[i];
                list[i] = list[j];
                list[j] = temp;

                i = j;
            }
            
        }
        public void heapifyAdd(int n)
        {
            //The minimum value
            int smallest;
            //Left child
            int l = 2 * (n + 1) - 1;
            //Right child
            int r = 2 * (n + 1) - 1 + 1;
            //If left child is smallest
            if (l < list.Count && (list[l].CompareTo(list[n]) < 0)) smallest = l;
            else smallest = n;
            //If right child is smallest
            if (r < list.Count && (list[r].CompareTo(list[smallest]) < 0)) smallest = r;
            //If n is not smallest
            if (smallest != n)
            {
                //Swap
                int temp = list[n];
                list[n] = list[smallest];
                list[smallest] = temp;
                this.heapifyAdd(smallest);
            }
        }
        //Returns the minimum value or root of the heap
        public int findMin()
        {
            return list[0];
        }
        //Remove the minimum value and reorder the list
        public void removeMin()
        {
            if (list.Count <= 0) return;
            int min = list[0];
            list[0] = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            heapifyAdd(0);
        }
        //Run removeMin until list is empty.  Thuis prints the numbers in order
        public void heapSort()
        {
            while (list.Count > 0)
            {
                Console.Write(list[0] + " ");
                removeMin();
            }
        }
    }
    
}
