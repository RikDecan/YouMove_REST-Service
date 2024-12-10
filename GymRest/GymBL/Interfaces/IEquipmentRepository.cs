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
        public Equipment CreateEquipment(Equipment equipment);
    }


}
