#nullable disable
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;




namespace LpPhBkViews.PhBk {

    public interface IPhbkPhoneViewExtForLkUp {
        public System.Int32  PhoneId { get; set; }

        public System.String  Phone { get; set; }

        public System.Int32  EmployeeIdRef { get; set; }

        public System.Int32  PhoneTypeIdRef { get; set; }

    }

    public interface IPhbkPhoneViewExtForLkUpMsg {
        // 1 - insert; 2 - update; 3 - delete;
        public int Action { get; set; } 
        public IPhbkPhoneViewExtForLkUp OldVals { get; set; } 
        public IPhbkPhoneViewExtForLkUp NewVals { get; set; } 
    }

/*
  In appsettings.json it must be added the section like below.
  1. If a RabbitMq cluster is present:

  "PhbkPhoneViewExtForLkUpConf": {
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

  "PhbkPhoneViewExtForLkUpConf": {
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
  var myOptions = new PhbkPhoneViewExtForLkUpConf();
  configuration.GetSection(PhbkPhoneViewExtForLkUpConf.ConfName).Bind(myOptions);
   ...

*/

    public class PhbkPhoneViewExtForLkUpConf {
        public static string ConfName = "PhbkPhoneViewExtForLkUpConf";
        public string HostName { get; set; } = String.Empty;
        public string Username { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public string VirtualHostName { get; set; } = String.Empty;
        public string[] ClusterIpAddresses { get; set; } = null!;
    }
}

