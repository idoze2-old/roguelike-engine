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
        DAL.Component.Map Current_Map;
        DAL.Component.Tile CurrentBrush;
        LayerCollection Layers;
        Point HoveredCellLoc;
        private void Brush_Selector_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentBrush = (DAL.Component.Tile)Brush_Selector.SelectedItem;
        }
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
            foreach (DAL.Component.Tile Tile in DAL.UserMethods.GetTiles())
            {
                Brush_Selector.Items.Add(Tile);
            }
            Brush_Selector.SelectedItem = Brush_Selector.Items[0];
            
        }
        private void Depth_Selector_ValueChanged(object sender, EventArgs e)
        {
            Current_Map = DAL.UserMethods.GetMapsBySaveFile(((DAL.Component.SaveFile)SaveFile_Dropdown.SelectedItem).ID)[(int)Depth_Selector.Value];
            LoadMap();
        }
        private void SaveFile_Dropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            Depth_Selector.Maximum = DAL.UserMethods.GetMapsBySaveFile(((DAL.Component.SaveFile)SaveFile_Dropdown.SelectedItem).ID).Max(m => m.Depth);
            Depth_Selector.Value = Depth_Selector.Minimum;
            Current_Map = DAL.UserMethods.GetMapsBySaveFile(((DAL.Component.SaveFile)SaveFile_Dropdown.SelectedItem).ID)[(int)Depth_Selector.Value];
            LoadMap();
        }
        private void LoadMap()
        {
            PrintArea_panel.Controls.Clear();
            Layers = new LayerCollection(Current_Map);
            PrintArea_panel.Controls.Add(Print_box);
            PictureBox[] LayerPboxes = Layers.ToPictureBoxes();
            LayerPboxes[0].MouseClick += Print_box_Click;
            foreach (PictureBox Pbox in LayerPboxes)
            {
                Pbox.Visible = true;
                Pbox.BorderStyle = BorderStyle.FixedSingle;
                Pbox.Location = new Point(0, 0);
                Pbox.MouseMove += Print_box_MouseMove;
                PrintArea_panel.Controls.Add(Pbox);
                Pbox.BringToFront();
            }
        }
        private void Print_box_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Point P = new Point(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y);
            if (!(P.X < 0 || P.Y < 0 || P.X > Print_box.Bounds.Width || P.Y > Print_box.Bounds.Bottom))
            {
                CellMarker.Show();
                HoveredCellLoc = new Point((P.X / 8), (P.Y / 16));
                CellMarker.Location = new Point(HoveredCellLoc.X * 8, HoveredCellLoc.Y * 16);
                CellMarker.BringToFront();
                Print_box.Controls.Add(CellMarker);
            }
            else
            {
                CellMarker.Hide();
            }
        }
        private void Print_box_Click(object sender, EventArgs e)
        {
            int id = CurrentBrush.ID;
            int y = HoveredCellLoc.Y;
            int x = HoveredCellLoc.X;
            //CHANGE!
            int z = 0;
            //!!
            Color color = Color.Cyan;
            char glyph = CurrentBrush.Glyph;
            DAL.Component.MapObject obj = new DAL.Component.MapObject(id, x, y, z, color, glyph);
            Layers.Add(obj);
            LoadMap();
        }
        private void CellMarker_Click(object sender, EventArgs e)
        {
            Print_box_Click(sender, e);
        }
    }
    //TOMOVE
    #region Component Classes
    public struct LayerCollection
    {
        private Layer[] layers;
        public LayerCollection(DAL.Component.Map map)
        {
            layers = new Layer[map.Layers];
            for (int z = 0; z < map.Layers; z++)
            {
                layers[z] = new Layer(map, z);

            }
        }
        public void Add(DAL.Component.MapObject Obj)
        {
            layers[Obj.Z].AddOrUpdateCell(Obj);
        }
        public PictureBox[] ToPictureBoxes()
        {
            PictureBox[] PictureBoxes = new PictureBox[layers.Length];
            for (int i = 0; i < PictureBoxes.Length; i++)
            {
                PictureBoxes[i] = layers[i].Pbox;
            }
            return PictureBoxes;
        }
    }
    public class Layer
    {
        private List<Cell> cells;
        private PictureBox pbox;
        public Layer(DAL.Component.Map map, int Depth)
        {
            pbox = new PictureBox();
            pbox.Image = new Bitmap(8, 16);
            cells = new List<Cell>();
            foreach (DAL.Component.MapObject Obj in map.Objects[Depth])
            {
                AddOrUpdateCell(Obj);
            }

        }
        private PictureBox GenPbox()
        {
            pbox.Size = new Size(80, 160);
            Bitmap bmp = new Bitmap(pbox.Size.Width, pbox.Size.Height);
            Cell[] OldCells = new Cell[cells.Count];
            cells.CopyTo(OldCells);
            foreach (Cell cell in OldCells)
            {
                AddOrUpdateCell(cell);
            }
            //bmp.MakeTransparent();
            pbox.Image = bmp;
            return pbox;
        }
        public PictureBox Pbox { get => GenPbox(); set => pbox = value; }
        private void AddCell(Cell cell)
        {
            cells.Add(cell);
        }
        private void RemoveCell(int CellX, int CellY)
        {
            try
            {
                cells.RemoveAll(c => (c.X == CellX) && (c.Y == CellY));
            }
            catch { }


        }
        private void PrintCell(Cell obj)
        {
            Graphics g = Graphics.FromImage(pbox.Image);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            g.DrawImage(obj.Bmp, obj.X * 8, obj.Y * 16);
        }
        private void ClearCell(int CellX, int CellY)
        {
            Graphics g = Graphics.FromImage(pbox.Image);
            Rectangle rec = new Rectangle(CellX * 8, CellY * 16, 8, 16);
            g.FillRectangle(Brushes.Transparent, rec);

        }
        public void AddOrUpdateCell(DAL.Component.MapObject NewObj)
        {
            RemoveCell(NewObj.X, NewObj.Y);
            AddCell(new Cell(NewObj));
            ClearCell(NewObj.X, NewObj.Y);
            PrintCell(new Cell(NewObj));
        }

    }
    public class Cell : DAL.Component.MapObject
    {
        private Bitmap bmp;
        public Cell(DAL.Component.MapObject Obj)
            : base(Obj.ID, Obj.X, Obj.Y, Obj.Z, Obj.Color, Obj.Glyph)
        {
            #region Glyph Inscription On bmp for Mem-Saving
            Bmp = new Bitmap(8, 16);
            Bitmap target = Bmp;
            Graphics g = Graphics.FromImage(target);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            RectangleF recf = new RectangleF(0, 0, 8, 16);
            g.DrawString(Glyph.ToString(), new Font("IBM", 8), new SolidBrush(Color), recf);
            #endregion

        }
        public Bitmap Bmp { get => bmp; set => bmp = value; }
    }
    #endregion
    //TOMOVE END 

}
