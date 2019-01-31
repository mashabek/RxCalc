using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using static RxCalc.Enums;

namespace RxCalc
{
    public static class Enums
    {
        public enum Operators
        {
            Add, Subtract, Multiply, Divide
        }
    }
    public class MainWindowViewModel : BindableBase
    {
        private Subject<string> operandsSubject;
        private Subject<Operators> operatorsSubject;
        public MainWindowViewModel()
        {
            operandsSubject = new Subject<string>();
            operatorsSubject = new Subject<Enums.Operators>();
            InputOperandCommand = new DelegateCommand<string>(InputOperand);
           // InputOperatorCommand = new DelegateCommand<Operators>(InputOperator);
            operandsSubject.Take(15).Subscribe(oper => Display += oper);
        }
        private string _display;
        public string Display
        {
            get { return _display; }
            set { SetProperty(ref _display, value); }
        }
        private void InputOperand(string operand)
        {
            operandsSubject.OnNext(operand);
        }
        private void InputOperator(Enums.Operators @operator)
        {
            operatorsSubject.OnNext(@operator);
        }
        public DelegateCommand<string> InputOperandCommand
        {
            get; set;
        }
        public DelegateCommand<Operators> InputOperatorCommand
        {
            get; set;
        }
    }
}
