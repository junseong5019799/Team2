using MSFactoryDAC;
using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.Data;
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
        public DataTable MoveStockList(List<int> stock_no)
        {
            return dac.MoveStockList(stock_no);
        }

        public List<StorageVO> SelectStorage(int? CorporationID = null, int? FactoryID = null)
        {
            return dac.SelectStorage(CorporationID, FactoryID);
        }

        public List<InOutVO> SelectInOut()
        {
            return dac.SelectInOut();
        }
        public List<StorageVO> GetStorageDetailList(int product_id)
        {
            return dac.GetStorageDetailList(product_id);
        }
        public bool MoveStorage(int storage_id, int stock_no)
        {
            return dac.MoveStorage(storage_id, stock_no);
        }

        public void UpdateStatus(int storage_ID, string storage_Status)
        {
            if (storage_Status == "Y")
                storage_Status = "N";
            else
                storage_Status = "Y";

            dac.UpdateStatus(storage_ID, storage_Status);
        }

        public List<StorageVO> StorageComboBindings(int corpValue, int facValue)
        {
            return dac.StorageComboBindings(corpValue, facValue);
        }

        public bool SaveStorage(StorageVO vo)
        {
            return dac.SaveStorage(vo);
        }

        public bool StorageDelete(List<int> storage_idList)
        {
            return dac.StorageDelete(storage_idList);
        }
    }
}
