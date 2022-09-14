

using CommonInterfacesClassLibrary.Interfaces;

namespace CommonUserControlLibrary.Classes {
    public class ColumnSelectorItemDef: IColumnSelectorItemDefInterface
    {
        public string Name { get; set; }
        public string Caption { get; set; }
        public bool IsChecked { get; set; }
    }
}

