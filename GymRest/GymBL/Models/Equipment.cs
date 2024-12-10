namespace GymBL.Models 
{ 
    public class Equipment
    {
        public Equipment(string deviceType, bool inService)
        {
            DeviceType = deviceType;
            InService = inService;
        }

        public Equipment(int equipmentId, string deviceType, bool inService)
        {
            EquipmentId = equipmentId;
            DeviceType = deviceType;
            InService = inService;
        }

        public int EquipmentId { get; set; }
        public string DeviceType { get; set; }
        public bool InService { get; set; }

    }
}
