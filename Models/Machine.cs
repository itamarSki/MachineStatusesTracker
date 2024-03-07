using System.ComponentModel;

namespace MachineStatusesTracker.Models
{
    public class Machine
    {
        public Machine()
        {

        }

        public string? Name { get; set; }
        public string? Notes { get; set; }
        public Status? Status { get; set; }
        public string? LogoSrc{ get; set; }
    }

    public enum Status
    {
        [Description("On")]
        ON,
        [Description("Off")]
        OFF,
        [Description("Maintenance")]
        MAINTENANCE
    }
}
