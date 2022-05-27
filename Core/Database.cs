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
    internal class Number
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
    internal class Database
    {
        public static List<User> users = new List<User>();
        public static List<Post> posts = new List<Post>();
        public static List<Message> messages = new List<Message>();
        public static List<Report> reports = new List<Report>();

        public static void Decode()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream u = new FileStream("NumberOfUsers.txt", FileMode.Open, FileAccess.Read);
            Number.NumberOfUsers = (int)bf.Deserialize(u);
            u.Close();

            FileStream p = new FileStream("NumberOfPosts.txt", FileMode.Open, FileAccess.Read);
            Number.NumberOfPosts = (int)bf.Deserialize(p);
            p.Close();

            FileStream m = new FileStream("NumberOfMessages.txt", FileMode.Open, FileAccess.Read);
            Number.NumberOfMessages = (int)bf.Deserialize(m);
            m.Close();

            FileStream r = new FileStream("NumberOfReports.txt", FileMode.Open, FileAccess.Read);
            Number.NumberOfReports = (int)bf.Deserialize(r);
            r.Close();

            FileStream fff = new FileStream("users.txt", FileMode.Open, FileAccess.Read);

            User c;
            for (int i = 0; i < Number.NumberOfUsers; i++)
            {
                c = (User)bf.Deserialize(fff);
                users.Add(c);
            }
            fff.Close();

            FileStream ffff = new FileStream("posts.txt", FileMode.Open, FileAccess.Read);
            Post g;
            for (int i = 0; i < Number.NumberOfPosts; i++)
            {
                g = (Post)bf.Deserialize(ffff);
                posts.Add(g);
            }
            ffff.Close();

            FileStream fffff = new FileStream("messages.txt", FileMode.Open, FileAccess.Read);
            Message mm;
            for (int i = 0; i < Number.NumberOfMessages; i++)
            {
                mm = (Message)bf.Deserialize(fffff);
                messages.Add(mm);
            }
            fffff.Close();

            FileStream ffffff = new FileStream("reports.txt", FileMode.Open, FileAccess.Read);
            Report re;
            for (int i = 0; i < Number.NumberOfReports; i++)
            {
                re = (Report)bf.Deserialize(ffffff);
                reports.Add(re);
            }
            ffffff.Close();
        }

        public static void Save(User u)
        {
            users.Add(u);
            Number.NumberOfUsers++;
        }

        public static void Save(Post p)
        {
            posts.Add(p);
            Number.NumberOfPosts++;
        }

        public static void Save(Message m)
        {
            messages.Add(m);
            Number.NumberOfMessages++;
        }

        public static void Save(Report r)
        {
            reports.Add(r);
            Number.NumberOfReports++;
        }

        public static void Remove(User u)
        {
            bool IsRemoved = users.Remove(u);
            if (IsRemoved) Number.NumberOfUsers--;
        }

        public static void Remove(Post p)
        {
            bool IsRemoved = posts.Remove(p);
            if (IsRemoved) Number.NumberOfPosts--;
        }

        public static void Remove(Message m)
        {
            bool IsRemoved = messages.Remove(m);
            if (IsRemoved) Number.NumberOfMessages--;
        }

        public static void Remove(Report r)
        {
            bool IsRemoved = reports.Remove(r);
            if (IsRemoved) Number.NumberOfReports--;
        }

        public static void Finish()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream f = new FileStream("users.txt", FileMode.Create, FileAccess.Write);
            for (int i = 0; i < Number.NumberOfUsers; i++)
            {
                bf.Serialize(f, users[i]);
            }
            f.Close();

            FileStream uu = new FileStream("NumberOfUsers.txt", FileMode.Create, FileAccess.Write);
            bf.Serialize(uu, Number.NumberOfUsers);
            uu.Close();

            FileStream ff = new FileStream("posts.txt", FileMode.Create, FileAccess.Write);
            for (int i = 0; i < Number.NumberOfPosts; i++)
            {
                bf.Serialize(ff, posts[i]);
            }
            ff.Close();

            FileStream pp = new FileStream("NumberOfPosts.txt", FileMode.Create, FileAccess.Write);
            bf.Serialize(pp, Number.NumberOfPosts);
            pp.Close();

            FileStream fff = new FileStream("messages.txt", FileMode.Create, FileAccess.Write);
            for (int i = 0; i < Number.NumberOfMessages; i++)
            {
                bf.Serialize(fff, messages[i]);
            }
            fff.Close();

            FileStream mm = new FileStream("NumberOfMessages.txt", FileMode.Create, FileAccess.Write);
            bf.Serialize(mm, Number.NumberOfMessages);
            mm.Close();

            FileStream ffff = new FileStream("reports.txt", FileMode.Create, FileAccess.Write);
            for (int i = 0; i < Number.NumberOfReports; i++)
            {
                bf.Serialize(ffff, messages[i]);
            }
            ffff.Close();

            FileStream rr = new FileStream("NumberOfReports.txt", FileMode.Create, FileAccess.Write);
            bf.Serialize(rr, Number.NumberOfReports);
            rr.Close();
        }
    }
}
