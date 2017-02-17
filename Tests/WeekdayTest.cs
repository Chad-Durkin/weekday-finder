using Xunit;
using WeekdayApp.Objects;
using System;
using System.Collections.Generic;

namespace WeekdayAppTest
{
    public class WeekdayAppTest : IDisposable
    {
        [Fact]
        public void WeekdayConstructor_DefiningPrivateVariables_ConcatingDate()
        {
            //arrange
            int month = 07;
            int day = 06;
            int year = 1993;
            string date = month + "-" + day + "-" + year;
            //act
            Weekday newWeekday = new Weekday(month, day, year);
            //assert
            Assert.Equal(date, newWeekday.GetDate());
        }

        [Fact]
        public void WeekdayConstructor_SettingLeapYear_CorrectBool()
        {
            //arrange
            bool checkLeapyear = true;
            int month = 07;
            int day = 06;
            int year = 2000;
            //act
            Weekday newWeekday = new Weekday(month, day, year);
            //assert
            Assert.Equal(checkLeapyear, newWeekday.GetLeapYear());
        }

        [Fact]
        public void WeekdayConstructor_SettingLegalDay_CorrectBool()
        {
            //arrange
            bool checkLegalDay = false;
            int month = 2;
            int day = 29;
            int year = 1993;
            //act
            Weekday newWeekday = new Weekday(month, day, year);
            //assert
            Assert.Equal(checkLegalDay, newWeekday.GetLegalDay());
        }

        [Fact]
        public void WeekdayConstructor_SettingDayOfTheWeek_CorrectInt()
        {
            //arrange
            int dayOfTheYear = 2;
            int month = 1;
            int day = 29;
            int year = 2064;
            //act
            Weekday newWeekday = new Weekday(month, day, year);
            //assert
            Assert.Equal(dayOfTheYear, newWeekday.GetDayOfTheYear());
        }

        [Fact]
        public void WeekdayConstructor_FinalDayOfTheWeek_CorrectString()
        {
            //arrange
            string dayOfTheYear = "Thursday";
            int month = 2;
            int day = 16;
            int year = 2017;
            //act
            Weekday newWeekday = new Weekday(month, day, year);
            //assert
            Assert.Equal(dayOfTheYear, newWeekday.GetFinalDay());
        }



        public void Dispose()
        {
          Weekday.DeleteAll();
        }
    }
}
