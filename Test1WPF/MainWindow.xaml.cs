using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Test1WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        string _Name;
        public string userName
        {
            get { return _Name; }
            set { _Name = value;
                NotifyPropertyChanged();
            } 
        }
        string _DOB;
        public string DOB
        {
            get { return _DOB; }
            set { _DOB = value;
                NotifyPropertyChanged();
            }
        }

        int _Age;
        public int Age
        {
            get { return _Age; }
            set
            {
                _Age = value;
                NotifyPropertyChanged();
            }
        }

        public MainWindow()
        {
            
            InitializeComponent();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine(_Name, _DOB);
            Age = get_age(_DOB);
        }
        public int get_age(string dob)
        {
            DateTime dobDT = Convert.ToDateTime(dob);
            int age = 0;
            age = DateTime.Now.Subtract(dobDT).Days;
            age = age / 365;
            return age;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
