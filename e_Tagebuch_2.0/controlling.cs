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
    }
}
