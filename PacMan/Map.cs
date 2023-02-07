using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_PacMan
{
    internal class Map
    {
        string path = "..\\maps\\";
        public char[,] map = new char[,] { };

        public Map(string str)
        {
            string[] lines = File.ReadAllLines(str);
            int xL = int.Parse(lines[0]);
            map = new char[25, 25];
            for (int y = 2; y < lines.Length; y++)
            {
                string res = lines[y].Replace(",", "");
                char[] l = res.ToCharArray();
                for (int x = 0; x < l.Length; x++)
                {
                    map[x, y - 2] = l[x];
                }
            }
        }

        public Map(char[,] map)
        {
            this.map = map;
            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    this.map[x, y] = '0';
                }
            }
        }

        public void Save()
        {
            string name = "map-";

            StringBuilder str;
            str = new StringBuilder();
            str.Append(map.GetLength(0) + "\r\n");
            str.Append(map.GetLength(1) + "\r\n");
            for (int y = 0; y < map.GetLength(1); y++)
            {
                str.Append(map[0, y]);
                for (int x = 1; x < map.GetLength(0); x++)
                {
                    str.Append("," + map[x, y]);
                }
                str.Append("\r\n");
            }
            // searches the current directory
            int fCount = Directory.GetFiles(path, "*").Length;
            string pathM = path + name + "1" + ".mx";
            System.Diagnostics.Debug.WriteLine(!File.Exists(pathM));

            File.WriteAllText("map-1.mx", str.ToString());

            if (!File.Exists(pathM))
                File.WriteAllText(pathM, str.ToString());
            else
            {
                pathM = path + name + (fCount + 1) + ".mx";
                File.WriteAllText(pathM, str.ToString());
            }
        }
    }
}
