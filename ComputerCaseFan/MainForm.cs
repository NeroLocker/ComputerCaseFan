using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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

            // Устанавливаем набор допустимых значений для количества лопастей
            List<int> dataList = new List<int>() { 6, 7, 8, 9 };

            foreach (int element in dataList)
            {
                bladesQuantityComboBox.Items.Add(element);
            }
        }

    private int BladesQuantityIndex { get; set; }

        //public void ValidateFields()
        //{

        //}

        private void CreateFanButton_Click(object sender, EventArgs e)
        {
            ParametersKeeper keeper;

            // Читаем данные с формы
            double frameLength = Convert.ToDouble(frameLengthTextBox.Text);
            double holesDiameter = Convert.ToDouble(holesDiameterTextBox.Text);
            double bladeThickness = double.Parse(thicknessTextBox.Text, CultureInfo.InvariantCulture);

            //int bladesQuantity = 6;      

            int bladesQuantity = Convert.ToInt32(bladesQuantityComboBox.Items[BladesQuantityIndex].ToString());

            double bladeTurn = Convert.ToDouble(bladeTurnTextBox.Text);

            try
            {
                keeper = new ParametersKeeper(frameLength, holesDiameter, bladeThickness, bladesQuantity, bladeTurn);

                FANBuilder fanBuilder = new FANBuilder();

                fanBuilder.Build(keeper);
            }
            catch (ArgumentException exception)
            {
                // Длина рамки
                if (exception.Message == "Frame length is less than 20")
                {
                    frameLengthTextBox.BackColor = Color.MistyRose;
                }

                if (exception.Message == "Frame length is more than 30")
                {
                    frameLengthTextBox.BackColor = Color.MistyRose;
                }



                // Диаметр рамочных отверстий
                if (exception.Message == "Holes diameter is less than 1")
                {
                    holesDiameterTextBox.BackColor = Color.MistyRose;
                }

                if (exception.Message == "Holes diameter is more than 2.5")
                {
                    holesDiameterTextBox.BackColor = Color.MistyRose;
                }



                // Толщина лопастей
                if (exception.Message == "Blade thickness is less than 0.03")
                {
                    thicknessTextBox.BackColor = Color.MistyRose;
                }

                if (exception.Message == "Blade thickness is more than 0.15")
                {
                    thicknessTextBox.BackColor = Color.MistyRose;
                }



                // Количество лопастей
                if (exception.Message == "Blades quantity is less than 6")
                {
                    bladesQuantityComboBox.BackColor = Color.MistyRose;
                }

                if (exception.Message == "Blades quantity is more than 9")
                {
                    bladesQuantityComboBox.BackColor = Color.MistyRose;
                }



                // Поворот лопастей
                if (exception.Message == "Blade turn is less than 2")
                {
                    bladeTurnTextBox.BackColor = Color.MistyRose;
                }

                if (exception.Message == "Blade turn is more than 3")
                {
                    bladeTurnTextBox.BackColor = Color.MistyRose;
                }
            }
            

            
        }


        /// <summary>
        /// Событие при нажатии кнопки "Default parameters", заполняющее все поля заметки параметрами по умолчанию
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DefaultParametersButton_Click(object sender, EventArgs e)
        {
            frameLengthTextBox.Text = "20";
            holesDiameterTextBox.Text = "1";
            thicknessTextBox.Text = "0.03";
            bladesQuantityComboBox.SelectedIndex = 0;
            bladeTurnTextBox.Text = "2";
        }

        private void BladesQuantityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            BladesQuantityIndex = bladesQuantityComboBox.SelectedIndex;

            if (BladesQuantityIndex == -1)
            {
                CreateFanButton.Enabled = false;
            }

            else
            {
                CreateFanButton.Enabled = true;
            }

        }
    }
}
