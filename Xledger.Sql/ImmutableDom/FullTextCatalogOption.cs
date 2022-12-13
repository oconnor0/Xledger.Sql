using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class FullTextCatalogOption : TSqlFragment {
        protected ScriptDom.FullTextCatalogOptionKind optionKind;
    
        public ScriptDom.FullTextCatalogOptionKind OptionKind => optionKind;
    
        public static FullTextCatalogOption FromMutable(ScriptDom.FullTextCatalogOption fragment) {
            return (FullTextCatalogOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
