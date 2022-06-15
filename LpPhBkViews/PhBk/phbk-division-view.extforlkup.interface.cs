#nullable disable
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;




namespace LpPhBkViews.PhBk {

    public interface IPhbkDivisionViewExtForLkUp {
        public System.Int32  DivisionId { get; set; }

        public System.String  DivisionName { get; set; }

        public System.Int32  EntrprsIdRef { get; set; }

    }

    public interface IPhbkDivisionViewExtForLkUpMsg {
        // 1 - insert; 2 - update; 3 - delete;
        public int Action { get; set; } 
        public IPhbkDivisionViewExtForLkUp OldVals { get; set; } 
        public IPhbkDivisionViewExtForLkUp NewVals { get; set; } 
    }

/*
  In appsettings.json it must be added the section like below.
  1. If a RabbitMq cluster is present:

  "PhbkDivisionViewExtForLkUpConf": {
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

  "PhbkDivisionViewExtForLkUpConf": {
    "HostName ": "192.168.100.3",
    "Username": "Admin",
    "Password": "Admin",
    "VirtualHostName": "phbkhost",
    "ClusterIpAddresses": []
  }

  3. Add code to the Program.cs file as shown below:



  var builder = WebApplication.CreateBuilder(args);
  ...
  ConfigurationManager configuration = builder.Configuration;
   ...
  var myOptions = new PhbkDivisionViewExtForLkUpConf();
  configuration.GetSection(PhbkDivisionViewExtForLkUpConf.ConfName).Bind(myOptions);
   ...

*/

    public class PhbkDivisionViewExtForLkUpConf {
        public static string ConfName = "PhbkDivisionViewExtForLkUpConf";
        public string HostName { get; set; } = String.Empty;
        public string Username { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public string VirtualHostName { get; set; } = String.Empty;
        public string[] ClusterIpAddresses { get; set; } = null!;
    }
}

