namespace s2w3ChallengeNS
{
    class Program
    {
        static void Main(string[] args)
        {
            IGrader grader = new UndergradStudentGrader();
            IGrader grader2 = new PostgradStudentGrader();

            GradingService gradingService = new GradingService(grader);
            gradingService.CalculateGrade(85, 87, 94);

            GradingService gradingService2 = new GradingService(grader2);
            gradingService2.CalculateGrade(91, 77, 88);
        }

    }
}