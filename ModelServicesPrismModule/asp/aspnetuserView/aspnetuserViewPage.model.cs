using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.interfaces.asp.aspnetuserView;

namespace ModelServicesPrismModule.asp.aspnetuserView {
    public class AspnetuserViewPage: IaspnetuserViewPage
    {
        public AspnetuserViewPage() {}

        [JsonConstructorAttribute]
        public AspnetuserViewPage(IList<AspnetuserView> items) 
        {
            if(items is null)
                this.items = new List<IAspnetuserView>();
            else
                this.items = new List<IAspnetuserView>(items);
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
        public IList<IAspnetuserView> items { get; set; }
    }
}

