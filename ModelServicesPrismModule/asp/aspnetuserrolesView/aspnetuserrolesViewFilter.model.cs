using System.Collections.Generic;
using ModelInterfacesClassLibrary.interfaces.asp.aspnetuserrolesView;

namespace ModelServicesPrismModule.asp.aspnetuserrolesView {
    public class AspnetuserrolesViewFilter: IAspnetuserrolesViewFilter 
    {
        public IList<System.String>  UserId { get; set; }
        public IList< string > userIdOprtr { get; set; }
        public IList<System.String>  RoleId { get; set; }
        public IList< string > roleIdOprtr { get; set; }
        public IList<System.String>  UUserName { get; set; }
        public IList< string > uUserNameOprtr { get; set; }
        public IList<System.String>  RName { get; set; }
        public IList< string > rNameOprtr { get; set; }
        public IList< string > orderby { get; set; }
        public int? page { get; set; }
        public int? pagesize { get; set; }
    }
}

