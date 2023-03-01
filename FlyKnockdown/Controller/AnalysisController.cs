using FlyKnockdown.Model;
using FlyKnockdown.View;

namespace FlyKnockdown.Controller
{
    internal static class AnalysisController
    {
        public static void assignKnockdown(Fly fly, String[,] timeIntervals)
        {
            int movementIndex = fly.getMovement().Length - 1;
            string timesCrossed = "0";
            while(movementIndex >= 0 && timesCrossed.Equals("0"))
            {
                timesCrossed = fly.getMovement()[movementIndex];
                movementIndex--;
            }

            DateTime start = DateTime.Parse(timeIntervals[0,0] + " " + timeIntervals[0,1]);
            DateTime end = DateTime.Parse(timeIntervals[movementIndex+1,0] + " " + 
                                          timeIntervals[movementIndex+1,1]);

            TimeSpan timeAlive = end - start;
            fly.setTimeAlive(timeAlive.TotalMinutes);
        }
    }
}
