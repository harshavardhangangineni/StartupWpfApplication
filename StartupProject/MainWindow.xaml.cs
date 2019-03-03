using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace StartupProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            IsOpenOnStartUp.IsChecked = false;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Startup.Text = "on Startup The application is opened.Try to restart the system";
            InstallMeOnStartUp(true);
        }

        private void IsOpenOnStartUp_Unchecked(object sender, RoutedEventArgs e)
        {
            Startup.Text = "Check the Checkbox to open on startup";
            InstallMeOnStartUp(false);
        }
        void InstallMeOnStartUp(bool b)
        {
            try
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                Assembly curAssembly = Assembly.GetExecutingAssembly();
                if(b)
                key.SetValue(curAssembly.GetName().Name, curAssembly.Location);
                else
                {
                    key.DeleteValue(curAssembly.GetName().Name);
                }
            }
            catch { }
        }

    }
}
