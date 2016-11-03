using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareNimpGame.Core
{
    public class Tileset
    {
        public string firstGid { get; set; }
        public string name { get; set; }
        public string tileWidth { get; set; }

        public string tileHeight { get; set; }

        public List<string> properties { get; set; }

        public Tileset()
        {
            properties = new List<string>();
        }
    }
}
