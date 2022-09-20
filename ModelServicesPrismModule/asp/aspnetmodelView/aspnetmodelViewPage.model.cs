using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.interfaces.asp.aspnetmodelView;

namespace ModelServicesPrismModule.asp.aspnetmodelView {
    public class AspnetmodelViewPage: IaspnetmodelViewPage
    {
        public AspnetmodelViewPage() {}

        [JsonConstructorAttribute]
        public AspnetmodelViewPage(IList<AspnetmodelView> items) 
        {
            if(items is null)
                this.items = new List<IAspnetmodelView>();
            else
                this.items = new List<IAspnetmodelView>(items);
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
        public IList<IAspnetmodelView> items { get; set; }
    }
}

