namespace Double_Linked_List_Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();

            //Adding nodes to the list.
            list.AddToFront(10);
            list.AddToFront(20);
            list.AddToEnd(30);
            list.AddToEnd(40);

            //Display the list.
            list.DisplayForward();
            list.DisplayBackward();

            //Deleting a node.
            list.DeleteNode(10);
            list.DisplayForward();
        }
    }

    class Node
    {
        public int data;
        public Node next;
        public Node prev;

        public Node(int data)
        {
            this.data = data;
            this.next = null;
            this.prev = null;
        }
    };

    class LinkedList
    {
        public Node head;
        public Node tail;

        public LinkedList()
        {
            head = null;
            tail = null;
        }

        public void AddToFront(int data)
        {
            Node newNode = new Node(data);
            if (head == null)
            {
                head = tail = newNode; //If the list is empty, head and tail are the same.
            }
            else
            {
                newNode.next = head;
                head.prev = newNode;
                head = newNode;
            }
        }

        public void AddToEnd(int data)
        {
            Node newNode = new Node(data);
            if (tail == null)
            {
                head = tail = newNode;
            }
            else
            {
                tail.next = newNode;
                newNode.prev = tail;
                tail = newNode;
            }
        }

        public void DeleteNode(int data)
        {
            Node current = head;
            while (current != null)
            {
                if (current.data == data)
                {
                    if (current.prev != null) current.prev.next = current.next;
                    if (current.next != null) current.next.prev = current.prev;

                    if (current == head) head = current.next;
                    if (current == tail) tail = current.prev;
                    break;
                }
                current = current.next;
            }
        }

        public void DisplayForward()
        {
            Node current = head;
            while (current != null)
            {
                Console.Write(current.data + " ");
                current = current.next;
            }
            Console.WriteLine();
        }

        public void DisplayBackward()
        {
            Node current = tail;
            while (current != null)
            {
                Console.Write(current.data + " ");
                current = current.prev;
            }
            Console.WriteLine();
        }
    }
}
