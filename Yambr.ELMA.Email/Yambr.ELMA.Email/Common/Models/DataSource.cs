using System;

namespace Yambr.ELMA.Email.Common.Models
{
    public class DataSource
    {
        public DataSource()
        {}

        public DataSource(string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            Name = name;
        }

        public string Name { get; set; }
    }
}