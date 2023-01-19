using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms.Internals;

namespace LinkedApp.Models
{
    public class QueryParams
    {
        public ObservableCollection<QueryParam> List { get; set; }
        public string GetValueOf(string property)
        {
            string value = null;
            List.ForEach(parameter =>
            {
                if(parameter.Property == property)
                {
                    value = parameter.Value;
                }
            });
          
            return value;
        }
        public void SetParameterList(string intendData)
        {
            ObservableCollection<QueryParam> queryParams = new ObservableCollection<QueryParam>();
            intendData.Split(',').ForEach(queryData =>
            {
                QueryParam queryParam = new QueryParam();
                queryParam.Property = queryData.Split('=')[0];
                queryParam.Value = queryData.Split('=')[1];
                queryParams.Add(queryParam);
            });
            List = queryParams;
        }
    }
    public class QueryParam
    {
        public string Property { get; set; }
        public string Value {get; set; } 
    }

}
