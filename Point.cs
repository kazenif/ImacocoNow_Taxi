using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace PCGPS
{
    class GPSPoint : Object
    {
        private Double latitude;
        private Double longitude;
        private string name;

        public GPSPoint()
        {
            this.latitude = 0.0D;
            this.longitude = 0.0D;
            this.name = "";
        }

        public GPSPoint(Double Lat, Double Lon, string name)
        {
            this.latitude = Lat;
            this.longitude = Lon;
            this.name = name;
        }

        public Double Latitude
        {
            set
            {
                this.latitude = value;
            }
            get
            {
                return this.latitude;
            }
        }

        public Double Longitude
        {
            set
            {
                this.longitude = value;
            }
            get
            {
                return this.longitude;
            }
        }
        public string Name
        {
            set
            {
                this.name = value;
            }
            get
            {
                return this.name;
            }
        }

        public override string ToString()
        {
            return latitude.ToString() + "," + longitude.ToString() + "," + name;
        }

        public static GPSPoint Parse(string s)
        {
            Double Lat;
            Double Lon;
            string[] points = s.Split(',');
            try
            {
                Lat = Double.Parse(points[0]);
            }
            catch (Exception /* e */)
            {
                Lat = 0;
            }
            try
            {
                Lon = Double.Parse(points[1]);
            }
            catch (Exception /* e */)
            {
                Lon = 0;
            }
            string name = "無名の地点";
            if (points.Length > 2)
            {
                name = points[2];
            }
            return new GPSPoint(Lat, Lon, name);
        }
    }

    public class GPSTrackPoint : Object
    {
        string[] gpsMode = { "---", "GPS", "DGPS", "PPS", "RTK", "FRTK", "est", "man", "sim" };

        public GPSTrackPoint()
        {
            Latitude = 0.0D;
            Longitude = 0.0D;
            time = DateTime.Now;
            Direction = 0.0D;
            Velocity = 0.0D;
            Height = 0.0D;
            GPSfix = 0;
            SateliteCount = 0;
            Valid = "V";
            SoftError = false;
        }

        public Double Latitude;
        public Double Longitude;
        public DateTime time;
        public Double Direction;
        public Double Velocity;
        public Double Height;
        public int GPSfix;
        public int SateliteCount;
        public string Valid;
        public bool SoftError;
        public string GetTimeString()
        {
            return time.ToString("yyyy-MM-dd'T'HH:mm:ss.Fzzz");
        }

        public string GetHttpParameter()
        {
            return "time=" + HttpUtility.UrlEncode(time.ToString("yyyy-MM-dd'T'HH:mm:ss.Fzzz")) +
                "&lat=" + Latitude + "&lon=" + Longitude +
                "&gpsq=" + GPSfix + "&gpsn=" + SateliteCount +
                "&gpsh=" + Height + "&gpsd=" + Direction + "&gpsv=" + Velocity;
        }

        public string GetGpsMode()
        {
            try
            {
                return gpsMode[GPSfix];
            }
            catch (Exception)
            {
                return "---";
            }
        }
    }
}
