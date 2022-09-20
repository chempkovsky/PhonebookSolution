using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.interfaces.asp.aspnetuserpermsView;

namespace ModelServicesPrismModule.asp.aspnetuserpermsView {
    public class AspnetuserpermsViewPage: IaspnetuserpermsViewPage
    {
        public AspnetuserpermsViewPage() {}

        [JsonConstructorAttribute]
        public AspnetuserpermsViewPage(IList<AspnetuserpermsView> items) 
        {
            if(items is null)
                this.items = new List<IAspnetuserpermsView>();
            else
                this.items = new List<IAspnetuserpermsView>(items);
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
        public IList<IAspnetuserpermsView> items { get; set; }
    }
}

