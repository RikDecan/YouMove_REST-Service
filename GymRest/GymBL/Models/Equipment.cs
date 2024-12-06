namespace GymBL.Models 
{ 
    public class Equipment
    {
        public Equipment(string deviceType)//zonder id
        {
            DeviceType = deviceType;
        }

        public Equipment(int equipmentId, string deviceType) //met id
        {
            EquipmentId = equipmentId;
            DeviceType = deviceType;
        }

        public int EquipmentId { get; set; }
        public string DeviceType { get; set; }
    }
}
