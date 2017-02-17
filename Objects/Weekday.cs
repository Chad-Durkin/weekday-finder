using System;
using System.Collections.Generic;

 namespace WeekdayApp.Objects
 {
     public class Weekday
     {
       private int _month;
       private int _day;
       private int _year;
       private string _date;
       private bool _leapyear;
       private bool _legalday;
       private int _dayOfWeek;
       private string _finalDayOfWeek;
       private static List<Weekday> _allWeekdays = new List<Weekday>();
       private static Dictionary<int, string> _correspondingDay = new Dictionary<int, string>() {{0, "Sunday"}, {1, "Monday"}, {2, "Tuesday"}, {3, "Wednesday"}, {4, "Thursday"}, {5, "Friday"}, {6, "Saturday"}};
       //  private int[] thirtyOneMonths = new int[] {1, 3, 5, 7, 8, 10, }

       public Weekday(int month, int day, int year)
       {
         _month = month;
         _day = day;
         _year = year;
         _date = _month + "-" + _day + "-" + _year;
         _leapyear = LeapYear();
         _legalday = CheckMonthsDays();
         _dayOfWeek = FindTheWeekDay();
         _finalDayOfWeek = ConvertToWeekDay();
         Console.WriteLine(_finalDayOfWeek);
         _allWeekdays.Add(this);
       }

       //Check for leap Year
       public bool LeapYear()
       {
         if((_year % 100) == 0)
         {
           if((_year % 400) == 0)
           {
             return true;
           }
           else
           {
             return false;
           }
         }

         if((_year % 4) == 0)
         {
           return true;
         }

         return false;
       }
       //Check for Months Day limit
       public bool CheckMonthsDays()
       {
         if(_leapyear == true && _month == 2)
         {
           if(_day > 29)
           {
             return false;
           }
         }
         else
         {
          if(_month == 2 && _day > 28)
          {
            return false;
          }
          else if((_month < 8 && (_month % 2 != 0)) || (_month > 7 && (_month % 2 == 0)))
          {
            if(_day > 31)
            {
              return false;
            }
          }
          else
          {
            if(_day > 30)
            {
              return false;
            }
          }
         }

         return true;
       }
       //Get int version of day of the week
       public int FindTheWeekDay()
       {
         string newYear = _year.ToString();
         string strLastTwo = newYear.Substring(2, 2);
         string strFirstTwo = newYear.Substring(0, 2);
         int lastTwo = int.Parse(strLastTwo);
         int firstTwo = int.Parse(strFirstTwo);
         int dayOfWeek;
         string nameOfDay;
         int newMonth = _month + 10;
         if(newMonth > 12)
         {
           newMonth = newMonth - 12;
         }
         else{
           lastTwo = lastTwo - 1;
         }

         int divideThis = (_day + ((13*newMonth) / 5) + lastTwo + (lastTwo/4) + (firstTwo/4) - (2*firstTwo));

         if(divideThis > 0)
         {
           dayOfWeek = divideThis % 7;
         }
         else if(divideThis < 0)
         {
           dayOfWeek = (divideThis * -1) / 7;
           dayOfWeek = ((dayOfWeek * 7) + divideThis) + 7;
         }
         else{
           dayOfWeek = divideThis;
         }
         return dayOfWeek;
       }
       //Convert int into string version of day of week
       public string ConvertToWeekDay()
       {
         return _correspondingDay[_dayOfWeek];
       }
       //Getters and Setters
       public string GetFinalDay()
       {
         return _finalDayOfWeek;
       }
       public int GetDayOfTheYear()
       {
         return _dayOfWeek;
       }
       public bool GetLegalDay()
       {
         return _legalday;
       }
       public bool GetLeapYear()
       {
         return _leapyear;
       }
       public void SetDay(int day)
       {
         _day = day;
       }
       public int GetDay()
       {
         return _day;
       }
       public void SetMonth(int month)
       {
         _month = month;
       }
       public int GetMonth()
       {
         return _month;
       }
       public void SetYear(int year)
       {
         _year = year;
       }
       public int GetYear()
       {
         return _year;
       }
       public string GetDate()
       {
         return _date;
       }
       public static void DeleteAll()
       {
         _allWeekdays.Clear();
       }
     }
 }
