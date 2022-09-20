using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ModelInterfacesClassLibrary.interfaces.asp.aspnetuserrolesView;

namespace ModelServicesPrismModule.asp.aspnetuserrolesView {
    public class AspnetuserrolesViewPage: IaspnetuserrolesViewPage
    {
        public AspnetuserrolesViewPage() {}

        [JsonConstructorAttribute]
        public AspnetuserrolesViewPage(IList<AspnetuserrolesView> items) 
        {
            if(items is null)
                this.items = new List<IAspnetuserrolesView>();
            else
                this.items = new List<IAspnetuserrolesView>(items);
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
        public IList<IAspnetuserrolesView> items { get; set; }
    }
}

