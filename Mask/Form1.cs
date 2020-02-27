using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Drawing;
using System.Collections.Concurrent;
using System.Threading;

namespace Mask
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 商店列表
        /// </summary>
        private List<ShopInfo> shops
        {
            get => _shops;
            set
            {
                this._shops = value;
                BindShops();
            }
        }
        private List<ShopInfo> _shops;

        /// <summary>
        /// 用户当前选定药店
        /// </summary>
        private ShopInfo currentShop;

        /// <summary>
        /// 抢购结果列表
        /// </summary>
        private ConcurrentBag<AppointmentResult> appointmentResults = new ConcurrentBag<AppointmentResult>();

        /// <summary>
        /// 构造函数
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            this.dgvShops.AutoGenerateColumns = false;
        }

        /// <summary>
        /// 一些初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("请等待上方药店列表加载完毕在进行抢购~");
            txtName.Text = ConfigurationManager.AppSettings["user_name"];
            txtID.Text = ConfigurationManager.AppSettings["id_card"];
            txtTel.Text = ConfigurationManager.AppSettings["phone_no"];
            txtFilter.Text = ConfigurationManager.AppSettings["word"];
            txtThreadNum.Text = "10";
            shops = await new MaskWebClient().GetShopList();
            this.timeAutoStop.Value = DateTime.Now.Date.AddHours(21);
        }

        /// <summary>
        /// 绑定商店到gridview控件
        /// </summary>
        private void BindShops()
        {
            if (shops == null || string.IsNullOrWhiteSpace(txtFilter.Text))
            {
                dgvShops.DataSource = shops;
                return;
            }
            var keyWords = txtFilter.Text.Split(' ');
            dgvShops.DataSource = shops.Where(p => keyWords.All(kw => p.serviceAddress.Contains(kw) || p.serviceName.Contains(kw))).ToList();
        }

        /// <summary>
        /// 用户选择药店事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvShops_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dgvShops.SelectedRows.Count < 1)
            {
                return;
            }
            currentShop = this.dgvShops.SelectedRows[0].DataBoundItem as ShopInfo;
            this.label5.Text = currentShop?.ToString();
        }

        /// <summary>
        /// 抢购按钮点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGO_Click(object sender, EventArgs e)
        {
            if (this.currentShop == null)
            {
                MessageBox.Show("请等待商店列表加载完毕，然后再选择一个~");
            }
            var parm = new RequestParm()
            {
                pharmacyName = currentShop.serviceName,
                pharmcayId = currentShop.id,
                pharmacyAddress = currentShop.serviceAddress,
                realName = txtName.Text.Trim().RSAEncrypt(),
                idcard = txtID.Text.Trim().RSAEncrypt(),
                mobile = txtTel.Text.Trim().RSAEncrypt()
            };

            var endTime = this.timeAutoStop.Value;
            // 新开一个线程 防止卡死
            var cts = new CancellationTokenSource();
            Task.Run(() =>
            {
                // 循环生成若干个线程抢口罩 每次等待10秒
                do
                {
                    Task.Run(() =>
                    {
                        var tasks = Enumerable.Range(0, int.Parse(txtThreadNum.Text)).Select(p => new Task(() =>
                        {
                            var appointmentReuslt = new AppointmentResult()
                            {
                                Time = DateTime.Now,
                                Name = txtName.Text,
                                ShopName = this.currentShop.serviceName
                            };
                            if (new MaskWebClient().MakeAppointment(parm, out var json))
                            {
                                appointmentReuslt.Result = "成功";
                                MessageBox.Show("预约成功");
                                cts.Cancel();
                            }
                            else
                            {
                                appointmentReuslt.Result = "失败";
                            }
                            appointmentReuslt.Json = json;
                            appointmentResults.Add(appointmentReuslt);
                            BindResult();
                        }, cts.Token)).ToList();
                        tasks.ForEach(p => p.Start());
                        Task.WaitAll(tasks.ToArray());
                    }, cts.Token);
                    Thread.Sleep(10000);
                } while (endTime >= DateTime.Now);
                MessageBox.Show("全部线程执行完毕，没提示就是没抢到了...");
            }, cts.Token);
        }

        /// <summary>
        /// 过滤栏变更事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            BindShops();
        }

        /// <summary>
        /// 绑定抢购结果到gridview
        /// </summary>
        private void BindResult()
        {
            if (this.dgvResult.InvokeRequired)
            {
                this.dgvResult.Invoke(new Action(() => BindResult()));
            }
            else
            {
                this.dgvResult.DataSource = appointmentResults.OrderByDescending(p => p, AppointmentResultComparer.Instance).ToList();
            }
        }

        /// <summary>
        /// 保存config 不过不起作用。。。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConfigurationManager.AppSettings.Set("user_name", txtName.Text);
            ConfigurationManager.AppSettings.Set("id_card", txtID.Text);
            ConfigurationManager.AppSettings.Set("phone_no", txtTel.Text);
            ConfigurationManager.AppSettings.Set("word", txtFilter.Text);
        }
    }





}
