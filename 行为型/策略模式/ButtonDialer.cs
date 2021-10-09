using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 策略模式
{
    public class ButtonDialer
    {

        public interface ButtonServer
        {
            void buttonPressed(int token);
        }


        public class Button
        {
            public const int SEND_BUTTON = -99;

            private readonly int m_token;

            private ButtonServer m_buttonServer;

            public Button(int token)
            {
                m_token = token;
            }

            public void press()
            {
                m_buttonServer.buttonPressed(m_token);
            }
        }

        public class Dialer
        {
            public void enterDigit(int digit)
            {
                Console.WriteLine($"enter digit:{digit}");
            }

            public void dial()
            {
                Console.WriteLine("dialing...");
            }
        }

        public class DigitButtonDialerAdapter : ButtonServer
        {
            private Dialer m_dialer;

            #region Implementation of ButtonServer

            public void buttonPressed(int token)
            {
                m_dialer.enterDigit(token);
            }

            #endregion
        }

        public class SendButtonDialerAdapter : ButtonServer
        {
            private Dialer m_dialer;

            #region Implementation of ButtonServer

            public void buttonPressed(int token)
            {
                m_dialer.dial();
            }

            #endregion
        }

        /*策略模式是一种行为模式，多个策略实现同一个策略接口，编程的时候client程序依赖策略接口，
         运行期根据不同上下文向client程序传入不同的策略实现。*/

        /* 适配器模式是一种结构模式，用于将两个不匹配的接口适配起来，使其能够正常工作 */

        /* 观察者模式： 是一种行为模式，解决一对多的对象依赖关系，将被观察者对象的行为通知到多个观察者，也就是监听者对象。 */

        /* 模板方法模式，就是在父类中用抽象方法定义计算的骨架和过程，而抽象方法的实现则留在子类中 */

        /* 开闭原则可以说是软件设计的原则的原则，是软件设计的核心原则，其他的设计原则更偏向技术性，具有技术性的知道意义，
           而开闭原则是方向性的，在软件设计的过程中，应该时刻以开闭原则指导，审视自己的设计：当需求变更的时候，现在的设计能否
           不修改代码就可以实现功能的扩展？如果不是就应该进一步使用其他的设计原则和设计模式去重新设计*/
    }
}
