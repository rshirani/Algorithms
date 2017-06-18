using System;

namespace Heap
{
    public abstract class Heap<T>
    {
        private T[] _list;
        private int _lastIndex = -1;
        private int _size;

        public T GetRoot()
        {
            if (_lastIndex < 0)
            { return default(T); }

            return _list[0];
        }

        public T Remove(int index = 0)
        {
            if (index > _lastIndex)
                return default(T);

            _list[index] = _list[_lastIndex--];
            HeapifyDown(index);

            return _list[index];
        }

        public void Add(T val)
        {
            if (_size <= _lastIndex)
                return;

            _list[++_lastIndex] = val;
        }

        public abstract void HeapifyUp(int index);

        public abstract void HeapifyDown(int index = 0);
    }

    public class MaxHeap<T> : Heap<T> where T : IComparable
    {

        private T[] _list;
        private int _lastIndex = -1;
        private int _size;
        public int Length => _lastIndex;

        public MaxHeap(T val, int size)
        {
            _size = size;
            _list[++_lastIndex] = val;
        }

        public override void HeapifyUp(int index)
        {
            HeapHelper<T>.HeapifyUp(_list, _lastIndex, false /*isMinHeap*/, index);
        }

        public override void HeapifyDown(int index = 0)
        {
            HeapHelper<T>.HeapifyUp(_list, _lastIndex, false /*isMinHeap*/, index);
        }
    }

    public class MinHeap<T> : Heap<T> where T : IComparable
    {

        private T[] _list;
        private int _lastIndex = -1;
        private int _size;
        public int Length => _lastIndex;

        public MinHeap(T val, int size)
        {
            _size = size;
            _list[++_lastIndex] = val;
        }

        public override void HeapifyUp(int index)
        {
            HeapHelper<T>.HeapifyUp(_list, _lastIndex, true /*isMinHeap*/, index);
        }

        public override void HeapifyDown(int index = 0)
        {
            HeapHelper<T>.HeapifyDown(_list, _lastIndex, true /*isMinHeap*/, index);
        }
    }

    public static class HeapHelper<T> where T : IComparable
    {
        public static void HeapifyUp(T[] _list, int _lastIndex, bool isMinHeap, int index = 0)
        {
            int parentIndex = (index - 1) / 2;

            if (parentIndex <= 0)
                return;

            if ((isMinHeap && _list[parentIndex].CompareTo(_list[index]) > 0) ||
                (!isMinHeap && _list[parentIndex].CompareTo(_list[index]) < 0))
            {
                var temp = _list[parentIndex];
                _list[parentIndex] = _list[index];
                _list[index] = temp;

                HeapifyUp(_list, _lastIndex, isMinHeap, parentIndex);
            }
        }

        public static void HeapifyDown(T[] _list, int _lastIndex, bool isMinHeap, int index = 0)
        {
            if (2 * index + 1 < _lastIndex)
                return;

            int maxIndex = 2 * index + 1;

            if (_lastIndex > 2 * index + 2)
            {
                if(isMinHeap)
                {
                    if (_list[maxIndex].CompareTo(_list[2 * index + 2]) > 0)
                    {
                        maxIndex = 2 * index + 2;
                    }
                }
                else
                {
                    if (_list[maxIndex].CompareTo(_list[2 * index + 2]) < 0)
                    {
                        maxIndex = 2 * index + 2;
                    }
                }

            }

            if ((isMinHeap && _list[index].CompareTo(_list[maxIndex]) > 0) ||
                (!isMinHeap && _list[index].CompareTo(_list[maxIndex]) < 0))
            {
                var temp = _list[index];
                _list[index] = _list[maxIndex];
                _list[maxIndex] = temp;
            }

            HeapifyDown(_list, _lastIndex, isMinHeap, maxIndex);
        }
    }
}
