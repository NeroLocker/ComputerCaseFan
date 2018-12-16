using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;

namespace ComputerCaseFan
{
    /// <summary>
    /// Сущность для коммуникации с AutoCad
    /// </summary>
    class CADManager
    {
        private Document _document;

        /// <summary>
        /// Хранит базу данных
        /// </summary>
        private Database _database;

        /// <summary>
        /// Хранит сущность редактора
        /// </summary>
        private Editor _editor;
       
        public Document Document
        {
            get { return _document; }
            private set { _document = value; }
        }

        public Database Database
        {
            get { return _database; }
            private set { _database = value; }
        }

        public Editor Editor
        {
            get { return _editor; }
            private set { _editor = value; }
        }

        public CADManager()
        {
            // Инициализируем поля
            this.Document = Application.DocumentManager.MdiActiveDocument;
            this.Database = this.Document.Database;
            this.Editor = Application.DocumentManager.MdiActiveDocument.Editor;

            this.SayHello();
        }

        private void SayHello()
        {
            this.Editor.WriteMessage("Link is set");
        }

        /// <summary>
        /// Возвращает таблицу записей
        /// </summary>
        /// <param name="database"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public BlockTableRecord GetBlockTableRecord(Database database, Transaction transaction)
        {
            // Открываем block table (таблицу сущностей) на чтение
            BlockTable blockTable = transaction.GetObject(database.BlockTableId, OpenMode.ForRead) as BlockTable;

            // Открываем пространство модели block table record на запись
            BlockTableRecord blockTableRecord = transaction.GetObject(blockTable[BlockTableRecord.ModelSpace],
                    OpenMode.ForWrite) as BlockTableRecord;

            return blockTableRecord;
        }
    }
}
