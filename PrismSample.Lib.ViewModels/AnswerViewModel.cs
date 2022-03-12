using Prism.Mvvm;
using Reactive.Bindings;

namespace PrismSample.Lib.ViewModels
{
    public class AnswerViewModel : BindableBase
    {
        public ReactiveProperty<string> Answer { get; }

        public AnswerViewModel()
        {
            Answer = new ReactiveProperty<string>("4");
        }
    }
}
