using System;
using System.Collections.Generic;
using System.Configuration;

namespace PeopleViewer
{
    public static class SimpleContainer
    {
        private static Dictionary<Type, object> InstanceCatalog;

        static SimpleContainer()
        {
            InstanceCatalog = new Dictionary<Type, object>();
        }

        public static void MapInstance<T>(object concreteType)
        {
            Type instanceType = typeof(T);
            if (InstanceCatalog.ContainsKey(instanceType))
                InstanceCatalog.Remove(instanceType);
            InstanceCatalog.Add(instanceType, concreteType);
        }
        //Gets an instance, first from our built up catalogue
        //if not found then from our app.config file.
        public static T Get<T>() where T : class
        {
            T instance = GetFromInstanceCatalog<T>();
            if (instance == null)
                instance = GetFromConfig<T>();
            return instance;
        }

        private static T GetFromInstanceCatalog<T>() where T : class
        {
            object instance;
            InstanceCatalog.TryGetValue(typeof(T), out instance);
            return instance as T;
        }

        //this gets the value from the app.config folder
        //using the dll file requested.
        //where the key has to be the fully qulified tyoe name.
        private static T GetFromConfig<T>() where T : class
        {
            string typeName = ConfigurationManager.AppSettings[typeof(T).ToString()];
            if (string.IsNullOrEmpty(typeName))
                return null;

            Type repoType = Type.GetType(typeName);
            object repoInstance = Activator.CreateInstance(repoType);
            T repo = repoInstance as T;
            return repo;
        }
    }
}
