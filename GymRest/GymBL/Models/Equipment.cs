namespace GymBL.Models 
{ 
    public class Equipment
    {
        public Equipment(bool inRepair)
        {
            InRepair = inRepair;
        }

        public Equipment(string deviceType, bool inRepair)
        {
            DeviceType = deviceType;
            InRepair = inRepair;
        }

        public Equipment(int equipmentId, string deviceType, bool inRepair)
        {
            EquipmentId = equipmentId;
            DeviceType = deviceType;
            InRepair = inRepair;
        }

        public int EquipmentId { get; set; }
        public string DeviceType { get; set; }
        public bool InRepair { get; set; }

    }
}
