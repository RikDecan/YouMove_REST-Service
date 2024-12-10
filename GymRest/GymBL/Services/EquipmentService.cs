using GymBL.Interfaces;
using GymBL.Models;
using GymBL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBL.Services
{
    public class EquipmentService
    {
        private IEquipmentRepository repo;

        public  EquipmentService(IEquipmentRepository repo)
        {
            this.repo = repo;
        }

        public Equipment CreateEquipment(Equipment equipment)
        {
            try
            {
                return repo.CreateEquipment(equipment);
            }
            catch (Exception ex)
            {
                throw new Exception("Geef info voor het aanmaken", ex);
            }
        }

        public Equipment UpdateEquipmentById(int id, Equipment equipment)
        {
            try
            {
                return repo.UpdateEquipmentById(id, equipment);
            }
            catch (Exception ex)
            {
                throw new Exception("Geef Toestel", ex);
            }

        }

        public Equipment ToggleEquipmentInService(int id) {

            try
            {
                return repo.ToggleEquipmentInService(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Geef Toestel", ex);
            }

        }

    }
}

