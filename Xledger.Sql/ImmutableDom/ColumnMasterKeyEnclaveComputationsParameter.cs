using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ColumnMasterKeyEnclaveComputationsParameter : ColumnMasterKeyParameter, IEquatable<ColumnMasterKeyEnclaveComputationsParameter> {
        protected BinaryLiteral signature;
    
        public BinaryLiteral Signature => signature;
    
        public ColumnMasterKeyEnclaveComputationsParameter(BinaryLiteral signature = null, ScriptDom.ColumnMasterKeyParameterKind parameterKind = ScriptDom.ColumnMasterKeyParameterKind.KeyStoreProviderName) {
            this.signature = signature;
            this.parameterKind = parameterKind;
        }
    
        public ScriptDom.ColumnMasterKeyEnclaveComputationsParameter ToMutableConcrete() {
            var ret = new ScriptDom.ColumnMasterKeyEnclaveComputationsParameter();
            ret.Signature = (ScriptDom.BinaryLiteral)signature.ToMutable();
            ret.ParameterKind = parameterKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(signature is null)) {
                h = h * 23 + signature.GetHashCode();
            }
            h = h * 23 + parameterKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ColumnMasterKeyEnclaveComputationsParameter);
        } 
        
        public bool Equals(ColumnMasterKeyEnclaveComputationsParameter other) {
            if (other is null) { return false; }
            if (!EqualityComparer<BinaryLiteral>.Default.Equals(other.Signature, signature)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.ColumnMasterKeyParameterKind>.Default.Equals(other.ParameterKind, parameterKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ColumnMasterKeyEnclaveComputationsParameter left, ColumnMasterKeyEnclaveComputationsParameter right) {
            return EqualityComparer<ColumnMasterKeyEnclaveComputationsParameter>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ColumnMasterKeyEnclaveComputationsParameter left, ColumnMasterKeyEnclaveComputationsParameter right) {
            return !(left == right);
        }
    
        public static ColumnMasterKeyEnclaveComputationsParameter FromMutable(ScriptDom.ColumnMasterKeyEnclaveComputationsParameter fragment) {
            return (ColumnMasterKeyEnclaveComputationsParameter)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
