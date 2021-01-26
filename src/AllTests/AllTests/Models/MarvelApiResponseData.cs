using System;
using System.Collections.Generic;
using System.Text;

namespace AllTests.Models {
    public class MarvelApiResponseData<T> where T : class {

        public int Offset { get; set; }
        public int Limit { get; set; }
        public int Total { get; set; }
        public int Count { get; set; }
        public List<T> Results { get; set; }

    }
}
