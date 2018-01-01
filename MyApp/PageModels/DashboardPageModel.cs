using MyApp.Models;
using MyApp.Models.WidgetConfiguration;
using System.ComponentModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyApp.Services.API;
using Newtonsoft.Json;
using System.Windows.Input;
using Xamarin.Forms;
using FreshMvvm;

namespace MyApp.PageModels
{
    public class DashboardPageModel : FreshBasePageModel, INotifyPropertyChanged
    {
        public DashboardPageModel(ICoreServiceDependencies coreServiceDependencies)
        {
            HttpService = coreServiceDependencies.HttpService;
            AppSettingsService = coreServiceDependencies.AppSettingsService;

            ListNavigateCommand = new Command<ListRecord<PortalListRecord>>(ListNavigate);
        }

        protected internal IHttpService HttpService { get; set; }

        protected internal IAppSettingsService AppSettingsService { get; set; }

        public User User { get; set; }

        public AppSettings AppSettings { get; set; }

        public ListResult<PortalListRecord> ListResult { get; set; }

        public string ListTitle { get; set; }

        public ICommand ListNavigateCommand { get; set; }

        public override void Init(object initData)
        {
            base.Init(initData);

            User = initData as User;
            AppSettings = AppSettingsService.Get<AppSettings>(MyAppConstants.AppSettings);

            ListTitle = "Incomplete";

            ListResult = new ListResult<PortalListRecord>
            {
                Records = new List<ListRecord<PortalListRecord>>{
                    new ListRecord<PortalListRecord>{
                        Record = new PortalListRecord{
                            Title = "Questionnaire",
                            SubTitle = "NOW",
                            SubTitleLabel = "Due: ",
                            SubDetail = "Complete Safety Questionnaire",
                            DetailLabel = "Assigned To:",
                            Detail = "Me",
                            RecordType = MyTaskRecordType.Questionnaire
                        },
                        RowProperties = new RowProperties{CanDownload = false}
                    },
                    new ListRecord<PortalListRecord>{
                        Record = new PortalListRecord{
                            Title = "Investigation",
                            SubTitle = "NOW",
                            SubTitleLabel = "Due: ",
                            SubDetail = "Review investigation for incident #1 that occurred on Dec 25,2017",
                            DetailLabel = "Assigned To:",
                            Detail = "Me",
                            RecordType = MyTaskRecordType.Investigation
                        },
                        RowProperties = new RowProperties{CanDownload = false}
                    },
                    new ListRecord<PortalListRecord>{
                        Record = new PortalListRecord{
                            Title = "Action",
                            SubTitle = "Jan 29,2018",
                            SubTitleLabel = "Due: ",
                            SubDetail = "Description: Safety Goggles",
                            DetailLabel = "Assigned To:",
                            Detail = "Me",
                            RecordType = MyTaskRecordType.Action
                        },
                        RowProperties = new RowProperties{CanDownload = false}
                    },
                    new ListRecord<PortalListRecord>{
                        Record = new PortalListRecord{
                            Title = "Campaign",
                            SubTitle = "Feb 02,2018",
                            SubTitleLabel = "Due: ",
                            SubDetail = "Enter Monthly Ergonomic Campaign for US",
                            DetailLabel = "Assigned To:",
                            Detail = "Me",
                            RecordType = MyTaskRecordType.Campaign
                        },
                        RowProperties = new RowProperties{CanDownload = false}
                    },
                    new ListRecord<PortalListRecord>{
                        Record = new PortalListRecord{
                            Title = "Inspection",
                            SubTitle = "Jun 06,2018",
                            SubTitleLabel = "Due: ",
                            SubDetail = "Complete Monthly Fire/Life Safety for West Region",
                            DetailLabel = "Assigned To:",
                            Detail = "Me",
                            RecordType = MyTaskRecordType.Inspection
                        },
                        RowProperties = new RowProperties{CanDownload = false}
                    },
                    new ListRecord<PortalListRecord>{
                        Record = new PortalListRecord{
                            Title = "Medical Test",
                            SubTitle = "Sept 15,2017",
                            SubTitleLabel = "Due: ",
                            SubDetail = "Audiogram",
                            DetailLabel = "Assigned To:",
                            Detail = "Me",
                            RecordType = MyTaskRecordType.MedicalRecord
                        },
                        RowProperties = new RowProperties{CanDownload = false}
                    },
                    new ListRecord<PortalListRecord>{
                        Record = new PortalListRecord{
                            Title = "Metric",
                            SubTitle = "Sept 20,2018",
                            SubTitleLabel = "Due: ",
                            SubDetail = "Enter Yearly Injury Count Target for Cape Canaveral PB3",
                            DetailLabel = "Assigned To:",
                            Detail = "Me",
                            RecordType = MyTaskRecordType.Metric
                        },
                        RowProperties = new RowProperties{CanDownload = false}
                    },
                    new ListRecord<PortalListRecord>{
                        Record = new PortalListRecord{
                            Title = "Survey",
                            SubTitle = "Apr 19,2019",
                            SubTitleLabel = "Due: ",
                            SubDetail = "Complete Trial Survey",
                            DetailLabel = "Assigned To:",
                            Detail = "Me",
                            RecordType = MyTaskRecordType.Survey
                        },
                        RowProperties = new RowProperties{CanDownload = false}
                    }
                }.ToArray()
            };
        }

        public void ListNavigate(ListRecord<PortalListRecord> record)
        {
            App.NavigationPage.PushAsync(FreshPageModelResolver.ResolvePageModel<MainTabPageModel>());
        }

        public async Task<ListWidget> GetListWidget() {

            var appSettings = AppSettingsService.Get<AppSettings>(MyAppConstants.AppSettings);
            var response = await HttpService.GetAsync($"{appSettings?.Api}/assets/json/list-configs/my-tasks-incomplete-config.json");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var listWidget = JsonConvert.DeserializeObject<ListWidget>(content);

                return listWidget;
            }
            return null;
        }
    }
}
