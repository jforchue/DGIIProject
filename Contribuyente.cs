using System.ComponentModel.DataAnnotations;

namespace DGIIProject
{
    public class Contribuyente
    {
        public Contribuyente()
        {
            this.ComprobantesFiscales = new List<ComprobanteFiscal>();
        }

        public Contribuyente(string RncCedula,
            string Nombre, TipoContribuyente Tipo, EstadoContibuyente Status, List<ComprobanteFiscal> comprobanteFiscals)
        {
            this.RncCedula = RncCedula;
            this.Nombre = Nombre;
            this._Tipo = Tipo;
            this._Status = Status;
            this.ComprobantesFiscales = comprobanteFiscals ?? new List<ComprobanteFiscal>();
            Key = Guid.NewGuid();
        }

        public string RncCedula { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get { return _Tipo == TipoContribuyente.PersonaJuridica ? "PERSONA JURIDICA" : "PERSONA FISICA"; } }
        public string Status { get { return _Status == EstadoContibuyente.Activo ? "activo" : "inactivo"; } }
        private TipoContribuyente _Tipo { get; set; }
        private EstadoContibuyente _Status { get; set; }
        public List<ComprobanteFiscal> ComprobantesFiscales { get; set; }
        public Guid Key { get; set; }
    }

    public enum EstadoContibuyente
    {
        Activo,
        Inactivo
    }

    public enum TipoContribuyente
    {
        PersonaJuridica,
        PersonaFisica
    }
}
