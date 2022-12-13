using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class ConstraintDefinition : TSqlFragment {
        protected Identifier constraintIdentifier;
    
        public Identifier ConstraintIdentifier => constraintIdentifier;
    
        public static ConstraintDefinition FromMutable(ScriptDom.ConstraintDefinition fragment) {
            return (ConstraintDefinition)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
