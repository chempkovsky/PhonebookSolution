using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.interfaces.asp.aspnetroleView;

namespace ModelServicesPrismModule.asp.aspnetroleView {
    public class AspnetroleViewPage: IaspnetroleViewPage
    {
        public AspnetroleViewPage() {}

        [JsonConstructorAttribute]
        public AspnetroleViewPage(IList<AspnetroleView> items) 
        {
            if(items is null)
                this.items = new List<IAspnetroleView>();
            else
                this.items = new List<IAspnetroleView>(items);
        }

        [JsonProperty(PropertyName = "page")]
        public int page { get; set; }

        [JsonProperty(PropertyName = "pagesize")]
        public int pagesize { get; set; }

        [JsonProperty(PropertyName = "pagecount")]
        public int pagecount { get; set; }

        [JsonProperty(PropertyName = "total")]
        public int total { get; set; }

        [JsonProperty(PropertyName = "items")]
        public IList<IAspnetroleView> items { get; set; }
    }
}

