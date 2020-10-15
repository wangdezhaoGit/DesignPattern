using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 建造者模式
{
    class Program
    {
        /*
         * 建造者模式，在创建比较复杂的对象，或者对象包含多个组成部分时比较 有用，用于将对象的创建过程与使用分离，
         * 隔离具体的创建细节，方便以后的扩展
         * 他的使用场景：
         *  1.对象的创建比较复杂，需要进行许多处理工作
         *  2.对象包含多个组成部分，而这几个部分之间常常会有较为固定的顺序
         *  3.创建对象需要很多参数，会导致构建时的参数列表过长，难以理解和维护
         *
         *
         * 关键字  Builder:抽象出一个父类，然后具体的步骤交给子类去实现，对于其中共同的部分，可以在抽象父类中提供默认实现
         *        Director:指挥者，用于构建一个使用Builder接口的对象，主要作用 1.隔离客户和对象的生产过程；2.负责控制产品对象的生产过程
         *
         *     导演类 Director 在 Builder模式中具有很重要的作用，它用于指导具体构建者如何构建产品，控制调用先后次序，并向调用者返回完整的产品类，
         * 但是有些情况下需要简化系统结构，可以把Director和抽象建造者进行结合
         *   
         *
         * Builder模式可以将一个类的构建和表示进行分离
         */
        static void Main(string[] args)
        {
            
        }
    }
}
