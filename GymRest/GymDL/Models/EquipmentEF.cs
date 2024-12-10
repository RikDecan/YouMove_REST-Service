using System.ComponentModel.DataAnnotations;

namespace GymDL.Models 
{ 
    public class EquipmentEF
    {
        public EquipmentEF(int equipmentId, string deviceType, bool inService)
        {
            EquipmentId = equipmentId;
            DeviceType = deviceType;
            InService = inService;
        }

        [Key]

        public int EquipmentId { get; set; }
        public string DeviceType { get; set; }
         public bool InService { get; set; }

    }
}
