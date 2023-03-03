using System.ComponentModel;

namespace ActivitiesCounter.Entities
{
    public enum ActivityType
    {
        [Description("Rol")]
        RPG,

        [Description("Juegos de mesa")]
        BoardGame,

        [Description("Rol en vivo")]
        LARP,

        [Description("Demostración")]
        Presentation,

        [Description("Concurso")]
        Contest,

        [Description("Otros")]
        Other
    }
}
