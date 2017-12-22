using MyApp.Models;
using System.ComponentModel;

namespace MyApp.PageModels
{
    public class DashboardPageModel : FreshMvvm.FreshBasePageModel, INotifyPropertyChanged
    {
        public DashboardPageModel()
        {
        }

        public User User { get; set; }

        public override void Init(object initData)
        {
            base.Init(initData);

           User = initData as User;
        }
    }
}
