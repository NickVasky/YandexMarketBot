using System;
using System.Collections.Generic;

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
        public List<string> cpu { get;}
        public Range<int> ram { get;}
        public Range<int> ssd { get;}
        public Range<int> hdd { get;}
        public Range<double> weight { get;}
        public Range<int> battery { get;}
        public int reviews { get;}
        public double rating { get;}
        public int productsCount { get;}
        
        public MarketFilters(
                List<string> cpu,
                int? ramFrom, int? ramTo,
                int? ssdFrom, int? ssdTo,
                int? hddFrom, int? hddTo,
                double? weightFrom, double? weightTo,
                int? batteryFrom, int? batteryTo,
                int reviews, double rating, int productsCount)
        {
            this.cpu = cpu;
            
            this.ram = SetRangeInt(ramFrom, ramTo);
            this.ssd = SetRangeInt(ssdFrom, ssdTo);
            this.hdd = SetRangeInt(hddFrom, hddTo);
            this.weight = SetRangeDouble(weightFrom, weightTo);
            this.battery = SetRangeInt(batteryFrom, batteryTo);
            this.reviews = reviews;
            this.rating = rating;
            this.productsCount = productsCount;
        }
        
        private static Range<int>? SetRangeInt(int? fromValue, int? toValue) {
            if (fromValue.HasValue && toValue.HasValue)
                return new Range<int>(fromValue.Value, toValue.Value);
            else if (fromValue.HasValue && !toValue.HasValue)
                return new Range<int>(fromValue.Value, fromValue.Value);
            else if (!fromValue.HasValue && toValue.HasValue)
                return new Range<int>(0, toValue.Value);
            else
                return null;
        }
        private static Range<double>? SetRangeDouble(double? fromValue, double? toValue) {
            if (fromValue.HasValue && toValue.HasValue)
                return new Range<double>(fromValue.Value, toValue.Value);
            else if (fromValue.HasValue && !toValue.HasValue)
                return new Range<double>(fromValue.Value, fromValue.Value);
            else if (!fromValue.HasValue && toValue.HasValue)
                return new Range<double>(0, toValue.Value);
            else
                return null;
        }
    }
}