using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SquareNimpGame.Core
{
    public class Map
    {

        public Entity map;

        private XmlDocument doc= new XmlDocument();

        public Map(string mapName, ContentManager content)
        {
            doc.Load("./Content/Assets/Maps/Map01/map.xml");
        }

        private void LoadMap()
        {

        }

        public void Update()
        {

        }

        public void Draw()
        {

        }
    }
}
