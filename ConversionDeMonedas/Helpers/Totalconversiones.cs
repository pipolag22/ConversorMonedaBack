
using ConversionDeMonedas.Models.Enum;

namespace ConversionDeMonedas.Helpers
{
    public class Totalconversiones
    {
        public int GetTotalconversiones(Suscripcion sub)
        {
            int totalconversiones = 0;

            if (sub == Suscripcion.Free)
            {
                totalconversiones = 10;
            }
            else if (sub == Suscripcion.Trial)
            {
                totalconversiones = 100;
            }
            else if (sub == Suscripcion.Pro)
            {
                totalconversiones = -1;
            }
            else
            {
                totalconversiones = 0;
            }
            return totalconversiones;
        }
    }
}

