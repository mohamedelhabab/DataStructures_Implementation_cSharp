﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections
{
    public class GenericArrayList<T> : IEnumerable<T> where  T : new()
    {
        //array type must be object because arrayList is not a fixed type Collection
        T[] list;

        /// <summary>
        /// Total count for items in arraylist 
        /// </summary>
        public int Length { get; private set; }

        public GenericArrayList()
        {
            list = new T[0];
        }

        /// <summary>
        /// Add new item to ArrayList
        /// </summary>
        /// <param name="item">new item</param>
        /// <returns>The new item index in the ArrayList</returns>
        public int Add(T item)
        {
            T[] newList = new T[list.Length + 1];

            for (int i = 0; i < list.Length; i++)
            {
                newList[i] = list[i];
            }

            newList[newList.Length - 1] = item;

            list = newList;
            Length = list.Length;

            return list.Length - 1;

        }

        /// <summary>
        /// Insert item at specific index
        /// </summary>
        /// <param name="index">The index to insert the new item</param>
        /// <param name="item">item</param>
        /// <returns></returns>
        public int Insert(int index, T item)
        {
            T[] newList = new T[list.Length + 1];
            newList[index] = item;

            for (int i = 0; i < list.Length; i++)
            {
                if (newList[i] == null)
                {
                    newList[i] = list[i];
                }
                else
                {
                    newList[i + 1] = list[i];
                }
            }

            list = newList;
            Length = list.Length;

            return list.Length - 1;
        }

        /// <summary>
        /// Remove item at specific index
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            int newListIndex = 0;

            T[] newList = new T[list.Length - 1];

            for (int listPtr = 0; listPtr < list.Length; listPtr++)
            {
                if (listPtr != index)
                {
                    newList[newListIndex] = list[listPtr];

                    newListIndex++;
                }
            }

            list = newList;
            Length = list.Length;
        }

        /// <summary>
        /// Get item at specific index
        /// </summary>
        /// <param name="index">index for item</param>
        /// <returns></returns>
        public T GetItem(int index)
        {
            return list[index];
        }

        /// <summary>
        /// Print all items to console
        /// </summary>
        public void PrintItems()
        {
            for (int i = 0; i < list.Length; i++)
            {
                Console.WriteLine(list[i]);
            }
        }

        //exhausted search used here
        //Future Work : use a better search algorithm !

        /// <summary>
        /// Get the index of specific item
        /// </summary>
        /// <param name="item">item</param>
        /// <returns></returns>
        public int IndexOf(T item)
        {
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i].ToString() == item.ToString())
                    return i;
            }

            return -1;

        }
        /// <summary>
        /// Replace item with a new one
        /// </summary>
        /// <param name="index">item index to be replaced</param>
        /// <param name="item">the new item value</param>

        public void ReplaceWith(int index, T item)
        {
            list[index] = item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < list.Length; i++)
            {
                yield return list[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < list.Length; i++)
            {
                yield return list[i];
            }
        }
    }
}
