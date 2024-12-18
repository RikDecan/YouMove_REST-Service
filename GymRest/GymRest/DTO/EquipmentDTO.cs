namespace GymRest.DTO
{
    public class EquipmentDTO
    {
        public EquipmentDTO(string deviceType, bool inRepair)
        {
            DeviceType = deviceType;
            InRepair = inRepair;
        }

        public string DeviceType { get; set; }
        public bool InRepair { get; set; }
    }
}
