using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 单例
{
    class Program
    {
        static void Main(string[] args)
        {
            var singleton = SingletonStudent.GetInstance();
        }

        class SingletonStudent
        {
            private static SingletonStudent _singletonStudent;

            private static object _singletonLock = new object();//锁同步

            public static SingletonStudent GetInstance()
            {
                //// 双if +lock
                if (_singletonStudent == null)
                {
                    lock (_singletonLock)
                    {
                        if (_singletonStudent == null)
                        {
                            _singletonStudent = new SingletonStudent();
                        }
                    }
                }

                return _singletonStudent;
            }
        }

        //利用静态变量实现单例模式
        //是不是觉得很优雅, 利用静态变量去实现单例,  由CLR保证，在程序第一次使用该类之前被调用，而且只调用一次
        // 
        // PS: 但是他的缺点也很明显, 在程序初始化后, 静态对象就被CLR构造了, 哪怕你没用。
        public class Singleton
        {
            private static readonly Singleton _singletonInstance = new Singleton();

            public static Singleton GetInstance
            {
                get => _singletonInstance;
            }
        }

        //利用静态构造函数实现单例模式 
        public class SingletonSecond
        {
            private static SingletonSecond _singletonSecond = null;

            static SingletonSecond()
            {
                _singletonSecond = new SingletonSecond();
            }

            public static SingletonSecond GetInstance()
            {
                return _singletonSecond;
            }
        }

        //单例模式中的延迟加载
        /*
         * 延迟加载或延迟加载是一种设计模式，或者您可以说这是一个概念，通常用于将对象的初始化延迟到需要时。
         * 因此，延迟加载的主要目标是按需加载对象，或者您可以根据需要说出对象。
           
           作为 .NET Framework 4.0 的一部分引入的惰性关键字为惰性初始化（即按需对象初始化）提供了内置支持。
           如果要使对象（如 Singleton）以延迟初始化，则只需将对象的类型（单例）传递给lazy 关键字
         */

        public class LazyClass
        {
            private static readonly Lazy<LazyClass> _instanceLazy = new Lazy<LazyClass>(() => new LazyClass());

            public static LazyClass GetInstance()
            {
                return _instanceLazy.Value;
            }
        }
    }
}
