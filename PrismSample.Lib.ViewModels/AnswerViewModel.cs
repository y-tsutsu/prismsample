using Prism.Events;
using Prism.Mvvm;
using Reactive.Bindings;
using Unity;

namespace PrismSample.Lib.ViewModels
{
    using Models;
    using Views;

    public class AnswerViewModel : BindableBase
    {
        public ReactiveProperty<string> Answer { get; }

        public ReactiveCommand<object>? ShowDialogCommand { get; }

        [Dependency]
        public IModel? Model { get; set; }

        [Dependency]
        public IDialogHelper? DialogHelper { get; set; }

        public AnswerViewModel(IEventAggregator eventAggregator)
        {
            Answer = new ReactiveProperty<string>("4");

            eventAggregator.GetEvent<PubSubEvent<double>>().Subscribe(CalculateAnswer);

            ShowDialogCommand = new ReactiveCommand()
                .WithSubscribe(_ => DialogHelper!.ShowDialog($"N^2 = {Answer.Value}"));
        }

        private void CalculateAnswer(double operand)
        {
            Answer.Value = Model!.Calculate(operand).ToString();
        }
    }
}
