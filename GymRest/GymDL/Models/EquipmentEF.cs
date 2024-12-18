using System.ComponentModel.DataAnnotations;

namespace GymDL.Models 
{
    public class EquipmentEF
    {
        public EquipmentEF()
        {
        }

        public EquipmentEF(int equipmentId, string deviceType, bool inRepair)
        {
            EquipmentId = equipmentId;
            DeviceType = deviceType;
            InRepair = inRepair;
        }

        public EquipmentEF(int equipmentId, string deviceType, bool inRepair, ICollection<ReservationEF> reservations) : this(equipmentId, deviceType, inRepair)
        {
            Reservations = reservations;
        }

        [Key]
        public int EquipmentId { get; set; }
        public string DeviceType { get; set; }
        public bool InRepair { get; set; }

        // Navigation Properties
        public ICollection<ReservationEF> Reservations { get; set; }
    }
}
