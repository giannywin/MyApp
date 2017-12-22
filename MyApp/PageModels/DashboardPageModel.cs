using System;
using Xamarin.Forms;
using MyApp.Models;

namespace MyApp.PageModels
{
    public class DashboardPageModel : BasePageModel
    {
        public DashboardPageModel()
        {
        }

        public string Username { get; set; }

        public override void Init(object initData)
        {
            base.Init(initData);

            var user = initData as User;

            Username = user?.Username;
        }
    }
}
