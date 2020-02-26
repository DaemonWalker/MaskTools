using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Mask
{
    class MaskWebClient : WebClient
    {
        const string APPOINTMENT = @"http://smy.zwfw.dl.gov.cn/masks-manage/api/main/getMaskMaskorder";
        const string SHOPLIST = @"http://smy.zwfw.dl.gov.cn/masks-manage/api/main/getMaskServiceinfoList";
        public MaskWebClient()
        {
            this.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.122 Safari/537.36");
            this.Headers.Add(HttpRequestHeader.ContentType, "application/json;charset=UTF-8");
            this.Encoding = Encoding.UTF8;
        }
        public async Task<List<ShopInfo>> GetShopList()
        {
            try
            {
                var json = await this.UploadStringTaskAsync(SHOPLIST, "POST", @"{""serviceName"":"""",""page"":1,""limit"":130,""lng"":""110.299877"",""lat"":""20.014208"",""area"":""""}");
                return JArray.Parse(JObject.Parse(JObject.Parse(json)["result"].ToString())["list"].ToString()).Select(p => new ShopInfo()
                {
                    serviceAddress = p["serviceAddress"].ToString(),
                    serviceName = p["serviceName"].ToString(),
                    id = p["id"].ToString()
                }).OrderBy(p => p.serviceName).ToList();
            }
            catch
            {
                throw new Exception("获取药店列表失败，请重新启动软件");
            }
        }
        public bool MakeAppointment(RequestParm parm, out string result)
        {
            var json = JsonConvert.SerializeObject(parm);
            try
            {
                result = this.UploadString(APPOINTMENT, "POST", json);
                if (result.Contains("200") || result.Contains("成功"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                result = string.Empty;
                return false;
            }
        }

        protected override WebRequest GetWebRequest(Uri address)
        {
            var req = base.GetWebRequest(address);
            req.Timeout = 30000;
            return req;
        }
    }
}
