using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;
using System.Data.Entity;
namespace Schedule.Models
{
    public class Excelparser
    {
        public void excelParser(WorkContext workContext)
        {
            List<Worker> workList = new List<Worker>();
            List<ShiftWorker> shiftWorkerList = new List<ShiftWorker>();
            DataTable dt = new DataTable();
            IQueryable<Worker> workerQuery;
            IQueryable<Shift> shiftQuery;
            XSSFWorkbook xssfwb;
            Worker worker = new Worker();
            Shift shift = new Shift();
            DateTime date = new DateTime();
            double dateValue = 1;
            string cell = "-1";
            string filePath = @"C:\Users\jarjoa\Documents\Visual Studio 2015\Projects\WebApplication1\WebApplication1\Schema.xlsx";
            bool vacation = false;
            string reason = "";
            using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                xssfwb = new XSSFWorkbook(file);
            }
            
            ISheet sheet = xssfwb.GetSheet("Schema1");
            shiftQuery = workContext.shifts;
            workerQuery = workContext.workers;
            

            for (int row = 4; row <= 54; row++)
            {
                if (sheet.GetRow(row) != null)
                {

                    int nrOfCells = sheet.GetRow(row).LastCellNum - 1;
                    

                    for(int cellNr = 0; cellNr <= nrOfCells; cellNr++ )
                    {
                        
                        try
                        {
                            cell = sheet.GetRow(row).GetCell(cellNr).ToString().ToLower();
                        }

                        catch (NullReferenceException e) { }


                        if (cellNr == 0 && cell == "")
                        {
                            row++;
                            cellNr--;
                        }
                        else
                        {
                            if (cellNr == 0)
                            {
                                
                                date = DateTime.Parse("2016.01.01");
                                if (cell != "" && cell != null)
                                {
                                    worker = checkWorker(workerQuery, cell);
                                    workList.Add(worker);
                                }
                            }

                            else
                            {
                                shift = checkShift(shiftQuery, cell);
                                vacation = false;
                                reason = "";
                                if(shift.shiftId.ToLower().Contains("s"))
                                {
                                    vacation = true;
                                    if(shift.shiftId.ToLower().Contains("f"))
                                    {
                                        reason = "Föräldraledighet";
                                    }
                                    else if (shift.shiftId.ToLower().Contains("t"))
                                    {
                                        reason = "Tjänstledighet";
                                    }

                                }
                                if(shift.shiftId.ToLower().Contains("bl"))
                                {
                                    vacation = true;
                                    reason = "beredskapsledig";
                                }
                                shiftWorkerList.Add(addShiftWorker(worker, shift, date, vacation, reason));
                                date = date.AddDays(dateValue);
                            }

                        }
                                              
                    }

                }
            }
            //Behöver hantera 5sb etc N: Hitta ett sätt att göra det programmatiskt tex med concat string och sedan plockja de enstaka bokstäverna. Lägga upp allt blir bara jobbigt.
            //kanske behöver skapa en till class medd avvikelser från pass med olika värden som man kan lägga till som foreign key.
            //shiftWorkerList.ForEach(c => workContext.shiftworkers.Add(c));
            foreach(var c in shiftWorkerList)
            {
                dateValue++;
                workContext.shiftworkers.Add(c);
                workContext.SaveChanges();
            }
            int h = 0;
        }

        public Worker checkWorker(IQueryable<Worker> workerQuery, string surName)
        {
            Worker match = new Worker();
            var query = from Schedule.Models.Worker worker in workerQuery
                      where worker.workerSurName == surName
                    select worker;
            /*List<Worker> query = new List<Worker>();
           // int i = 0;
            foreach(var item in workerQuery.loc)
            {
                if(item.workerSurName.Equals(surName))
                {
                    query.Add(item);
                }
                else { }
            }*/
            if(query.Count() == 1)
            {
                match = query.First();
            }
            else
            {
                //match.workerName = "unknown";
                match.workerName = surName;
            }
            return match;
        }

        public Shift checkShift(IQueryable<Shift> shiftQuery, string shiftId )
        {
            Shift match = new Shift();
            if (shiftId == "")
            {
                shiftId = "0";
            }
            if(shiftId.ToLower().Contains("s"))
            {
                
            }
            var query = from Shift shift in shiftQuery
                        where shift.shiftId == shiftId
                        select shift;

            if (query.Count() == 1)
            {
                match = query.First();
                
            }

            else
            {
                match.shiftId = shiftId;
            }
            
            return match;
        }

        public ShiftWorker addShiftWorker(Worker worker, Shift shift, DateTime date , bool vacation ,string reason)
        {
            ShiftWorker shiftWorker = new ShiftWorker();
            shiftWorker.shift = shift;
            shiftWorker.worker = worker;
            shiftWorker.date = date.ToString();
            shiftWorker.vacation = vacation;
            shiftWorker.vacationReason = reason;
            return shiftWorker;
        }
    }
}

/*
public void parser()
{
    // Displays an OpenFileDialog so the user can select a Cursor.
    OpenFileDialog openFileDialog1 = new OpenFileDialog();
    openFileDialog1.Filter = "excelfiler|*.xls";
    openFileDialog1.Title = "välv personalfilen";
    DataTable dt = new DataTable();
    // Show the Dialog.
    // If the user clicked OK in the dialog and
    // a .CUR file was selected, open it.
    if (openFileDialog1.ShowDialog() == DialogResult.OK)
    {
        string filepath = openFileDialog1.FileName;

    }
    HSSFWorkbook hssfwb;
    using (FileStream file = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read))
    {
        hssfwb = new HSSFWorkbook(file);
    }

    ISheet sheet = hssfwb.GetSheet("Blad1");
    PList.Clear();
    List<Personal> temp = new List<Personal>();
    for (int row = 0; row <= sheet.LastRowNum; row++)
    {
        if (sheet.GetRow(row) != null) //null is when the row only contains empty cells 
        {  /*
                    MessageBox.Show(string.Format("Row {0} = {1}", row, sheet.GetRow(row).GetCell(0).StringCellValue));
                    MessageBox.Show(string.Format("Row {0} = {1}", row, sheet.GetRow(row).GetCell(1).StringCellValue));
            string i = "-1";
            try
            {
                i = sheet.GetRow(row).GetCell(0).StringCellValue;
            }
            catch { }
            if (i != "-1")
            {
                Personal p = new Personal(sheet.GetRow(row).GetCell(2).StringCellValue.ToLower(),
                    sheet.GetRow(row).GetCell(1).StringCellValue.ToLower(),
                    i);
                temp.Add(p);
            }

        }
    }
    if (temp.Count > 0)
    {
        PList = temp;
    }
    refreshlists();






}*/