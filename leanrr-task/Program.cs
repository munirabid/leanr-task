using System;

namespace leanrr_task
{
    class Program
    {
        static void Main(string[] args)
        {
            var workdays = NumberOfWorkdays(GetDate("2022-01-11"), GetDate("2022-02-01"));
            Console.WriteLine(workdays == 21 ? "Passed" : "Failed");
            workdays = NumberOfWorkdays(GetDate("2022-01-03"), GetDate("2022-01-07"));
            Console.WriteLine(workdays == 4 ? "Passed" : "Failed");
            workdays = NumberOfWorkdays(GetDate("2022-01-07"), GetDate("2022-01-07"));
            Console.WriteLine(workdays == 0 ? "Passed" : "Failed");
            workdays = NumberOfWorkdays(GetDate("2022-01-08"), GetDate("2022-01-10"));
            Console.WriteLine(workdays == 0 ? "Passed" : "Failed");
            try
            {
                NumberOfWorkdays(GetDate("2022-01-18"), GetDate("2022-01-10"));
                Console.WriteLine("Failed");
            }
            catch (Exception)
            {
                Console.WriteLine("Passed");
            }
        }

        public static DateTime GetDate(string dateTime)
        {
            DateTime oDate = DateTime.ParseExact(dateTime, "yyyy-MM-dd", null);

            return oDate;
        }

        /// <summary>
        /// This method should return the number of workdays (monday to friday) between the specified dates
        /// You do not need to take holidays into account.
        /// The start date is included in the range, the end date is excluded
        /// Using external libraries is not allowed.
        /// </summary>
        public static int NumberOfWorkdays(DateTime startDate, DateTime endDate)
        {
            DateTime startingDay = startDate.Date;
            DateTime endingDay = endDate.Date.AddDays(-1);

            if (startingDay > endingDay)
            {
                return 0;
            }

            TimeSpan timeSpan = endingDay - startingDay;
            int workingDays = timeSpan.Days + 1;
            int fullWeekCount = workingDays / 7;
            // check if there are weekends
            if (workingDays > fullWeekCount * 7)
            {
                // if out if weekends if of 1-day or 2-days
                int firstDayOfWeek = (int)startingDay.DayOfWeek;
                int lastDayOfWeek = (int)endingDay.DayOfWeek;
                if (lastDayOfWeek < firstDayOfWeek)
                    lastDayOfWeek += 7;
                if (firstDayOfWeek <= 6)
                {
                    if (lastDayOfWeek >= 7)// saturday and sunday are in remaining time
                        workingDays -= 2;
                    else if (lastDayOfWeek >= 6)// saturday is in the remaining time
                        workingDays -= 1;
                }
                else if (firstDayOfWeek <= 7 && lastDayOfWeek >= 7)// sunday is in the remaining time
                    workingDays -= 1;
            }

            return workingDays;
        }
    }
}
