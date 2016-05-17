namespace _03.GenericList
{
    using System;

    public class GenericList<T> where T : IComparable
    {
        private const byte DefaultSize = 16;
        private T[] array;
        private uint size;
        private uint index;

        public GenericList(uint size = DefaultSize)
        {
            this.Size = size;
            this.Index = 0;
            this.array = new T[size];
        }

        public uint Size
        {
            get { return this.size; }
            private set { this.size = value; }
        }

        public uint Index { get; private set; }

        public T this[uint i]
        {
            get
            {
                return this.array[i];
            }

            set
            {
                if (i < 0 || i > this.index)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Index must be in range [{0}, {1}]!", 0, this.index));
                }

                // this[i] = value;
            }
        }

        public void Add(T element)
        {
            if (this.index >= this.array.Length - 1)
            {
                T[] newArray = new T[this.array.Length * 2];
                this.array.CopyTo(newArray, 0);
                this.array = newArray;
            }

            this.array[this.index] = element;
            this.index++;
        }

        public void RemoveByIndex(uint elementIndex)
        {
            for (uint i = elementIndex; i < this.index; i++)
            {
                this.array[i] = this.array[i + 1];
            }

            this.index--;
            this.array[this.index] = default(T);
        }

        public void InsertAtPos(T element, uint pos)
        {
            for (uint i = this.index; i > pos; i--)
            {
                this.array[i] = this.array[i - 1];
            }

            if (pos >= this.array.Length)
            {
                throw new ArgumentOutOfRangeException(string.Format("The position you are tryint to insert at is not in list's length range [0,{0}] !", this.array.Length));
            }

            this.array[pos] = element;
            this.index++;
        }

        public void Clear()
        {
            for (int i = 0; i < this.array.Length; i++)
            {
                this.array[i] = default(T);
            }
        }

        public int FindFirstIndexOf(T element)
        {
            for (int i = 0; i < this.index; i++)
            {
                if (element.CompareTo(this.array[i]) == 0)
                {
                    return i;
                }
            }

            return -1;
        }

        public override string ToString()
        {
            string result = string.Join(", ", this.array); // "printing the ENTIRE list (override ToString())." 

            return result;
        }

        public T Min(params T[] el)
        {
            T minValue = el[0];
            for (int i = 1; i < el.Length; i++)
            {
                if (minValue.CompareTo(el[i]) > 0)
                {
                    minValue = el[i];
                }
            }

            return minValue;
        }

        public T Max(params T[] el)
        {
            T maxValue = el[0];
            for (int i = 1; i < el.Length; i++)
            {
                if (maxValue.CompareTo(el[i]) < 0)
                {
                    maxValue = el[i];
                }
            }

            return maxValue;
        }
    }
}
