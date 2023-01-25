using System.ComponentModel;
using System.Windows.Controls;

namespace AakStudio.Shell.UI.Showcase.ControlViews
{
    /// <summary>
    /// TextBoxView.xaml 的交互逻辑
    /// </summary>
    public partial class TextBoxView : UserControl
    {
        public string? Number
        {
            get => number;
            set
            {
                number = value;
                OnPropertyChanged(nameof(Number));
            }
        }

        public TextBoxView()
        {
            InitializeComponent();
        }

        private string? number;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class NumberValidator : ValidationRule
    {
        public override ValidationResult Validate
          (object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (string.IsNullOrEmpty(value.ToString()))
            {
                return new ValidationResult(true, "");
            }

            if (int.TryParse(value.ToString(), out int _) == false)
            {
                return new ValidationResult(false, "Numbers only!");
            }

            return ValidationResult.ValidResult;
        }
    }
}
