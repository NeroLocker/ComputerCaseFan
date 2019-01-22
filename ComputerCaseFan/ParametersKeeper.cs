using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.Geometry;

namespace ComputerCaseFan
{
    /// <summary>
    /// Хранит параметры вентилятора
    /// </summary>
    public class ParametersKeeper
    {
        /// <summary>
        /// Хранит радиус центрального круга
        /// </summary>
        public readonly int CentralCircleRadius = 8;
            
        /// <summary>
        /// Хранит длину рамки
        /// </summary>
        private double _frameLength;

        /// <summary>
        /// Хранит диаметр рамочных отверстий
        /// </summary>
        private double _holesDiameter;

        /// <summary>
        /// Хранит толщину лопастей
        /// </summary>
        private double _bladeThickness;

        /// <summary>
        /// Хранит количество лопастей
        /// </summary>
        private int _bladesQuantity;

        /// <summary>
        /// Хранит поворот лопасти
        /// </summary>
        private double _bladeTurn;

        /// <summary>
        /// Хранит радиус рамочных отверстий
        /// </summary>
        private double _holesRadius;

        public double HolesRadius
        {
            get { return _holesRadius;}
            private set { _holesRadius = value; }
        }

        public double FrameLength
        {
            get { return _frameLength;}
            private set
            {
                if (value < 20)
                {
                    throw new ArgumentException("Frame length is less than 20");
                }

                if (value > 25)
                {
                    throw new ArgumentException("Frame length is more than 25");
                }

                _frameLength = value;
            }
        }
        public double HolesDiameter
        {
            get { return _holesDiameter;}
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Holes diameter is less than 1");
                }

                if (value > 2.5)
                {
                    throw new ArgumentException("Holes diameter is more than 2.5");
                }

                _holesDiameter = value;

                // Неявно рассчитываем радиус отверстий и заносим значение в поле
                HolesRadius = _holesDiameter / 2;
            }
        }

        public double BladeThickness
        {
            get { return _bladeThickness;}
            private set
            {
                if (value < 0.03)
                {
                    throw new ArgumentException("Blade thickness is less than 0.03");
                }

                if (value > 0.15)
                {
                    throw new ArgumentException("Blade thickness is more than 0.15");
                }

                _bladeThickness = value;
            }
        }

        public int BladesQuantity
        {
            get { return _bladesQuantity; }
            private set
            {
                if (value < 6)
                {
                    throw new ArgumentException("Blades quantity is less than 6");
                }

                if (value > 9)
                {
                    throw new ArgumentException("Blades quantity is more than 9");
                }

                _bladesQuantity = value;
            }
        }

        public double BladeTurn
        {
            get { return _bladeTurn;}
            private set
            {
                if (value < 15)
                {
                    throw new ArgumentException("Blade turn is less than 15");
                }

                if (value > 22)
                {
                    throw new ArgumentException("Blade turn is more than 22");
                }

                _bladeTurn = value;
            }
        }

        /// <summary>
        /// Конструктор, инициализирующий параметры вентилятора
        /// </summary>
        /// <param name="frameLength"></param>
        /// <param name="holesDiameter"></param>
        /// <param name="bladeThickness"></param>
        /// <param name="bladesQuantity"></param>
        /// <param name="bladeTurn"></param>
        public ParametersKeeper(double frameLength, double holesDiameter, double bladeThickness, int bladesQuantity, double bladeTurn)
        {
            this.FrameLength = frameLength;
            this.HolesDiameter = holesDiameter;
            this.BladeThickness = bladeThickness;
            this.BladesQuantity = bladesQuantity;
            this.BladeTurn = bladeTurn;
        }
    }
}
