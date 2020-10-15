using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 备忘录模式
{
    class Program
    {
        /// <summary>
        /// 备忘录：ChessmanMemento
        /// </summary>
        public class ChessmanMemento
        {
            public string Label { get; set; }
            public int X { get; set; }
            public int Y { get; set; }

            public ChessmanMemento(string label, int x, int y)
            {
                Label = label;
                X = x;
                Y = y;
            }
        }

        /// <summary>
        /// 原发器：Chessman
        /// </summary>
        public class Chessman
        {
            public string Label { get; set; }
            public int X { get; set; }
            public int Y { get; set; }

            public Chessman(string label, int x, int y)
            {
                Label = label;
                X = x;
                Y = y;
            }

            // 保存状态
            public ChessmanMemento Save()
            {
                return new ChessmanMemento(Label, X, Y);
            }

            // 恢复状态
            public void Restore(ChessmanMemento memento)
            {
                Label = memento.Label;
                X = memento.X;
                Y = memento.Y;
            }
        }

        /// <summary>
        /// 负责人：MementoCaretaker
        /// </summary>
        public class MementoCaretaker
        {
            public ChessmanMemento Memento { get; set; }
        }

        static void Main(string[] args)
        {
            MementoCaretaker mc = new MementoCaretaker();
            Chessman chess = new Chessman("车", 1, 1);
            Display(chess);

            // 保存状态
            mc.Memento = chess.Save();
            chess.Y = 4;
            Display(chess);

            // 保存状态
            mc.Memento = chess.Save();
            Display(chess);
            chess.X = 5;
            Display(chess);


            Console.WriteLine("---------- Sorry，俺悔棋了 ---------");

            // 恢复状态
            chess.Restore(mc.Memento);
            Display(chess);

            Console.ReadKey();
        }
        public static void Display(Chessman chess)
        {
            Console.WriteLine("棋子 {0} 当前位置为：第 {1} 行 第 {2} 列", chess.Label, chess.X, chess.Y);
        }
    }
}
