using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinhThongMinh.DTO.CongNo
{
    public class CongNoDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public decimal AmountOwed { get; set; }
    }
}
