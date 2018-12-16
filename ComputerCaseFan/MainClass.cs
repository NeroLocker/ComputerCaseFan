using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.GraphicsInterface;

namespace ComputerCaseFan
{
    public class MainClass
    {
        [CommandMethod("StartProgram")]
        public void StartProgram()
        {
            // Вызываем главную форму
            var mainForm = new MainForm();
            mainForm.Show();
        }
    }
}
