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

        public List<Property> properties { get; set; }

        public string pathSprite { get; set; }

        public Tileset()
        {
            properties = new List<Property>();
        }
    }
}

public class Property
{
    public string propName { get; set; }
    public string propValue {get; set; }
}