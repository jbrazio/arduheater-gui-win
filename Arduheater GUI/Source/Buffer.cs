/**
 * Arduheater GUI for Windows
 * Copyright (C) 2018 João Brázio [joao@brazio.org]
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 *
 */

using System;

namespace Arduheater_GUI
{ 
    public struct Buffer_t<T>
    {
        private T[] Data { get; set; }
        private uint Head { get; set; }
        private uint Tail { get; set; }
        public uint Capacity { get; private set; }

        public Buffer_t(uint capacity)
        {
            Data = new T[capacity];
            Capacity = capacity;
            Head = Tail = 0;
        }

        public void Enqueue(T item)
        {
            /*
            if (Full)
            {
                throw new InvalidOperationException("Buffer is full.");
            }
            */

            Data[Tail]= item;
            Tail = (Tail + 1) % Capacity;
        }

        public T Dequeue
        {
            get
            {
                if (Empty)
                {
                    throw new InvalidOperationException("Buffer is empty.");
                }

                T item = Data[Head];
                Head = (Head + 1) % Capacity;

                return item;
            }
        }

        public uint Size => (Tail - Head);

        public Boolean Full => (Head == (Tail + 1) % Capacity);

        public Boolean Empty => (Head == Tail);

        public void Reset() => Head = Tail;
    }
}
