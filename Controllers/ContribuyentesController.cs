using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace DGIIProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContribuyentesController : ControllerBase
    {
        SqlConnection sql = new SqlConnection();

        public IConfiguration Configuration { get; }

        List<Contribuyente> contribuyentes = new List<Contribuyente>();

        public ContribuyentesController(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;

            sql.ConnectionString = configuration.GetConnectionString("DevConnection");

            contribuyentes = new List<Contribuyente>()
            {
                new Contribuyente("00112345678", "Juan Pérez", (TipoContribuyente)1, EstadoContibuyente.Activo, new List<ComprobanteFiscal>
                {
                    new ComprobanteFiscal("B010123456", 50000, 9000),
                    new ComprobanteFiscal("B010789012", 75000, 13500)
                }),
                new Contribuyente("00123456789", "María García",  (TipoContribuyente)2, EstadoContibuyente.Inactivo, new List<ComprobanteFiscal>
                {
                    new ComprobanteFiscal("B010345678", 60000, 10800),
                    new ComprobanteFiscal("B010901234", 35000, 6300)
                }),
                new Contribuyente("00134567890", "Pedro López",  (TipoContribuyente)1, EstadoContibuyente.Activo, new List<ComprobanteFiscal>()),
                new Contribuyente("00145678901", "Ana Martínez",  (TipoContribuyente)2, EstadoContibuyente.Inactivo, new List<ComprobanteFiscal>()),
                new Contribuyente("00156789012", "Luis Rodríguez",  (TipoContribuyente)1, EstadoContibuyente.Activo, new List<ComprobanteFiscal>
                {
                    new ComprobanteFiscal("B010567890", 80000, 14400)
                }),
                new Contribuyente("00167890123", "Laura Hernández",  (TipoContribuyente)2, EstadoContibuyente.Inactivo, new List<ComprobanteFiscal>
                {
                    new ComprobanteFiscal("B010234567", 40000, 7200),
                    new ComprobanteFiscal("B010890123", 55000, 9900)
                }),
                new Contribuyente("00178901234", "Carlos Sánchez",  (TipoContribuyente)1, EstadoContibuyente.Activo, new List<ComprobanteFiscal>
                {
                    new ComprobanteFiscal("B010456789", 70000, 12600)
                }),
                new Contribuyente("00189012345", "Sofía Díaz",  (TipoContribuyente)2, EstadoContibuyente.Inactivo, new List<ComprobanteFiscal>
                {
                    new ComprobanteFiscal("B010012345", 45000, 8100)
                }),
                new Contribuyente("00190123456", "Roberto Gómez",  (TipoContribuyente)1, EstadoContibuyente.Activo, new List<ComprobanteFiscal>
                {
                    new ComprobanteFiscal("B010678901", 85000, 15300),
                    new ComprobanteFiscal("B010234567", 60000, 10800),
                    new ComprobanteFiscal("B010890123", 70000, 12600)
                }),
                new Contribuyente("00101234567", "Elena Vázquez",  (TipoContribuyente)2, EstadoContibuyente.Activo, new List<ComprobanteFiscal>
                {
                    new ComprobanteFiscal("B010345678", 50000, 9000),
                    new ComprobanteFiscal("B010901234", 90000, 16200)
                })
            };
        }

        [HttpGet]
        public object Get()
        {
            return contribuyentes;
        }

        [HttpGet]
        [Route("{id}")]
        public object Comprobantes(string id)
        {
            var contribuyente = contribuyentes.SingleOrDefault(x => x.RncCedula == id);

            if (contribuyente == null)
                return new { Message = "Esta persona no existe." };

            var comprobantes = contribuyente.ComprobantesFiscales
                .Select(x => new { RncCedula = id, x.NCF, x.Monto, x.Itibis18 });

            if (comprobantes.Count() == 0)
                return new { Message = "Esta persona no tiene comprobantes." };

            return comprobantes;
        }

        [HttpGet]
        [Route("/ContribuyentesComprobantes")]
        public object ContribuyentesComprobantes()
        {
            return contribuyentes.Select(x => new
            {
                x.Nombre,
                x.RncCedula,
                x.Tipo,
                x.Status,
                x.ComprobantesFiscales,
                x.Key,
                TotalItebis = Math.Round(x.ComprobantesFiscales.Sum(x1 => x1.Itibis18), 2)
            });
        }
    }
}