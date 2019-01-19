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

        private void CreateFanButton_Click(object sender, EventArgs e)
        {
            //ParametersKeeper keeper = new ParametersKeeper(20, 1, 0.03, 6, 2);


            //ParametersKeeper keeper = new ParametersKeeper((double)Int32.Parse(frameLengthTextBox.Text),
            //    (double)Int32.Parse(holesDiameterTextBox.Text),
            //    (double)Int32.Parse(thicknessTextBox.Text),
            //    Int32.Parse(bladesQuantityComboBox.Items[0].ToString()),
            //    (double)Int32.Parse(bladeTurnTextBox.Text));

            double length = Convert.ToDouble(frameLengthTextBox.Text);
            double diameter = Convert.ToDouble(holesDiameterTextBox.Text);
            double thickness = Convert.ToDouble(thicknessTextBox.Text);
            int quant = Convert.ToInt32(bladesQuantityComboBox.Items[0].ToString());
            double turn = Convert.ToDouble(bladeTurnTextBox.Text);
            ParametersKeeper keeper = new ParametersKeeper(length, diameter, thickness, quant, turn);

            FANBuilder fanBuilder = new FANBuilder();

            fanBuilder.Build(keeper);
        }

        private void DefaultParametersButton_Click(object sender, EventArgs e)
        {
            frameLengthTextBox.Text = "20";
            holesDiameterTextBox.Text = "1";
            thicknessTextBox.Text = "0.03";
            bladesQuantityComboBox.DataSource = new List<int>() {6, 7, 8, 9};
            bladesQuantityComboBox.SelectedIndex = 0;
            bladeTurnTextBox.Text = "2";
        }
    }
}
