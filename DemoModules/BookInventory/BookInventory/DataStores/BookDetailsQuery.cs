﻿using MySql.Data.MySqlClient;
using Mystique.Core.Contracts;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Linq;

namespace BookInventory.DataStores
{
    public class BookDetailsQuery : IDataStoreQuery
    {
        private IDbHelper _dbHelper = null;

        public BookDetailsQuery(IDbHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public string QueryName
        {
            get
            {
                return "Book_Details";
            }
        }

        public string Query(string parameter)
        {
            var param = JsonConvert.DeserializeObject<BookDetailsQueryParameter>(parameter);

            var sql = "SELECT * FROM Book WHERE BookId=@id";

            var dataTable = _dbHelper.ExecuteDataTable(sql, new MySqlParameter { ParameterName = "@id", MySqlDbType = MySqlDbType.Guid, Value = param.BookId });

            return JsonConvert.SerializeObject(dataTable.Rows.Cast<DataRow>().Select(p => new BookDetailViewModel
            {
                BookId = Guid.Parse(p["BookId"].ToString()),
                BookName = p["BookName"].ToString(),
                ISBN = p["ISBN"].ToString(),
                DateIssued = Convert.ToDateTime(p["DateIssued"])
            }).ToList());
        }
    }

    public class BookDetailsQueryParameter
    {
        public Guid BookId { get; set; }
    }

    public class BookDetailViewModel
    {
        public Guid BookId { get; set; }

        public string BookName { get; set; }

        public string ISBN { get; set; }

        public DateTime DateIssued { get; set; }
    }

}
