using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using devDept.Eyeshot;
using devDept.Graphics;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Eyeshot.Labels;
using System.Diagnostics;
using devDept.Eyeshot.Translators;



namespace Building
{
    public partial class Form1 : Form
    {
        const string colour = "colour";
        double baseLength = 2500;
        double baseWidth = 2500;
        double baseHeight = 500;

        double column1Length = 500;
        double column1Width = 500;
        double column1Height = 800;
        double column1XOffset = 0;
        double column1YOffset = -500;
        double column2XOffset = 0;
        double column2YOffset = 0;

        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            viewportLayout1.Grid.Visible = false;
    
            Reset();
            viewportLayout1.ZoomFit();
            base.OnLoad(e);
        }

        private void baseLength_changed(object sender, EventArgs e)
        {
            baseLength = double.Parse(textBox1.Text);
            viewportLayout1.Entities.Clear();
            Reset();
        }

        private void baseWidth_changed(object sender, EventArgs e)
        {
            baseWidth = double.Parse(textBox2.Text);
            viewportLayout1.Entities.Clear();
            Reset();
        }

        private void baseHeight_changed(object sender, EventArgs e)
        {
            baseHeight = double.Parse(textBox3.Text);
            viewportLayout1.Entities.Clear();
            Reset();
        }

        private void column1Length_changed(object sender, EventArgs e)
        {
            column1Length = double.Parse(textBox4.Text);
            viewportLayout1.Entities.Clear();
            Reset();
        }

        private void column1Width_changed(object sender, EventArgs e)
        {
            column1Width = double.Parse(textBox5.Text);
            viewportLayout1.Entities.Clear();
            Reset();
        }

        private void column1Height_changed(object sender, EventArgs e)
        {
            column1Height = double.Parse(textBox6.Text);
            viewportLayout1.Entities.Clear();
            Reset();
        }

        private void column1XOffset_changed(object sender, EventArgs e)
        {
            column1XOffset = double.Parse(textBox7.Text);
            viewportLayout1.Entities.Clear();
            Reset();
        }

        private void column1YOffset_changed(object sender, EventArgs e)
        {
            column1YOffset = double.Parse(textBox8.Text);
            viewportLayout1.Entities.Clear();
            Reset();
        }

        private void column2XOffset_changed(object sender, EventArgs e)
        {
            column2XOffset = double.Parse(textBox9.Text);
            viewportLayout1.Entities.Clear();
            Reset();
        }

        private void column2YOffset_changed(object sender, EventArgs e)
        {
            column2YOffset = double.Parse(textBox10.Text);
            viewportLayout1.Entities.Clear();
            Reset();
        }

        private void Reset()
        {    
            //Make base
            Mesh baseSlab = BuildSlab(baseLength, baseWidth, baseHeight);

            //Make column
            Mesh column = BuildColumn1(column1Length, column1Width, column1Height);
            double Xoffset = (((baseLength - column1Length) /2) + column1XOffset);
            double Yoffset = (((baseWidth  + column1Width) /2) + column1YOffset);
            column.Translate( Xoffset, Yoffset, baseHeight);

            //Add Base Length Dimension
            Point3D corner1 = new Point3D(0, 0, 0);
            Plane XY = Plane.XY;
            XY.Origin = corner1;
            LinearDim dimLength = new LinearDim(XY, new Point3D(0, -250, 0), new Point3D(baseLength, -250, 0), new Point3D(baseLength / 2, -250, 0), 100);
            viewportLayout1.Entities.Add(dimLength);

            //Add Base Width Dimension
            Point3D corner2 = new Point3D(0, 0, 0);
            Plane YX = Plane.YX;
            YX.Origin = corner2;
            LinearDim dimWidth = new LinearDim(YX, new Point3D(-250, 0, 0), new Point3D(-250, baseWidth, 0), new Point3D(-250, baseWidth / 2, 0), -100);
            viewportLayout1.Entities.Add(dimWidth);

            //Add Base Height Dimension
            Point3D corner3 = new Point3D(0, 0, 0);
            Plane ZX = Plane.ZX;
            ZX.Origin = corner3;
            LinearDim dimHeight = new LinearDim(ZX, new Point3D(-250, 0, 0), new Point3D(-250, 0, baseHeight), new Point3D(-250, 0, baseHeight / 2), -100);

            //******* dimHeight.Billboard = true; This is actually pretty cool**********

            viewportLayout1.Entities.Add(dimHeight);

            viewportLayout1.Entities.Add(baseSlab, Color.Transparent);
            viewportLayout1.Entities.Add(column, Color.Transparent);
     
            viewportLayout1.Invalidate();
        }

        private Mesh BuildSlab(double baseLength, double baseWidth, double baseHeight)
        {
            return Mesh.CreateBox(baseLength, baseWidth, baseHeight);
        }

        private Mesh BuildColumn1(double column1Length, double column1Width, double column1Height)
        {
            return Mesh.CreateBox(column1Length, column1Width, column1Height);
        }
    }
}
