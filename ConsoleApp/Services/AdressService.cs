using ConsoleApp.Entities;
using ConsoleApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Services
{
    internal class AdressService
    {
        private readonly AdressRepository _adressRepository;

        public AdressService(AdressRepository adressRepository)
        {
            _adressRepository = adressRepository;
        }

        public AdressEntity CreateAdress(string streetName, string postalCode, string city)
        {
            var adressEntity = _adressRepository.Get(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city );
            adressEntity ??= _adressRepository.Create(new AdressEntity { StreetName = streetName, PostalCode = postalCode, City = city });

            return adressEntity;
        }

        public AdressEntity GetAdressByAdressName(string streetName, string postalCode, string city)
        {
            var adressEntity = _adressRepository.Get(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
            return adressEntity;

        }

        public AdressEntity GetAdressById(int id)
        {
            var adressEntity = _adressRepository.Get(x => x.Id == id);
            return adressEntity;
        }

        public IEnumerable<AdressEntity> GetAdresses()
        {
            var adresseses = _adressRepository.GetAll();
            return adresseses;
        }

        public AdressEntity updateAdress(AdressEntity adressEntity)
        {
            var updatedAdressEntity = _adressRepository.Update(x => x.Id == adressEntity.Id, adressEntity);
            return updatedAdressEntity;
        }

        public void DeleteAdress(int id)
        {
            _adressRepository.Delete(x => x.Id == id);
        }
    }
}
