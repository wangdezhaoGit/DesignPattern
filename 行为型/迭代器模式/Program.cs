using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 迭代器模式
{
    class Program
    {
        public interface Iterator<T>
        {
            bool hasNext();
            void next();
            T currentItem();
        }

        public class  ArrayIterator<T> : Iterator<T>
        {
            private int cursor;
            private ArrayList<T> arrayList;

            public ArrayIterator(ArrayList arrayList) { this.cursor = 0; this.arrayList = arrayList; }

            #region Implementation of Iterator<T>

            public bool hasNext()
            {
                return cursor != arrayList.size();
            }

            public void next()
            {
                cursor++;
            }

            public T currentItem()
            {
                if (cursor >= arrayList.size()) { throw new NoSuchElementException(); }
                return arrayList.get(cursor);
            }

            #endregion
        }

        static void Main(string[] args)
        {
            ArrayList<string> names = new ArrayList<>(); names.add("xzg"); names.add("wang"); names.add("zheng");

            Iterator iterator = new ArrayIterator(names); while (iterator.hasNext()) { System.out.println(iterator.currentItem()); iterator.next(); }
        }
    }
}
