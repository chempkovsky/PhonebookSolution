using System.Collections.Generic;
using ModelInterfacesClassLibrary.Phonebook.LprEmployee02;

namespace ModelServicesPrismModule.Phonebook.LprEmployee02 {
    public class LprEmployee02ViewFilter: ILprEmployee02ViewFilter 
    {
        public IList<System.Int32>  EmployeeId { get; set; }
        public IList< string > employeeIdOprtr { get; set; }
        public IList<System.Int32>  EmpLastNameIdRef { get; set; }
        public IList< string > empLastNameIdRefOprtr { get; set; }
        public IList<System.Int32>  EmpFirstNameIdRef { get; set; }
        public IList< string > empFirstNameIdRefOprtr { get; set; }
        public IList<System.Int32>  EmpSecondNameIdRef { get; set; }
        public IList< string > empSecondNameIdRefOprtr { get; set; }
        public IList<System.Int32>  DivisionIdRef { get; set; }
        public IList< string > divisionIdRefOprtr { get; set; }
        public IList< string > orderby { get; set; }
        public int? page { get; set; }
        public int? pagesize { get; set; }
    }
}

