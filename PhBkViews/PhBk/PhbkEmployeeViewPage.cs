//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Linq.Expressions;
// using Newtonsoft.Json;
// using Newtonsoft.Json.Serialization;


namespace PhBkViews.PhBk {

    public class PhbkEmployeeViewPage {
        public int page { get; set; }
        public int pagesize { get; set; }
        public int pagecount { get; set; }
        public int total { get; set; }
        public List<PhbkEmployeeView> items { get; set; } = null!;
    }

}

