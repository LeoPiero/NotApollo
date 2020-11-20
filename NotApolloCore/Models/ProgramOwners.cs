using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NotApolloCore.Models
{
    
    
    public class ProgramOwners
    {
        public enum OwnerStatusCode
        {
            Inactive = 0,
            Active = 1
        }

        [Key]
        public int ProgramOwnerID { get; set; }
        public string Name { get; set; }
        public string UserID { get; set; }
        public string Department { get; set; }
        public string EmailAddress { get; set; }
        public DateTime CreateDate { get; set; }        
        public OwnerStatusCode ProgramOwnerStatus { get; set; }
     
        
        //Note: Once we get programs created we will need to define the relationship between them.
        //People can own multiple programs
        //public ICollection<Program> Programs { get; set; }
       
    }
}
