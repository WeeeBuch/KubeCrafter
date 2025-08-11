using System.Configuration;
using System.Data;
using System.Windows;
using KubeCrafter.WinApp.Worker;

namespace KubeCrafter.WinApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public void ApplyTheme(string themeName)
        {
            var dict = new ResourceDictionary();
            switch (themeName)
            {
                case "Light":
                    dict.Source = new Uri("Themes/Light.xaml", UriKind.Relative);
                    break;
                case "Dark":
                    dict.Source = new Uri("Themes/Dark.xaml", UriKind.Relative);
                    break;
            }

            var existingDict = Resources.MergedDictionaries.FirstOrDefault(d => d.Source != null && d.Source.OriginalString.StartsWith("Themes/"));
            if (existingDict != null)
                Resources.MergedDictionaries.Remove(existingDict);

            Resources.MergedDictionaries.Add(dict);
        }
    }

}
