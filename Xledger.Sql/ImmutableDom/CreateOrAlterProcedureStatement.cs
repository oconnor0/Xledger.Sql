using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateOrAlterProcedureStatement : ProcedureStatementBody, IEquatable<CreateOrAlterProcedureStatement> {
        public CreateOrAlterProcedureStatement(ProcedureReference procedureReference = null, bool isForReplication = false, IReadOnlyList<ProcedureOption> options = null, IReadOnlyList<ProcedureParameter> parameters = null, StatementList statementList = null, MethodSpecifier methodSpecifier = null) {
            this.procedureReference = procedureReference;
            this.isForReplication = isForReplication;
            this.options = options is null ? ImmList<ProcedureOption>.Empty : ImmList<ProcedureOption>.FromList(options);
            this.parameters = parameters is null ? ImmList<ProcedureParameter>.Empty : ImmList<ProcedureParameter>.FromList(parameters);
            this.statementList = statementList;
            this.methodSpecifier = methodSpecifier;
        }
    
        public ScriptDom.CreateOrAlterProcedureStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateOrAlterProcedureStatement();
            ret.ProcedureReference = (ScriptDom.ProcedureReference)procedureReference.ToMutable();
            ret.IsForReplication = isForReplication;
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.ProcedureOption)c.ToMutable()));
            ret.Parameters.AddRange(parameters.SelectList(c => (ScriptDom.ProcedureParameter)c.ToMutable()));
            ret.StatementList = (ScriptDom.StatementList)statementList.ToMutable();
            ret.MethodSpecifier = (ScriptDom.MethodSpecifier)methodSpecifier.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(procedureReference is null)) {
                h = h * 23 + procedureReference.GetHashCode();
            }
            h = h * 23 + isForReplication.GetHashCode();
            h = h * 23 + options.GetHashCode();
            h = h * 23 + parameters.GetHashCode();
            if (!(statementList is null)) {
                h = h * 23 + statementList.GetHashCode();
            }
            if (!(methodSpecifier is null)) {
                h = h * 23 + methodSpecifier.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateOrAlterProcedureStatement);
        } 
        
        public bool Equals(CreateOrAlterProcedureStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ProcedureReference>.Default.Equals(other.ProcedureReference, procedureReference)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsForReplication, isForReplication)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ProcedureOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ProcedureParameter>>.Default.Equals(other.Parameters, parameters)) {
                return false;
            }
            if (!EqualityComparer<StatementList>.Default.Equals(other.StatementList, statementList)) {
                return false;
            }
            if (!EqualityComparer<MethodSpecifier>.Default.Equals(other.MethodSpecifier, methodSpecifier)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateOrAlterProcedureStatement left, CreateOrAlterProcedureStatement right) {
            return EqualityComparer<CreateOrAlterProcedureStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateOrAlterProcedureStatement left, CreateOrAlterProcedureStatement right) {
            return !(left == right);
        }
    
        public static CreateOrAlterProcedureStatement FromMutable(ScriptDom.CreateOrAlterProcedureStatement fragment) {
            return (CreateOrAlterProcedureStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
