// #nullable disable
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;




namespace LpPhBkViews.PhBk {

    public interface IPhbkEmployeeViewExtForLkUp {
        public System.Int32  EmployeeId { get; set; }

        public System.String  EmpLastName { get; set; }

        public System.String  EmpFirstName { get; set; }

        public System.String ?  EmpSecondName { get; set; }

        public System.Int32  DivisionIdRef { get; set; }

    }

    public interface IPhbkEmployeeViewExtForLkUpMsg {
        // 1 - insert; 2 - update; 3 - delete;
        public int Action { get; set; } 
        public IPhbkEmployeeViewExtForLkUp OldVals { get; set; } 
        public IPhbkEmployeeViewExtForLkUp NewVals { get; set; } 
    }

/*
  In appsettings.json it must be added the section like below.
  1. If a RabbitMq cluster is present:

  "PhbkEmployeeViewExtForLkUpConf": {
    "HostName ": "192.168.100.3",
    "Username": "Admin",
    "Password": "Admin",
    "VirtualHostName": "phbkhost",
    "ClusterIpAddresses": [
      "192.168.100.4",
      "192.168.100.5",
      "192.168.100.6"
    ]
  }


  2. If a RabbitMq cluster is not present:

  "PhbkEmployeeViewExtForLkUpConf": {
    "HostName ": "192.168.100.3",
    "Username": "Admin",
    "Password": "Admin",
    "VirtualHostName": "phbkhost",
    "ClusterIpAddresses": []
  }

  3. In the Program.cs file add the code like below:

  var builder = WebApplication.CreateBuilder(args);
  ...
  ConfigurationManager configuration = builder.Configuration;
   ...
  var myOptions = new PhbkEmployeeViewExtForLkUpConf();
  configuration.GetSection(PhbkEmployeeViewExtForLkUpConf.ConfName).Bind(myOptions);
   ...

*/

    public class PhbkEmployeeViewExtForLkUpConf {
        public static string ConfName = "PhbkEmployeeViewExtForLkUpConf";
        public string HostName { get; set; } = String.Empty;
        public string Username { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public string VirtualHostName { get; set; } = String.Empty;
        public string[] ClusterIpAddresses { get; set; } = null!;
    }
}

