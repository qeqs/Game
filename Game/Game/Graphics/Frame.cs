using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Graphics
{
    class Frame
    {
        private List<Sprite> sprites=new List<Sprite>();
        public void Add(params Sprite[] obj)
        {
            sprites.AddRange(obj);
        }
        private void SortByDepth()
        {
            sprites.OrderBy(x => Config.Sprites[x.Name].depth);
        }
    }
}
