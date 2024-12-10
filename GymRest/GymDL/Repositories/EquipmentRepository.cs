using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymBL.Interfaces;
using GymBL.Models;
using GymDL.Exceptions;
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

        public Equipment UpdateEquipmentById(int id, Equipment equipment)
        {
            if (equipment == null)
            {
                throw new ArgumentNullException(nameof(equipment), "Equipment cannot be null");
            }

            try
            {
                var equipmentDB = _context.Equipment.Find(id);

                if (equipmentDB == null)
                {
                    throw new MemberNotFoundException(id);
                }
                equipment.EquipmentId = id;
                _context.Entry(equipmentDB).CurrentValues.SetValues(MapEquipment.MapToDL(equipment));
                _context.SaveChanges();

                return MapEquipment.MapToDomain(equipmentDB);
            }
            catch (Exception ex)
            {
                throw new Exception("Member not found");
            }

        }

        public Equipment ToggleEquipmentInService(int id)
        {
            try
            {
                var equipmentDB = _context.Equipment.Find(id);

                if (equipmentDB == null)
                {
                    throw new MemberNotFoundException(id);
                }

                equipmentDB.InService = !equipmentDB.InService;

                _context.SaveChanges();

                return MapEquipment.MapToDomain(equipmentDB);
            }
            catch (Exception ex)
            {
                throw new Exception("Error toggling InService status", ex);
            }
        }


    }
}
