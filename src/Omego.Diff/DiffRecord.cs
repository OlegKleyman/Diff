using System;
using System.Collections;
using System.Collections.Generic;

namespace Omego.Diff
{
    public class DiffRecord
    {
        private readonly Dictionary<DiffProperty, object> properties;

        public DiffRecord(int id, Dictionary<DiffProperty, object> properties)
        {
            if (properties == null)
            {
                throw new ArgumentNullException("properties");
            }

            Id = id;
            this.properties = properties;
        }

        public int Id { get; private set; }

        public T Property<T>(DiffProperty key)
        {
            return (T) properties[key];
        }

        public bool ContainsKey(DiffProperty key)
        {
            return properties.ContainsKey(key);
        }
    }
}