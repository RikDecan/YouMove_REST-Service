﻿using GymBL.Models;
using GymDL.Exceptions;
using GymDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymDL.Mappers
{
    internal class MapRunningSessionMain
    {
        public static RunningSessionMain MapToDomain(RunningSessionMainEF db)
        {
            try
            {
                return new RunningSessionMain(
                    db.RunningSessionId,
                    db.Date,
                    db.MemberId,
                    db.Duration,
                    db.AvgSpeed,

                    db.Details?.Select(MapRunningSessionDetail.MapToDomain).ToList() ?? new List<RunningSessionDetail>()
                );
            }
            catch (Exception ex)
            {
                throw new MapException("MapProgram - MapToDomain", ex);
            }
        }
        public static RunningSessionMainEF MapToDB(RunningSessionMain g)
        {
            try
            {
                return new RunningSessionMainEF(
                    g.RunningSessionId, 
                    g.Date, 
                    g.MemberId, 
                    g.Duration, 
                    g.AvgSpeed, 

                    g.Details?.Select(MapRunningSessionDetail.MapToDL).ToList() ?? new List<RunningSessionDetailEF>()
                );
            }
            catch (Exception ex)
            {
                throw new MapException("MapProgram - MapToDB", ex);
            }
        }
    }
}
