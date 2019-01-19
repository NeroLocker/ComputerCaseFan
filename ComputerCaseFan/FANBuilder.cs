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
using Polyline = Autodesk.AutoCAD.DatabaseServices.Polyline;
using Region = Autodesk.AutoCAD.DatabaseServices.Region;

namespace ComputerCaseFan
{
    public class FANBuilder
    {
        private ParametersKeeper ParametersKeeper { get; set; }

        private CADManager Manager { get; set; }

        /// <summary>
        /// Строит объект вентилятора
        /// </summary>
        /// <param name="parametersKeeper"></param>
        public void Build(ParametersKeeper parametersKeeper)
        {
            this.ParametersKeeper = parametersKeeper;

            this.Manager = new CADManager();

            using (DocumentLock documentLock = Manager.Document.LockDocument())
            {
                using (Transaction transaction = Manager.Database.TransactionManager.StartTransaction())
                {
                    BlockTableRecord blockTableRecord = Manager.GetBlockTableRecord(Manager.Database, transaction);

                    // Создаём рамку
                    Solid3d frameSolid = MakeFrame();

                    // Создаём ротор
                    Solid3d rotorSolid = MakeRotor();

                    // Создаём лопасть
                    Solid3d bladeSolid = MakeBlade();

                    // Добавляем записи в таблицу и в транзакцию                    
                    blockTableRecord.AppendEntity(frameSolid);
                    
                    transaction.AddNewlyCreatedDBObject(frameSolid, true);

                    blockTableRecord.AppendEntity(rotorSolid);
                    transaction.AddNewlyCreatedDBObject(rotorSolid, true);

                    blockTableRecord.AppendEntity(bladeSolid);
                    transaction.AddNewlyCreatedDBObject(bladeSolid, true);                                                        

                    List<Entity> bladesPolarArray = MakeBladesPolarArray(bladeSolid);
                    // Проходим массив из лопастей и добавляем каждый объект в таблицу и транзакцию
                    foreach (Entity currentBlade in bladesPolarArray)
                    {
                        blockTableRecord.AppendEntity(currentBlade);
                        transaction.AddNewlyCreatedDBObject(currentBlade, true);
                    }
                    
                    // Коммитим
                    transaction.Commit();
                }                
            }
        }

        /// <summary>
        /// Возвращает полярные координаты
        /// </summary>
        /// <param name="pPt"></param>
        /// <param name="dAng"></param>
        /// <param name="dDist"></param>
        /// <returns></returns>
        static Point2d PolarPoints(Point2d pPt, double dAng, double dDist)
        {
            return new Point2d(pPt.X + dDist * Math.Cos(dAng), pPt.Y + dDist * Math.Sin(dAng));
        }

        /// <summary>
        /// Возвращает полярный массив лопастей
        /// </summary>
        /// <param name="bladeSolid"></param>
        /// <returns></returns>
        private List<Entity> MakeBladesPolarArray(Solid3d bladeSolid)
        {
            List<Entity> polarArray = new List<Entity>();

            // Create a 6 object polar array that goes a 360
            int nCount = 1;

            // Set a value in radians for 60 degrees
            double dAng = 1.0472;

            // Use (0,0,0) as the base point for the array
            Point2d acPt2dArrayBase = new Point2d(0, 0);

            while (nCount < ParametersKeeper.BladesQuantity)
            {                
                Entity acEntClone = bladeSolid.Clone() as Entity;

                Extents3d acExts;
                Point2d acPtObjBase;

                // Typically the upper-left corner of an object's extents is used
                // for the point on the object to be arrayed unless it is
                // an object like a circle.
                Circle acCircArrObj = acEntClone as Circle;

                if (acCircArrObj != null)
                {
                    acPtObjBase = new Point2d(acCircArrObj.Center.X,
                                                acCircArrObj.Center.Y);
                }
                else
                {
                    acExts = acEntClone.Bounds.GetValueOrDefault();
                    acPtObjBase = new Point2d(acExts.MinPoint.X,
                                                acExts.MaxPoint.Y);
                }

                double dDist = acPt2dArrayBase.GetDistanceTo(acPtObjBase);
                double dAngFromX = acPt2dArrayBase.GetVectorTo(acPtObjBase).Angle;               

                Point2d acPt2dTo = PolarPoints(acPt2dArrayBase,
                                                (nCount * dAng) + dAngFromX,
                                                dDist);

                Vector2d acVec2d = acPtObjBase.GetVectorTo(acPt2dTo);
                Vector3d acVec3d = new Vector3d(acVec2d.X, acVec2d.Y, 0);
                acEntClone.TransformBy(Matrix3d.Displacement(acVec3d));


                // The following code demonstrates how to rotate each object like
                // the ARRAY command does.
                acExts = acEntClone.Bounds.GetValueOrDefault();
                acPtObjBase = new Point2d(acExts.MinPoint.X,
                                            acExts.MaxPoint.Y);

                // Rotate the cloned entity around its upper-left extents point
                Matrix3d curUCSMatrix = Manager.Document.Editor.CurrentUserCoordinateSystem;
                CoordinateSystem3d curUCS = curUCSMatrix.CoordinateSystem3d;
                acEntClone.TransformBy(Matrix3d.Rotation(nCount * dAng, curUCS.Zaxis, new Point3d(acPtObjBase.X, acPtObjBase.Y, 0)));


                //blockTableRecord.AppendEntity(acEntClone);
                //transaction.AddNewlyCreatedDBObject(acEntClone, true);
                polarArray.Add(acEntClone);

                nCount = nCount + 1;
            }

            return polarArray;
        }

        /// <summary>
        /// Возвращает трехмерный объект рамки
        /// </summary>
        /// <returns></returns>
        private Solid3d MakeFrame()
        {
            double holesRadius = ParametersKeeper.HolesRadius;
            double halfOfFrameLength = ParametersKeeper.FrameLength / 2;

            // Создаём внешние стороны рамки
            Line lineA = new Line(new Point3d(halfOfFrameLength, halfOfFrameLength, 0),
                new Point3d(halfOfFrameLength, -halfOfFrameLength, 0));
            Line lineB = new Line(new Point3d(halfOfFrameLength, -halfOfFrameLength, 0),
                new Point3d(-halfOfFrameLength, -halfOfFrameLength, 0));
            Line lineC = new Line(new Point3d(-halfOfFrameLength, -halfOfFrameLength, 0),
                new Point3d(-halfOfFrameLength, halfOfFrameLength, 0));
            Line lineD = new Line(new Point3d(-halfOfFrameLength, halfOfFrameLength, 0),
                new Point3d(halfOfFrameLength, halfOfFrameLength, 0));

            // Создаём рамочные отверстия
            Circle upperRightCircle = new Circle();
            upperRightCircle.Center = new Point3d(halfOfFrameLength - 2, halfOfFrameLength - 2, 0);
            upperRightCircle.Radius = holesRadius;

            Circle bottomRightCircle = new Circle();
            bottomRightCircle.Center = new Point3d(halfOfFrameLength - 2, -halfOfFrameLength + 2, 0);
            bottomRightCircle.Radius = holesRadius;

            Circle bottomLeftCircle = new Circle();
            bottomLeftCircle.Center = new Point3d(-halfOfFrameLength + 2, -halfOfFrameLength + 2, 0);
            bottomLeftCircle.Radius = holesRadius;

            Circle upperLeftCircle = new Circle();
            upperLeftCircle.Center = new Point3d(-halfOfFrameLength + 2, halfOfFrameLength - 2, 0);
            upperLeftCircle.Radius = holesRadius;

            // Создаём центральное отверстие
            Circle centralCircle = new Circle();
            centralCircle.Center = new Point3d(0, 0, 0);
            centralCircle.Radius = 8;

            // Создаём полигон для рамки
            DBObjectCollection framePolygon = GetPolygon(lineA, lineB, lineC, lineD);
            framePolygon = AddToPolygon(framePolygon, upperRightCircle, bottomRightCircle, bottomLeftCircle,
                upperLeftCircle, centralCircle);

            // Создаём общую область из полигона для рамки
            DBObjectCollection frameRegion = Region.CreateFromCurves(framePolygon);
            Region linesRegion = frameRegion[0] as Region;

            // Вычитаем нужные области
            // Пропускаем нулевой индекс
            for (int index = 1; index < frameRegion.Count; index++)
            {
                linesRegion.BooleanOperation(BooleanOperationType.BoolSubtract, (Region)frameRegion[index]);
            }

            // Создаём рамку
            Solid3d frameSolid = new Solid3d();
            frameSolid.Extrude(linesRegion, 10, 0);

            return frameSolid;            
        }

        /// <summary>
        /// Возвращает трехмерный объект ротора
        /// </summary>
        /// <returns></returns>
        private Solid3d MakeRotor()
        {
            // Создаём ротор
            Circle rotorCircle = new Circle();
            rotorCircle.Center = new Point3d(0, 0, 0);
            rotorCircle.Radius = 0.4 * ParametersKeeper.CentralCircleRadius;

            // Создаём полигон для ротора
            DBObjectCollection rotorPolygon = new DBObjectCollection();
            rotorPolygon.Add(rotorCircle);

            // Создаём роторную область
            DBObjectCollection rotorRegion = Region.CreateFromCurves(rotorPolygon);            
            Region rotorCircleRegion = rotorRegion[0] as Region;

            // Создаём ротор
            Solid3d rotorSolid = new Solid3d();
            rotorSolid.Extrude(rotorCircleRegion, 10, 0);

            return rotorSolid;
        }

        /// <summary>
        /// Возвращает трехмерный объект лопасти
        /// </summary>
        /// <returns></returns>
        private Solid3d MakeBlade()
        {
            Solid3d bladeSolid = new Solid3d();
            bladeSolid.CreateBox(ParametersKeeper.BladeThickness, 4, 10);
            bladeSolid.TransformBy(Matrix3d.Displacement(new Point3d(0, -4, 5) - Point3d.Origin));

            // Повернём объект на 15 градусов вокруг оси, определенной вектором с точками
            //(0, 1, 5) and (0, -1, 5)
            Vector3d vectorRotate = new Point3d(0, 1, 5).GetVectorTo(new Point3d(0, -1, 5));
            bladeSolid.TransformBy(Matrix3d.Rotation(0.25, vectorRotate, new Point3d(0, 1, 5)));

            return bladeSolid;
        }

        /// <summary>
        /// Добавляет объекты к полигону
        /// </summary>
        /// <param name="polygon"></param>
        /// <param name="circles"></param>
        /// <returns></returns>
        private DBObjectCollection AddToPolygon(DBObjectCollection polygon, params Circle[] circles)
        {
            foreach (Circle currentCircle in circles)
            {
                polygon.Add(currentCircle);
            }

            return polygon;
        }

        /// <summary>
        /// Создаёт полигон из линий
        /// </summary>в
        /// <param name="lines"></param>
        /// <returns></returns>
        private DBObjectCollection GetPolygon(params Line[] lines)
        {
            DBObjectCollection polygon = new DBObjectCollection();

            foreach (Line currentLine in lines)
            {
                polygon.Add(currentLine);
            }

            return polygon;
        }
    }
}