using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessTracker.BL.Model
{
    [Serializable]
    public class Food
    {
        public int Id { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; }
        public double Callories { get; set; }

        /// <summary>
        /// Proteins
        /// </summary>
        public double Proteins { get; set; }

        /// <summary>
        /// Fats
        /// </summary>
        public double Fats { get; set; }

        /// <summary>
        /// Carbohydrates
        /// </summary>
        public double Carbohydrates { get; set; }

        /// <summary>
        /// Calories per 100 gramm
        /// </summary>
        public double Calories { get; set; }
        public virtual ICollection<Eating> Eatings { get; set; }

        public Food(string name) : this(name, 0, 0, 0, 0) { }
        public Food()
        {

        }
        public Food(string name, double callories, double proteins, double fats, double carbohydrates)
        {
            //check

            Name = name;
            Callories = callories / 100.0;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
