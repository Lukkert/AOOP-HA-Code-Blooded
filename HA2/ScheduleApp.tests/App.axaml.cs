using Avalonia;
using Avalonia.Markup.Xaml;

namespace UniversityManagement.Tests
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}