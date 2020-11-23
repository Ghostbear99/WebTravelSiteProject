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
        private string locationOneText;
        private string locationTwoHeader;
        private string locationTwoImage;
        private string locationTwoText;
        private string locationThreeHeader;
        private string locationThreeImage;
        private string locationThreeText;

        public State(string name, string basicInfo, string locationOneHeader, string locationOneImage, string locationOneInfo,
            string locationTwoHeader, string locationTwoImage, string locationTwoInfo, string locationThreeHeader, 
            string locationThreeImage, string locationThreeInfo)
        {
            this.name = name;
            this.basicInfo = basicInfo;
            this.locationOneHeader = locationOneHeader;
            this.locationOneImage = locationOneImage;
            this.locationOneText = locationOneInfo;
            this.locationTwoHeader = locationTwoHeader;
            this.locationTwoImage = locationTwoImage;
            this.locationTwoText = locationTwoInfo;
            this.locationThreeHeader = locationThreeHeader;
            this.locationThreeImage = locationThreeImage;
            this.locationThreeText = locationThreeInfo;
        }
        public State(){}
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
        public string LocationOneText
        {
            get
            {
                return locationOneText;
            }
            set
            {
                locationOneText = value;
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
        public string LocationTwoText
        {
            get
            {
                return locationTwoText;
            }
            set
            {
                locationTwoText = value;
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
        public string LocationThreeText
        {
            get
            {
                return LocationThreeText;
            }
            set
            {
                locationThreeText = value;
            }
        }
    }
}
