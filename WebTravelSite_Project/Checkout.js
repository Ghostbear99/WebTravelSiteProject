$(document).ready(function () {

    $("#flight-div").empty();
    $("#hotel-div").empty();

    $.ajax({
        type: "GET",
        url: "https://localhost:44342/api/Destination/GetAllFlightOrder",
        contentType: "application/json/; charset=utf-8",
        dataType: "json",
        success: function (data) {
            let flightList = data;
            if (flightList.length != 0) {
                $("#flight-head").css("display", "inline");
                for (let i = 0; i < flightList.length; i++) {
                    let company = flightList[i].Company;
                    let flightClass = flightList[i].FlightClass;
                    let numSeats = flightList[i].NumSeats;

                    let dateStartSplit = (flightList[i].TripStart).split("-");
                    let dateStart = (dateStartSplit[1] + "/" + dateStartSplit[2] + "/" + dateStartSplit[0]);
                    let tripStart = dateStart;

                    let dateEndSplit = (flightList[i].TripEnd).split("-");
                    let dateEnd = (dateEndSplit[1] + "/" + dateEndSplit[2] + "/" + dateEndSplit[0]);
                    let tripEnd = dateEnd;

                    let cost = "$" + flightList[i].Cost + "/per seat round trip";

                    let head = $("<h3 id='individual-flight-head'></h3>").text(flightList[i].Origin + "   To   " + flightList[i].Destination);
                    let companyText = $("<p class='flight-company'></p>").text(company);
                    let flightClassText = $("<p class='flight-class'></p>").text(flightClass);
                    let numSeatsText = $("<p class='flight-seats'></p>").text(numSeats);
                    let tripStartText = $("<p class='flight-start'></p>").text(tripStart);
                    let tripEndText = $("<p class='flight-end'></p>").text(tripEnd);
                    let costText = $("<p class='flight-cost'></p>").text(cost);

                    $("#flight-div").append(head,companyText, flightClassText,
                        numSeatsText, tripStartText, tripEndText, costText);
                }
            } else {
                $("#flight-head").css("display", "none");
                $("#flight-div").css("display", "none");
            }
        }
    })
    $.ajax({
        type: "GET",
        url: "https://localhost:44342/api/Destination/GetAllHotelOrder",
        contentType: "application/json/; charset=utf-8",
        dataType: "json",
        success: function (data) {
            hotelList = data;


            if (hotelList.length != 0) {
                $("#hotel-head").css("display", "inline");
                for (let i = 0; i < hotelList.length; i++) {
                    let destination = hotelList[i].Destination;
                    let hotelName = hotelList[i].HotelName;
                    let roomType = hotelList[i].RoomType;
                    let customerFirst = hotelList[i].CustomerFirst;
                    let customerLast = hotelList[i].CustomerLast;
                    let customerEmail = hotelList[i].CustomerEmail;

                    let dateStartSplit = (hotelList[i].TripStart).split("-");
                    let dateStart = (dateStartSplit[1] + "/" + dateStartSplit[2] + "/" + dateStartSplit[0]);
                    let tripStart = dateStart;

                    let dateEndSplit = (hotelList[i].TripEnd).split("-");
                    let dateEnd = (dateEndSplit[1] + "/" + dateEndSplit[2] + "/" + dateEndSplit[0]);
                    let tripEnd = dateEnd;

                    let pickedUp = hotelList[i].PickedUp;
                    let flightNum = hotelList[i].FlightNum;
                    let additionalResources = hotelList[i].AdditionalResources;
                    let numRooms = hotelList[i].NumRooms;
                    let cost = "$"+ hotelList[i].Cost + "/night";

                    let destinationText = $("<h3 class='hotel-head'></p>").text(destination + "(" + hotelName + ")");
                    let hotelNameText = $("<p class='hotel-name'></p>").text(hotelName);
                    let roomTypeText = $("<p class='hotel-room-type'></p>").text(roomType);
                    let firstNameText = $("<p class='hotel-first-name'></p>").text(customerFirst);
                    let lastNameText = $("<p class='hotel-last-name'></p>").text(customerLast);
                    let emailText = $("<p class='hotel-email'></p>").text(customerEmail);
                    let tripStartText = $("<p class='hotel-start'></p>").text(tripStart);
                    let tripEndText = $("<p class='hotel-end'></p>").text(tripEnd);
                    let pickedUpText = $("<p class='hotel-pick-up'></p>").text(pickedUp);
                    let numRoomsText = $("<p class='hotel-rooms'></p>").text(numRooms);
                    let costText = $("<p class='hotel-cost'></p>").text(cost);

                    $("#hotel-div").append(destinationText, hotelNameText, roomTypeText,
                        firstNameText, lastNameText, emailText, tripStartText, tripEndText, pickedUpText, numRoomsText, costText);

                    if (flightNum == "" && additionalResources != null) {
                        let additionalResourcesText = $("<p class='requests'></p>").text(additionalResources);
                        $("#hotel-div").append(additionalResourcesText);
                    } else if (additionalResources == null && flightNum != "") {
                        let flightNumText = $("<p class='flight-num'></p>").text(flightNum);
                        $("#hotel-div").append(flightNumText);
                    } else if (flightNum != "" && additionalResources != null) {
                        let flightNumText = $("<p class='flight-num'></p>").text(flightNum);
                        $("#hotel-div").append(flightNumText);
                        let additionalResourcesText = $("<p class='requests'></p>").text(additionalResources);
                        $("#hotel-div").append(additionalResourcesText);
                    }

                }
            } else {
                $("#hotel-head").css("display", "none");
                $("#hotel-div").css("display", "none");
            }
        }
    })
    $("#delete-all-flights").click(function(){
        $.ajax({
            type: "GET",
            url: "https://localhost:44342/api/Destination/PurgeFlightOrder",
            contentType: "application/json/; charset=utf-8",
            success: function () {
                location.reload();
            },
            error: function () {
                alert("There was an error in deleting all of your flights");
            }
        })
    })
    $("#delete-all-hotels").click(function () {
        $.ajax({
            type: "GET",
            url: "https://localhost:44342/api/Destination/PurgeHotelOrder",
            contentType: "application/json/; charset=utf-8",
            success: function () {
                location.reload();
            },
            error: function () {
                alert("There was an error in deleting all of your hotels");
            }
        })
    })
    $("#submit-all-orders").click(function () {
        $.ajax({
            type: "GET",
            url: "https://localhost:44342/api/Destination/PurgeFlightOrder",
            contentType: "application/json/; charset=utf-8",
            success: function () {
                $.ajax({
                    type: "GET",
                    url: "https://localhost:44342/api/Destination/PurgeHotelOrder",
                    contentType: "application/json/; charset=utf-8",
                    dataType: "json",
                    success: function () {
                        alert("Your order was successfully placed");
                        location.reload();
                    },
                    error: function () {
                        alert("There was an error in sumbiting your hotel order");
                    }
                })
            },
            error: function () {
                alert("There was an error in submitting your flight order");
            }
        })
    })
})