using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.interfaces.asp.aspnetusermaskView;

namespace ModelServicesPrismModule.asp.aspnetusermaskView {
    public class AspnetusermaskViewPage: IaspnetusermaskViewPage
    {
        public AspnetusermaskViewPage() {}

        [JsonConstructorAttribute]
        public AspnetusermaskViewPage(IList<AspnetusermaskView> items) 
        {
            if(items is null)
                this.items = new List<IAspnetusermaskView>();
            else
                this.items = new List<IAspnetusermaskView>(items);
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
        public IList<IAspnetusermaskView> items { get; set; }
    }
}

