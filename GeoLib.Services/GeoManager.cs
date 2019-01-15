using GeoLib.Contracts;
using System;
using System.Collections.Generic;
using GeoLib.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoLib.Services
{
    public class GeoManager : IGeoService
    {
        private readonly IStateRepository _stateRepository;
        private readonly IZipCodeRepository _zipCodeRepository;

        public GeoManager()
        {

        }

        public GeoManager(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        public GeoManager(IZipCodeRepository zipCodeRepository)
        {
            _zipCodeRepository = zipCodeRepository;
        }

        public GeoManager(IZipCodeRepository zipCodeRepository, IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
            _zipCodeRepository = zipCodeRepository;
        }



        public IEnumerable<string> GetStates(bool primaryOnly)
        {
            List<string> stateData = new List<string>();

            IStateRepository stateRepository = _stateRepository ?? new StateRepository();

            IEnumerable<State> states = stateRepository.Get(primaryOnly);

            if(states != null)
            {
                foreach (State state in states)
                    stateData.Add(state.Abbreviation);
            }

            return stateData;
        }

        public ZipCodeData GetZipCodeInfo(string zip)
        {
            ZipCodeData zipCodeData = null;

            IZipCodeRepository zipCodeRepository = _zipCodeRepository ?? new ZipCodeRepository();

            ZipCode zipCodeEntity = zipCodeRepository.GetByZip(zip);

            if(zipCodeEntity != null)
            {
                zipCodeData = new ZipCodeData()
                {
                    City = zipCodeEntity.City,
                    State = zipCodeEntity.State.Abbreviation,
                    ZipCode = zipCodeEntity.Zip
                };
            }
            return zipCodeData;
        }

        public IEnumerable<ZipCodeData> GetZips(string state)
        {
            List<ZipCodeData> zipCodeData = new List<ZipCodeData>();

            IZipCodeRepository zipCodeRepository = _zipCodeRepository ?? new ZipCodeRepository();

            var zips = zipCodeRepository.GetByState(state);

            if(zips != null)
            {
                foreach(ZipCode zipCode in zips)
                {
                    zipCodeData.Add(new ZipCodeData()
                    {
                        City = zipCode.City,
                        State = zipCode.State.Abbreviation,
                        ZipCode = zipCode.Zip
                    });
                }
            }
            return zipCodeData;
         }


        public IEnumerable<ZipCodeData> GetZips(string zip, int range)
        {
            List<ZipCodeData> zipCodeData = new List<ZipCodeData>();

            IZipCodeRepository zipCodeRepository = _zipCodeRepository ?? new ZipCodeRepository();

            ZipCode zipEntity = zipCodeRepository.GetByZip(zip);
            var zips = zipCodeRepository.GetZipsForRange(zipEntity, range);

            if (zips != null)
            {
                foreach (ZipCode zipCode in zips)
                {
                    zipCodeData.Add(new ZipCodeData()
                    {
                        City = zipCode.City,
                        State = zipCode.State.Abbreviation,
                        ZipCode = zipCode.Zip
                    });
                }
            }
            return zipCodeData;
        }
    }
}
