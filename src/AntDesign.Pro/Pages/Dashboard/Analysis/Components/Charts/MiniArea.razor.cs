using System;
using System.Text.Json;
using System.Threading.Tasks;
using AntDesign.Charts;
using Microsoft.AspNetCore.Components;

namespace AntDesign.Pro.Pages.Dashboard.Analysis
{
    public partial class MiniArea
    {
        private IChartComponent<DataItem> _chart;
        private AreaConfig _config;

        public int Height { get; set; }
        public object data { get; set; }
        public bool ForceFit { get; set; }
        public string Color { get; set; } = ""
        public string borderColor { get; set; }
        public object scale { get; set; }
        public int borderWidth { get; set; }
        public string line { get; set; }
        public string xAxis { get; set; }
        public string yAxis { get; set; }
        public string animate { get; set; }

        [Inject]
        public IChartService ChartService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _config = new AreaConfig()
            {
                forceFit = ForceFit,
                height = Height,
                color = new []{ Color },

                xAxis = new ValueCatTimeAxis()
                {
                    type = "dateTime",
                    tickCount = 5,
                },
            };
            var data = await ChartService.GetVisitData();
            _chart.SetData(data);
            await base.OnInitializedAsync();
        }
    }
}