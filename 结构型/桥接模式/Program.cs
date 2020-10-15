using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 桥接模式
{
    class Program
    {
        //来源于：https://zhuanlan.zhihu.com/p/149264045
        public abstract class IRenderEngine
        {
            public abstract void Render(string name);
        }

        public class IShape
        {
            public string name;
            public IRenderEngine renderEngine;

            public IShape(IRenderEngine renderEngine)
            {
                this.renderEngine = renderEngine;
            }

            public void Draw()
            {
                renderEngine.Render(name);
            }
        }

      public class Sphere:IShape
      {
          public Sphere(IRenderEngine re) : base(re)
          {
              name = "Sphere";
          }
      }

      public class Cube:IShape
      {
          public Cube(IRenderEngine renderEngine) : base(renderEngine)
          {
              name = "Cube";
          }
      }

      public class Capsule:IShape
      {
          public Capsule(IRenderEngine renderEngine) : base(renderEngine)
          {
              name = "Capsule";
          }
      }

      public class OpenGL:IRenderEngine
      {
          #region Overrides of IRenderEngine

          public override void Render(string name)
          {
              Console.WriteLine("OpenGL绘制出来了" + name);
          }

          #endregion
      }

      public class DirectX : IRenderEngine
      {
          public override void Render(string name)
          {
              Console.WriteLine("DrectX绘制出来了:" + name);
          }
      }


      public class SuperRender : IRenderEngine
      {
          public override void Render(string name)
          {
              Console.WriteLine("SuperRender绘制出来了:" + name);
          }
      }

        static void Main(string[] args)
        {
             IShape shape = new Cube(new OpenGL());
             shape.Draw();
             Console.ReadKey();
        }
    }
}
