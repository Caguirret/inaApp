using System;
using System.Collections.Generic;
using System.Text;

namespace inaApp.Common.Enums
{
    public static class Enumeradores
    {
        public enum TipoIdentificacion
        {
            CedulaFisica = 1,
            CedulaJuridica =2,
            DIMEX = 3,
            NITE = 4,
            Pasaporte = 5
        }


        public enum TipoVenta
        {
            Contado = 1,
            Credito = 2
        }

        public enum TipoPago
        {
            Efectivo = 1,
            TarjetaCredito = 2,
            TarjetaDebito,
        }
    }
}
