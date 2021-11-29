using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ExamenParte2.Handlers {
    public class ProductsHandler : DatabaseHandler {
        public List<string> GetItemsByType(string type) {
            List<string> items = new List<string>();
            string query = "SELECT nombre " +
                           "FROM Producto " +
                           "WHERE tipo = '" + type + "' ";

            DataTable resultingTable = CreateTableFromQuery(query);

            foreach (DataRow column in resultingTable.Rows) {
                items.Add(Convert.ToString(column["nombre"]));
            }

            return items;
        }

        public int GetPriceForItem(string productName) {
            int price = 0;
            string query = "SELECT precio " +
                           "FROM Producto " +
                           "WHERE nombre = '" + productName + "' ";

            DataTable resultingTable = CreateTableFromQuery(query);
            price = Convert.ToInt32(resultingTable.Rows[0][0]);

            return price;
        }
    }
}