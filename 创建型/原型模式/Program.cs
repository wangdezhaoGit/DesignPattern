using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 原型模式
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * 关键字 ： Clone
             * 类实现 ICloneable接口 
             *
             *  原型模式属于创建型模式，其主要作用就是用一个对象创建出新的对象，既简化了对象的创建过程，又对外隐藏创建细节。
             * 通常我们会使用new关键字来创建对象，但是当对象构造方法接受大量参数，或者需要设置大量字段时，代码就会显得冗长。
             * 这时大家可能会想到使用工厂模式将对象的创建与使用分离，但是工厂模式会造成类膨胀，当产品比较多时，会导致项目中充斥着大量的产品类和工厂类。
             * 原型模式给我们指出另一条路，即克隆，复制一个一模一样的自己，从而达到创建新对象的目的。
             */

            var myClass1 = new MyClass(1, "我是一");
            var myClass2 = (MyClass)myClass1.Clone();
            myClass2.Name = "我是二";
            Console.WriteLine($"{myClass2.ID}{myClass2.Name}");
            Console.WriteLine($"{myClass1.ID}{myClass1.Name}");
            Console.ReadKey();
        }

        public class MyClass : ICloneable
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public MyClass(int id, string name)
            {
                ID = id;
                Name = name;
            }

            #region Implementation of ICloneable

            /// <summary>创建作为当前实例副本的新对象。</summary>
            /// <returns>作为此实例副本的新对象。</returns>
            public object Clone()
            {
                return (MyClass)MemberwiseClone();
            }

            #endregion
        }
    }
}
