using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace DGIIProject
{
    public class ComprobanteFiscal
    {
        public string NCF { get; set; }
        public double Monto { get; set; }
        public double Itibis18 { get; set; }
        public Guid Key { get; set; }

        public ComprobanteFiscal(string ncf, double monto, double itibis)
        {
            this.NCF = ncf;
            this.Monto = monto;
            this.Itibis18 = itibis;
            this.Key = Guid.NewGuid();
        }
    }
}
