using System;
using System.Collections.Generic;

namespace Algorithm
{
    //동적배열 연습 
    class MyList<T>
    {
        const int DEFAULT_SIZE = 1;
        T[] _data = new T[DEFAULT_SIZE];

        public int Count = 0; // 실제로 사용중인 데이터 개수
        public int Capacity { get { return _data.Length; } }

        public void Add(T item)
        {
            //1. 공간이 충분히 남아 있는지 확인한다
            if (Count >= Capacity)
            {
                //공간을 다시 늘려서 확보한다
                T[] newArray = new T[Count * 2];
                for (int i = 0; i < Count; i++)
                    newArray[i] = _data[i];
                _data = newArray;
            }

            // 2. 공간에다가 데이터를 넣어준다
            _data[Count] = item;
            Count++;
        }
        public T this[int index]
        {
            get { return _data[index]; }
            set { _data[index] = value; }
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < Count - 1; i++)
                _data[i] = _data[i + 1];
            _data[Count - 1] = default(T);
            Count--;
        }
    }
    // ------------------------------------------//

    // Linked List연습

    class MyLinkedListNode<T>
    {
        public T Data;
        public MyLinkedListNode<T> Next;
        public MyLinkedListNode<T> Prev;
    }

    class MyLinkedList<T>
    {
        public MyLinkedListNode<T> Head = null; //첫번째
        public MyLinkedListNode<T> Tail = null; // 마지막
        public int Count = 0;

        public MyLinkedListNode<T> AddLast(T data)
        {
            MyLinkedListNode<T> newRoom = new MyLinkedListNode<T>();
            newRoom.Data = data;

            //만약에 아직 방이 아예 없었다면, 새로 추가한 첫번째 방이 Head이다
            if (Head == null)
                Head = newRoom;

            // 기존의 [마지막 방 ] 과 [새로 추가되는방]을 연결해준H
            if (Tail != null)
            {
                Tail.Next = newRoom;
                newRoom.Prev = Tail;
            }

            //[새로 추가되는방] [마지막방]으로 인정한다.
            Tail = newRoom;
            Count++;
            return newRoom;
        }

        public void Remove(MyLinkedListNode<T> room)
        {
            //[기존의 첫번째 방의 다음방] 을 [첫번째 방] 으로 인정한다
            if(Head == room)
                Head = Head.Next;

            //[ 기존의 마지막방의 이전 방을 [마지막 방] 으로 인정한다.
            if (Tail == room)
                Tail = Tail.Prev;

            if (room.Prev != null)
                room.Prev.Next = room.Next;

            if (room.Next != null)
                room.Next.Prev = room.Prev;

            Count--;
        }
    }

    


    public class DSPractice
    {

        public int[] _data = new int[25]; // 배열
        public List<int> _data2 = new List<int>(); // 동적배열
        public LinkedList<int> _data3 = new LinkedList<int>(); // 연결 리스d


    }
}
