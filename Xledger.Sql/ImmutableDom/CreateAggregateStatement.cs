using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateAggregateStatement : TSqlStatement, IEquatable<CreateAggregateStatement> {
        protected SchemaObjectName name;
        protected AssemblyName assemblyName;
        protected IReadOnlyList<ProcedureParameter> parameters;
        protected DataTypeReference returnType;
    
        public SchemaObjectName Name => name;
        public AssemblyName AssemblyName => assemblyName;
        public IReadOnlyList<ProcedureParameter> Parameters => parameters;
        public DataTypeReference ReturnType => returnType;
    
        public CreateAggregateStatement(SchemaObjectName name = null, AssemblyName assemblyName = null, IReadOnlyList<ProcedureParameter> parameters = null, DataTypeReference returnType = null) {
            this.name = name;
            this.assemblyName = assemblyName;
            this.parameters = parameters is null ? ImmList<ProcedureParameter>.Empty : ImmList<ProcedureParameter>.FromList(parameters);
            this.returnType = returnType;
        }
    
        public ScriptDom.CreateAggregateStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateAggregateStatement();
            ret.Name = (ScriptDom.SchemaObjectName)name.ToMutable();
            ret.AssemblyName = (ScriptDom.AssemblyName)assemblyName.ToMutable();
            ret.Parameters.AddRange(parameters.SelectList(c => (ScriptDom.ProcedureParameter)c.ToMutable()));
            ret.ReturnType = (ScriptDom.DataTypeReference)returnType.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            if (!(assemblyName is null)) {
                h = h * 23 + assemblyName.GetHashCode();
            }
            h = h * 23 + parameters.GetHashCode();
            if (!(returnType is null)) {
                h = h * 23 + returnType.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateAggregateStatement);
        } 
        
        public bool Equals(CreateAggregateStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<AssemblyName>.Default.Equals(other.AssemblyName, assemblyName)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ProcedureParameter>>.Default.Equals(other.Parameters, parameters)) {
                return false;
            }
            if (!EqualityComparer<DataTypeReference>.Default.Equals(other.ReturnType, returnType)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateAggregateStatement left, CreateAggregateStatement right) {
            return EqualityComparer<CreateAggregateStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateAggregateStatement left, CreateAggregateStatement right) {
            return !(left == right);
        }
    
        public static CreateAggregateStatement FromMutable(ScriptDom.CreateAggregateStatement fragment) {
            return (CreateAggregateStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
