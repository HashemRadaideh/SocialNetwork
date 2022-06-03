using System.Collections;
using administrator = Core.Administrator;
using useraccount = Core.User;

/// <summary>
/// Database implementation for the Social Network project.
/// </summary>
namespace Core
{
    [Serializable]
    public class Table
    {
        private readonly string name = "";
        private readonly Hashtable rows = new();
        // ID is used as the the primary key for the table
        private int id = 0;

        public string Name => name;
        public Hashtable Rows => rows;
        public int ID => id;

        public Table(string name)
        {
            this.name = name;
        }

        public void AddData(object data)
        {
            id++;
            rows.Add(id, data);
        }

        public void RemoveData(object data)
        {
            rows.Remove(data);
        }

        public int IndexOf(object data)
        {
            int index = 0;

            foreach (object val in rows.Values)
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
        private static readonly Database instance = new();
        private Database()
        {
            // Load database from binary formated file Database.dat
            Load();
        }

        public static Database Instance => instance;

        private List<Table> tables = new();

        public void Load()
        {
            // Load database from binary formated file Database.dat
            // If the file does not exist, create a new database
            if (!File.Exists("Database.dat"))
            {
                CreateNewDatabase();
            }
            else
            {
                // Load database from binary formated file Database.dat
                using FileStream fs = new("Database.dat", FileMode.Open);
                System.Runtime.Serialization.IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                tables = (List<Table>)formatter.Deserialize(fs);
            }
        }

        public void Save()
        {
            // Save database to binary formated file Database.dat
            using FileStream fs = new("Database.dat", FileMode.Create);
            System.Runtime.Serialization.IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            formatter.Serialize(fs, tables);
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

            useraccount? acc1 = new("UN1", "11", true, "Zaid", "Ahmad", "Irbid", 28);
            useraccount? acc2 = new("UN2", "22", true, "Omar", "Farook", "Irbid", 30);
            useraccount? acc3 = new("UN3", "33", true, "Maha", "Hani", "Amman", 42);
            useraccount? acc4 = new("UN4", "44", true, "Hamzah", "Ali", "Zarqa", 37);
            useraccount? acc5 = new("UN5", "55", true, "Salma", "Waleed", "Jerash", 40);
            useraccount? acc6 = new("UN6", "66", false, "Ali", "Khaled", "Amman", 26);

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

            Add("posts", new Post(acc1.Username, "Liverpool beats Man. City 2-1", true, "Sport"));
            Add("posts", new Post(acc1.Username, "Apple expects to release iPhone 14 in October", true, "News"));
            Add("posts", new Post(acc2.Username, "Expect snow next Sunday", true, "Weather"));
            Add("posts", new Post(acc3.Username, "Italy fails to qualify for the world cup", true, "Sport"));
            Add("posts", new Post(acc3.Username, "The deficit exceeds 2 million dollars", true, "Economy"));
            Add("posts", new Post(acc5.Username, "The minimum wage has been raised to 300 dinars", true, "Economy"));

            Add("reports", new Report(acc1.Username, acc2.Username, "He is gay!?"));
            Add("reports", new Report(acc3.Username, acc2.Username, "Hello, World!"));

            Add("reports", new Report(acc2.Username, acc1.Username, "I like one piece!"));

            Add("reports", new Report(acc1.Username, acc5.Username, "Hey, there!"));
            Add("reports", new Report(acc3.Username, acc5.Username, "This is a report."));

            Save();
        }

        public void CreateNewTable(string name)
        {
            tables.Add(new Table(name));
        }

        public Table? GetTable(string name)
        {
            foreach (Table table in tables)
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
            Table? table = GetTable(tableName) ?? throw new Exception("Table does not exist");
            table.AddData(data);
        }

        public void Remove(string tableName, object data)
        {
            Table? table = GetTable(tableName) ?? throw new Exception("Table does not exist");
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

            Table? table = GetTable("users") ?? throw new Exception("Table does not exist");
            foreach (object? user in table.Rows.Values)
            {
                useraccount? u = (useraccount)user;
                if (u.Username == username && u.Password == password && u.Status)
                {
                    return u;
                }
            }

            return null;
        }

        public int IndexOf(string TableName, string Username)
        {
            Table? table = GetTable(TableName) ?? throw new Exception("Table does not exist");

            int index = 0;

            foreach (object? user in table.Rows.Values)
            {
                useraccount? u = (useraccount)user;
                if (u.Username == Username)
                {
                    return index;
                }
            }

            return index;
        }
    }
}
