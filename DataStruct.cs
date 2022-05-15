using System.Collections;
/// <summary>
/// Implementation of the List class that is used to store the objects in the database.
/// Even though there is a datatype builtin in c# called List<>, it is not used in this project.
/// Because it wasn't covered in out course.
/// </summary>
namespace Personal
{
    class List<T> : IEnumerable, IEnumerator<T>
    {
        private class LinkedList<Type>
        {
            private class Node<Type2>
            {
                public Type2 data;
                public Node<Type2>? next;

                public Node(Type2 data) => this.data = data;

                public object Clone()
                {
                    return this.MemberwiseClone();
                }
            }

            private Node<Type>? Head;
            private Node<Type>? Tail;
            private int size;

            public int Size { get => size; private set => size = value; }

            public void Add(Type item)
            {
                var node = new Node<Type>(item);
                if (Head is null)
                    Head = Tail = node;
                else
                    Tail!.next = Tail = node;
                size++;
            }

            public void AddAt(int index, Type item)
            {
                if (index < 0 || index > size)
                    throw new IndexOutOfRangeException();
                if (index == 0)
                    AddFirst(item);
                else if (index == size)
                    AddLast(item);
                else
                {
                    var node = new Node<Type>(item);
                    var prev = Head;
                    for (int i = 0; i < index - 1; i++)
                        prev = prev!.next;
                    if (prev!.next is null)
                        throw new IndexOutOfRangeException();
                    node.next = prev.next;
                    prev.next = node;
                    size++;
                }
            }

            public void AddFirst(Type item)
            {
                var node = new Node<Type>(item);
                node.next = Head;
                Head = node;
                if (size == 0)
                    Tail = node;
                size++;
            }

            public void AddLast(Type item)
            {
                var node = new Node<Type>(item);
                if (size == 0)
                    Head = Tail = node;
                else
                {
                    Tail!.next = node;
                    Tail = node;
                }
                size++;
            }

            public Type Pop()
            {
                if (Head is null)
                    throw new InvalidOperationException();
                var item = Head.data;
                Head = Head.next;
                size--;
                return item;
            }

            public Type PopAt(int index)
            {
                if (index < 0 || index >= size)
                    throw new IndexOutOfRangeException();
                if (index == 0)
                    return PopFirst();
                else if (index == size - 1)
                    return PopLast();
                else
                {
                    var prev = Head;
                    for (int i = 0; i < index - 1; i++)
                        prev = prev!.next;
                    if (prev!.next is null)
                        throw new IndexOutOfRangeException();
                    var item = prev.next!.data;
                    prev.next = prev.next.next;
                    size--;
                    return item;
                }
            }

            public Type PopFirst()
            {
                if (Head is null)
                    throw new InvalidOperationException();
                var item = Head.data;
                Head = Head.next;
                size--;
                return item;
            }

            public Type PopLast()
            {
                if (Head is null)
                    throw new InvalidOperationException();
                var prev = Head;
                for (int i = 0; i < size - 2; i++)
                    prev = prev!.next;
                if (prev!.next is null)
                    throw new InvalidOperationException();
                var item = prev.next!.data;
                prev.next = null;
                Tail = prev;
                size--;
                return item;
            }

            public Type Get()
            {
                if (Head is null)
                    throw new InvalidOperationException();
                return Head.data;
            }

            public Type GetAt(int index)
            {
                var current = Head;
                while (index > 0)
                {
                    current = current!.next;
                    index--;
                }
                return current!.data;
            }
        }

        private LinkedList<T>? list = new LinkedList<T>();

        private int position = -1;

        public int Length
        {
            get
            {
                if (list is null)
                    return 0;
                return list.Size;
            }
        }

        public void Add(T item)
        {
            if (list is null)
                list = new LinkedList<T>();
            list.Add(item);
        }

        public void AddAt(int index, T item)
        {
            if (list is null)
                list = new LinkedList<T>();
            list.AddAt(index, item);
        }

        public void AddFirst(T item)
        {
            if (list is null)
                list = new LinkedList<T>();
            list.AddFirst(item);
        }

        public void AddLast(T item)
        {
            if (list is null)
                list = new LinkedList<T>();
            list.AddLast(item);
        }

        public T Pop()
        {
            if (list is null)
                throw new InvalidOperationException();
            return list.Pop();
        }

        public T PopAt(int index)
        {
            if (list is null)
                throw new InvalidOperationException();
            return list.PopAt(index);
        }

        public T PopFirst()
        {
            if (list is null)
                throw new InvalidOperationException();
            return list.PopFirst();
        }

        public T PopLast()
        {
            if (list is null)
                throw new InvalidOperationException();
            return list.PopLast();
        }

        public T Get()
        {
            if (list is null)
                throw new InvalidOperationException();
            return list.Get();
        }

        public T GetAt(int index)
        {
            if (list is null)
                throw new InvalidOperationException();
            return list.GetAt(index);
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Length)
                    throw new IndexOutOfRangeException();
                return GetAt(index);
            }
            set
            {
                if (index < 0 || index >= Length)
                    throw new IndexOutOfRangeException();
                AddAt(index, value);
            }
        }

        public T Current
        {
            get
            {
                if (position < 0 || position >= Length)
                    throw new InvalidOperationException();
                return GetAt(position);
            }
        }

        object? IEnumerator.Current
        {
            get
            {
                if (position < 0 || position >= Length)
                    throw new InvalidOperationException();
                return GetAt(position);
            }
        }

        public bool MoveNext()
        {
            if (position < Length - 1)
            {
                position++;
                return true;
            }
            return false;
        }

        public void Reset() => position = -1;

        public IEnumerator<T> GetEnumerator()
        {
            if (list is not null)
                for (int i = 0; i < Length; i++)
                    yield return list.GetAt(i);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void Dispose() => list = null;
    }
}
