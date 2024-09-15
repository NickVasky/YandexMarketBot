using System;
using System.Collections.Generic;
using System.Data;
using UiPath.Core;
using UiPath.Core.Activities.Storage;
using UiPath.Excel;
using UiPath.Excel.Activities;
using UiPath.Excel.Activities.API;
using UiPath.Excel.Activities.API.Models;
using UiPath.Mail.Activities.Api;
using UiPath.Orchestrator.Client.Models;
using UiPath.Testing;
using UiPath.Testing.Activities.TestData;
using UiPath.Testing.Activities.TestDataQueues.Enums;
using UiPath.Testing.Enums;
using UiPath.UIAutomationNext.API.Contracts;
using UiPath.UIAutomationNext.API.Models;
using UiPath.UIAutomationNext.Enums;
using YandexMarketBot.ObjectRepository;

namespace YandexMarketBot
{
    public class Range<T> where T : System.Numerics.INumber<T>
    {
        public T fromValue { get;}
        public T toValue { get;}
        
        public Range(T fromValue, T toValue) 
        {
            this.fromValue = fromValue;
            this.toValue = toValue;
        }
        public Boolean IsInside(T number) {
            if (number >= this.fromValue && number <= this.toValue)
                return true;
            else
                return false;
        }
    }
    
    public class MarketFilters
    {
        public List<string> cpu;
        public Range<int> ram;
        public Range<int> ssd;
        public Range<int> hdd;
        public Range<double> weight; 
        public Range<int> battery; 
        
    }
}