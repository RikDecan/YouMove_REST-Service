using GymBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBL.Interfaces
{
    public interface IEquipmentRepository
    {
        public Equipment GetEquipmentById(int id);

        public Equipment CreateEquipment(Equipment equipment);

        public Equipment ToggleEquipmentInService(int id);

        public Equipment UpdateEquipmentById(int id, Equipment equipment);

    }


}
