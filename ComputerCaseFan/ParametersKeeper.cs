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
        private float _bladeThickness;

        /// <summary>
        /// Хранит количество лопастей
        /// </summary>
        private int _bladesQuantity;

        /// <summary>
        /// Хранит поворот лопасти
        /// </summary>
        private float _bladeTurn;

        private double _holesRadius;

        public double HolesRadius
        {
            get { return _holesRadius;}
            private set { _holesRadius = value; }
        }

        public double FrameLength
        {
            get { return _frameLength;}
            set
            {
                if (value < 20)
                {
                    throw new ArgumentException("Frame Length is less then 20");
                }

                if (value > 30)
                {
                    throw new ArgumentException("Frame Length is more then 30");
                }

                _frameLength = value;
            }
        }
        public double HolesDiameter
        {
            get { return _holesDiameter;}
            set
            {
                if (value < 0.1)
                {
                    throw new ArgumentException("Holes diameter is less then 0.1");
                }

                if (value > 1.1)
                {
                    throw new ArgumentException("Holes diameter is more then 1.1");
                }

                _holesDiameter = value;
                HolesRadius = _holesDiameter / 2;
            }
        }
        public double BladeThickness { get; set; }
        public int BladesQuantity { get; set; }
        public float BladeTurn { get; set; }
        public double CentralCircleRadius { get; set; }
    }
}
