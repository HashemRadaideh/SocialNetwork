using System.Collections;
using administrator = Account.Administrator;
using useraccount = Account.User;

/// <summary>
/// Database implementation for the Social Network project.
/// </summary>
namespace Database
{
    [Serializable]
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
        private Database()
        {
            // Load database from binary formated file Database.dat
            Load();
        }

        public static Database Instance { get { return instance; } }

        private List<Table> tables = new List<Table>();

        public void Load()
        {
            // Load database from binary formated file Database.dat
            // If the file does not exist, create a new database
            if (!System.IO.File.Exists("Database.dat"))
            {
                CreateNewDatabase();
            }
            else
            {
                // Load database from binary formated file Database.dat
                using (System.IO.FileStream fs = new System.IO.FileStream("Database.dat", System.IO.FileMode.Open))
                {
                    System.Runtime.Serialization.IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    this.tables = (List<Table>)formatter.Deserialize(fs);
                }
            }
        }

        public void Save()
        {
            // Save database to binary formated file Database.dat
            using (System.IO.FileStream fs = new System.IO.FileStream("Database.dat", System.IO.FileMode.Create))
            {
                System.Runtime.Serialization.IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                formatter.Serialize(fs, this.tables);
            }
        }

        ~Database()
        {
            Save();
        }

        private void CreateNewDatabase()
        {
            CreateNewTable("users");
            CreateNewTable("reports");
            CreateNewTable("posts");
            CreateNewTable("messages");

            var acc1 = new useraccount("HashemWasTaken", "0", true, "Hashem", "Al_Radaideh", "Irbid", 20);
            var acc2 = new useraccount("HashemIsTaken", "1", true, "Hashem", "Al_Radaideh", "Irbid", 20, new List<Account.User>() { acc1 });
            var acc3 = new useraccount("HashemTaken", "h", true, "Hashem", "Al_Radaideh", "Irbid", 20, new List<Account.User>() { acc1, acc2 });
            var acc4 = new useraccount("Hashem", "h", true, "Hashem", "Al_Radaideh", "Irbid", 20, new List<Account.User>() { acc1, acc2, acc3 });

            Add("users", acc1);
            Add("users", acc2);
            Add("users", acc3);
            Add("users", acc4);

            Add("reports", new Actions.Report(IndexOf("users", acc1.Username), IndexOf("users", acc2.Username), "This is a report"));
            Add("reports", new Actions.Report(IndexOf("users", acc3.Username), IndexOf("users", acc2.Username), "This is a report"));

            Add("reports", new Actions.Report(IndexOf("users", acc2.Username), IndexOf("users", acc1.Username), "This is a report"));

            Add("reports", new Actions.Report(IndexOf("users", acc1.Username), IndexOf("users", acc2.Username), "This is a report"));
            Add("reports", new Actions.Report(IndexOf("users", acc3.Username), IndexOf("users", acc2.Username), "This is a report"));
            Save();
        }

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
                if (u.Username == username && u.Password == password && u.Status)
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
    }
}
