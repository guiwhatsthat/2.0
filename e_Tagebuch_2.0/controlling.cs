using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Tagebuch_2._0
{
    class controlling
    {
        public bool Check_Credential(string t_Username, string t_Password)
        {
            using (var DB = new e_Tagebuch_Context())
            {
                return DB.Users.Any(u => u.Username == t_Username && u.Password == t_Password);     
            }
        }

        public void Show_Diary(string t_CurrentUserName)
        {
            //Create a from DiaryElector
            frmDiaryElector DiaryElector = new frmDiaryElector(t_CurrentUserName);
            DiaryElector.Show();
        }

        public int Create_Diary(string t_Name, string t_User)
        {
            int id = -1;
            using (var DB = new e_Tagebuch_Context())
            {
                //Get UserID
                var user = DB.Users.FirstOrDefault(u => u.Username == t_User);
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

        public List<String> Get_AllDiaries()
        {
            List<String> AllDiaries = new List<String>();
            using (var DB = new e_Tagebuch_Context())
            {
                //Get list of all entries
                AllDiaries = DB.Diaries.Select(d => d.Name).ToList();
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
    }
}
