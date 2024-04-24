using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public interface IBalance
    {
        // Property
        public double Balance { get; set; }

        //Abstract Methods
        double WalletRecharge(double rechargeAmount);
        double DeductBalance(double deductAmount);
        
        
        
    }
}