using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SimpleConverter.Service.Extensions;
using SimpleConverter.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;

namespace SimpleConverter.Service
{
    public class ConverterService : IConverterService
    {

        public ResponseModel GetHtmlTableFromJson(string json)
        {
            JArray jsonAsArray = JsonConvert.DeserializeObject(json) as JArray;
            var classes = jsonAsArray
                .OfType<JObject>()
                .ToList();

            StringBuilder sb = new StringBuilder();
            sb.Append("<html><body><table> ");
            var anyClass = classes.FirstOrDefault();
            if (anyClass != null)
            {
                sb.Append("<thead><tr>");
                var properties = anyClass.Properties().Select(x => x.Name).ToList();
                foreach (var property in properties)
                {
                    sb.Append($"<th>{property}</th>");
                }

                sb.Append("<tr><thead>");
            }

            sb.Append("<tbody>");
            foreach (JObject item in classes)
            {
                sb.Append("<tr>");
                foreach (var property in item.Properties())
                {
                    sb.Append($"<td>{property.Value}</td>");
                    
                }
                sb.Append("</tr>");
            }
            sb.Append("</tbody>");
            sb.Append("</table></body></html>");

            return new ResponseModel { Response = sb.ToString() };
        }

        public ResponseModel GetXmlFromJson(string json)
        {
            JArray jsonAsArray = JsonConvert.DeserializeObject(json) as JArray;
            var classes = jsonAsArray
                .OfType<JObject>()
                .ToList();

            StringBuilder sb = new StringBuilder();
            sb.Append("<root>");
            foreach (JObject item in classes)
            {
                sb.Append("<node>");
                foreach (var property in item.Properties())
                {
                    sb.Append($"<{property.Name}>{property.Value}</{property.Name}>");
                }
                sb.Append("</node>");
            }
            sb.Append("</root>");
            return new ResponseModel { Response = sb.ToString() };
        }

    }
}
