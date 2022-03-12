using Prism.Events;
using Prism.Mvvm;
using Reactive.Bindings;
using Unity;

namespace PrismSample.Lib.ViewModels
{
    using Models;

    public class AnswerViewModel : BindableBase
    {
        public ReactiveProperty<string> Answer { get; }

        public ReactiveCommand<object>? ShowDialogCommand { get; }

        [Dependency]
        public IModel? Model { get; set; }

        public AnswerViewModel(IEventAggregator eventAggregator)
        {
            Answer = new ReactiveProperty<string>("4");

            eventAggregator.GetEvent<PubSubEvent<double>>().Subscribe(CalculateAnswer);
        }

        private void CalculateAnswer(double operand)
        {
            Answer.Value = Model != null ? Model.Calculate(operand).ToString() : string.Empty;
        }
    }
}
