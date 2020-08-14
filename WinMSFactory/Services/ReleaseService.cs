using MSFactoryDAC;
using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinMSFactory
{
    class ReleaseService
    {
        ReleaseDAC dac = new ReleaseDAC();

        public List<ReleaseVO> GetReleasePlan()
        {
            return dac.GetReleasePlan();    
        }

        public List<ReleaseVO> SelectProducts()
        {
            return dac.SelectProducts();
        }

        public List<ReleaseVO> SelectProductGroup()
        {
            return dac.SelectProductGroup();
        }
        public List<ReleaseVO> SelectProductByGroup(int groupID)
        {
            return dac.SelectProductByGroup(groupID);
        }
           
        public List<ReleaseVO> SelectPlanID ()
        {
            return dac.SelectPlanID();
        }
         
        public List<BomVO> SelectProduct()
        {
            return dac.SelectProduct();
        }

        public List<ReleaseVO> GetReleasePlanByDate(string fromDate, string toDate)
        {
            return dac.GetReleasePlanByDate(fromDate, toDate);
        }
         
        public DataTable GetReleasePlanDetail(int release_no)
        {
            return dac.GetReleasePlanDetail(release_no);
        }

        public DataTable Calculate_ReleasePlan(int release_no, DateTime from, DateTime to)
        {
            return dac.Calculate_ReleasePlan(release_no, from, to);
        }

        public bool SaveReleasePlan(DataTable dgv, ReleaseVO release)
        {
            return dac.SaveReleasePlan(dgv, release);
        }

        public bool UpdateReleaseDateCancel(int release_no, int product_id)
        {
            return dac.UpdateReleaseDateCancel(release_no, product_id);
        }

        public bool UpdateReleaseDate(int release_no, int product_id)
        {
            return dac.UpdateReleaseDate(release_no, product_id);
        }

        public bool IsUpperData(int ProductGroupID, int ProductID, ref int previousPrice, ref DateTime? previousTime)
        {
            return dac.IsUpperData(ProductGroupID, ProductID, ref previousPrice, ref previousTime);
        }

        public int GetProductID(string name)
        {
            return dac.GetProductID(name);
        }
    }
}
