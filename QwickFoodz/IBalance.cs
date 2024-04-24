using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    public interface IBalance
    {
        public double WalletBalance { get; }
        double WalletRecharge(double rechargeAmount);
        double DeductBalance(double deductAmount);


    }
}