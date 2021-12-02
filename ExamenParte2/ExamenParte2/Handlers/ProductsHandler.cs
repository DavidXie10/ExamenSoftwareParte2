using System;
using System.Collections.Generic;
using System.Data;

namespace ExamenParte2.Handlers {
    public class ProductsHandler : DatabaseHandler {
        public List<string> GetItemsByType(string type) {
            List<string> items = new List<string>();
            QueryBuilder query = new QueryBuilder().From("Producto").Select("nombre").Where("tipo", "=", "'" + type + "'");

            DataTable resultingTable = CreateTableFromQuery(query.GetSqlQuery());

            foreach (DataRow column in resultingTable.Rows) {
                items.Add(Convert.ToString(column["nombre"]));
            }

            return items;
        }

        public int GetPriceForItem(string productName) {
            int price = 0;

            QueryBuilder query = new QueryBuilder().From("Producto").Select("precio").Where("nombre", "=", "'" + productName + "'");

            DataTable resultingTable = CreateTableFromQuery(query.GetSqlQuery());
            price = Convert.ToInt32(resultingTable.Rows[0][0]);

            return price;
        }
    }
}