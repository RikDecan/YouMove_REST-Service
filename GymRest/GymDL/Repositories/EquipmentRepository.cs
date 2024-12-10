using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymBL.Interfaces;
using GymBL.Models;
using GymDL.Mappers;

namespace GymDL.Repositories
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly GymContext _context;

        public EquipmentRepository(GymContext context)
        {
            _context = context;
        }


        public Equipment CreateEquipment(Equipment equipment)
        {
            var equipmentEF = MapEquipment.MapToDL(equipment);

            _context.Equipment.Add(equipmentEF);

            _context.SaveChanges();

            return equipment;
        }
    }
}
