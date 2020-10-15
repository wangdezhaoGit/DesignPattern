using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 策略模式
{
    class Program
    {

        /// <summary>
        /// 抽象策略类：折扣Discount
        /// </summary>
        public interface IDiscount
        {
            double Calculate(double price);
        }

        /// <summary>
        /// 环境类：电影票MovieTicket
        /// </summary>
        public class MovieTicket
        {
            private double _price;
            private IDiscount _discount;

            public double Price
            {
                get
                {
                    return _discount.Calculate(_price);
                }
                set
                {
                    _price = value;
                }
            }

            public IDiscount Discount
            {
                set
                {
                    _discount = value;
                }
            }
        }

        /// <summary>
        /// 具体策略类：学生票折扣StudentDiscount
        /// </summary>
        public class StudentDiscount : IDiscount
        {
            public double Calculate(double price)
            {
                Console.WriteLine("学生票：");
                return price * 0.8;
            }
        }

        /// <summary>
        /// 具体策略类：VIP会员票VIPDiscount
        /// </summary>
        public class VIPDiscount : IDiscount
        {
            public double Calculate(double price)
            {
                Console.WriteLine("VIP票：");
                Console.WriteLine("增加积分！");
                return price * 0.5;
            }
        }

        /// <summary>
        /// 具体策略类：儿童票折扣ChildrenDiscount
        /// </summary>
        public class ChildrenDiscount : IDiscount
        {
            public double Calculate(double price)
            {
                Console.WriteLine("儿童票：");
                return price - 10;
            }
        }
        static void Main(string[] args)
        {
            MovieTicket mt = new MovieTicket();
            double originalPrice = 60.0;
            double currentPrice = originalPrice;

            mt.Price = originalPrice;
            Console.WriteLine("原始票价：{0}", originalPrice);
            Console.WriteLine("----------------------------------------");

            IDiscount discount = new ChildrenDiscount();
            if (discount != null)
            {
                mt.Discount = discount;
                currentPrice = mt.Price;
            }
            Console.WriteLine("折后票价：{0}", currentPrice);

            Console.ReadKey();
        }
    }
}
