using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Требуется реализовать класс двусвязного списка и операции вставки, удаления и поиска элемента в нём в соответствии с интерфейсом.

namespace Two_Link_List
{
    class Program
    {
        static void Main()
        {
            //Создание экземпляра класса список
            var Node = new Realize();
            Node.Inicilization(); 
            //Инициализация, присвоение начального значения
            //0

            //Заполнения списка
            for (int i = 1; i <= 5; i++)
                Node.AddNode(i);
            //ожидается добавление элемента i
            //1 2 3 4 5

            //Создание элемента списка, присваивание ему значения и добавление в список
            var new_list = new Node();
            new_list.Value = 6;
            Node.AddNodeAfter(new_list,5);
            //ожидается добавление элемента 6, после элемента 5
            //1 2 3 4 5 6

            //удаление элемента по его индексу
            Node.RemoveNode(5);
            //ожидается удаление элемента 5
            //1 2 3 4 6

            var new_new_list = new Node();
            new_new_list.Value = 10;

            //удаление элемента 
            Node.RemoveNode(new_new_list);
            
            // ожидается, ошибка содержимого элемента
            //1 2 3 4 6

            Node.RemoveNode(new_list);
            //ожидается удаление элемента 6
            //1 2 3 4 

            new_list=Node.FindNode(4);
            Console.WriteLine("найденый элемент " + new_list.Value);
            //ожидается 4
            //1 2 3 4 

            //Вывод списка и подсчёт количества его элемента
            Console.WriteLine("Всего элементов " + Node.GetCount());
            // ожидается 1 2 3 4 
            Console.ReadKey();
        }
    }

}
