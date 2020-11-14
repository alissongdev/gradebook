using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void InMemoryBookBookCalculatesAnAverageGrade()
        {
            // Arrange
            var book = new InMemoryBook("Test's Book");
            book.AddGrade(76.3);
            book.AddGrade(84.7);
            book.AddGrade(92.6);

            // Act
            var result = book.GetStatistics();

            // Assert
            Assert.Equal(84.5, result.Average, 1);
            Assert.Equal(92.6, result.High, 1);
            Assert.Equal(76.3, result.Low, 1);
            Assert.Equal('B', result.Letter);
        }

        [Fact]
        public void DiskBookCalculatesAnAverageGrade()
        {
            // Arrange
            var book = new DiskBook("Test's Book");
            book.AddGrade(76.3);
            book.AddGrade(84.7);
            book.AddGrade(92.6);

            // Act
            var result = book.GetStatistics();

            // Assert
            Assert.Equal(84.5, result.Average, 1);
            Assert.Equal(92.6, result.High, 1);
            Assert.Equal(76.3, result.Low, 1);
            Assert.Equal('B', result.Letter);
        }

        [Fact]
        public void InMemoryBookAddGradeArgumentException()
        {
            // Arrange
            var book = new InMemoryBook("Test's Book");

            // Assert & Act
            Assert.Throws<ArgumentException>(() => book.AddGrade(105.0));
        }

        [Fact]
        public void DiskBookAddGradeArgumentException()
        {
            // Arrange
            var book = new DiskBook("Test's Book");

            // Assert & Act
            Assert.Throws<ArgumentException>(() => book.AddGrade(110.0));
        }
    }
}
