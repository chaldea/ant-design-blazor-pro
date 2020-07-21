using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace AntDesign.Pro
{
    public interface IChartService
    {
        Task<ICollection<DataItem>> GetVisitData();
        // Task<ICollection<DataItem>> GetVisitData2();
        // Task<ICollection<DataItem>> GetSalesData();
        // Task<ICollection<SearchDataItem>> GetSearchData();
        // Task<ICollection<OfflineDataItem>> GetOfflineData();
        // Task<ICollection<OfflineChartDataItem>> GetOfflineChartData();
        // Task<ICollection<DataItem>> GetSalesTypeData();
        // Task<ICollection<DataItem>> GetSalesTypeDataOnline();
        // Task<ICollection<DataItem>> GetSalesTypeDataOffline();
        // Task<ICollection<RadarDataItem>> GetRadarData();
        // Task<FakeChartData> GetFakeChartData();
    }

    public class ChartService : IChartService
    {
        private readonly NavigationManager _navigationManager;
        private readonly HttpClient _httpClient;
        private FakeChartData _data;

        public ChartService(NavigationManager navigationManager, HttpClient httpClient)
        {
            _navigationManager = navigationManager;
            _httpClient = httpClient;
        }

        public async Task<ICollection<DataItem>> GetVisitData()
        {
            return (await GetFakeChartData()).VisitData;
        }
        //
        // public async Task<ICollection<DataItem>> GetVisitData2()
        // {
        //     return (await GetFakeChartData()).VisitData2;
        // }
        //
        // public async Task<ICollection<DataItem>> GetSalesData()
        // {
        //     return (await GetFakeChartData()).SalesData;
        // }
        //
        // public async Task<ICollection<SearchDataItem>> GetSearchData()
        // {
        //     return (await GetFakeChartData()).SearchData;
        // }
        //
        // public async Task<ICollection<OfflineDataItem>> GetOfflineData()
        // {
        //     return (await GetFakeChartData()).OfflineData;
        // }
        //
        // public async Task<ICollection<OfflineChartDataItem>> GetOfflineChartData()
        // {
        //     return (await GetFakeChartData()).OfflineChartData;
        // }
        //
        // public async Task<ICollection<DataItem>> GetSalesTypeData()
        // {
        //     return (await GetFakeChartData()).SalesTypeData;
        // }
        //
        // public async Task<ICollection<DataItem>> GetSalesTypeDataOnline()
        // {
        //     return (await GetFakeChartData()).SalesTypeDataOnline;
        // }
        //
        // public async Task<ICollection<DataItem>> GetSalesTypeDataOffline()
        // {
        //     return (await GetFakeChartData()).SalesTypeDataOffline;
        // }
        //
        // public async Task<ICollection<RadarDataItem>> GetRadarData()
        // {
        //     return (await GetFakeChartData()).RadarData;
        // }

        public async Task<FakeChartData> GetFakeChartData()
        {
            if (_data == null)
            {
                var baseUrl = _navigationManager.ToAbsoluteUri(_navigationManager.BaseUri);
                var json = await _httpClient.GetStringAsync(new Uri(baseUrl, "data/fake_chart_data.json").ToString());
                _data = JsonSerializer.Deserialize<FakeChartData>(json);
                Console.WriteLine(_data.VisitData.Count);
            }
            return _data;
        }
    }

    public class FakeChartData
    {
        [JsonPropertyName("visitData")]
        public ICollection<DataItem> VisitData { get; set; }
        // [JsonPropertyName("visitData2")]
        // public ICollection<DataItem> VisitData2 { get; set; }
        // [JsonPropertyName("salesData")]
        // public ICollection<DataItem> SalesData { get; set; }
        // [JsonPropertyName("searchData")]
        // public ICollection<SearchDataItem> SearchData { get; set; }
        // [JsonPropertyName("offlineData")]
        // public ICollection<OfflineDataItem> OfflineData { get; set; }
        // [JsonPropertyName("offlineChartData")]
        // public ICollection<OfflineChartDataItem> OfflineChartData { get; set; }
        // [JsonPropertyName("salesTypeData")]
        // public ICollection<DataItem> SalesTypeData { get; set; }
        // [JsonPropertyName("salesTypeDataOnline")]
        // public ICollection<DataItem> SalesTypeDataOnline { get; set; }
        // [JsonPropertyName("salesTypeDataOffline")]
        // public ICollection<DataItem> SalesTypeDataOffline { get; set; }
        // [JsonPropertyName("radarData")]
        // public ICollection<RadarDataItem> RadarData { get; set; }
    }

    public class DataItem
    {
        [JsonPropertyName("x")]
        public string X { get; set; }
        [JsonPropertyName("y")]
        public int Y { get; set; }
    }

    public class SearchDataItem
    {
        [JsonPropertyName("index")]
        public int Index { get; set; }
        [JsonPropertyName("Keyword")]
        public string Keyword { get; set; }
        [JsonPropertyName("ceyword")]
        public int Count { get; set; }
        [JsonPropertyName("range")]
        public int Range { get; set; }
        [JsonPropertyName("status")]
        public int Status { get; set; }

    }

    public class OfflineDataItem
    {
        [JsonPropertyName("name")]
        public int Name { get; set; }
        [JsonPropertyName("cvr")]
        public float Cvr { get; set; }
    }

    public class OfflineChartDataItem
    {
        [JsonPropertyName("x")]
        public int X { get; set; }
        [JsonPropertyName("y1")]
        public int Y1 { get; set; }
        [JsonPropertyName("y2")]
        public int Y2 { get; set; }
    }

    public class RadarDataItem
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("label")]
        public string Label { get; set; }
        [JsonPropertyName("value")]
        public int Value { get; set; }
    }
}
