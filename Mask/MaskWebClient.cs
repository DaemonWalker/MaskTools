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
    /// <summary>
    /// 没想继承来着，但是webclient没有timeout就很难受。。。
    /// </summary>
    class MaskWebClient : WebClient
    {
        /// <summary>
        /// 抢口罩地址
        /// </summary>
        const string APPOINTMENT = @"http://smy.zwfw.dl.gov.cn/masks-manage/api/main/getMaskMaskorder";

        /// <summary>
        /// 获取商店列表地址
        /// </summary>
        const string SHOPLIST = @"http://smy.zwfw.dl.gov.cn/masks-manage/api/main/getMaskServiceinfoList";

        /// <summary>
        /// 设置UA,content-type,编码
        /// </summary>
        public MaskWebClient()
        {
            this.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.122 Safari/537.36");
            this.Headers.Add(HttpRequestHeader.ContentType, "application/json;charset=UTF-8");
            this.Encoding = Encoding.UTF8;
        }

        /// <summary>
        /// 获取商店列表
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// 预约口罩
        /// </summary>
        /// <param name="parm"></param>
        /// <param name="result"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 设置超时时间 30 秒
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        protected override WebRequest GetWebRequest(Uri address)
        {
            var req = base.GetWebRequest(address);
            req.Timeout = 30000;
            return req;
        }
    }
}
