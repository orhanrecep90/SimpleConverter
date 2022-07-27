
using SimpleConverter.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleConverter.Service
{
    public interface IConverterService
    {
        ResponseModel GetHtmlTableFromJson(string json);
        ResponseModel GetXmlFromJson(string json);
    }
}
