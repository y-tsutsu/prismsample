using System.Windows;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Unity;
using PrismSample.Lib.Models;
using PrismSample.Lib.Views;
using PrismSample.Lib.ViewModels;

namespace PrismSample.App.Main
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IDialogHelper, DialogHelper>();
            containerRegistry.Register<IModel, Model>();
        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();

            ViewModelLocationProvider.Register<MainWindow, MainWindowViewModel>();
            ViewModelLocationProvider.Register<OperandView, OperandViewModel>();
            ViewModelLocationProvider.Register<AnswerView, AnswerViewModel>();
        }
    }
}
