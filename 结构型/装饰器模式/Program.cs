using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 装饰器模式
{
    class Program
    {

        /*
         *　装饰模式可以在不改变一个对象本身功能的基础上给对象增加额外的新行为，在现实生活中，这种情况也到处存在，
         * 例如一张照片，可以不改变照片本身，给它增加一个相框，使得它具有防潮的功能，而且用户可以根据需要给它增加不同类型的相框，
         * 甚至可以在一个小相框的外面再套一个大相框。
         */


        /// <summary>
        /// 抽象界面构件类：抽象构件类
        /// </summary>
        public abstract class Component
        {
            public abstract void Display();
        }

        /// <summary>
        /// 窗体类：具体构件类
        /// </summary>
        public class Window : Component
        {
            public override void Display()
            {
                Console.WriteLine("显示窗体!");
            }
        }

        /// <summary>
        /// 文本框类：具体构件类
        /// </summary>
        public class TextBox : Component
        {
            public override void Display()
            {
                Console.WriteLine("显示文本框!");
            }
        }

        /// <summary>
        /// 列表框类：具体构件类
        /// </summary>
        public class ListBox : Component
        {
            public override void Display()
            {
                Console.WriteLine("显示列表框!");
            }
        }

        /// <summary>
        /// 构件装饰类：抽象装饰类
        /// </summary>
        public class ComponentDecorator : Component
        {
            private Component component;

            public ComponentDecorator(Component component)
            {
                this.component = component;
            }

            public override void Display()
            {
                component.Display();
            }
        }

        /// <summary>
        /// 滚动条装饰类：具体装饰类
        /// </summary>
        public class ScrollBarDecorator : ComponentDecorator
        {
            public ScrollBarDecorator(Component component) : base(component)
            {

            }

            public override void Display()
            {
                this.SetScrollBar();
                base.Display();
            }

            public void SetScrollBar()
            {
                Console.WriteLine("为构件增加滚动条!");
            }
        }

        /// <summary>
        /// 黑色边框装饰类：具体装饰类
        /// </summary>
        public class BlackBorderDecorator : ComponentDecorator
        {
            public BlackBorderDecorator(Component component) : base(component)
            {

            }

            public override void Display()
            {
                this.SetScrollBar();
                base.Display();
            }

            public void SetScrollBar()
            {
                Console.WriteLine("为构件增加黑色边框!");
            }
        }


        static void Main(string[] args)
        {
            Component component = new Window();
            
            Component componentSB = new ScrollBarDecorator(component);

            componentSB.Display();

            Console.WriteLine();

            Component componentBB = new BlackBorderDecorator(componentSB);
            componentBB.Display();

            Console.ReadKey();
        }

    }
}
