/**

* Calculate Age in C#

* https://gist.github.com/faisalman

*

* Copyright 2012-2013, Faisalman <fyzlman@gmail.com>

* Licensed under The MIT License

* http://www.opensource.org/licenses/mit-license

*/


using System;

public class Age

{

    public int Years { get; set; }

    public int Months { get; set; }

    public int Days { get; set; }

    public string FullAge
    {
        get
        {
            return "Years: " + Years.ToString() + "  Months: " + Months.ToString() + "  Days: " + Days.ToString();
        }
    }

    public Age(DateTime Bday)
    {

        Count(Bday);

    }

    //public Age(DateTime Bday, DateTime Cday)

    //{

    //    Count(Bday, Cday);

    //}



    public void Count(DateTime Bday)
    {

        Count(Bday, DateTime.Today);

    }



    private void Count(DateTime Bday, DateTime Cday)
    {

        if ((Cday.Year - Bday.Year) > 0 ||

            (((Cday.Year - Bday.Year) == 0) && ((Bday.Month < Cday.Month) ||

              ((Bday.Month == Cday.Month) && (Bday.Day <= Cday.Day)))))

        {

            int DaysInBdayMonth = DateTime.DaysInMonth(Bday.Year, Bday.Month);

            int DaysRemain = Cday.Day + (DaysInBdayMonth - Bday.Day);

            if (Cday.Month > Bday.Month)

            {

                this.Years = Cday.Year - Bday.Year;

                this.Months = Cday.Month - (Bday.Month + 1) + Math.Abs(DaysRemain / DaysInBdayMonth);

                this.Days = (DaysRemain % DaysInBdayMonth + DaysInBdayMonth) % DaysInBdayMonth;

            }

            else if (Cday.Month == Bday.Month)

            {

                if (Cday.Day >= Bday.Day)

                {

                    this.Years = Cday.Year - Bday.Year;

                    this.Months = 0;

                    this.Days = Cday.Day - Bday.Day;

                }

                else

                {

                    this.Years = (Cday.Year - 1) - Bday.Year;

                    this.Months = 11;

                    this.Days = DateTime.DaysInMonth(Bday.Year, Bday.Month) - (Bday.Day - Cday.Day);

                }

            }

            else

            {

                this.Years = (Cday.Year - 1) - Bday.Year;

                this.Months = Cday.Month + (11 - Bday.Month) + Math.Abs(DaysRemain / DaysInBdayMonth);

                this.Days = (DaysRemain % DaysInBdayMonth + DaysInBdayMonth) % DaysInBdayMonth;

            }

        }

        else

        {

            throw new ArgumentException("Birthday date must be earlier than current date");

        }
    }

    private DateTime CalculateAge(DateTime DateOfBirth)
    {
        //Get DateTime of Now.
        var now = DateTime.Now;
        //Get Month of Birth.
        var currentMonth = DateOfBirth.Month;
        //Actual Age.
        Years = 0;
        Months = 0;
        //Get Days count from birthday to now.
        Days = (now - DateOfBirth).Days;

        //It means that the days is more than month.
        while (Days >= MonthDays(currentMonth))
        {
            Months++; //Add one Month
                      //Remove the current Month days from life Days.
            Days -= MonthDays(currentMonth);

            if (Months == 12)
            {   //If it's December then:
                Years++; //Add new Year.
                Months = 0; //Clear Months.
            }

            //If current month reached 12 set it to 0
            if (currentMonth == 12)
                currentMonth = 0;
            //Move to next Month.
            currentMonth++;
        }

        //Every 4 years the current February days= 29 not 28
        var daysToRemove = Convert.ToInt32(Years / 4);

        //Remove these days as today to calculate days correct.
        var editedDate = new DateTime(now.Year, now.Month, Days)
            .AddDays(-daysToRemove);

        //Just take days only, calculate years and months.
        return new DateTime((editedDate.Year - now.Year) + Years,
           (editedDate.Month - now.Month) + Months, editedDate.Day);
    }
    int MonthDays(int Month)
    {
        switch (Month)
        {   //Month: Days.
            case 1: return 31;
            case 2: return 28;
            case 3: return 31;
            case 4: return 30;
            case 5: return 31;
            case 6: return 30;
            case 7: return 31;
            case 8: return 31;
            case 9: return 30;
            case 10: return 31;
            case 11: return 30;
            case 12: return 31;
            default: return 0;
        }
    }
}





/**

 * Usage example:

 * ==============

 * DateTime bday = new DateTime(1987, 11, 27);

 * DateTime cday = DateTime.Today;

 * Age age = new Age(bday, cday);

 * Console.WriteLine("It's been {0} years, {1} months, and {2} days since your birthday", age.Year, age.Month, age.Day);

 */
