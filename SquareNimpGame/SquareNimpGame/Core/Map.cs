using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
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
        public string mapName;

        public Entity[,] map;

        public List<Tileset> tilesets;

        private XmlDocument doc= new XmlDocument();
        private string toMap;
        public Map(string mapName)
        {
            this.mapName = mapName;
            map = new Entity[25, 40];
            Debug.WriteLine("passe");
            tilesets = new List<Tileset>();
            doc.Load("./Content/Assets/Maps/"+ mapName +"/map.xml");
            LoadMap();
        }

        private void LoadMap()
        {

            // ON CHARGE LES TILESETS ET LEURS PROPS
            Tileset tmp;
            XmlNodeList nodes = doc.DocumentElement.SelectNodes("/map/tileset");
            foreach(XmlNode node in nodes)
            {              
                node.Attributes.Item(0);
                tmp = new Tileset() {
                    firstGid = node.Attributes["firstgid"].Value,
                    name = node.Attributes["name"].Value,
                    tileWidth = node.Attributes["tilewidth"].Value,
                    tileHeight = node.Attributes["tileheight"].Value
                };
                
                foreach (XmlNode tileNode in node)
                {
                    if(tileNode.Name == "tile")
                    {
                        foreach (XmlNode propertiesNode in tileNode)
                        {
                            foreach(XmlNode propNode in propertiesNode)
                            {
                                if(propNode.Name == "property")
                                {
                                    tmp.properties.Add(new Property()
                                    {
                                        propName = propNode.Attributes["name"].Value,
                                        propValue = propNode.Attributes["value"].Value
                                    });
                                }
                            }
                        }
                    }
                    if(tileNode.Name == "image")
                    {
                        tmp.pathSprite = "Assets/Maps/" + mapName + "/" + tileNode.Attributes["source"].Value;
                    }
                }
                tilesets.Add(tmp);
                nodes = doc.DocumentElement.SelectNodes("/map/layer/data/tile");
                int x = 0;
                int y = 0;
                int i = 0;
                XmlNode tmpNode;
                while (y <= 24)
                {
                    while(x <= 39)
                    {
                        tmpNode = nodes.Item(i);
                        int j = 0;
                        while(tmpNode.Attributes["gid"].Value != tilesets[j].firstGid)
                            j++;
                        map[y, x] = new Entity() { 
                            x = x,
                            y = y,
                            id = i,
                            tileset = tilesets[j]
                        };
                        x++;
                    }
                    x = 0;
                    y++;
                }
            }
        }

        public void LoadContent(ContentManager Content)
        {
            Debug.WriteLine("rentre");
            int x = 0;
            int y = 0;

            while (y <= 24)
            {
                while (x <= 39)
                {
                    map[y, x].texture = Content.Load<Texture2D>(map[y, x].tileset.pathSprite);
                    x++;
                }
                x = 0;
                y++;
            }
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch sb)
        {

            int x = 0;
            int y = 0;
            while (y <= 24)
            {
                while (x <= 39)
                {
                    sb.Draw(map[y, x].texture, new Microsoft.Xna.Framework.Rectangle(map[y, x].pixelX, map[y, x].pixelY, 32, 32), Color.White);
                }
                x = 0;
                y++;
            }
            sb.End();
        }
    }
}
