using Quasar.Domain.DTOs;
using Quasar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TopSecret.Application.MappSatellites
{
   public class Mapper
    {
        public ResponseSatellites mappLocation(Satellite response)
        {
           
           return new ResponseSatellites 
            {
                Name= response.name,
                PositionX= float.Parse(response.postionX),
               PositionY = float.Parse(response.postionY)

             //  Message = response.word1+ ' '+ response.word2 + ' ' + response.word3 + ' ' + response.word4
            };
         
        }

        public ResponseSatellitesMessage mappMessage(Satellite response)
        {

            return new ResponseSatellitesMessage
            {
                Name = response.name,
                Message = "Este Es Un Mensaje"
            };

        }
        public List<ResponseTopSecret> mappTopSecret(List<Satellite> response)
        {

            return response.Select(s => new ResponseTopSecret
            {
                 position= new Position { x = float.Parse(s.postionX), y = float.Parse(s.postionY) },
                 message= s.word1 + ' ' + s.word2 + ' ' + s.word3 + ' ' + s.word4
            }).ToList();

           

        }
        public List<ResponseTopSecret> mappTopSecretBydistance(List<Satellite> response)
        {

            return response.Select(s => new ResponseTopSecret
            {
                position = new Position { x = float.Parse(s.postionX), y = float.Parse(s.postionY) },
                message = s.word1 + ' ' + s.word2 + ' ' + s.word3 + ' ' + s.word4
            }).ToList();



        }



    }
}
