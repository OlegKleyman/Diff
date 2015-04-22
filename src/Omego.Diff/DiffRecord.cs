using System;
using System.Collections;
using System.Collections.Generic;

namespace Omego.Diff
{
    public class DiffRecord
    {
        private readonly Dictionary<DiffProperties, object> properties;

        public DiffRecord(int id, Dictionary<DiffProperties, object> properties)
        {
            if (properties == null)
            {
                throw new ArgumentNullException("properties");
            }

            Id = id;
            this.properties = properties;
        }

        public int Id { get; private set; }

        public T Property<T>(DiffProperties property)
        {
            return (T) properties[property];
        }

        public bool ContainsKey(DiffProperties key)
        {
            return properties.ContainsKey(key);
        }
    }
}