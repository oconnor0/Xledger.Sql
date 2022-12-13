using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class SensitivityClassificationStatement : TSqlStatement {
        protected IReadOnlyList<ColumnReferenceExpression> columns;
    
        public IReadOnlyList<ColumnReferenceExpression> Columns => columns;
    
        public static SensitivityClassificationStatement FromMutable(ScriptDom.SensitivityClassificationStatement fragment) {
            return (SensitivityClassificationStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
