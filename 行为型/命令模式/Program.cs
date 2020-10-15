using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 命令模式
{
    class Program
    {

        /// <summary>
        /// 功能键设置窗口类
        /// </summary>
        public class FBSettingWindow
        {
            // 窗口标题
            public string Title { get; set; }
            // 所有功能键集合
            private IList<FunctionButton> functionButtonList = new List<FunctionButton>();

            public FBSettingWindow(string title)
            {
                this.Title = title;
            }

            public void AddFunctionButton(FunctionButton fb)
            {
                functionButtonList.Add(fb);
            }

            public void RemoveFunctionButton(FunctionButton fb)
            {
                functionButtonList.Remove(fb);
            }

            // 显示窗口及功能键
            public void Display()
            {
                Console.WriteLine("显示窗口：{0}", this.Title);
                Console.WriteLine("显示功能键：");

                foreach (var fb in functionButtonList)
                {
                    Console.WriteLine(fb.Name);
                }

                Console.WriteLine("------------------------------------------");
            }
        }

        /// <summary>
        /// 请求发送者：功能键
        /// </summary>
        public class FunctionButton
        {
            // 功能键名称
            public string Name { get; set; }
            // 维持一个抽象命令对象的引用
            private Command command;

            public FunctionButton(string name)
            {
                this.Name = name;
            }

            // 为功能键注入命令
            public void SetCommand(Command command)
            {
                this.command = command;
            }

            // 发送请求的方法
            public void OnClick()
            {
                Console.WriteLine("点击功能键：");
                if (command != null)
                {
                    command.Execute();
                }
            }
        }


        /// <summary>
        /// 抽象命令类
        /// </summary>
        public abstract class Command
        {
            public abstract void Execute();
        }

        /// <summary>
        /// 具体命令类：帮助命令
        /// </summary>
        public class HelpCommand : Command
        {
            private HelpHandler hander;

            public HelpCommand()
            {
                hander = new HelpHandler();
            }

            // 命令执行方法，将调用请求接受者的业务方法
            public override void Execute()
            {
                if (hander != null)
                {
                    hander.Display();
                }
            }
        }

        /// <summary>
        /// 具体命令类：最小化命令
        /// </summary>
        public class MinimizeCommand : Command
        {
            private WindowHandler handler;

            public MinimizeCommand()
            {
                handler = new WindowHandler();
            }

            // 命令执行方法，将调用请求接受者的业务方法
            public override void Execute()
            {
                if (handler != null)
                {
                    handler.Minimize();
                }
            }
        }


        /// <summary>
        /// 请求接受者：帮助文档处理类
        /// </summary>
        public class WindowHandler
        {
            public void Minimize()
            {
                Console.WriteLine("正在最小化窗口至托盘...");
            }
        }

        /// <summary>
        /// 请求接受者：帮助文档处理类
        /// </summary>
        public class HelpHandler
        {
            public void Display()
            {
                Console.WriteLine("正在显示帮助文档...");
            }
        }

        static void Main(string[] args)
        {
            // Step1.模拟显示功能键设置窗口
            FBSettingWindow window = new FBSettingWindow("功能键设置窗口");

            // Step2.假如目前要设置两个功能键
            FunctionButton buttonA = new FunctionButton("功能键A");
            FunctionButton buttonB = new FunctionButton("功能键B");

            // Step3.读取配置文件和反射生成具体命令对象
            Command commandA = new HelpCommand();
            Command commandB = new MinimizeCommand();

            // Step4.将命令注入功能键
            buttonA.SetCommand(commandA);
            buttonB.SetCommand(commandB);

            window.AddFunctionButton(buttonA);
            window.AddFunctionButton(buttonB);
            window.Display();

            // Step5.调用功能键的业务方法
            buttonA.OnClick();
            buttonB.OnClick();

            Console.ReadKey();
        }
    }
}
