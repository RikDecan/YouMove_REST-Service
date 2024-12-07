using System.ComponentModel.DataAnnotations;

namespace GymDL.Models 
{ 
    public class EquipmentEF
    {
        public EquipmentEF(int equipmentId, string deviceType)
        {
            EquipmentId = equipmentId;
            DeviceType = deviceType;
        }
        [Key]

        public int EquipmentId { get; set; }
        public string DeviceType { get; set; }

    }
}
