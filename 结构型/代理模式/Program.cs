using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 代理模式
{
    class Program
    {
        /*
         *   代理模式，它在不改变原始类（或叫被代理类）代码的情况下，通过引入代理类 来给原始类附加功能。
         *
         *   代理模式为对象提供一个替身，从而控制对这个对象的访问。
         *
         *   外接的请求通过对象到达实际对象，实际对象的响应通过代理返回给外界，代理模式一个明显的优点是限制外界对对象的访问，从而起到保护对象的作用，
         * 缺点是增加了复杂性，而且由于需要代理做转换，增加了调用链的长度
         *
         *   当由于某种原因不能将对象直接暴露给外界时，或者需要限制对对象的访问时，就可以考虑使用代理模式
         *
         * https://www.cnblogs.com/NaLanZiYi-LinEr/p/11746272.html
         *
         * https://time.geekbang.org/column/article/201823
         */
        static void Main(string[] args)
        {
            
        }
    }
}
