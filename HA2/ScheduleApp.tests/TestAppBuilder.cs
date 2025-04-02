using Avalonia;
using Avalonia.Headless;
using Avalonia.Headless.XUnit;

[assembly: AvaloniaTestApplication(typeof(ScheduleApp.Tests.TestAppBuilder))]

namespace ScheduleApp.Tests;
    public class TestAppBuilder
{
    public static AppBuilder BuildAvaloniaApp() =>
        AppBuilder.Configure<App>()
                  .UseHeadless(new AvaloniaHeadlessPlatformOptions());
}