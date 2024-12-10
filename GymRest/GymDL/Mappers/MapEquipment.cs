using GymBL.Models;
using GymDL.Exceptions;
using GymDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymDL.Mappers
{
    internal class MapEquipment
    {

        public static Equipment MapToDomain(EquipmentEF db)
        {
            try
            {
                return new Equipment(db.EquipmentId, db.DeviceType, db.InService);
            }
            catch (Exception ex)
            {
                throw new MapException("MapProgram - MapToDomain", ex);
            }
        }
        public static EquipmentEF MapToDL(Equipment g)
        {
            try
            {
                return new EquipmentEF(g.EquipmentId, g.DeviceType, g.InService);
            }
            catch (Exception ex)
            {
                throw new MapException("MapProgram - MapToDB", ex);
            }
        }
    }
}
