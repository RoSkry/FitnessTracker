using FitnessTracker.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FitnessTracker.BL.Controller
{
    public class ExerciseController : BaseController
    {
        private readonly User user;
        private const string EXERCISE_FILE_NAME = "exercises.dat";
        private const string ACTIVITY_FILE_NAME = "activity.dat";
        public List<Exercise> Exercises { get; }
        public List<Activity> Activities { get; }

        public ExerciseController(User user)
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user));

            Exercises = GetAllExrcises();
            Activities = GetAllActivities();
        }

        private List<Activity> GetAllActivities()
        {
            return Load<List<Activity>>(ACTIVITY_FILE_NAME) ?? new List<Activity>();
        }

        public void Add(Activity activity, DateTime begin, DateTime end)
        {
            var act = Activities.SingleOrDefault(a=>a.Name == activity.Name);

            if(act==null)
            {
                Activities.Add(activity);

                var exercise = new Exercise(begin, end, activity, user);
                Exercises.Add(exercise);             
            }
            else
            {
                var exercise = new Exercise(begin, end, act, user);
                Exercises.Add(exercise);
            }
            Save();
        }

        private List<Exercise> GetAllExrcises()
        {
            return Load<List<Exercise>>(EXERCISE_FILE_NAME) ?? new List<Exercise>();
        }

        private void Save()
        {
            Save(EXERCISE_FILE_NAME, Exercises);
            Save(ACTIVITY_FILE_NAME, Activities);
        }
    }
}
