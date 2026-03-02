using s2w3ChallengeNS;

namespace UndergradStudentTestsNS
{
    [TestClass]
    public sealed class UndergradStudentTests
    {
        [TestMethod]
        public void CalculateGrade_ValidInputs_ReturnsWeightedAverage()
        {
            // Arrange
            double expected = 85.3;
            var grader1 = new UndergradStudentGrader();

            // Act
            double actual = grader1.CalculateGrade(91, 77, 88);

            // Assert
            Assert.AreEqual(expected, actual, 0.0001, "Weighted Average not calculated correctly");
        }

        [TestMethod]
        public void CalculateGrade_InputBelowZero_ThrowsException()
        {
            // Arrange
            var grader2 = new UndergradStudentGrader();

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                grader2.CalculateGrade(94, -1, 80);
            });
        }

        [TestMethod]
        public void CalculateGrade_InputAboveOneHundred_ThrowsException()
        {
            // Arrange
            var grader2 = new UndergradStudentGrader();

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                grader2.CalculateGrade(94, 101, 80);
            });
        }
    }
}
