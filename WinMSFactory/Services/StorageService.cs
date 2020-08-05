using MSFactoryDAC;
using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinMSFactory.Services
{
    public class StorageService
    {
        StorageDAC dac = new StorageDAC();

        public List<StorageVO> GetStorage()
        {
            return dac.GetStorage();
        }
        
        public List<StorageVO> SelectProductAll(int selectStorage)
        {
            return dac.SelectProductAll(selectStorage);
        }
        
        public List<StorageVO> SelectStockID(List<int> IDList)
        {
            return dac.SelectStockID(IDList);
        }

        public List<StorageVO> GetStorageDetailList(int product_id)
        {
            return dac.GetStorageDetailList(product_id);
        }

        public List<InOutVO> SelectInOut()
        {
            return dac.SelectInOut(); 
        }

        public bool UpdateStorageID(List<int> IDList, int storage_id)
        {
            return dac.UpdateStorageID(IDList, storage_id);
        }
    }
}
