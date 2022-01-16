using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YabousNews.Helper
{

    public class DataTableParameters
    {
        public DataTableParameters(dynamic data)
        {
             string d = data.ToString();
             JObject ss = JObject.Parse(d);
             Start = (int)ss["start"];
             Length = (int)ss["length"];
             Draw = (int)ss["draw"];
             SearchKey = (string)ss["SearchKey"];
        }
        public List<DataTableColumn> Columns { get; set; }
        public int Draw { get; set; }
        public int Length { get; set; }
        public List<DataOrder> Order { get; set; }
        public Search Search { get; set; }
        public int Start { get; set; }
        public List<Object> Others { get; set; }
        public string SearchKey { get; set; }
      
        public void add(Object x)
        {
            this.Others.Add(x);
        }
    }
   
    public class Search
    {
        public bool Regex { get; set; }
        public string Value { get; set; }
    }

    public class DataTableColumn
    {
        public string Data { get; set; }
        public string Name { get; set; }
        public bool Orderable { get; set; }
        public bool Searchable { get; set; }
        public Search Search { get; set; }

    }

    public class DataOrder
    {
        public int Column { get; set; }
        public string Dir { get; set; }


    }
}