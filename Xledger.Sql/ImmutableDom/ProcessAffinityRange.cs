using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ProcessAffinityRange : LiteralRange, IEquatable<ProcessAffinityRange> {
        public ProcessAffinityRange(Literal from = null, Literal to = null) {
            this.from = from;
            this.to = to;
        }
    
        public ScriptDom.ProcessAffinityRange ToMutableConcrete() {
            var ret = new ScriptDom.ProcessAffinityRange();
            ret.From = (ScriptDom.Literal)from.ToMutable();
            ret.To = (ScriptDom.Literal)to.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(from is null)) {
                h = h * 23 + from.GetHashCode();
            }
            if (!(to is null)) {
                h = h * 23 + to.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ProcessAffinityRange);
        } 
        
        public bool Equals(ProcessAffinityRange other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.From, from)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.To, to)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ProcessAffinityRange left, ProcessAffinityRange right) {
            return EqualityComparer<ProcessAffinityRange>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ProcessAffinityRange left, ProcessAffinityRange right) {
            return !(left == right);
        }
    
        public static ProcessAffinityRange FromMutable(ScriptDom.ProcessAffinityRange fragment) {
            return (ProcessAffinityRange)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
