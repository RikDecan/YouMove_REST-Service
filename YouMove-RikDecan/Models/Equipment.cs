namespace YouMove_RikDecan.Models
{
    public class equipment
    {
        public int EquipmentId { get; set; }
        public string DeviceType { get; set; }

        public equipment(string deviceType) //zonder id
        {
            DeviceType = deviceType;
        }

        public equipment(int equipmentId, string deviceType) //met id
        {
            EquipmentId = equipmentId;
            DeviceType = deviceType;
        }

    }
}
