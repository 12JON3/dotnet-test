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

        private void Reset()
        {
            viewportLayout1.Entities.Clear();
            viewportLayout1.Labels.Clear();

            double baseLength = 2500;
            double baseWidth = 2500;
            double baseHeight = 500;

            double column1Length = 500;
            double column1Width = 500;
            double column1Height = 800;
            double column1XOffset = 0;
            double column1YOffset = -500;

         /*double baseLength = double.Parse(textBox1.Text);
            double baseWidth = double.Parse(textBox2.Text);
            double baseHeight = double.Parse(textBox3.Text);

            double column1Length = double.Parse(textBox4.Text);
            double column1Width = double.Parse(textBox5.Text);
            double column1Height = double.Parse(textBox6.Text);
            double column1XOffset = double.Parse(textBox7.Text);
            double column1YOffset = double.Parse(textBox8.Text);

            double column2XOffset = double.Parse(textBox9.Text);
            double column2YOffset = double.Parse(textBox10.Text); */

            //Make base
            Mesh baseSlab = BuildSlab(baseLength, baseWidth, baseHeight);

            //Make column
            Mesh column = BuildColumn1(column1Length, column1Width, column1Height);
            column.Translate(column1XOffset, column1YOffset, baseHeight);

            viewportLayout1.Entities.Add(baseSlab);
            viewportLayout1.Entities.Add(column);

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
