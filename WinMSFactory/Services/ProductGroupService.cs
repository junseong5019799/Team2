﻿using MSFactoryDAC;
using MSFactoryVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinMSFactory
{
    
    public class ProductGroupService
    {
        ProductGroupDAC dac = new ProductGroupDAC();

        public List<GroupComboVO> ProductGroupComboBindingsNotAll()
        {
            return dac.ProductGroupComboBindingsNotAll();
        }
        public List<GroupComboVO> ProductGroupComboBindings()
        {
            return dac.ProductGroupComboBindings();
        }
        public List<ProductGroupVO> SelectAllProductGroups()
        {
            return dac.SelectAllProductGroups();
        }

        public bool InsertGroup(ProductGroupVO pdgVO)
        {
            return dac.InsertGroup(pdgVO);
        }

        public void UpdateStatus(int itemNum, int StatusNum)
        {
            dac.UpdateStatus(itemNum, StatusNum);
        }

        
    }
}
