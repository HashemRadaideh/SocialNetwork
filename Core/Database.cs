/// <summary>
/// Database implementation for the Social Network project.
/// </summary>
namespace Database
{
    using System;
    using System.Collections;
    using administrator = Account.Administrator;
    using useraccount = Account.User;

    public class Table
    {
        private string name = "";
        private Hashtable rows = new Hashtable();
        // ID is used as the the primary key for the table
        private int id = 0;

        public string Name { get => name; }
        public Hashtable Rows { get => rows; }
        public int ID { get => id; }

        public Table(string name)
        {
            this.name = name;
        }

        public void AddData(object data)
        {
            id++;
            this.rows.Add(id, data);
        }

        public int IndexOf(object data)
        {
            int index = 0;

            foreach (object val in this.rows.Values)
            {
                if (val.Equals(data))
                {
                    return index;
                }
            }

            return index;
        }
    }

    [Serializable]
    public class Database
    {
        // Design pattern: Singleton
        // The Database class is a singleton, meaning that there is only one instance of the database
        // This is done to ensure that there is one and only one database in the System
        private static readonly Database instance = new Database();
        private Database() { }
        public static Database Instance { get { return instance; } }

        private List<Table> tables = new List<Table>();

        public void CreateNewTable(string name)
        {
            this.tables.Add(new Table(name));
        }

        public Table? GetTable(string name)
        {
            foreach (Table table in this.tables)
            {
                if (table.Name.Equals(name))
                {
                    return table;
                }
            }

            return null;
        }

        public void Add(string tableName, object data)
        {
            var table = this.GetTable(tableName) ?? throw new Exception("Table does not exist");
            table.AddData(data);
        }

        public object? Login(string? username, string? password)
        {
            username ??= "";
            password ??= "";

            if (username == "admin" && password == "0")
            {
                return administrator.Instance;
            }

            var table = GetTable("users") ?? throw new Exception("Table does not exist");
            foreach (var user in table.Rows.Values)
            {
                var u = (useraccount)user;
                if (u.Username == username && u.Password == password)
                {
                    return u;
                }
            }

            return null;
        }

        public int IndexOf(string TableName, string Username)
        {
            var table = GetTable(TableName) ?? throw new Exception("Table does not exist");

            int index = 0;

            foreach (var user in table.Rows.Values)
            {
                var u = (useraccount)user;
                if (u.Username == Username)
                {
                    return index;
                }
            }

            return index;
        }

        internal void LoadDatabase()
        {

        }

        internal void SaveDatabase()
        {

        }
    }
}
