using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class InPredicate : BooleanExpression, IEquatable<InPredicate> {
        protected ScalarExpression expression;
        protected ScalarSubquery subquery;
        protected bool notDefined = false;
        protected IReadOnlyList<ScalarExpression> values;
    
        public ScalarExpression Expression => expression;
        public ScalarSubquery Subquery => subquery;
        public bool NotDefined => notDefined;
        public IReadOnlyList<ScalarExpression> Values => values;
    
        public InPredicate(ScalarExpression expression = null, ScalarSubquery subquery = null, bool notDefined = false, IReadOnlyList<ScalarExpression> values = null) {
            this.expression = expression;
            this.subquery = subquery;
            this.notDefined = notDefined;
            this.values = ImmList<ScalarExpression>.FromList(values);
        }
    
        public ScriptDom.InPredicate ToMutableConcrete() {
            var ret = new ScriptDom.InPredicate();
            ret.Expression = (ScriptDom.ScalarExpression)expression.ToMutable();
            ret.Subquery = (ScriptDom.ScalarSubquery)subquery.ToMutable();
            ret.NotDefined = notDefined;
            ret.Values.AddRange(values.SelectList(c => (ScriptDom.ScalarExpression)c.ToMutable()));
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
            if (!(subquery is null)) {
                h = h * 23 + subquery.GetHashCode();
            }
            h = h * 23 + notDefined.GetHashCode();
            h = h * 23 + values.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as InPredicate);
        } 
        
        public bool Equals(InPredicate other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Expression, expression)) {
                return false;
            }
            if (!EqualityComparer<ScalarSubquery>.Default.Equals(other.Subquery, subquery)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.NotDefined, notDefined)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ScalarExpression>>.Default.Equals(other.Values, values)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(InPredicate left, InPredicate right) {
            return EqualityComparer<InPredicate>.Default.Equals(left, right);
        }
        
        public static bool operator !=(InPredicate left, InPredicate right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (InPredicate)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.expression, othr.expression);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.subquery, othr.subquery);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.notDefined, othr.notDefined);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.values, othr.values);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static InPredicate FromMutable(ScriptDom.InPredicate fragment) {
            return (InPredicate)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
