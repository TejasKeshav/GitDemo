using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSelFramework.utilities
{
    public class JsonReader

    {

        
        public String extractData(String tokenName)
        {
            String myJsonString=File.ReadAllText("utilities/testData.json");
            var jsonObject=JToken.Parse(myJsonString);
            return jsonObject.SelectToken(tokenName).Value<string>();
        }

        public String[] extractDataArray(String tokenName)
        {
            String myJsonString = File.ReadAllText("utilities/testData.json");
            var jsonObject = JToken.Parse(myJsonString);
            List<String> productsList =jsonObject.SelectTokens(tokenName).Values<string>().ToList();
           return  productsList.ToArray();


        }
    }
}
