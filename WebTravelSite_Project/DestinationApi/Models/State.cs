using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DestinationApi.Models
{
    public class State
    {
        private string name;
        private string basicInfo;
        private string locationOneHeader;
        private string locationOneImage;
        private string locationOneInfo;
        private string locationTwoHeader;
        private string locationTwoImage;
        private string locationTwoInfo;
        private string locationThreeHeader;
        private string locationThreeImage;
        private string locationThreeInfo;

        public State(string name, string basicInfo, string locationOneHeader, string locationOneImage, string locationOneInfo,
            string locationTwoHeader, string locationTwoImage, string locationTwoInfo, string locationThreeHeader, 
            string locationThreeImage, string locationThreeInfo)
        {
            this.name = name;
            this.basicInfo = basicInfo;
            this.locationOneHeader = locationOneHeader;
            this.locationOneImage = locationOneImage;
            this.locationOneInfo = locationOneInfo;
            this.locationTwoHeader = locationTwoHeader;
            this.locationTwoImage = locationTwoImage;
            this.locationTwoInfo = locationTwoInfo;
            this.locationThreeHeader = locationThreeHeader;
            this.locationThreeImage = locationThreeImage;
            this.locationThreeInfo = locationThreeInfo;
        }
        public State()
        {
            this.name = "test";
            this.basicInfo = "test";
            this.locationOneHeader = "test";
            this.locationOneImage = "test";
            this.locationOneInfo = "test";
            this.locationTwoHeader = "test";
            this.locationTwoImage = "test";
            this.locationTwoInfo = "test";
            this.locationThreeHeader = "test";
            this.locationThreeImage = "test";
            this.locationThreeInfo = "test";
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string BasicInfo
        {
            get
            {
                return basicInfo;
            }
            set
            {
                basicInfo = value;
            }
        }
        public string LocationOneHeader
        {
            get
            {
                return locationOneHeader;
            }
            set
            {
                locationOneHeader = value;
            }
        }
        public string LocationOneImage
        {
            get
            {
                return locationOneImage;
            }
            set
            {
                locationOneImage = value;
            }
        }
        public string LocationOneInfo
        {
            get
            {
                return locationOneInfo;
            }
            set
            {
                locationOneInfo = value;
            }
        }
        public string LocationTwoHeader
        {
            get
            {
                return locationTwoHeader;
            }
            set
            {
                locationTwoHeader = value;
            }
        }
        public string LocationTwoImage
        {
            get
            {
                return locationTwoImage;
            }
            set
            {
                locationTwoImage = value;
            }
        }
        public string LocationTwoInfo
        {
            get
            {
                return locationTwoInfo;
            }
            set
            {
                locationTwoInfo = value;
            }
        }
        public string LocationThreeHeader
        {
            get
            {
                return locationThreeHeader;
            }
            set
            {
                locationThreeHeader = value;
            }
        }
        public string LocationThreeImage
        {
            get
            {
                return locationThreeImage;
            }
            set
            {
                locationThreeImage = value;
            }
        }
        public string LocationThreeInfo
        {
            get
            {
                return LocationThreeInfo;
            }
            set
            {
                locationThreeInfo = value;
            }
        }
    }
}
