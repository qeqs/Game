using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Graphics
{
    class Frame
    {
        public List<Sprite> sprites=new List<Sprite>();
        public void Add(params Sprite[] obj)
        {
            sprites.AddRange(obj);
        }
        public void Add(params Animation[] obj)
        {
            foreach(Animation a in obj)
            {
                sprites.Add(a.Sprite);
            }
        }
        private void SortByDepth()
        {
            sprites.OrderBy(x => Config.Sprites[x.Name].depth);
        }
    }
}
