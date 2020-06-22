using System;
using System.Collections.Generic;
using System.Text;

namespace Kolpi.Shared.Models
{
    public class EditBase
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateModified { get; set; }
        public string ModifiedBy { get; set; }
    }
}
