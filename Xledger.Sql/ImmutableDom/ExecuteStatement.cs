using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ExecuteStatement : TSqlStatement, IEquatable<ExecuteStatement> {
        protected ExecuteSpecification executeSpecification;
        protected IReadOnlyList<ExecuteOption> options;
    
        public ExecuteSpecification ExecuteSpecification => executeSpecification;
        public IReadOnlyList<ExecuteOption> Options => options;
    
        public ExecuteStatement(ExecuteSpecification executeSpecification = null, IReadOnlyList<ExecuteOption> options = null) {
            this.executeSpecification = executeSpecification;
            this.options = ImmList<ExecuteOption>.FromList(options);
        }
    
        public ScriptDom.ExecuteStatement ToMutableConcrete() {
            var ret = new ScriptDom.ExecuteStatement();
            ret.ExecuteSpecification = (ScriptDom.ExecuteSpecification)executeSpecification.ToMutable();
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.ExecuteOption)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(executeSpecification is null)) {
                h = h * 23 + executeSpecification.GetHashCode();
            }
            h = h * 23 + options.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ExecuteStatement);
        } 
        
        public bool Equals(ExecuteStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ExecuteSpecification>.Default.Equals(other.ExecuteSpecification, executeSpecification)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ExecuteOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ExecuteStatement left, ExecuteStatement right) {
            return EqualityComparer<ExecuteStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ExecuteStatement left, ExecuteStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ExecuteStatement)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.executeSpecification, othr.executeSpecification);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.options, othr.options);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static ExecuteStatement FromMutable(ScriptDom.ExecuteStatement fragment) {
            return (ExecuteStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
