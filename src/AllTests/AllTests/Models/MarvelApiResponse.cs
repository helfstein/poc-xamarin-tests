namespace AllTests.Models {
    public class MarvelApiResponse<T> where T : class {

        public int Code { get; set; }
        public string Status { get; set; }
        public string Copyright { get; set; }
        public string AttributionText { get; set; }
        public string AttributionHTML { get; set; }
        public string ETag { get; set; }

        public MarvelApiResponseData<T> Data { get; set; }



    }
}
