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
using Autodesk.AutoCAD.Windows;

namespace ComputerCaseFan
{
    public partial class MainForm : Form
    {
        private int BladesQuantityIndex { get; set; }

        private int VisualStyleIndex { get; set; }

        /// <summary>
        /// Конструктор главной формы
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            // Устанавливаем набор допустимых значений для количества лопастей
            List<int> dataList = new List<int>() { 6, 7, 8, 9 };

            foreach (int element in dataList)
            {
                bladesQuantityComboBox.Items.Add(element);
            }

            List<string> visualStylesList = new List<string>() { "Hidden", "Realistic", "Wireframe"};

            foreach (string element in visualStylesList)
            {
                visualStyleComboBox.Items.Add(element);
            }
        }

        /// <summary>
        /// Проверяет корректность полей
        /// </summary>
        /// <returns></returns>
        private bool AreAllFieldsCorrect()
        {
            // Проверка того, что поля пусты
            // Проверка того, что не выбрано количество лопастей

            if (frameLengthTextBox.Text.Length == 0)
            {
                return false;
            }

            if (holesDiameterTextBox.Text.Length == 0)
            {
                return false;
            }

            if (thicknessTextBox.Text.Length == 0)
            {
                return false;
            }

            if (bladesQuantityComboBox.SelectedIndex == -1)
            {
                return false;
            }

            if (bladeTurnTextBox.Text.Length == 0)
            {
                return false;
            }

            if (visualStyleComboBox.SelectedIndex == -1)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Удаляет все вхождения точек слева и справа от введеных строк пользователя
        /// </summary>
        private void TrimFields()
        {
            frameLengthTextBox.Text = frameLengthTextBox.Text.Trim('.');
            holesDiameterTextBox.Text = holesDiameterTextBox.Text.Trim('.');
            thicknessTextBox.Text = thicknessTextBox.Text.Trim('.');
            bladeTurnTextBox.Text = bladeTurnTextBox.Text.Trim('.');
        }
        
        /// <summary>
        /// Событие при нажатии кнопки "Create Fan", создающее вентилятор по введеным параметрам
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateFanButton_Click(object sender, EventArgs e)
        {
            // Поля должны быть заполнены
            if (AreAllFieldsCorrect())
            {
                // Объявляем хранитель параметров
                ParametersKeeper keeper;

                // Удаляем все вхождения точек слева и справа от введеной строки
                TrimFields();

                // Читаем данные с формы
                double frameLength = double.Parse(frameLengthTextBox.Text, CultureInfo.InvariantCulture);
                double holesDiameter = double.Parse(holesDiameterTextBox.Text, CultureInfo.InvariantCulture);
                double bladeThickness = double.Parse(thicknessTextBox.Text, CultureInfo.InvariantCulture);
                int bladesQuantity = Convert.ToInt32(bladesQuantityComboBox.Items[BladesQuantityIndex].ToString());
                double bladeTurn = double.Parse(bladeTurnTextBox.Text, CultureInfo.InvariantCulture);

                // Попытка построить вентилятор
                try
                {
                    keeper = new ParametersKeeper(frameLength, holesDiameter, 
                        bladeThickness, bladesQuantity, bladeTurn);

                    FANBuilder fanBuilder = new FANBuilder();

                    fanBuilder.VisualStyle = visualStyleComboBox.Items[VisualStyleIndex].ToString();

                    fanBuilder.Build(keeper);
                }
                // Ловим исключения при инициализации полей хранителя параметров
                catch (ArgumentException exception)
                {
                    // Подсвечиваем соответствующие поля
                    if (exception.Message == "Frame length is less than 20")
                    {
                        frameLengthTextBox.BackColor = Color.MistyRose;
                    }

                    if (exception.Message == "Frame length is more than 25")
                    {
                        frameLengthTextBox.BackColor = Color.MistyRose;
                    }
 
                    if (exception.Message == "Holes diameter is less than 1")
                    {
                        holesDiameterTextBox.BackColor = Color.MistyRose;
                    }

                    if (exception.Message == "Holes diameter is more than 2.5")
                    {
                        holesDiameterTextBox.BackColor = Color.MistyRose;
                    }

                    if (exception.Message == "Blade thickness is less than 0.03")
                    {
                        thicknessTextBox.BackColor = Color.MistyRose;
                    }

                    if (exception.Message == "Blade thickness is more than 0.15")
                    {
                        thicknessTextBox.BackColor = Color.MistyRose;
                    }

                    if (exception.Message == "Blades quantity is less than 6")
                    {
                        bladesQuantityComboBox.BackColor = Color.MistyRose;
                    }

                    if (exception.Message == "Blades quantity is more than 9")
                    {
                        bladesQuantityComboBox.BackColor = Color.MistyRose;
                    }

                    if (exception.Message == "Blade turn is less than 15")
                    {
                        bladeTurnTextBox.BackColor = Color.MistyRose;
                    }

                    if (exception.Message == "Blade turn is more than 22")
                    {
                        bladeTurnTextBox.BackColor = Color.MistyRose;
                    }
                }
            }

            // Если нет, то ничего не делаем
            else
            {                
            }            
        }

        /// <summary>
        /// Событие при нажатии кнопки "Default parameters", заполняющее все поля заметки параметрами по умолчанию
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DefaultParametersButton_Click(object sender, EventArgs e)
        {
            // Возвращаем стандартный цвет полей
            frameLengthTextBox.BackColor = Color.White;
            holesDiameterTextBox.BackColor = Color.White;
            thicknessTextBox.BackColor = Color.White;
            bladesQuantityComboBox.BackColor = Color.White;
            bladeTurnTextBox.BackColor = Color.White;
            
            // Присваиваем стандартные параметры
            frameLengthTextBox.Text = "20";
            holesDiameterTextBox.Text = "1.5";
            thicknessTextBox.Text = "0.03";
            bladesQuantityComboBox.SelectedIndex = 0;
            bladeTurnTextBox.Text = "15";
            visualStyleComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Событие при изменении индекса выбранного количества лопастей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BladesQuantityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            BladesQuantityIndex = bladesQuantityComboBox.SelectedIndex;
        }

        # region Enter Events
        /// <summary>
        /// Событие, возникающее в тот момент, когда поле FrameLengthTextBox является активным
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrameLengthTextBox_Enter(object sender, EventArgs e)
        {
            frameLengthTextBox.BackColor = Color.White;
        }

        /// <summary>
        /// Событие, возникающее в тот момент, когда поле HolesDiameterTextBox является активным
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HolesDiameterTextBox_Enter(object sender, EventArgs e)
        {
            holesDiameterTextBox.BackColor = Color.White;            
        }

        /// <summary>
        /// Событие, возникающее в тот момент, когда поле ThicknessTextBox является активным
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThicknessTextBox_Enter(object sender, EventArgs e)
        {
            thicknessTextBox.BackColor = Color.White;
        }

        /// <summary>
        /// Событие, возникающее в тот момент, когда поле BladesQuantityComboBox является активным
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BladesQuantityComboBox_Enter(object sender, EventArgs e)
        {
            bladesQuantityComboBox.BackColor = Color.White;
        }

        /// <summary>
        /// Событие, возникающее в тот момент, когда поле BladeTurnTextBox является активным
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BladeTurnTextBox_Enter(object sender, EventArgs e)
        {
            bladeTurnTextBox.BackColor = Color.White;
        }
        #endregion

        # region Key Press Events
        /// <summary>
        /// Событие при нажатии кнопки в поле FrameLengthTextBox, не позволяющее ввести любые символы
        /// кроме цифр, точек и клавиши BackSpace
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrameLengthTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // ASCII коды
            // с 48 по 57 - цифры
            // 8 - BackSpace
            // 46 - точка
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) 
                && number != 8 && number != 46)
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Событие при нажатии кнопки в поле HolesDiameterTextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HolesDiameterTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            FrameLengthTextBox_KeyPress(sender, e);
        }

        /// <summary>
        /// Событие при нажатии кнопки в поле ThicknessTextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThicknessTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            FrameLengthTextBox_KeyPress(sender, e);
        }

        /// <summary>
        /// Событие при нажатии кнопки в поле BladeTurnTextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BladeTurnTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            FrameLengthTextBox_KeyPress(sender, e);
        }
        #endregion

        private void VisualStyleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            VisualStyleIndex = visualStyleComboBox.SelectedIndex;
        }
    }
}
