using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 工厂模式和抽象工厂模式
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             *     简单工厂是一个具体类，负责生产所有的产品，当有新的产品产生时，就需要修改生产产品的逻辑，不符合“对扩展开放，对修改关闭”的原则;
             *     工厂模式会为每个产品生产一个对应的工厂，当有新的产品出现时，只需要增加新的工厂即可；
             *     抽象工厂能够生成一个产品族，其中的每一个生产产品的方法都是利用工厂模式。
             *     抽象工厂模式（Abstract Factory）：提供一个创建一系列相关或相互依赖对象的接口，而无需指定它们具体的类。
             *     抽象工厂的例子网站： https://www.jianshu.com/p/886cbf1c067c
             */
        }
    }
}
