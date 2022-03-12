using System.ComponentModel.DataAnnotations;
using System.Reactive.Linq;
using Prism.Events;
using Prism.Mvvm;
using Reactive.Bindings;
using Unity;

namespace PrismSample.Lib.ViewModels
{
    using Views;

    public class OperandViewModel : BindableBase
    {
        [Required, Range(-10000, 10000)]
        public ReactiveProperty<string> Operand { get; }

        [Dependency]
        public IDialogHelper? DialogHelper { get; set; }

        public ReactiveCommand<object> ShowDialogCommand { get; }

        public OperandViewModel(IEventAggregator eventAggregator)
        {
            Operand = new ReactiveProperty<string>("2").SetValidateAttribute(() => Operand);

            Observable.WithLatestFrom
            (
                Operand,
                Operand.ObserveHasErrors,
                (o, e) => (o, e)
            )
            .Where(x => !x.e)
            .Subscribe(x =>
            {
                eventAggregator.GetEvent<PubSubEvent<double>>().Publish(double.Parse(x.o));
            });

            ShowDialogCommand = new ReactiveCommand(Operand.ObserveHasErrors.Select(x => !x))
                .WithSubscribe(_ => DialogHelper!.ShowDialog($"N = {Operand.Value}"));
        }
    }
}
