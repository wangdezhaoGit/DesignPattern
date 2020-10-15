﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 模板模式
{
    class Program
    {
        /// <summary>
        /// 抽象类：Account
        /// </summary>
        public abstract class Account
        {
            // 基本方法 - 具体方法
            public bool Validate(string account, string password)
            {
                Console.WriteLine("账号 : {0}", account);
                Console.WriteLine("密码 : {0}", password);

                if (account.Equals("张无忌") && password.Equals("123456"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            // 基本方法 - 抽象方法
            public abstract void CalculateInterest();

            // 基本方法 - 具体方法
            public void Display()
            {
                Console.WriteLine("显示利息");
            }

            // 基本方法 - 钩子方法
            public virtual bool IsAllowDisplay()
            {
                return true;
            }

            // 模板方法
            public void Handle(string account, string password)
            {
                if (!Validate(account, password))
                {
                    Console.WriteLine("账户或密码错误，请重新输入！");
                    return;
                }

                CalculateInterest();

                if (IsAllowDisplay())
                {
                    Display();
                }
            }
        }

        /// <summary>
        /// 具体子类：CurrentAccount => 活期账户类
        /// </summary>
        public class CurrentAccount : Account
        {
            // 重写父类的抽象基本方法
            public override void CalculateInterest()
            {
                Console.WriteLine("按活期利率计算利息！");
            }

            // 重写父类的钩子方法
            public override bool IsAllowDisplay()
            {
                return base.IsAllowDisplay();
            }
        }

        /// <summary>
        /// 具体子类：SavingAccount => 定期账户类
        /// </summary>
        public class SavingAccount : Account
        {
            // 重写父类的抽象基本方法
            public override void CalculateInterest()
            {
                Console.WriteLine("按定期利率计算利息！");
            }

            // 重写父类的钩子方法
            public override bool IsAllowDisplay()
            {
                return false;
            }
        }

        static void Main(string[] args)
        {
            Account account = new CurrentAccount();
            //Account account = new SavingAccount();
            if (account != null)
            {
                account.Handle("张无忌", "123456");
            }

            Console.ReadKey();
        }
    }
}
