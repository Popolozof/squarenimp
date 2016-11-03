using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SquareNimpGame.Core
{
    public class Map
    {

        public Entity map;

        public List<Tileset> tilesets;

        private XmlDocument doc= new XmlDocument();

        public Map(string mapName)
        {
            Debug.WriteLine("passe");
            tilesets = new List<Tileset>();
            doc.Load("./Content/Assets/Maps/"+ mapName +"/map.xml");
            LoadMap();
        }

        private void LoadMap()
        {
            Debug.WriteLine("passe");
            XmlNodeList nodes = doc.DocumentElement.SelectNodes("/map/tileset");
            Debug.WriteLine(">>>>" + nodes.Count);
            int i = 0;
            foreach(XmlNode node in nodes)
            {
                
                i++;
                Debug.WriteLine(i + " - ok");
                Debug.WriteLine(node.Name + " - " + node.Attributes.Count + " - " + node.Attributes["firstgid"].Value);
                node.Attributes.Item(0);
                tilesets.Add(new Tileset() {
                    firstGid = node.Attributes["firstgid"].Value,
                    name = node.Attributes["name"].Value,
                    tileWidth = node.Attributes["tilewidth"].Value,
                    tileHeight = node.Attributes["tileheight"].Value
                });
            }
        }

        public void Update()
        {

        }

        public void Draw()
        {

        }
    }
}
