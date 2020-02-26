using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Tagebuch_2._0
{
    class controlling
    {
        public User Check_Credential(string t_Username, string t_Password)
        {
            using (var DB = new e_Tagebuch_Context())
            {
                return DB.Users.FirstOrDefault(u => u.Username == t_Username && u.Password == t_Password);     
            }
        }

        public void Show_Diary(int t_currentUserID)
        {
            //Create a from DiaryElector
            frmDiaryElector DiaryElector = new frmDiaryElector(t_currentUserID);
            DiaryElector.Show();
        }

        public int Create_Diary(string t_Name, int t_ID)
        {
            int id = -1;
            using (var DB = new e_Tagebuch_Context())
            {
                //Get UserID
                var user = DB.Users.FirstOrDefault(u => u.UserID == t_ID);
                //Create Diary
                var newDiary = DB.Diaries.Add(new Diary()
                {
                    Name = t_Name,
                    user_id = user.UserID
                });
                DB.SaveChanges();
                id = newDiary.DiaryID;
            }
            return id;
        }

        public void Show_SearchWindow(int t_DiaryID)
        {
            //Create a from SearchWindow
            frmSearchWindow SearchWindow = new frmSearchWindow(t_DiaryID);
            SearchWindow.Show();
        }

        public int Create_Entry(string t_Name, int t_DiaryID)
        {
            int id = -1;
            using (var DB = new e_Tagebuch_Context())
            {
                //Create entry
                var newEntry = DB.Entries.Add(new Entry()
                {
                    Name = t_Name,
                    Diary_id = t_DiaryID,
                    Date = DateTime.Now.Date
                   
                });
                DB.SaveChanges();
                id = newEntry.EntryID;
            }
            return id;
        }

        public List<Entry> Get_AllEntries(int t_DiaryID)
        {
            List<Entry> AllEntries = new List<Entry>();
            using (var DB = new e_Tagebuch_Context())
            {
                //Get list of all entries
                AllEntries = DB.Entries.Where(e => e.Diary_id == t_DiaryID).ToList();
            }
            return AllEntries;
        }

        public List<String> Get_AllDiaries(int t_UserID)
        {
            List<String> AllDiaries = new List<String>();
            using (var DB = new e_Tagebuch_Context())
            {
                //Get list of all entries
                AllDiaries = DB.Diaries.Where(d => d.user_id == t_UserID).Select(d => d.Name).ToList();
            }
            return AllDiaries;
        }

        public void Save_Entry(int t_ID, string t_Name, DateTime t_Date, string t_Text, string t_Picture)
        {
            using (var DB = new e_Tagebuch_Context())
            {
                //Get entry
                var entry = DB.Entries.FirstOrDefault(e => e.EntryID == t_ID);

                //set current values
                entry.Name = t_Name;
                entry.Date = t_Date.Date;
                entry.Text = t_Text;
                entry.Picture = t_Picture;

                //Save
                DB.SaveChanges();
            }
        }

        public Diary Get_DiaryFromEntry(int t_EntryID)
        {
            e_Tagebuch_Context DB = new e_Tagebuch_Context();
            int diaryID = DB.Entries.FirstOrDefault(e => e.EntryID == t_EntryID).Diary_id;
            return DB.Diaries.FirstOrDefault(d => d.DiaryID == diaryID);
        }

        public void Save_types(int t_EntryID, string[] t_typ)
        {
            e_Tagebuch_Context DB = new e_Tagebuch_Context();
            var entry = DB.Entries.FirstOrDefault(e => e.EntryID == t_EntryID);
            string type = string.Join(",",t_typ);
            entry.Type = type;
            DB.SaveChanges();
        }

        public string[] Get_types(int t_EntryID)
        {
            e_Tagebuch_Context DB = new e_Tagebuch_Context();
            var entry = DB.Entries.FirstOrDefault(e => e.EntryID == t_EntryID);
            if (entry.Type != null)
            {
                return entry.Type.Split(',');
            }
            return null;
        }
        
        public bool Diary_Exist(string t_Name)
        {
            e_Tagebuch_Context DB = new e_Tagebuch_Context();
            return DB.Diaries.Any(d => d.Name == t_Name);
        }

        public bool Remove_Entry(int t_EntryID) 
        {
            bool returnValue = true;
            try
            {
                e_Tagebuch_Context DB = new e_Tagebuch_Context();
                DB.Entries.Remove(DB.Entries.FirstOrDefault(e => e.EntryID == t_EntryID));
                DB.SaveChanges();
            } catch
            {
                returnValue = false;
            }

            return returnValue;
        }

        public List<Entry> Search_Entries(string t_SearchMethod, string t_Value)
        {
            var foundEntries = new List<Entry>();
            e_Tagebuch_Context DB = new e_Tagebuch_Context();

            if (t_SearchMethod == "Name")
            {
                foundEntries = DB.Entries.Where(e => e.Name == t_Value).ToList();
            }
            else if (t_SearchMethod == "Date")
            {
                DateTime date = DateTime.Parse(t_Value).Date;
                foundEntries = DB.Entries.Where(e => e.Date == date).ToList();
            }
            else if (t_SearchMethod == "Type")
            {
                foundEntries = DB.Entries.Where(e => e.Type.Contains(t_Value)).ToList();
                
            }
            
            return foundEntries;
        }

        public List<object> Get_EmptyDays(DateTime t_From, DateTime t_To)
        {
            var foundEntries = new List<object>();
            e_Tagebuch_Context DB = new e_Tagebuch_Context();

            //Date range (Aus dem Internet: https://stackoverflow.com/questions/1847580/how-do-i-loop-through-a-date-range)
            IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
            {
                for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                    yield return day;
            }
            foreach (DateTime day in EachDay(t_From, t_To))
            {
                if (!DB.Entries.Any(e => e.Date == day))
                {
                    var value = new { Name = "Empty day", Date = day};
                    foundEntries.Add(value);
                }
            }
            return foundEntries;
        }

        public int Get_UserID(string t_UserName)
        {
            e_Tagebuch_Context DB = new e_Tagebuch_Context();
            return DB.Users.FirstOrDefault(u => u.Username == t_UserName).UserID;
        }
        public string Get_UserName(int t_UserID)
        {
            e_Tagebuch_Context DB = new e_Tagebuch_Context();
            return DB.Users.FirstOrDefault(u => u.UserID == t_UserID).Username;
        }
        public string Get_DiaryUser(int t_DiaryID)
        {
            e_Tagebuch_Context DB = new e_Tagebuch_Context();
            return Get_UserName(DB.Diaries.FirstOrDefault(d => d.DiaryID== t_DiaryID).user_id);
        }

        public User Create_User (string t_User, string t_Pw)
        {
            e_Tagebuch_Context DB = new e_Tagebuch_Context();
            var newUser = DB.Users.Add(new User()
            {
                Username = t_User,
                Password = t_Pw
            });
            DB.SaveChanges();
            return newUser;
        }
    }
}
