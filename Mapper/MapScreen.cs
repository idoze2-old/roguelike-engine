using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mapper
{
    public partial class MapScreen : Form
    {
        public MapScreen()
        {
            InitializeComponent();
        }

        private void MapScreen_Load(object sender, EventArgs e)
        {
            
            foreach (DAL.Component.SaveFile SF in DAL.UserMethods.GetSaveFilesByUser(Program.UserID))
            {
                SaveFile_Dropdown.Items.Add(SF);

            }
        }
        private void Depth_Selector_ValueChanged(object sender, EventArgs e)
        {
            Invalidate();
        }
        private void SaveFile_Dropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            Depth_Selector.Maximum = DAL.UserMethods.GetMapsBySaveFile(((DAL.Component.SaveFile)SaveFile_Dropdown.SelectedItem).ID).Max(m => m.Depth);
        }
        #region MapParser
        private PictureBox[] MapToLayers(DAL.Component.Map map)
        {
            PictureBox[] Layers = new PictureBox[map.Layers];
            for (int z = 0; z < map.Layers; z++)
            {
                Layers[z] = new PictureBox();
                Layers[z].Size = new Size(map.Width * 8, map.Height * 16);
                Bitmap bmp = new Bitmap(Layers[z].Image);
                for (int y = 0; y < map.Height; y++)
                    for (int x = 0; x < map.Width; x++)
                    {
                        DAL.Component.MapObject obj = map.GetObject(x, y, z);
                        PrintOnBitmap(obj, bmp);
                    }

            }
            return Layers;

        }
        private void PrintOnBitmap(DAL.Component.MapObject obj, Bitmap target)
        {
            Graphics g = Graphics.FromImage(target);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            RectangleF recf = new RectangleF(obj.X, obj.Y, 8, 16);
            g.DrawString(obj.Glyph.ToString(), new Font("IBM", 8), new SolidBrush(obj.Color), recf);
            g.Flush();
        }

        #endregion
    }
}
