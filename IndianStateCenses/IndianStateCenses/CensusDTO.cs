using IndianStateCenses.Constructor_for_different_CSV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStateCenses
{
    public class CensusDTO
    {
        public int serialNumber;
        public string stateName;
        public long population;
        public long area;
        public long density;
        public string state;
        public string stateCode;
        public int tin;

        //public CensusDTO(IndianStateCenses indianStateCenses)
        //{
        //    this.state = indianStateCenses.state;
        //    this.population = indianStateCenses.population;
        //    this.area = indianStateCenses.area;
        //    this.density = indianStateCenses.density;
        //}
        public CensusDTO(IndianStateCode indianStateCode)
        {
            this.serialNumber = indianStateCode.serialNumber;
            this.stateName = indianStateCode.stateName;
            this.stateCode = indianStateCode.stateCode;
            this.tin = indianStateCode.tin;
        }
        public CensusDTO(IndianStateCensusData indianStateCenses)
        {
            this.state = indianStateCenses.state;
            this.population = indianStateCenses.population;
            this.area = indianStateCenses.area;
            this.density = indianStateCenses.density;
        }
    }
}