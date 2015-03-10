using System;
using System.Collections;
using System.Collections.Generic;

namespace Library
{
    public class StandardCatalog : ISaveable, IPersistable
    {
        public void Load()
        {
        }

        public string Save()
        {
            return "Catalog Save";
        }
    }

    public class ExplicitCatalog : ISaveable, IPersistable
    {
        //public string Save()
        //{
        //    return "Catalog Save";
        //}

        string ISaveable.Save()
        {
            return "ISaveable Save";
        }

        string IPersistable.Save()
        {
            return "IPersistable Save";
        }
    }

    //using interfaces to return different types.
    public class Catalog: ISaveable, IVoidSaveable
    {
        public string Save() //implementing the ISaveable
        {
            throw new NotImplementedException();
        }

        void IVoidSaveable.Save()
        {
            throw new NotImplementedException();
        }
    }

    public class EnumerableCatalog : IEnumerable<string>
    {

        public IEnumerator<string> GetEnumerator()
        {
            // all of our code here to return a 
            //type which implements IEnumerator
            //or reurn yield value in a loop.
            return null;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
