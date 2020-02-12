using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace e_Tagebuch_2._0
{
    public class e_Tagebuch_Context : DbContext
    {
        public e_Tagebuch_Context() : base()
        {
            Database.SetInitializer<e_Tagebuch_Context>(new CreateDatabaseIfNotExists<e_Tagebuch_Context>());
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Diary> Diaries { get; set; }
        public DbSet<Entry> Entries{ get; set; }
        public DbSet<Type> Types{ get; set; }
    }
    
    class model
    {
    }

    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public ICollection<Diary> Diaries { get; set; }
    }

    public class Diary
    {
        public int DiaryID { get; set; }
        public string Name { get; set; }
        public int user_id { get; set; }

        public ICollection<Entry> Entries { get; set; }
    }
    public class Entry
    {
        public int EntryID { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string Type { get; set; }
        public string Picture { get; set; }
        public DateTime Date { get; set; }
        public int Diary_id { get; set; }
    }

    public class Type
    {
        public int TypeID { get; set; }
        public string Name { get; set; }
    }

}
