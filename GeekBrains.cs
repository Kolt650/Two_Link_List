using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Two_Link_List
{
    public class Node
    {
        public int Value { get; set; }
        public Node NextNode { get; set; }
        public Node PrevNode { get; set; }
    }

    //Начальную и конечную ноду нужно хранить в самой реализации интерфейса
    public interface ILinkedList
    {
        int GetCount(); // возвращает количество элементов в списке
        void AddNode(int value);  // добавляет новый элемент списка
        void AddNodeAfter(Node node, int value); // добавляет новый элемент списка после определённого элемента
        void RemoveNode(int index); // удаляет элемент по порядковому номеру
        void RemoveNode(Node node); // удаляет указанный элемент
       // Node FindNode(int searchValue); // ищет элемент по его значению
    }

    public class Realize : ILinkedList
    {
        Node head = new Node();
        Node tail = new Node();

        //Добавленый мной метод
        public void Inicilization()
        {
            head = null;
            tail = null;
        }

        // возвращает количество элементов в списке
        public int GetCount()
        {
            int count = 0;
            if (head == null)
                return count;
            else
            {
                var list = new Node();
                list = head;
                while (list != null)
                {
                    count++;
                    Console.WriteLine(count+" Элемент "+" равен "+list.Value);
                    list = list.NextNode;
                }
                return count;
            }
        }

        // добавляет новый элемент списка
        public void AddNode(int value)
        {


            var newlist = new Node();
            newlist.Value = value;

            if (head == null)
                head = newlist;
            else
            {
                var list = head;
                while (list.NextNode != null)
                    list = list.NextNode;

                list.NextNode = newlist;
                newlist.PrevNode = list;
            }
            tail = newlist;
        }

        // добавляет новый элемент списка после определённого элемента
        public void AddNodeAfter(Node node, int value)
        {
            if (head == null)
                head = node;
            else 
            {
                var list = new Node();
                list = head;
                while ((list.Value != value) && (list.NextNode != null))
                    list = list.NextNode;
                if (list != null)
                {
                    node.PrevNode = list;
                    node.NextNode = list.NextNode;
                    list.NextNode = node;
                }
                else
                    Console.WriteLine("Данное значение отсутствует в списке");
            }
            tail = tail.NextNode;
        }

        // удаляет элемент по порядковому номеру
        //Поставь обратный порядок ифов с элсами!!!
        public void RemoveNode(int index)
        {
            if (index == 1)
            {
                head = head.NextNode;
                head.PrevNode = null;
            }
            else
            {
                var list = head;
                int count = 0;
                while ((count != index - 1) && (list.NextNode != null))
                {
                    list = list.NextNode;
                    count++;
                }
                if (list.NextNode != null)
                {
                    list.PrevNode.NextNode = list.NextNode;
                    list.NextNode.PrevNode = list.PrevNode;
                    list = null;
                }
                else if (list.NextNode == null)
                {
                    if (count < index)
                        Console.WriteLine("Ошибка ввода индекса, не найдено");
                    else
                    {
                        list.PrevNode.NextNode = null;
                        tail = list;
                    }
                }
            }
        }

        // удаляет указанный элемент
        public void RemoveNode(Node node)
        {
            if (node == head)
            {
                head = head.NextNode;
                head.PrevNode = null;
            }
            else
            {
                var list = head;
                int count = 0;
                while ((list != node) && (list.NextNode != null))
                {
                    list = list.NextNode;
                    count++;
                }
                if (list.NextNode != null)
                {
                    list.PrevNode.NextNode = list.NextNode;
                    list.NextNode.PrevNode = list.PrevNode;
                    list = null;
                }
                else if (list.NextNode == null)
                {
                    if ( list != node )
                        Console.WriteLine("Ошибка ввода индекса , не найдено");
                    else
                    {
                        list.PrevNode.NextNode = null;
                        tail = list;
                    }
                }
            }
        }

         //ищет элемент по его значению
        public Node FindNode(int searchValue)
        {
            var list = head;
            while (list.Value != searchValue)
                list=list.NextNode;
            return list;
        }
    }
}
