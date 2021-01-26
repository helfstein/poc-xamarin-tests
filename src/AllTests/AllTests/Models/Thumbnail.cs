using System;
using System.Collections.Generic;
using System.Text;

namespace AllTests.Models {
    public class Thumbnail {

        public string Path { get; set; }
        public string Extension { get; set; }
        
        /// <summary>
        /// full image, constrained to 500px wide
        /// </summary>
        public string Default => $"{Path}/detail.{Extension}";
        
        /// <summary>
        /// no variant descriptor
        /// </summary>
        public string FullSize => $"{Path}.{Extension}";

        #region Standard
        /// <summary>
        /// Square 65x45px
        /// </summary>
        public string StandardSmall => $"{Path}/standard_small.{Extension}";

        /// <summary>
        /// Square 100x100px
        /// </summary>
        public string StandardMedium => $"{Path}/standard_medium.{Extension}";

        /// <summary>
        /// Square 140x140px
        /// </summary>
        public string StandardLarge => $"{Path}/standard_large.{Extension}";

        /// <summary>
        /// Square 200x200px
        /// </summary>
        public string StandardXLarge => $"{Path}/standard_xlarge.{Extension}";

        /// <summary>
        /// Square 250x250px
        /// </summary>
        public string StandardFantastic => $"{Path}/standard_fantastic.{Extension}";

        /// <summary>
        /// Square 180x180px
        /// </summary>
        public string StandardAmazing => $"{Path}/standard_amazing.{Extension}";
        #endregion

        #region Portrait
        /// <summary>
        /// Square 50x75px
        /// </summary>
        public string PortraitSmall => $"{Path}/portrait_small.{Extension}";

        /// <summary>
        /// Square 100x150px
        /// </summary>
        public string PortraitMedium => $"{Path}/portrait_medium.{Extension}";

        /// <summary>
        /// Square 150x225px
        /// </summary>
        public string PortraitXLarge => $"{Path}/portrait_xlarge.{Extension}";

        /// <summary>
        /// Square 168x252px
        /// </summary>
        public string PortraitFantastic => $"{Path}/portrait_fantastic.{Extension}";

        /// <summary>
        /// Square 300x450px
        /// </summary>
        public string PortraitUncanny => $"{Path}/portrait_uncanny.{Extension}";

        /// <summary>
        /// Square 216x324px
        /// </summary>
        public string PortraitIncredible => $"{Path}/portrait_incredible.{Extension}";
        #endregion

        #region Landscape
        /// <summary>
        /// Square 120x90px
        /// </summary>
        public string LandscapeSmall => $"{Path}/landscape_small.{Extension}";

        /// <summary>
        /// Square 175x130px
        /// </summary>
        public string LandscapeMedium => $"{Path}/landscape_medium.{Extension}";

        /// <summary>
        /// Square 190x140px
        /// </summary>
        public string LandscapeLarge => $"{Path}/landscape_large.{Extension}";

        /// <summary>
        /// Square 270x200px
        /// </summary>
        public string LandscapeXLarge => $"{Path}/landscape_xlarge.{Extension}";

        /// <summary>
        /// Square 250x156px
        /// </summary>
        public string LandscapeAmazing => $"{Path}/landscape_amazing.{Extension}";

        /// <summary>
        /// Square 464x261px
        /// </summary>
        public string LandscapeIncredible => $"{Path}/landscape_incredible.{Extension}";
        #endregion




    }



}
