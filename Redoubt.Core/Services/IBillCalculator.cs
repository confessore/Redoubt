namespace Redoubt.Core.Services
{
    public interface IBillCalculator
    {
        double TipAmount(double subTotal, int gratuity);
        double BillTotal(double subTotal, int gratuity);
    }
}
