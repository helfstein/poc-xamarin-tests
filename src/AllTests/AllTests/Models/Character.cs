using System;
using System.Collections.Generic;
using System.Text;

namespace AllTests.Models {
    public class Character {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Modified { get; set; }
        public DateTime? ModifiedAt { get {
                if (DateTime.TryParse(Modified, out var data)) {
                    return data;
                }
                return new DateTime();
            }
        }
        public Thumbnail Thumbnail { get; set; }

    }
}
