using MvvmCross.Core.ViewModels;
using Redoubt.Core.Services;
using System.Windows.Input;

namespace Redoubt.Core.ViewModels
{
    public class BillViewModel : MvxViewModel
    {
        readonly IBillCalculator _calculation;
        private string _customerEmail;
        double _subTotal;
        int _gratuity;
        double _tip;
        double _total;

        public ICommand NavBack
        {
            get
            {
                return new MvxCommand(() => Close(this));
            }
        }

        public string CustomerEmail
        {
            get { return _customerEmail; }
            set
            {
                _customerEmail = value;

                RaisePropertyChanged(() => CustomerEmail);
            }
        }

        public double SubTotal
        {
            get { return _subTotal; }
            set
            {
                _subTotal = value;
                RaisePropertyChanged(() => SubTotal);
                Recalculate();
            }
        }

        public int Gratuity
        {
            get { return _gratuity; }
            set
            {
                _gratuity = value;
                RaisePropertyChanged(() => Gratuity);
                Recalculate();
            }
        }

        public double Tip
        {
            get { return _tip; }
            set
            {
                _tip = value;
                RaisePropertyChanged(() => Tip);
            }
        }

        public double Total
        {
            get { return _total; }
            set
            {
                _total = value;
                RaisePropertyChanged(() => Total);
            }
        }

        public BillViewModel(IBillCalculator calculation)
        {
            _calculation = calculation;
        }

        public void Init(int subTotal)
        {
            SubTotal = subTotal;
        }

        public override void Start()
        {
            _gratuity = 10;
            Recalculate();
            base.Start();
        }

        void Recalculate()
        {
            Tip = _calculation.TipAmount(SubTotal, Gratuity);
            Total = _calculation.BillTotal(SubTotal, Gratuity);
        }
    }
}
