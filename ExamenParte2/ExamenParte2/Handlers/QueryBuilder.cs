
namespace ExamenParte2.Handlers {
    public class QueryBuilder {
        private string[] Columns;
        private string Table;
        private string SqlQuery;

        public string GetSqlQuery() {
            return this.SqlQuery;
        }

        public QueryBuilder From(string table) {
            this.Table = table;
            this.SqlQuery = string.Empty;
            this.SqlQuery = this.Select("*").GetSqlQuery();

            return this;
        }

        public QueryBuilder Select(params string[] Columns) {
            this.Columns = Columns;
            this.SqlQuery = string.Concat(new string[] {
                "SELECT ",
                string.Join(",", this.Columns),
                " FROM ",
                this.Table
            });

            return this;
        }

        public QueryBuilder Where(string column, string operation, string parameter) {
            this.SqlQuery = string.Concat(new string[] {
                "SELECT ",
                string.Join(",", this.Columns),
                " FROM ",
                this.Table,
                " WHERE ",
                string.Join(" ", column, operation, parameter)
            });

            return this;
        }
    }
}