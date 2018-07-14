using NLog;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;
using System;

namespace LogSample.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public Command<ClickedEventArgs> ButtonExceptionCommand { get; }
        public Command<ClickedEventArgs> ButtonTraceCommand { get; }
        public Command<ClickedEventArgs> ButtonDebugCommand { get; }
        public Command<ClickedEventArgs> ButtonInfoCommand { get; }
        public Command<ClickedEventArgs> ButtonWarnCommand { get; }
        public Command<ClickedEventArgs> ButtonErrorCommand { get; }
        public Command<ClickedEventArgs> ButtonFatalCommand { get; }

        public MainPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService) 
            : base (navigationService)
        {
            Title = "Main Page";
            var logger = Xamarin.Forms.DependencyService.Get<ILoggingService>();
            ButtonExceptionCommand = new Command<ClickedEventArgs>(async x =>
            {
                try
                {
                    await Test1Async();
                }
                catch (Exception ex)
                {
                    logger.Error(ex, nameof(ButtonExceptionCommand));
                }
            });
            ButtonTraceCommand = new Command<ClickedEventArgs>(async x =>
            {
                try
                {
                    logger.Trace("trace log message.");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                }
            });
            ButtonDebugCommand = new Command<ClickedEventArgs>(async x =>
            {
                try
                {
                    logger.Debug("debug log message.");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                }
            });
            ButtonInfoCommand = new Command<ClickedEventArgs>(async x =>
            {
                try
                {
                    logger.Info("info log message.");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                }
            });
            ButtonWarnCommand = new Command<ClickedEventArgs>(async x =>
            {
                try
                {
                    logger.Warn("warn log message.");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                }
            });
            ButtonErrorCommand = new Command<ClickedEventArgs>(async x =>
            {
                try
                {
                    logger.Error("error log message.");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                }
            });
            ButtonFatalCommand = new Command<ClickedEventArgs>(async x =>
            {
                try
                {
                    logger.Fatal("fatal log message.");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                }
            });
        }

        private async System.Threading.Tasks.Task Test1Async()
        {
            await Test2Async();
        }

        private async System.Threading.Tasks.Task Test2Async()
        {
            await NavigationService.NavigateAsync("TestPage");
        }
    }
}
