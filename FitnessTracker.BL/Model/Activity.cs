using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessTracker.BL.Model
{
    [Serializable]
    public class Activity
    {
        public string Name { get; set; }
        public double CalloriesPerMinute { get; }

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
