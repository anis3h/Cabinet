using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CoreUnitTests.ApplicationCore.Helper {

    public class AgeTests {

        [Theory]
        [MemberData(nameof(TestData))]
        public void Count_DatesShouldCount(DateTime bDay, DateTime cDay, int expectedYear, int expectedMonth, int expectedDay) {

            // Arrange // Act
            var age = new Age(bDay, cDay);           

            // Assert
            Assert.Equal(expectedYear, age.Years);
            Assert.Equal(expectedMonth, age.Months);
            Assert.Equal(expectedDay, age.Days);
        }

        [Fact]
        public void FullAge_ShouldReturnRightString() {

            // Arrange
            var bDay = new DateTime(2017, 5, 9);
            var cDay = new DateTime(2018, 9, 18);

            // Act
            var age = new Age(bDay, cDay);

            // Assert
            Assert.Equal("Years: 1  Months: 4  Days: 9", age.FullAge);
        }


        public static IEnumerable<object[]> TestData() {

            yield return new object[] { new DateTime(2018, 9, 9), new DateTime(2018, 9, 18), 0, 0, 9 };
            yield return new object[] { new DateTime(2018, 5, 5), new DateTime(2018, 9, 18), 0, 4, 13 };
            yield return new object[] { new DateTime(2017, 5, 9), new DateTime(2018, 9, 18), 1, 4, 9 };
            yield return new object[] { new DateTime(2013, 3, 21), new DateTime(2018, 9, 18), 5, 5, 28 };
            yield return new object[] { new DateTime(2008, 7, 12), new DateTime(2018, 9, 18), 10, 2, 6 };
        }
    }
}
