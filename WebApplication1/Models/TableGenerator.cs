using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Schedule.Models
{
    public class TableGenerator
    {
        static public DataTable generate(DateTime date, string span, List<int> groups)
        {
            DataTable dt = new DataTable();
            DateTime toDate;
            if (span.Equals("day"))
            {
                toDate = date;
            } else if (span.Equals("week"))
            {
                date = date.AddDays(-(int)date.DayOfWeek + (int)DayOfWeek.Monday);
                toDate = date.AddDays(7);
            } else
            {
                toDate = date.AddMonths(1);
            }
            var shiftworkers = ShiftWorker.get(date, toDate, groups);
            Dictionary<string, int> addedWorkers = new Dictionary<string, int>();
            int counter = 0;
            dt.Columns.Add(new DataColumn("Name"));
            foreach (var s in shiftworkers)
            {
                if (!dt.Columns.Contains(s.date.ToShortDateString()))
                {
                    dt.Columns.Add(new DataColumn(s.date.ToShortDateString()));
                }
                string shiftId = s.shift.shiftId;
                if (s.vacation)
                {
                    shiftId = shiftId + "s";
                }
                if (!addedWorkers.Keys.Contains(s.worker.workerName + " " + s.worker.workerSurName))
                {
                    DataRow row = dt.NewRow();
                    row["Name"] = s.worker.workerName + " " + s.worker.workerSurName;
                    row[s.date.ToShortDateString()] = shiftId;
                    dt.Rows.Add(row);
                    addedWorkers[s.worker.workerName + " " + s.worker.workerSurName] = counter;
                    counter++;

                }
                else
                {
                    dt.Rows[addedWorkers[s.worker.workerName + " " + s.worker.workerSurName]][s.date.ToShortDateString()] = shiftId;
                }
            }
            return dt;
        }
    }
}