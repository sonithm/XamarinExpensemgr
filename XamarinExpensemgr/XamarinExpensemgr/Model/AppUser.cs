using System;

namespace ExpenseMgr.Model
{
    public class AppUser
    {
        [Newtonsoft.Json.JsonProperty("Id")]
        public string Id
        {
            get;
            set;
        }

        public string UsrName
        {
            get;
            set;
        }

        public string UsrEmail
        {
            get;
            set;
        }

        public int Height
        {
            get;
            set;
        }

        public string Sex
        {
            get;
            set;
        }

        public DateTime DateOBirth
        {
            get;
            set;
        }
    }
}
