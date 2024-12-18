using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymBL.Interfaces;
using GymBL.Models;
using GymDL.Exceptions;
using GymDL.Mappers;
using Microsoft.EntityFrameworkCore;

namespace GymDL.Repositories
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly GymContext _context;

        public EquipmentRepository(GymContext context)
        {
            _context = context;
        }

        public Equipment GetEquipmentById(int id) 
        {
            try
            {
                var equipment = _context.Equipment.FirstOrDefault(e => e.EquipmentId == id);

                if (equipment == null)
                {
                    throw new Exception("Equipment not found");
                }

                return MapEquipment.MapToDomain(equipment);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        
        public List<Equipment> GetEquipments()
        {
            return _context.Equipment.Include(equipment => equipment.Reservations).Select(equipment => MapEquipment.MapToDomain(equipment)).ToList();
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

                equipmentDB.InRepair = !equipmentDB.InRepair;

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
