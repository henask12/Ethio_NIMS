using ENIMS.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ENIMS.DataObjects
{
    public class MasterDataTransactionalHistory
    {
        [Key]
        public long Id { get; set; }
        public long RecordId { get; set; }
        public DateTime ActionDate { get; set; }
		public ActionType ActionType { get; set; } 
		public ActionTable ActionTable { get; set; }
		public string ActionTakenBy { get; set; }
        public string RecordDataInJson { get; set; } 
        public string Description { get; set; }

	}
}
