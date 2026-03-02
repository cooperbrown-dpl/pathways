namespace s2w3ChallengeNS
{
    public class PostgradStudentGrader : IGrader
    {
        public double CalculateGrade(double grade1, double grade2, double grade3)
        {
            Console.WriteLine("Inside Grade method of PostgradStudentGrader.");
            // validate grades are between 0 and 100
            if (grade1 < 0 || grade1 > 100 ||
                grade2 < 0 || grade2 > 100 ||
                grade3 < 0 || grade3 > 100)
            {
                throw new System.ArgumentOutOfRangeException("Grades entered must be between 0 and 100.");
            }
            return GradePostgradStudent(grade1, grade2, grade3);
        }
        private double GradePostgradStudent(double grade1, double grade2, double grade3)
        {
            // Average of 3 grades
            double finalGrade = Math.Round(((grade1 + grade2 + grade3) / 3), 2);

            Console.WriteLine($"Final grade for postgrad student is: {finalGrade}.");

            return finalGrade;
        }
    }
}
