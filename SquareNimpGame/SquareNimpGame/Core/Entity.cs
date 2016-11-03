using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareNimpGame.Core
{
    public class Entity
    {

        public Texture2D texture;

        public int x { get; set; }
        public int y { get; set; }

        public Tileset tileset { get; set; }
        public int id { get; set; }

        public int pixelX {
            get {return x * 32;}
        }
        public int pixelY {
            get {return y * 32;}
        }
    
    }
}
