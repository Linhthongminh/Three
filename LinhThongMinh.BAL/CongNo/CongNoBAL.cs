using LinhThongMinh.DAL.CongNo;
using LinhThongMinh.DTO.CongNo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinhThongMinh.BAL.CongNo
{
    public class CongNoBAL
    {
        CongNoDAL dal = new CongNoDAL();
        public List<CongNoDTO> ReadCongNo()
        {
            List<CongNoDTO> congNos = dal.ReadCongNo();
            return congNos;
        }

        public void New(CongNoDTO congNo)
        {
            dal.New(congNo);
        }

        public void Edit(CongNoDTO congNo)
        {
            dal.Edit(congNo);
        }

        public void Delete(CongNoDTO congNo)
        {
            dal.Delete(congNo);
        }

        public void Save(CongNoDTO congNo)
        {
            dal.Save(congNo);
        }
    }
}
