using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseMgr.Model
{
    public class ExpenseMaster
    {
        [Newtonsoft.Json.JsonProperty("Id")]
        public string Id
        {
            get;
            set;
        }

        public string UsrEmail
        {
            get;
            set;
        }
        public DateTime DateTaken
        {
            get;
            set;
        }

        public decimal Price
        {
            get;
            set;
        }

        public decimal Quantity
        {
            get;
            set;
        }

        public decimal Total
        {
            get;
            set;
        }

        //public decimal TotalDEE
        //{
        //    get;
        //    set;
        //}
        //public string LifeStyle
        //{
        //    get;
        //    set;
        //}

        //public string MedicalCondition
        //{
        //    get;
        //    set;
        //}
        //public string FoodPref
        //{
        //    get;
        //    set;
        //}

    }
}
