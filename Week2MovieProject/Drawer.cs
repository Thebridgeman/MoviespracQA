using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2MovieProject
{
    class Drawer : IDrawer
        {
            public void Draw(IEnumerable<IDrawable> drawables)
            {
                Console.Clear();
                foreach (var drawable in drawables)
                {
                    drawable.Draw();
                }
            }
        }
    }

