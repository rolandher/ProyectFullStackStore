using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmonStore.Infrastructure.Entities
{
    public class UserEntity
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]//CAMELCASE 
        public string User_Id { get; set; }        
        public string Names { get; set; }
        public string SurNames { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }          
        public bool State { get; set; }
    }
}
