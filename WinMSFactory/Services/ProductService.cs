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
    public class ProductService
    {
        ProductDAC dac = new ProductDAC();

        public List<ProductVO> SelectAllProducts()
        {
            return dac.SelectAllProducts();
        }


        public void UpdateStatus(int ItemNum, int StatusNum)
        {
            dac.UpdateStatus(ItemNum, StatusNum);
        }

        public bool InsertProducts(ProductInsertVO InsertData, char IsBomCopy)
        {
            return dac.InsertProducts(InsertData, IsBomCopy);
        }

        public string SelectProductName(int codeNum)
        {
            return dac.SelectProductName(codeNum);
        }

        public bool DeleteProducts(int ProductNo)
        {
            return dac.DeleteProducts(ProductNo);
        }

        public List<ProductPriceManageVO> ProductPriceSelect()
        {
            return dac.ProductPriceSelect();
        }

        public List<CompanyVO> SelectProductBindings(int SelectedCompanyValue)
        {
            return dac.SelectProductBindings(SelectedCompanyValue);
        }

        public bool InsertMaterialPrice(ProductPriceManageVO InsertData)
        {
            return dac.InsertMaterialPrice(InsertData);
        }


        public List<SellPriceManageVO> SelectAllPriceProducts()
        {
            return dac.SelectAllPriceProducts();
        }

        public bool UpsertMaterialPrice(ProductPriceManageVO insertData)
        {
            return dac.UpsertMaterialPrice(insertData);
        }

        public DataTable SelectAllProductsToTable()
        {
            return dac.SelectAllProductsToTable();
        }

        public bool UpdateProducts(ProductInsertVO productInsert)
        {
            return dac.UpdateProducts(productInsert);
        }

        public bool DeleteMaterialPrice(int selectedRow)
        {
            return dac.DeleteMaterialPrice(selectedRow);
        }

        public DataTable GetProducts()
        {
            return dac.GetProducts();
        }

        public bool UpsertSellPrice(SellPriceManageVO manageVO)
        {
            return dac.UpsertSellPrice(manageVO);
        }

        public bool DeleteSellPrice(int value)
        {
            return dac.DeleteSellPrice(value);
        }

        public bool IsUpperData(int CompanyID, int ProductID, ref int PreviousPrice, ref DateTime? PreviousTime)
        {
            return dac.IsUpperData(CompanyID, ProductID, ref PreviousPrice, ref PreviousTime);
        }

        public List<ProductPriceManageVO> DateSettings(int material_Price_Code)
        {
            return dac.DateSettings(material_Price_Code);
        }

        public bool IsBomExists(int productIDNum)
        {
            return dac.IsBomExists(productIDNum);
        }
    }
}
