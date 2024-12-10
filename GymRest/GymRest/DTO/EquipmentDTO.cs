namespace GymRest.DTO
{
    public class EquipmentDTO
    {
        public EquipmentDTO(string deviceType, bool inService)
        {
            DeviceType = deviceType;
            InService = inService;
        }

        public string DeviceType { get; set; }
        public bool InService { get; set; }
    }
}
