

using System.Collections.Generic;

namespace Com.ZimVie.Wcs.Framework
{
    public class ValueObjectList<T> :ValueObject where T:ValueObject
    {
        /// <summary>
        ///  ValueObject List.
        /// </summary>
        private List<T> list = new List<T>();

        /// <summary>
        /// Get current ValueObject list. 
        /// It clones the existing list and returns the cloned list for the protection of inner value.
        /// </summary>
        public List<T> GetCurrentList()
        {
            // clone
            return new List<T>(list);
        }

        /// <summary>
        /// Get current ValueObject list. 
        /// It does not clones the existing list.
        /// </summary>
        public List<T> GetList()
        {
            return list;
        }

        /// <summary>
        /// Method to set new list of ValueObjects.
        /// create new list for the protection of inner value.
        /// </summary>
        /// <param name="list">List of ValueObject</param>
        public void SetNewList(List<T> list)
        {

            // validating parameter
            if (list == null) return;//do nothing  
            this.list = new List<T>(list);

        }
        /// <summary>
        /// Adding a ValueObject to the existing list.
        /// </summary>ValueObject of type<E>. (null is allowed)
        /// <param name="e"></param>
        public void add(T e)
        {
            list.Add(e);
        }


    }


    
}
