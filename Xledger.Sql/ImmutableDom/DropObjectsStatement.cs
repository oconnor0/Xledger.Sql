using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class DropObjectsStatement : TSqlStatement {
        protected IReadOnlyList<SchemaObjectName> objects;
        protected bool isIfExists;
    
        public IReadOnlyList<SchemaObjectName> Objects => objects;
        public bool IsIfExists => isIfExists;
    
    }

}
