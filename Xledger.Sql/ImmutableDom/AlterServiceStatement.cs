using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterServiceStatement : AlterCreateServiceStatementBase, IEquatable<AlterServiceStatement> {
        public AlterServiceStatement(Identifier name = null, SchemaObjectName queueName = null, IReadOnlyList<ServiceContract> serviceContracts = null) {
            this.name = name;
            this.queueName = queueName;
            this.serviceContracts = serviceContracts is null ? ImmList<ServiceContract>.Empty : ImmList<ServiceContract>.FromList(serviceContracts);
        }
    
        public ScriptDom.AlterServiceStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterServiceStatement();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.QueueName = (ScriptDom.SchemaObjectName)queueName.ToMutable();
            ret.ServiceContracts.AddRange(serviceContracts.SelectList(c => (ScriptDom.ServiceContract)c.ToMutable()));
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
            if (!(queueName is null)) {
                h = h * 23 + queueName.GetHashCode();
            }
            h = h * 23 + serviceContracts.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterServiceStatement);
        } 
        
        public bool Equals(AlterServiceStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.QueueName, queueName)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ServiceContract>>.Default.Equals(other.ServiceContracts, serviceContracts)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterServiceStatement left, AlterServiceStatement right) {
            return EqualityComparer<AlterServiceStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterServiceStatement left, AlterServiceStatement right) {
            return !(left == right);
        }
    
        public static AlterServiceStatement FromMutable(ScriptDom.AlterServiceStatement fragment) {
            return (AlterServiceStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
