using Xamarin.Forms;
using System.Collections.Generic;
using CommonInterfacesClassLibrary.Interfaces;


namespace CommonServicesPrismModule.UserControls {
    /// <summary>
    /// Interaction logic for ColumnSelectorUserControl.xaml
    /// </summary>
    public partial class ColumnSelectorUserControl: ContentView
    {
        public ColumnSelectorUserControl()
        {
            InitializeComponent();
        }
        #region Columns
        public static readonly BindableProperty ColumnsProperty =
                BindableProperty.Create(
                "Columns", typeof(IEnumerable<IColumnSelectorItemDefInterface>),
                typeof(ColumnSelectorUserControl),
                null);
        public IEnumerable<IColumnSelectorItemDefInterface> Columns
        {
            get
            {
                return (IEnumerable<IColumnSelectorItemDefInterface>)GetValue(ColumnsProperty);
            }
            set
            {
                SetValue(ColumnsProperty, value);
            }
        }
        #endregion

    }
}

