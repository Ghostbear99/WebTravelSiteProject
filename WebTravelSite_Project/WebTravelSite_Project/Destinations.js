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
    let request = new XMLHttpRequest();
    let stateIndex = stateNames.indexOf(stateDiv.value)
    request.open("GET", "https://localhost:44342/api/Destination/GetState/" + stateIndex);
    request.setRequestHeader("Content-Type", "application/json; charset=utf-8");
    request.onreadystatechange = function () {
        if (request.readyState == 4 && request.status == 200) {
            let temp = (request.responseText).split('|');
            stateImage.src = temp[1];
        }
    };
    request.send();

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
        parent.location = "http://localhost:1337/Bookings.html";
    }
}