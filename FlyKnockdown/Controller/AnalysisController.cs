using FlyKnockdown.Model;
using FlyKnockdown.View;

namespace FlyKnockdown.Controller
{
    internal static class AnalysisController
    {
        public static void assignKnockdown(Fly fly, String[,] timeIntervals)
        {
            // Starting at the bottom of the movement data, keep track of
            // when the first non 0 value occurs.
            int movementIndex = fly.getMovement().Length - 1;
            string timesCrossed = "0";
            while(movementIndex >= 0 && timesCrossed.Equals("0"))
            {
                timesCrossed = fly.getMovement()[movementIndex];
                movementIndex--;
            }

            // Calculate the amount of time that took place between the
            // beginning and the end of the fly's movement.
            DateTime start = DateTime.Parse(timeIntervals[0,0] + " " + timeIntervals[0,1]);
            DateTime end = DateTime.Parse(timeIntervals[movementIndex+1,0] + " " + 
                                          timeIntervals[movementIndex+1,1]);
            TimeSpan timeAlive = end - start;
            fly.setTimeAlive(timeAlive.TotalMinutes); // Mark the calculated value as the fly's time alive.
        }
    }
}
