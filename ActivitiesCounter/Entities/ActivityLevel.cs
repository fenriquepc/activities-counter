using System.ComponentModel;

namespace ActivitiesCounter.Entities
{
    public enum ActivityLevel
    {
        [Description("Inicio")]
        Beginning,

        [Description("Medio")]
        Standard,

        [Description("Avanzado")]
        Advanced
    }
}
