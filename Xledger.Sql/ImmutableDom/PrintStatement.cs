using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class PrintStatement : TSqlStatement, IEquatable<PrintStatement> {
        protected ScalarExpression expression;
    
        public ScalarExpression Expression => expression;
    
        public PrintStatement(ScalarExpression expression = null) {
            this.expression = expression;
        }
    
        public ScriptDom.PrintStatement ToMutableConcrete() {
            var ret = new ScriptDom.PrintStatement();
            ret.Expression = (ScriptDom.ScalarExpression)expression.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(expression is null)) {
                h = h * 23 + expression.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as PrintStatement);
        } 
        
        public bool Equals(PrintStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Expression, expression)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(PrintStatement left, PrintStatement right) {
            return EqualityComparer<PrintStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(PrintStatement left, PrintStatement right) {
            return !(left == right);
        }
    
        public static PrintStatement FromMutable(ScriptDom.PrintStatement fragment) {
            return (PrintStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
