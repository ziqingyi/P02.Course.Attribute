﻿using P34.Course.Business.Interface;
using P37.Course.Web.SearchEngines.Interface;
using P37.Course.Web.SearchEngines.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using P37.Course.Web.Core.Models;

namespace P37.Course.Web.SearchEngines.SearchServiceTCP
{
    // it's better to have different project for query in database and query in Lucene search engine 
    //distributed search service
    //support paging search
    //CommodityModel is used for deserialize the search result, not sure how it is used. so create a class in search engine. 
    //CommodityModel is defined by the WCF service returned value's data structure. 


    //if you want to use this service in MVC5, you must copy system.serviceModel in app.config to Web.config in MVC proj(not Views folder)


    public class SearchService: ISearchService
    {
        public PageResult<CommodityModel> QueryCommodityPage(int pageIndex, int pageSize, string keyword,
            List<int> categoryIdList, string priceFilter, string priceOrderBy)
        { 
            LuceneSearchService.SearcherClient client = null;
            try
            {
               client = new LuceneSearchService.SearcherClient();

               //just search and get string, then deserialize to object. 
               string result = client.QueryCommodityPage(pageIndex, pageSize, keyword, categoryIdList?.ToArray(),
                   priceFilter, priceOrderBy);

               client.Close();

               return JsonConvert.DeserializeObject<PageResult<CommodityModel>>(result);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                if (client != null)
                {
                    client.Abort();
                }
                throw ex;
            }







        }


    }
}
