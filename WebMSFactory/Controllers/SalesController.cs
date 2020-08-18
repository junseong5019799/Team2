using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMSFactory.Controllers
{
    public class SalesController : Controller
    {
        // GET: SalesChart
        public ActionResult Chart()
        {
   //         //SELECT Month(release_date) Mon, SUM(SELL_CURRENT_PRICE * D.release_quantity) total_price
   //         FROM TBL_RELEASE_DETAIL D INNER JOIN TBL_PRODUCT P ON D.PRODUCT_ID = P.PRODUCT_ID

   //       INNER JOIN TBL_SELLPRICE_MANAGEMENT S ON D.PRODUCT_ID = S.PRODUCT_ID

   //           WHERE MONTH(RELEASE_DATE) BETWEEN MONTH(S.START_DATE) AND MONTH(ISNULL(S.END_DATE,'9999-12-31'))
			//	AND RELEASE_STATUS NOT IN('출고취소', '출고예정')
			//group by Month(release_date)

            PriceProductDAC dac = new PriceProductDAC();
            //dac.TotalSales()
            return View();
        }
    }
}