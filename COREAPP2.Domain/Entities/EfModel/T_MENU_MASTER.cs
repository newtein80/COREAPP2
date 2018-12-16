using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace COREAPP2.Domain.Entities.EfModel
{
    public partial class T_MENU_MASTER : BaseEntity
    {
        private T_MENU_MASTER()
        {

        }

        public T_MENU_MASTER(int mENU_IDENTITY, string mENU_ID, string mENU_NAME, string pARENT_MENUID, string uSER_ROLL, int? uSER_AUTH, int? uSER_DUTY, string mENU_AREA, string mENU_CONTROLLER, string mENU_ACTION, bool? uSE_YN, int sORT_ORDER, string cSS_CLASS)
        {
            MENU_IDENTITY = mENU_IDENTITY;
            MENU_ID = mENU_ID;
            MENU_NAME = mENU_NAME;
            PARENT_MENUID = pARENT_MENUID;
            USER_ROLL = uSER_ROLL;
            USER_AUTH = uSER_AUTH;
            USER_DUTY = uSER_DUTY;
            MENU_AREA = mENU_AREA;
            MENU_CONTROLLER = mENU_CONTROLLER;
            MENU_ACTION = mENU_ACTION;
            USE_YN = uSE_YN;
            SORT_ORDER = sORT_ORDER;
            CSS_CLASS = cSS_CLASS;
        }

        [Key]
        public int MENU_IDENTITY { get; private set; }
        public string MENU_ID { get; set; }
        public string MENU_NAME { get; set; }
        public string PARENT_MENUID { get; set; }
        public string USER_ROLL { get; set; }
        public int? USER_AUTH { get; set; }
        public int? USER_DUTY { get; set; }
        public string MENU_AREA { get; set; }
        public string MENU_CONTROLLER { get; set; }
        public string MENU_ACTION { get; set; }
        public bool? USE_YN { get; set; }
        public int SORT_ORDER { get; set; }
        public DateTime? CREATED_DATE { get; private set; } = DateTime.Now;
        public string CSS_CLASS { get; set; }

        //// DDD Patterns comment
        //// Using a private collection field, better for DDD Aggregate's encapsulation
        //// so OrderItems cannot be added from "outside the AggregateRoot" directly to the collection,
        //// but only through the method Order.AddOrderItem() which includes behavior.
        //private readonly List<T_MENU_MASTER> _MENU_MASTERs = new List<T_MENU_MASTER>();

        //// Using List<>.AsReadOnly() 
        //// This will create a read only wrapper around the private list so is protected against "external updates".
        //// It's much cheaper than .ToList() because it will not have to copy all items in a new collection. (Just one heap alloc for the wrapper instance)
        ////https://msdn.microsoft.com/en-us/library/e78dcd75(v=vs.110).aspx 
        //public IReadOnlyCollection<T_MENU_MASTER> _MENU_MASTERs_Readonly => _MENU_MASTERs.AsReadOnly();
    }
}
