using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessTracker.BL.Model
{
    [Serializable]
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }
        public double CalloriesPerMinute { get; set; }

        public Activity()
        {

        }
        public Activity(string name, double caloriesPerMinute)
        {
            //check 

            Name = name;
            CalloriesPerMinute = caloriesPerMinute;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
