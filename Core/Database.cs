using System.Runtime.Serialization.Formatters.Binary;

/*
*NOTE: Database implementation by Omar AL-Saleh
if you have any question, keep it for yourself I am not a google (بمزح ) ☻☻☻☻☻☻☻☻☻☻☻☻☻☻☻☻☻☻☻☻☻☻☻☻

*INFO: Hashem Al-Radaideh:
begin the main entry point of the program, calling the decode method,
and end the main with finish method to restore previous data and save new data in data base
!WARN: please do not use the atrribute Add or Remove for the lists in the database or it will generate (مصايب)
!HACK: insted of that use the static method Save, to add new (User, Post, Message, Report) to the list, and and the method Remove to remove (User, Post, Message, Report)
do not edit the database class especially the methods (decode,finish) without telling me

*INFO: Omar khasawneh:
Work on any class except the database class, but don't change the name of classes
and good luck
*/

/// <summary>
/// Database implementation for the Social Network Service project.
/// </summary>
namespace Core
{
    /// <summary>
    /// Dependency of the Database class.
    /// used to store the number of elements in each field of the database.
    /// </summary>
    [Serializable]
    public class Number
    {
        public static int NumberOfUsers = 0;
        public static int NumberOfPosts = 0;
        public static int NumberOfMessages = 0;
        public static int NumberOfReports = 0;
    }

    /// <summary>
    /// Implementation of the Database class.
    /// </summary>
    [Serializable]
    public class Database
    {
        public static List<User> Users = new List<User>();
        public static List<Post> Posts = new List<Post>();
        public static List<Message> Messages = new List<Message>();
        public static List<Report> Reports = new List<Report>();

        /// <summary>
        /// Load the database and it's contents from the file.
        /// </summary>
        public static void Decode()
        {
            var path = System.IO.Directory.GetCurrentDirectory() + "\\..\\..\\..\\Dependencies\\";
            BinaryFormatter bf = new BinaryFormatter();

            FileStream u = new FileStream(path + "NumberOfUsers.txt", FileMode.Open, FileAccess.Read);
            Number.NumberOfUsers = (int)bf.Deserialize(u);
            u.Close();

            FileStream p = new FileStream(path + "NumberOfPosts.txt", FileMode.Open, FileAccess.Read);
            Number.NumberOfPosts = (int)bf.Deserialize(p);
            p.Close();

            FileStream m = new FileStream(path + "NumberOfMessages.txt", FileMode.Open, FileAccess.Read);
            Number.NumberOfMessages = (int)bf.Deserialize(m);
            m.Close();

            FileStream r = new FileStream(path + "NumberOfReports.txt", FileMode.Open, FileAccess.Read);
            Number.NumberOfReports = (int)bf.Deserialize(r);
            r.Close();

            FileStream usersData = new FileStream(path + "users.txt", FileMode.Open, FileAccess.Read);
            for (int i = 0; i < Number.NumberOfUsers; i++)
            {
                User c = (User)bf.Deserialize(usersData);
                Users.Add(c);
            }
            usersData.Close();

            FileStream postsData = new FileStream(path + "posts.txt", FileMode.Open, FileAccess.Read);
            for (int i = 0; i < Number.NumberOfPosts; i++)
            {
                Post g = (Post)bf.Deserialize(postsData);
                Posts.Add(g);
            }
            postsData.Close();

            FileStream messagesData = new FileStream(path + "messages.txt", FileMode.Open, FileAccess.Read);
            for (int i = 0; i < Number.NumberOfMessages; i++)
            {
                Message mm = (Message)bf.Deserialize(messagesData);
                Messages.Add(mm);
            }
            messagesData.Close();

            FileStream reportsData = new FileStream(path + "reports.txt", FileMode.Open, FileAccess.Read);
            for (int i = 0; i < Number.NumberOfReports; i++)
            {
                Report re = (Report)bf.Deserialize(reportsData);
                Reports.Add(re);
            }
            reportsData.Close();
        }

        /// <summary>
        /// Save the database and it's contents to the file.
        /// </summary>
        public static void Finish()
        {
            var path = System.IO.Directory.GetCurrentDirectory() + "\\..\\..\\..\\Dependencies\\";
            BinaryFormatter bf = new BinaryFormatter();

            FileStream usersData = new FileStream(path + "users.txt", FileMode.Create, FileAccess.Write);
            for (int i = 0; i < Number.NumberOfUsers; i++)
            {
                bf.Serialize(usersData, Users[i]);
            }
            usersData.Close();

            FileStream usersNum = new FileStream(path + "NumberOfUsers.txt", FileMode.Create, FileAccess.Write);
            bf.Serialize(usersNum, Number.NumberOfUsers);
            usersNum.Close();

            FileStream postsData = new FileStream(path + "posts.txt", FileMode.Create, FileAccess.Write);
            for (int i = 0; i < Number.NumberOfPosts; i++)
            {
                bf.Serialize(postsData, Posts[i]);
            }
            postsData.Close();

            FileStream postsNum = new FileStream(path + "NumberOfPosts.txt", FileMode.Create, FileAccess.Write);
            bf.Serialize(postsNum, Number.NumberOfPosts);
            postsNum.Close();

            FileStream messagesData = new FileStream(path + "messages.txt", FileMode.Create, FileAccess.Write);
            for (int i = 0; i < Number.NumberOfMessages; i++)
            {
                bf.Serialize(messagesData, Messages[i]);
            }
            messagesData.Close();

            FileStream messagesNum = new FileStream(path + "NumberOfMessages.txt", FileMode.Create, FileAccess.Write);
            bf.Serialize(messagesNum, Number.NumberOfMessages);
            messagesNum.Close();

            FileStream reportsData = new FileStream(path + "reports.txt", FileMode.Create, FileAccess.Write);
            for (int i = 0; i < Number.NumberOfReports; i++)
            {
                bf.Serialize(reportsData, Messages[i]);
            }
            reportsData.Close();

            FileStream reportsNum = new FileStream(path + "NumberOfReports.txt", FileMode.Create, FileAccess.Write);
            bf.Serialize(reportsNum, Number.NumberOfReports);
            reportsNum.Close();
        }

        /// <summary>
        /// Save given item to the database.
        /// </summary>
        /// <param name="user">user to save.</param>
        public static void Save(User user)
        {
            Users.Add(user);
            Number.NumberOfUsers++;
        }

        /// <summary>
        /// Save given item to the database.
        /// </summary>
        /// <param name="post">post to save.</param>
        public static void Save(Post post)
        {
            Posts.Add(post);
            Number.NumberOfPosts++;
        }

        /// <summary>
        /// Save given item to the database.
        /// </summary>
        /// <param name="message">message to save.</param>
        public static void Save(Message message)
        {
            Messages.Add(message);
            Number.NumberOfMessages++;
        }

        /// <summary>
        /// Save given item to the database.
        /// </summary>
        /// <param name="report">report to save.</param>
        public static void Save(Report report)
        {
            Reports.Add(report);
            Number.NumberOfReports++;
        }

        /// <summary>
        /// Save given item to the database.
        /// </summary>
        /// <param name="user">user to save.</param>
        public static void Remove(User user)
        {
            bool IsRemoved = Users.Remove(user);
            if (IsRemoved) Number.NumberOfUsers--;
        }

        /// <summary>
        /// Save given item to the database.
        /// </summary>
        /// <param name="post">post to remove.</param>
        public static void Remove(Post post)
        {
            bool IsRemoved = Posts.Remove(post);
            if (IsRemoved) Number.NumberOfPosts--;
        }

        /// <summary>
        /// Save given item to the database.
        /// </summary>
        /// <param name="message">message to remove.</param>
        public static void Remove(Message message)
        {
            bool IsRemoved = Messages.Remove(message);
            if (IsRemoved) Number.NumberOfMessages--;
        }

        /// <summary>
        /// Save given item to the database.
        /// </summary>
        /// <param name="report">report to remove.</param>
        public static void Remove(Report report)
        {
            bool IsRemoved = Reports.Remove(report);
            if (IsRemoved) Number.NumberOfReports--;
        }
    }
}
