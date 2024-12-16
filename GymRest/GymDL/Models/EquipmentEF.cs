using System.ComponentModel.DataAnnotations;

namespace GymDL.Models 
{
    public class EquipmentEF
    {
        public EquipmentEF()
        {
        }

        public EquipmentEF(int equipmentId, string deviceType, bool inService)
        {
            EquipmentId = equipmentId;
            DeviceType = deviceType;
            InService = inService;
        }

        public EquipmentEF(int equipmentId, string deviceType, bool inService, ICollection<ReservationEF> reservations) : this(equipmentId, deviceType, inService)
        {
            Reservations = reservations;
        }

        [Key]
        public int EquipmentId { get; set; }
        public string DeviceType { get; set; }
        public bool InService { get; set; }

        // Navigation Properties
        public ICollection<ReservationEF> Reservations { get; set; }
    }
}
