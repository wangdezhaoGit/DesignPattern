using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 中介者模式
{
    class Program
    {
        /// <summary>
        /// 抽象同事类：抽象组件
        /// </summary>
        public abstract class Component
        {
            protected Mediator mediator;

            public void SetMediator(Mediator mediator)
            {
                this.mediator = mediator;
            }

            // 转发调用
            public void Changed()
            {
                mediator.ComponenetChanged(this);
            }

            public abstract void Update();
        }

        /// <summary>
        /// 具体同事类：按钮组件
        /// </summary>
        public class Button : Component
        {
            public override void Update()
            {
                // 按钮不产生响应
            }
        }

        /// <summary>
        /// 具体同事类：列表框组件
        /// </summary>
        public class List : Component
        {
            public override void Update()
            {
                Console.WriteLine("列表框增加一项：张无忌");
            }

            public void Select()
            {
                Console.WriteLine("列表框选中项：小龙女");
            }
        }

        /// <summary>
        /// 具体同事类：组合框组件
        /// </summary>
        public class ComboBox : Component
        {
            public override void Update()
            {
                Console.WriteLine("组合框增加一项：张无忌");
            }

            public void Select()
            {
                Console.WriteLine("组合框选中项：小龙女");
            }
        }

        /// <summary>
        /// 具体同事类：文本框组件
        /// </summary>
        public class TextBox : Component
        {
            public override void Update()
            {
                Console.WriteLine("客户信息增加成功后文本框清空");
            }

            public void SetText()
            {
                Console.WriteLine("文本框显示：小龙女");
            }
        }

        /// <summary>
        /// 具体同事类：标签组件
        /// </summary>
        public class Label : Component
        {
            public override void Update()
            {
                Console.WriteLine("文本标签内容改变，客户信息总数量加1");
            }
        }

        /// <summary>
        /// 抽象中介者
        /// </summary>
        public abstract class Mediator
        {
            public abstract void ComponenetChanged(Component c);
        }

        /// <summary>
        /// 具体中介者
        /// </summary>
        public class ConcreteMediator : Mediator
        {
            // 维持对各个同事对象的引用
            public Button addButton;
            public List list;
            public TextBox userNameTextBox;
            public ComboBox cb;

            // 封装同事对象之间的交互
            public override void ComponenetChanged(Component c)
            {
                // 单击按钮
                if (c == addButton)
                {
                    Console.WriteLine("-- 单击增加按钮 --");
                    list.Update();
                    cb.Update();
                    userNameTextBox.Update();
                }
                // 从列表框选择客户
                else if (c == list)
                {
                    Console.WriteLine("-- 从列表框选择客户 --");
                    cb.Select();
                    userNameTextBox.SetText();
                }
                // 从组合框选择客户
                else if (c == cb)
                {
                    Console.WriteLine("-- 从组合框选择客户 --");
                    cb.Select();
                    userNameTextBox.SetText();
                }
            }
        }

        static void Main(string[] args)
        {
            // Step1.定义中介者对象
            ConcreteMediator mediator = new ConcreteMediator();

            // Step2.定义同事对象
            Button addButton = new Button();
            List list = new List();
            ComboBox cb = new ComboBox();
            TextBox userNameTextBox = new TextBox();

            addButton.SetMediator(mediator);
            list.SetMediator(mediator);
            cb.SetMediator(mediator);
            userNameTextBox.SetMediator(mediator);

            mediator.addButton = addButton;
            mediator.list = list;
            mediator.cb = cb;
            mediator.userNameTextBox = userNameTextBox;

            // Step3.点击增加按钮
            addButton.Changed();

            Console.WriteLine("---------------------------------------------");

            // Step4.从列表框选择客户
            list.Changed();

            Console.ReadKey();
        }
    }
}
