using Xamarin.Forms;
using System.Windows.Input;
using CommonInterfacesClassLibrary.Interfaces;

namespace CommonUserControlLibrary.Classes {
    public class WebServiceFilterMenu: IWebServiceFilterMenuInterface
    {
        public string Id { get; set; }
        public string Caption { get; set; }
        public string IconName { get; set; }
        public Color IconColor { get; set; }
        public bool Enabled { get; set; }
        public object Data { get; set; }
        public object FeedbackData { get; set; }
        public ICommand Command { get; set; }
        public bool IsDestroyed { get; set; }
    }
}

