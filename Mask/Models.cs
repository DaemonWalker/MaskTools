using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mask
{
    class ShopInfo
    {
        public string serviceName { get; set; }
        public string serviceAddress { get; set; }
        public string id { get; set; }
        public override string ToString()
        {
            return $"{serviceName}";
        }
    }
    class RequestParm
    {
        public int maskCount { get; set; } = 5;
        public string subscribeDate { get; set; } = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
        public string subscribeTime { get; set; } = "下午";
        public string pharmacyName { get; set; }
        public string pharmacyAddress { get; set; }
        public string pharmacyMoblie { get; set; } = null;
        public string pharmcayId { get; set; }
        public string realName { get; set; }
        public string idcard { get; set; }
        public string mobile { get; set; }
        public string businessHours { get; set; } = null;
        public int subscribeChannel { get; set; } = 0;
    }

    class AppointmentResult
    {
        public DateTime Time { get; set; }
        public string Result { get; set; }
        public string Name { get; set; }
        public string ShopName { get; set; }
        public string Json { get; set; }
    }

    class AppointmentResultComparer : IComparer<AppointmentResult>
    {
        public static AppointmentResultComparer Instance { get; } = new AppointmentResultComparer();
        public int Compare(AppointmentResult x, AppointmentResult y)
        {
            if (x.Result.Contains("成功"))
            {
                return 1.CompareTo(2);
            }
            if (y.Result.Contains("成功"))
            {
                return 2.CompareTo(1);
            }
            return x.Time.CompareTo(y.Time);
        }
    }
}
