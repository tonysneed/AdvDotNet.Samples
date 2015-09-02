using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reactive.Linq;
using Microsoft.Reactive.Testing;

namespace RxTesting
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class RxTests : ReactiveTest
    {
        [TestMethod]
        public void ToObservable_Should_Filter_Enumerable()
        {
            // Act
            var actualObs = GetInts().ToObservable().Where(i => i % 2 == 0);
            var expectedObs = new int[]{ 2, 4, 6, 8, 10, 12 }.ToObservable(); 

            // Assert
            ReactiveAssert.AreElementsEqual(expectedObs, actualObs);
        }

        [TestMethod]
        public void Interval_Should_Return_Items_Based_On_Count()
        {
            // Arrange
            var scheduler = new TestScheduler();
            var expected = new long[] { 0, 1, 2, 3, 4, 5 };
            var actual = new List<long>();
            
            // Act
            var intervalObs = Observable.Interval(TimeSpan.FromSeconds(1), scheduler)
                .Take(6);
            intervalObs.Subscribe(i => actual.Add(i));
            scheduler.Start();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Interval_Should_Return_Items_Based_On_Duration()
        {
            // Arrange
            var scheduler = new TestScheduler();
            var expected = new long[] { 0, 1, 2, 3, 4, 5 };
            var actual = new List<long>();

            // Act
            var intervalObs = Observable.Interval(TimeSpan.FromSeconds(1), scheduler)
                .Take(TimeSpan.FromSeconds(6.5), scheduler);
            intervalObs.Subscribe(i => actual.Add(i));
            scheduler.Start();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Delay_Should_Offset_Completion_Time()
        {
            // Arrange
            var scheduler = new TestScheduler();

            // Act
            var startTime = scheduler.Now;
            DateTimeOffset expectedEndTime = startTime.AddSeconds(8);
            DateTimeOffset actualyEndTime = default(DateTimeOffset);
            var delayObs = Observable.Interval(TimeSpan.FromSeconds(1), scheduler)
                .Delay(TimeSpan.FromSeconds(2), scheduler)
                .Take(6).Timestamp(scheduler);
            delayObs.Subscribe(ts => actualyEndTime = ts.Timestamp);
            scheduler.Start();

            // Assert
            Assert.AreEqual(expectedEndTime, actualyEndTime);
        }

        private int[] GetInts()
        {
            int[] ints = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            return ints;
        }
    }
}
