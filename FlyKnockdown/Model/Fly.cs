namespace FlyKnockdown.Model
{
    internal class Fly
    {
        private int timeAlive = 0;
        private string groupName = "";
        private string[] movement;

        public Fly(string[] movement)
        {
            this.movement = movement;
        }

        public string[] getMovement()
        {
            return movement;
        }

        public void setTimeAlive(int timeAlive)
        {
            this.timeAlive = timeAlive;
        }

        public int getTimeAlive() 
        {
            return this.timeAlive;
        }

        public void setGroupName(string groupName)
        {
            this.groupName = groupName;
        }

        public string getGroupName() 
        {
            return this.groupName;
        }

    }
}
