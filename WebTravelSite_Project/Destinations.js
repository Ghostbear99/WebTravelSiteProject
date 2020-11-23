let stateNames = new Array("Alabama", "Alaska", "Arizona", "Arkansas", "California", "Colorado", "Connecticut", "Deleware", "Florida", "Georgia",
    "Hawaii", "Idaho", "Illinois", "Indiana", "Iowa", "Kansas", "Kentucky", "Louisiana", "Maine", "Maryland", "Massachusetts", "Michigan", "Minnesota",
    "Mississippi", "Missouri", "Montana", "Nebraska", "Nevada", "New Hampshire", "New Jersey", "New Mexico", "New York", "North Carolina",
    "North Dakota", "Ohio", "Oklahoma", "Oregon", "Pennsylvania", "Rhode Island", "South Carolina", "South Dakota", "Tennessee", "Texas",
    "Utah", "Vermont", "Virginia", "Washington", "West Virginia", "Wisconsin", "Wyoming");
window.onload = function () {
    let searchButton = document.getElementById("search-button");
    let searchText = document.getElementById("search-text");

    createPage();

    searchButton.onclick = function () {
        let searchValue = searchText.value;
        let stateListSection = document.getElementById("state-list");
        let stateSearchSection = document.getElementById("search-state-results");

        stateListSection.style.display = "none";

        clearStateResults();

        for (let i = 0; i < stateNames.length; i++) {
            if (stateNames[i].indexOf(searchValue) == false) {
                createState(stateSearchSection, stateNames[i]);
            }
        }

    }
}
function createPage() {
    let startStatePage = document.getElementById("state-list");
    for (let i = 0; i < stateNames.length; i++) {
        createState(startStatePage, stateNames[i]);
    }
}
function createState(stateDoc, stateName) {
    let masterDocument = stateDoc;

    let stateDiv = document.createElement("div");
    stateDiv.className = "state-tile";
    stateDiv.id = stateName + "-tile";
    stateDiv.value = stateName;

    let stateImageDiv = document.createElement("div");
    stateImageDiv.className = "state-img";

    let stateImage = document.createElement("img");
    stateImage.src = "https://philadelphiaencyclopedia.org/wp-content/uploads/2015/09/Philadelphia_Skyline-1.jpg";

    let stateTextDiv = document.createElement("div");

    let stateText = document.createElement("p");
    let stateAcutalText = document.createTextNode(stateName);
    stateText.appendChild(stateAcutalText);

    stateImageDiv.appendChild(stateImage);
    stateTextDiv.appendChild(stateText);

    stateDiv.appendChild(stateImageDiv);
    stateDiv.appendChild(stateTextDiv);

    masterDocument.appendChild(stateDiv);

    stateDiv.onclick = function () {
        let request = new XMLHttpRequest();
        let stateIndex = stateNames.indexOf(stateDiv.value)
        request.open("GET", "https://localhost:44342/api/Destination/GetState/" + stateIndex);
        request.setRequestHeader("Content-Type", "application/json; charset=utf-8");
        request.onreadystatechange = function () {
            if (request.readyState == 4 && request.status == 200) {
                let temp = (request.responseText).split('|');
                stateInfo(stateDoc, temp);
            }
        };
        request.send();
    }
}
function clearStateResults() {
    let masterDoc = document.getElementById("search-state-results");
    while (masterDoc.hasChildNodes()) {
        masterDoc.removeChild(masterDoc.firstChild);
    }
}
function stateInfo(stateDoc, infoArray) {
    let masterDocument = stateDoc;
    let arr = infoArray;

    masterDocument.style.display = "none";

    let stateDocument = document.getElementById("state-info");

    let header = document.createElement("h1");
    let headerText = document.createTextNode(arr[0]);
    header.appendChild(headerText);

    let info = document.createElement("p");
    let infoText = document.createTextNode(arr[1]);
    info.appendChild(infoText);

    let locationOneHeader = document.createElement("h2");
    let locationOneHeaderText = document.createTextNode(arr[2]);
    locationOneHeader.appendChild(locationOneHeaderText);

    let locationOneImage = document.createElement("img");
    locationOneImage.src = arr[3];

    let locationOneInfo = document.createElement("p");
    let locationOneInfoText = document.createTextNode(arr[4]);
    locationOneInfo.appendChild(locationOneInfoText);

    let locationTwoHeader = document.createElement("h2");
    let locationTwoHeaderText = document.createTextNode(arr[5]);
    locationTwoHeader.appendChild(locationTwoHeaderText);

    let locationTwoImage = document.createElement("img");
    locationTwoImage.src = arr[6];

    let locationTwoInfo = document.createElement("p");
    let locationTwoInfoText = document.createTextNode(arr[7]);
    locationTwoInfo.appendChild(locationTwoInfoText);
    /*
    let locationThreeHeader = document.createElement("h2");
    let locationThreeHeaderText = document.createTextNode(arr[8]);
    locationThreeHeader.appendChild(locationThreeHeaderText);

    let locationThreeImage = document.createElement("img");
    locationThreeImage.src = arr[9];

    let locationThreeInfo = document.createElement("p");
    let locationThreeInfoText = document.createTextNode(arr[10]);
    locationThreeInfo.appendChild(locationThreeInfoText);
    */


    stateDocument.appendChild(header);
    stateDocument.appendChild(info);
    stateDocument.appendChild(locationOneHeader);
    stateDocument.appendChild(locationOneImage);
    stateDocument.appendChild(locationOneInfoText);
    stateDocument.appendChild(locationTwoHeader);
    stateDocument.appendChild(locationTwoImage);
    stateDocument.appendChild(locationTwoInfoText);
    /*
    stateDocument.appendChild(locationThreeHeader);
    stateDocument.appendChild(locationThreeImage);
    stateDocument.appendChild(locationThreeInfoText);
    */

}