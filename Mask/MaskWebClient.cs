using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
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
        const string APPOINTMENT = @"https://national.eshiyun.info/masks-manage/api/main/getMaskMaskorder";

        /// <summary>
        /// 获取商店列表地址
        /// </summary>
        const string SHOPLIST = @"https://national.eshiyun.info/masks-manage/api/main/getMaskServiceinfoList";

        /// <summary>
        /// 用于检查是否预约成功
        /// </summary>
        const string MYORDER = @"https://national.eshiyun.info/masks-manage/myOrder";

        /// <summary>
        /// 用于检查更新
        /// </summary>
        const string UPDATEAPI = @"https://api.github.com/repos/DaemonWalker/MaskTools/releases/latest";

        private int timeout;

        /// <summary>
        /// 设置UA,content-type,编码
        /// </summary>
        public MaskWebClient(int timeout = 30000)
        {
            this.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.122 Safari/537.36");
            this.Headers.Add(HttpRequestHeader.ContentType, "application/json;charset=UTF-8");
            this.Headers.Add("X-Requested-With", "mobi.wonders.android.apps.smy");
            this.Encoding = Encoding.UTF8;
            this.timeout = timeout;
        }

        /// <summary>
        /// 获取商店列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<ShopInfo>> GetShopList()
        {
            try
            {
                this.timeout = 30000;
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

        public bool IsSuccessed(string idCard, string targetDate)
        {
            var json = JsonConvert.SerializeObject(new { idcard = idCard.RSAEncrypt(), limit = 20, page = 1, subscribeChannel = 0 });
            this.timeout = 5000;
            var result = this.UploadString(MYORDER, "POST", json);
            if (result.Contains(targetDate))
            {
                return true;
            }
            else
            {
                return false;
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
            this.timeout = 3000;
            var json = JsonConvert.SerializeObject(parm);
            try
            {
                result = this.UploadString(APPOINTMENT, "POST", json);
                if (result.Contains("200") || result.Contains("成功") || result.Contains("5天"))
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

        public bool CheckUpdate(out string downloadUrl)
        {
            this.timeout = 10000;
            try
            {
                var json = this.DownloadString(UPDATEAPI);
                var version = JObject.Parse(json)["tag_name"].ToString();
                var currentVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                var remoteVersion = new Version(version.Replace("v", ""));
                if (currentVersion < remoteVersion)
                {
                    downloadUrl = JArray.Parse(JObject.Parse(json)["assets"].ToString()).First()["browser_download_url"].ToString();
                    return true;
                }
                else
                {
                    downloadUrl = string.Empty;
                    return false;
                }
            }
            catch
            {
                downloadUrl = string.Empty;
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
            req.Timeout = this.timeout;
            return req;
        }
    }
}
