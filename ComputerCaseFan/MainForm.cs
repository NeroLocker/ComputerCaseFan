using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerCaseFan
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            ParametersKeeper keeper = new ParametersKeeper();
            keeper.FrameLength = 20;
            keeper.HolesDiameter = 1;
            keeper.CentralCircleRadius = 8;
            keeper.BladeThickness = 0.03;
            keeper.BladesQuantity = 6;
            Builder builder = new Builder();

            builder.MakeObject(keeper);
        }
    }
}
