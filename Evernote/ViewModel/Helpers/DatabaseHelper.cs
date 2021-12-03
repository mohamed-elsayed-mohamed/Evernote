using SQLite;
using System;
using System.Collections.Generic;
using System.IO;

namespace Evernote.ViewModel.Helpers
{
    public class DatabaseHelper
    {
        private static string dbFile = Path.Combine(Environment.CurrentDirectory, "notesdb.db");

        public static bool Insert<T>(T item)
        {
            using(SQLiteConnection connection = new SQLiteConnection(dbFile))
            {
                connection.CreateTable<T>();
                return connection.Insert(item) > 0;
            }
        }

        public static bool Update<T>(T item)
        {
            using (SQLiteConnection connection = new SQLiteConnection(dbFile))
            {
                connection.CreateTable<T>();
                return connection.Update(item) > 0;
            }
        }

        public static bool Delete<T>(T item)
        {
            using (SQLiteConnection connection = new SQLiteConnection(dbFile))
            {
                connection.CreateTable<T>();
                return connection.Delete(item) > 0;
            }
        }

        public static List<T> Read<T>() where T : new()
        {
            using (SQLiteConnection connection = new SQLiteConnection(dbFile))
            {
                connection.CreateTable<T>();
                return connection.Table<T>().ToList();
            }
        }
    }
}
