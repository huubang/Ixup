using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ixup.Business
{
    /// <summary>
    /// Represents a singly linked list.
    /// </summary>
    public class SinglyLinkedList
    {
        /// <summary>
        /// Gets the head of the singly linked list.
        /// </summary>
        public SinglyLinkedListNode Head { get; private set; }

        /// <summary>
        /// Initializes a new instance of the SinglyLinkedList which is empty.
        /// </summary>
        public SinglyLinkedList()
        {
            // Do nothing
        }

        /// <summary>
        /// Initializes a new instance of the SinglyLinkedList with only the head.
        /// </summary>
        /// <param name="headValue">Value of the head.</param>
        public SinglyLinkedList(int headValue)
        {
            Insert(headValue);
        }

        /// <summary>
        /// Indicates whether the linked list is empty.
        /// </summary>
        /// <returns>True if the list is empty and false otherwise.</returns>
        public bool IsEmpty()
        {
            return Head == null;
        }

        /// <summary>
        /// Inserts a new node before the head.
        /// </summary>
        /// <param name="newValue">Value of the new node.</param>
        public void Insert(int newValue)
        {
            SinglyLinkedListNode newNode = new SinglyLinkedListNode(newValue, this.Head);
            this.Head = newNode;
        }

        /// <summary>
        /// Get the n-th node counting from the tail of the linked list.
        /// Time complexity: O(n)
        /// </summary>
        /// <param name="index">Index of the specific node counting from the tail.</param>
        /// <returns>The n-th node counting from the tail of the linked list.</returns>
        /// <exception cref="IndexOutOfRangeException">If the list has less than n nodes.</exception>
        public SinglyLinkedListNode NodeFromTail(int index)
        {
            // Algorithm:
            // - Keep two nodes a and b apart by n node
            // - Advance both nodes in parallel until b reaches the end of the list
            // - At that time, a will be at the position n from tail                        

            SinglyLinkedListNode aNode = this.Head;
            SinglyLinkedListNode bNode = this.Head;

            for (int i = 0; i < index; i++)
            {
                if (bNode == null)
                {
                    throw new IndexOutOfRangeException($"List has less than {index} node(s)");
                }

                bNode = bNode.Next;
            }

            while (bNode != null)
            {
                aNode = aNode.Next;
                bNode = bNode.Next;
            }

            return aNode;
        }

        public override string ToString()
        {
            if (IsEmpty())
            {
                return "Empty";
            }
            else
            {
                SinglyLinkedListNode node = this.Head;
                StringBuilder list = new StringBuilder();

                while (node.Next != null)
                {
                    list.Append(node.Value + "->");
                    node = node.Next;
                }

                list.Append(node.Value);

                return list.ToString();
            }
        }
    }

    /// <summary>
    /// Represents a node in a singly linked list.
    /// </summary>
    public class SinglyLinkedListNode
    {
        /// <summary>
        /// Gets the next node in the linked list after this node.
        /// </summary>
        public SinglyLinkedListNode Next { get; set; }

        /// <summary>
        /// Gets the value of this node.
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Initializes a new instance of the SinglyLinkedListNode.
        /// </summary>
        /// <param name="value">Value of the node.</param>
        public SinglyLinkedListNode(int value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Initializes a new instance of the SinglyLinkedListNode with link to the next node.
        /// </summary>
        /// <param name="value">Value of the node.</param>
        /// <param name="next">Reference to the next node.</param>
        public SinglyLinkedListNode(int value, SinglyLinkedListNode next)
        {
            this.Value = value;
            this.Next = next;
        }

        public override string ToString()
        {
            if (this.Next == null)
            {
                return $"{this.Value} [Tail]";
            }
            else
            {
                return $"{this.Value} [->{this.Next.Value}]";
            }
        }
    }
}
