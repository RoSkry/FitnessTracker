using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace FitnessTracker.BL.Controller
{
    public abstract class BaseController
    {
        protected IDataSaver manager = new DatabaseDataSaver();

        protected void Save<T>(List<T> item) where T: class
        {
            manager.Save(item);
        }

        protected List<T> Load<T>() where T : class
        {
            return manager.Load<T>();
        }

    }
}
