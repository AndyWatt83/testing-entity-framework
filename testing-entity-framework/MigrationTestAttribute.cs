using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingEntityFramework
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class MigrationTestAttribute : Attribute
    {
        public int MigrationOrder { get; private set; }

        public MigrationTestAttribute(int migrationOrder) => MigrationOrder = migrationOrder;
    }

}
