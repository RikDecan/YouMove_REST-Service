namespace GymDL.Models 
{ 
    public class EquipmentEF
    {
        public EquipmentEF(int equipmentId, string deviceType)
        {
            EquipmentId = equipmentId;
            DeviceType = deviceType;
        }

        public int EquipmentId { get; set; }
        public string DeviceType { get; set; }

    }
}
