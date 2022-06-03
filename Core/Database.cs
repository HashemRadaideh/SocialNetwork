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

        public void RemoveData(object data)
        {
            this.rows.Remove(data);
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

            var acc1 = new useraccount("UN1", "11", true, "Zaid", "Ahmad", "Irbid", 28);
            var acc2 = new useraccount("UN2", "22", true, "Omar", "Farook", "Irbid", 30);
            var acc3 = new useraccount("UN3", "33", true, "Maha", "Hani", "Amman", 42);
            var acc4 = new useraccount("UN4", "44", true, "Hamzah", "Ali", "Zarqa", 37);
            var acc5 = new useraccount("UN5", "55", true, "Salma", "Waleed", "Jerash", 40);
            var acc6 = new useraccount("UN6", "66", false, "Ali", "Khaled", "Amman", 26);

            acc1.AddFriends(new List<useraccount>() { acc2, acc3 });
            acc2.AddFriends(new List<useraccount>() { acc1, acc3, acc5 });
            acc3.AddFriends(new List<useraccount>() { acc2, acc4, acc6 });
            acc4.AddFriends(new List<useraccount>() { acc5, acc6 });
            acc5.AddFriends(new List<useraccount>() { acc1, acc3, acc4 });
            acc6.AddFriends(new List<useraccount>() { acc1, acc2 });

            Add("users", acc1);
            Add("users", acc2);
            Add("users", acc3);
            Add("users", acc4);
            Add("users", acc5);
            Add("users", acc6);

            Add("posts", new Actions.Post(acc1.Username, "Liverpool beats Man. City 2-1", true, "Sport"));
            Add("posts", new Actions.Post(acc1.Username, "Apple expects to release iPhone 14 in October", true, "News"));
            Add("posts", new Actions.Post(acc2.Username, "Expect snow next Sunday", true, "Weather"));
            Add("posts", new Actions.Post(acc3.Username, "Italy fails to qualify for the world cup", true, "Sport"));
            Add("posts", new Actions.Post(acc3.Username, "The deficit exceeds 2 million dollars", true, "Economy"));
            Add("posts", new Actions.Post(acc5.Username, "The minimum wage has been raised to 300 dinars", true, "Economy"));

            Add("reports", new Actions.Report(acc1.Username, acc2.Username, "He is gay!?"));
            Add("reports", new Actions.Report(acc3.Username, acc2.Username, "Hello, World!"));

            Add("reports", new Actions.Report(acc2.Username, acc1.Username, "I like one piece!"));

            Add("reports", new Actions.Report(acc1.Username, acc5.Username, "Hey, there!"));
            Add("reports", new Actions.Report(acc3.Username, acc5.Username, "This is a report."));

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

        public void Remove(string tableName, object data)
        {
            var table = this.GetTable(tableName) ?? throw new Exception("Table does not exist");
            table.RemoveData(data);
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
