using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.interfaces.asp.aspnetrolemaskView;

namespace ModelServicesPrismModule.asp.aspnetrolemaskView {
    public class AspnetrolemaskViewPage: IaspnetrolemaskViewPage
    {
        public AspnetrolemaskViewPage() {}

        [JsonConstructorAttribute]
        public AspnetrolemaskViewPage(IList<AspnetrolemaskView> items) 
        {
            if(items is null)
                this.items = new List<IAspnetrolemaskView>();
            else
                this.items = new List<IAspnetrolemaskView>(items);
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
        public IList<IAspnetrolemaskView> items { get; set; }
    }
}

