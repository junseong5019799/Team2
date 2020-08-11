﻿using MSFactoryDAC;
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

        public bool InsertSellPrice(SellPriceManageVO vo)
        {
            return dac.InsertSellPrice(vo);
        }

        public bool SelectPriceData(int companyID, int productID, ref ProductPriceManageVO vo)
        {
            return dac.SelectPriceData(companyID, productID, ref vo);
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
        public DataTable GetProducts()
        {
            return dac.GetProducts();
        }
    }
}
