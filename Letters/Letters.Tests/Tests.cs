using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Letters.Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void Verify_First_Last_Is_Properly_Inserted_At_Back()
        {
            // Arrange
            var testBoard = new List<char>() { 'f', 'z', 'c', 't', 'v', 'g' };

            // Act
            var first = testBoard[0];
            testBoard.RemoveAt(0);
            testBoard.Insert(testBoard.Count, first);

            // Assert
            Assert.AreEqual('f', testBoard[^1]);
        }

        [TestMethod]
        public void Verify_Remove_Last_Is_Properly_Inserted_At_Front()
        {
            // Arrange
            var testBoard = new List<char>() { 'f', 'z', 'c', 't', 'v', 'g' };

            // Act
            var last = testBoard[^1];
            testBoard.RemoveAt(testBoard.Count - 1);
            testBoard.Insert(0, last);

            // Assert
            Assert.AreEqual('g', testBoard[0]);
        }

        [TestMethod]
        public void Verify_Board_Calculates_True_Index_Location()
        {
            // Arrange
            var testBoard = new List<char>() { 'a', 'z', 'c', 't', 'v', 'a' };

            // Act
            var index = Board.Index(testBoard, 'a');

            // Assert
            Assert.AreEqual(5, index);
        }

        [TestMethod]
        public void Verify_Board_Calculates_True_Index_Location_01()
        {
            // Arrange
            var testBoard = new List<char>() { 'a', 'z', 'c', 't', 'v', 'f' };

            // Act
            var index = Board.Index(testBoard, 'a');

            // Assert
            Assert.AreEqual(0, index);
        }

        [TestMethod]
        public void Verify_Board_Calculates_True_Index_Location_02()
        {
            // Arrange
            var testBoard = new List<char>() { 'a', 'z', 'a', 't', 'a', 'f' };

            // Act
            var index = Board.Index(testBoard, 'a');

            // Assert
            Assert.AreEqual(4, index);
        }

        [TestMethod]
        public void Verify_MidPoint_Calculations_On_An_Even_Length_String()
        {
            // Arrange
            var testBoard = new List<char>() { 'a', 'z', 'c', 't', 'v', 'a' };

            // Act
            var midpoint = Board.FindMidpointIndex(testBoard);

            // Assert
            Assert.AreEqual(3, midpoint);
        }

        [TestMethod]
        public void Verify_MidPoint_Calculations_On_An_Odd_Length_String()
        {
            // Arrange
            var testBoard = new List<char>() { 'a', 'z', 'c', 't', 'v' };

            // Act
            var midpoint = Board.FindMidpointIndex(testBoard);

            // Assert
            Assert.AreEqual(2, midpoint);
        }

        [TestMethod]
        public void Verify_Calculate_Moves_Using_Cat()
        {
            // Arrange
            var testBoard = new List<char>() { 'a', 'z', 'c', 't', 'v', 'a' };
            var word = "cat";

            // Act
            var moves = Board.CalculateMoves(testBoard, word);
            var expected = new List<Move>
            {
                new Move(Direction.Left),
                new Move(Direction.Left),
                new Move(Direction.Left, 'c'),
                new Move(Direction.Right),
                new Move(Direction.Right, 'a'),
                new Move(Direction.Left),
                new Move(Direction.Left, 't'),
            };

            // Assert
            expected.Should().Equal(moves);
        }

        [TestMethod]
        public void Verify_Calculate_Moves_Using_Tv()
        {
            // Arrange
            var testBoard = new List<char>() { 'a', 'z', 'c', 't', 'v', 'a' };
            var word = "tv";

            // Act
            var moves = Board.CalculateMoves(testBoard, word);
            var expected = new List<Move>
            {
                new Move(Direction.Right),
                new Move(Direction.Right),
                new Move(Direction.Right, 't'),
                new Move(Direction.Left, 'v')
            };

            // Assert
            expected.Should().Equal(moves);
        }
    }
}