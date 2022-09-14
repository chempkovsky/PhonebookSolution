using System.ComponentModel;
using Windows.UI.Xaml.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using CommonCustomControlLibrary.Controls;
using PrismPhonebook.UWP.Controls;

[assembly: ExportRenderer(typeof(NullableDatePicker), typeof(NullableDatePickerUWPRenderer))]
namespace PrismPhonebook.UWP.Controls {
    public class NullableDatePickerUWPRenderer: ViewRenderer<NullableDatePicker, Windows.UI.Xaml.Controls.Grid>
    {
        private CalendarDatePicker datePicker;
        private Windows.UI.Xaml.Controls.Button cancelButton;
        private Windows.UI.Xaml.Controls.Grid calendarView;

        protected override void OnElementChanged(ElementChangedEventArgs<NullableDatePicker> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null && Control == null)
            {
                this.datePicker = new CalendarDatePicker();
                this.datePicker.MinDate = this.Element.MinimumDate;
                this.datePicker.MaxDate = this.Element.MaximumDate;
                this.datePicker.Date = this.Element.NullableDate;
                this.datePicker.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Stretch;
                this.datePicker.DateChanged += DatePicker_DateChanged;
                this.cancelButton = new Windows.UI.Xaml.Controls.Button()
                {
                    Content = new SymbolIcon(Symbol.Cancel),
                    Margin = new Windows.UI.Xaml.Thickness(0),
                    Background = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.Transparent),
                    Command = new Command(
                        () => this.datePicker.Date = null,
                        () => this.datePicker.Date != null)
                };
                this.calendarView = new Windows.UI.Xaml.Controls.Grid() 
                { 
                    ColumnSpacing=0
                };
                this.calendarView.SizeChanged += CalendarView_SizeChanged;
                this.calendarView.ColumnDefinitions.Add(new Windows.UI.Xaml.Controls.ColumnDefinition()
                {
                    Width = new Windows.UI.Xaml.GridLength(1, Windows.UI.Xaml.GridUnitType.Star)
                });
                this.calendarView.ColumnDefinitions.Add(new Windows.UI.Xaml.Controls.ColumnDefinition()
                {
                    Width = new Windows.UI.Xaml.GridLength(0, Windows.UI.Xaml.GridUnitType.Auto)
                });
                this.calendarView.Children.Add(this.cancelButton);
                Windows.UI.Xaml.Controls.Grid.SetColumn(this.cancelButton, 1);
                this.calendarView.Children.Add(this.datePicker);
                Windows.UI.Xaml.Controls.Grid.SetColumn(this.datePicker, 0);
                this.SetNativeControl(this.calendarView);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == NullableDatePicker.NullableDateProperty.PropertyName) {
                var entry = (NullableDatePicker)this.Element;
                if (entry != null)
                {
                    this.datePicker.Date = entry.NullableDate;
                    ((Command)this.cancelButton.Command).ChangeCanExecute();
                }

            }
            if (e.PropertyName == Xamarin.Forms.DatePicker.FormatProperty.PropertyName)
            {
                var entry = (NullableDatePicker)this.Element;
                ((Command)cancelButton.Command).ChangeCanExecute();

                if (this.Element.Format == entry.PlaceHolder)
                {
                    this.datePicker.PlaceholderText = entry.PlaceHolder;
                    return;
                }
            }

            base.OnElementPropertyChanged(sender, e);
        }

        private void DatePicker_DateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
        {
            if (this.Element != null)
            {
                this.Element.NullableDate = args.NewDate?.Date;
            }
        }

        private void CalendarView_SizeChanged(object sender, Windows.UI.Xaml.SizeChangedEventArgs e)
        {
            if (this.Element != null)
            {
                // NOTE: Depending on the placeholder text, the width needed for the calendar view may be different
                this.Element.WidthRequest = e.NewSize.Width;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (Control != null)
            {
                this.datePicker.DateChanged -= DatePicker_DateChanged;
                this.datePicker = null;
                this.cancelButton = null;
                this.calendarView = null;
            }

            base.Dispose(disposing);
        }
    }
}

