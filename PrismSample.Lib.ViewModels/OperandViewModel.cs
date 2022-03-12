using System;
using System.ComponentModel.DataAnnotations;
using Prism.Mvvm;
using Reactive.Bindings;

namespace PrismSample.Lib.ViewModels
{
    public class OperandViewModel : BindableBase
    {
        [Required, Range(-10000, 10000)]
        public ReactiveProperty<string> Operand { get; }

        public OperandViewModel()
        {
            Operand = new ReactiveProperty<string>("2").SetValidateAttribute(() => Operand);
        }
    }
}
