using System;
using System.Collections.Generic;
using System.Text;

namespace PCGPS
{
    public class ImakokoPoint
    {
        public string user;
        public bool valid;
        public string nickname;
        public int type;
        public Double? lat;
        public Double? lon;
        public Double? altitude;
        public Double? velocity;
        public Double? dir;
        public string ustream_status;

        // ココから下は内部使用
        public Double? distance;
        public Double? direction;
        public Double? n_direction;
        public Double? prev_distance;
    }
}
