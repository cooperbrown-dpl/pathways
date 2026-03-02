using s2w3ChallengeNS;

namespace PostgradStudentTests
{
    [TestClass]
    public sealed class PostgradStudentTests
    {
        [TestMethod]
        public void CalculateGrade_ValidInputs_ReturnsAverage()
        {
            // Arrange
            double expected = 83.67;
            var grader2 = new PostgradStudentGrader();

            // Act
            double actual = grader2.CalculateGrade(76, 85, 90);

            // Assert
            Assert.AreEqual(expected, actual, 0.0001, "Average not calculated correctly");
        }

        [TestMethod]
        public void CalculateGrade_InputBelowZero_ThrowsException()
        {
            // Arrange
            var grader2 = new PostgradStudentGrader();

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                grader2.CalculateGrade(94, -10, 80);
            });
        }

        [TestMethod]
        public void CalculateGrade_InputAboveOneHundred_ThrowsException()
        {
            // Arrange
            var grader2 = new PostgradStudentGrader();

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                grader2.CalculateGrade(94, 44, 101);
            });
        }
    }
}
