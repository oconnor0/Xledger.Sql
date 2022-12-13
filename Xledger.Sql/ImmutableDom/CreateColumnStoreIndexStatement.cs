using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateColumnStoreIndexStatement : TSqlStatement, IEquatable<CreateColumnStoreIndexStatement> {
        protected Identifier name;
        protected bool? clustered;
        protected SchemaObjectName onName;
        protected IReadOnlyList<ColumnReferenceExpression> columns;
        protected BooleanExpression filterPredicate;
        protected IReadOnlyList<IndexOption> indexOptions;
        protected FileGroupOrPartitionScheme onFileGroupOrPartitionScheme;
        protected IReadOnlyList<ColumnReferenceExpression> orderedColumns;
    
        public Identifier Name => name;
        public bool? Clustered => clustered;
        public SchemaObjectName OnName => onName;
        public IReadOnlyList<ColumnReferenceExpression> Columns => columns;
        public BooleanExpression FilterPredicate => filterPredicate;
        public IReadOnlyList<IndexOption> IndexOptions => indexOptions;
        public FileGroupOrPartitionScheme OnFileGroupOrPartitionScheme => onFileGroupOrPartitionScheme;
        public IReadOnlyList<ColumnReferenceExpression> OrderedColumns => orderedColumns;
    
        public CreateColumnStoreIndexStatement(Identifier name = null, bool? clustered = null, SchemaObjectName onName = null, IReadOnlyList<ColumnReferenceExpression> columns = null, BooleanExpression filterPredicate = null, IReadOnlyList<IndexOption> indexOptions = null, FileGroupOrPartitionScheme onFileGroupOrPartitionScheme = null, IReadOnlyList<ColumnReferenceExpression> orderedColumns = null) {
            this.name = name;
            this.clustered = clustered;
            this.onName = onName;
            this.columns = columns is null ? ImmList<ColumnReferenceExpression>.Empty : ImmList<ColumnReferenceExpression>.FromList(columns);
            this.filterPredicate = filterPredicate;
            this.indexOptions = indexOptions is null ? ImmList<IndexOption>.Empty : ImmList<IndexOption>.FromList(indexOptions);
            this.onFileGroupOrPartitionScheme = onFileGroupOrPartitionScheme;
            this.orderedColumns = orderedColumns is null ? ImmList<ColumnReferenceExpression>.Empty : ImmList<ColumnReferenceExpression>.FromList(orderedColumns);
        }
    
        public ScriptDom.CreateColumnStoreIndexStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateColumnStoreIndexStatement();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.Clustered = clustered;
            ret.OnName = (ScriptDom.SchemaObjectName)onName.ToMutable();
            ret.Columns.AddRange(columns.SelectList(c => (ScriptDom.ColumnReferenceExpression)c.ToMutable()));
            ret.FilterPredicate = (ScriptDom.BooleanExpression)filterPredicate.ToMutable();
            ret.IndexOptions.AddRange(indexOptions.SelectList(c => (ScriptDom.IndexOption)c.ToMutable()));
            ret.OnFileGroupOrPartitionScheme = (ScriptDom.FileGroupOrPartitionScheme)onFileGroupOrPartitionScheme.ToMutable();
            ret.OrderedColumns.AddRange(orderedColumns.SelectList(c => (ScriptDom.ColumnReferenceExpression)c.ToMutable()));
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
            h = h * 23 + clustered.GetHashCode();
            if (!(onName is null)) {
                h = h * 23 + onName.GetHashCode();
            }
            h = h * 23 + columns.GetHashCode();
            if (!(filterPredicate is null)) {
                h = h * 23 + filterPredicate.GetHashCode();
            }
            h = h * 23 + indexOptions.GetHashCode();
            if (!(onFileGroupOrPartitionScheme is null)) {
                h = h * 23 + onFileGroupOrPartitionScheme.GetHashCode();
            }
            h = h * 23 + orderedColumns.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateColumnStoreIndexStatement);
        } 
        
        public bool Equals(CreateColumnStoreIndexStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<bool?>.Default.Equals(other.Clustered, clustered)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.OnName, onName)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ColumnReferenceExpression>>.Default.Equals(other.Columns, columns)) {
                return false;
            }
            if (!EqualityComparer<BooleanExpression>.Default.Equals(other.FilterPredicate, filterPredicate)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<IndexOption>>.Default.Equals(other.IndexOptions, indexOptions)) {
                return false;
            }
            if (!EqualityComparer<FileGroupOrPartitionScheme>.Default.Equals(other.OnFileGroupOrPartitionScheme, onFileGroupOrPartitionScheme)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ColumnReferenceExpression>>.Default.Equals(other.OrderedColumns, orderedColumns)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateColumnStoreIndexStatement left, CreateColumnStoreIndexStatement right) {
            return EqualityComparer<CreateColumnStoreIndexStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateColumnStoreIndexStatement left, CreateColumnStoreIndexStatement right) {
            return !(left == right);
        }
    
        public static CreateColumnStoreIndexStatement FromMutable(ScriptDom.CreateColumnStoreIndexStatement fragment) {
            return (CreateColumnStoreIndexStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
