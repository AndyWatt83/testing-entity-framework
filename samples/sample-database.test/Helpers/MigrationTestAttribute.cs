using System;

namespace SampleDatabase.Test
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class MigrationTestAttribute : Attribute
    {
        public int MigrationOrder { get; private set; }

        public MigrationTestAttribute(int migrationOrder) => MigrationOrder = migrationOrder;
    }

}
