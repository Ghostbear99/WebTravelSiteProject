$(document).ready(function () {
    let today = new Date().toISOString().slice(0, 10);
    $("#start").val(today);
    $("#end").val(today);
    $("#start").attr("min", today);
    $("#end").attr("min", today);

    $("#start").change(function () {
        let endMin = $(this).val();
        $("#end").attr("min", endMin)
        $("#end").val(endMin);
    })
    $("#hotel-type-select").change(function () {
        let hotelSelected = $("#hotel-select option:selected").text();
        let hotelTypeSelected = $("#hotel-type-select option:selected").text();
        if (hotelSelected != "Please Select" || hotelTypeSelected != "Please Select") {
            let getHotelString = "https://localhost:44342/api/Destination/GetHotel/" + hotelSelected;

            $.ajax({
                type: "GET",
                url: getHotelString,
                contentType: "application/json/; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    let hotel = data;
                    if (hotelTypeSelected == "Suite") {
                        $("#hotel-price").val(hotel.SuiteBedPrice);
                    } else if (hotelTypeSelected == "Two Bed") {
                        $("#hotel-price").val(hotel.TwoBedPrice);
                    } else {
                        $("#hotel-price").val(hotel.SingleBedPrice);
                    }
                }
            })
        }
    })
    $("#hotel-select").change(function () {
        let hotelSelected = $("#hotel-select option:selected").text();
        let hotelTypeSelected = $("#hotel-type-select option:selected").text();
        if (hotelSelected != "Please Select" || hotelTypeSelected != "Please Select") {
            let getHotelString = "https://localhost:44342/api/Destination/GetHotel/" + hotelSelected;

            $.ajax({
                type: "GET",
                url: getHotelString,
                contentType: "application/json/; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    let hotel = data;
                    if (hotelTypeSelected == "Suite") {
                        $("#hotel-price").val(hotel.SuiteBedPrice);
                    } else if (hotelTypeSelected == "Two Bed") {
                        $("#hotel-price").val(hotel.TwoBedPrice);
                    } else {
                        $("#hotel-price").val(hotel.SingleBedPrice);
                    }
                }
            })
        }
    })
    $("#add-to-cart").click(function () {
        let stringURL = "https://localhost:44342/api/Destination/InsertHotelOrder/"

        let numRooms = parseInt($("#numRooms").val());

        if (isNaN(numRooms) == false) {
                let stateDestination = $("#state-select-destination").val();
                let hotelName = $("#hotel-select").val();
                let hotelType = $("#hotel-type-select").val();
                let customerFirst = $("#firstName").val();
                let customerLast = $("#lastName").val();
                let customerEmail = $("#email").val();
                let tripStart = $("#start").val();
                let tripEnd = $("#end").val();
                let pickedUp = $('input[name=picked-up]:checked').val();
                let flightNum = $("#flightNumber").val();
                let additionalRequests = $("#requests").val();
                let hotelPrice = parseInt($("#hotel-price").val());
            if (hotelName != "Please Select" || hotelTypeSelected != "Please Select") {
                let orderData = "destination=" + stateDestination + "&hotelName=" + hotelName + "&roomType=" + hotelType + "&customerFirst=" + customerFirst +
                    "&customerLast=" + customerLast + "&customerEmail=" + customerEmail + "&tripStart=" + tripStart + "&tripEnd=" + tripEnd + "&pickedUp=" + pickedUp +
                    "&flightNum=" + flightNum + "&additionalRequests=" + additionalRequests + "&numRooms=" + numRooms + "&cost=" + hotelPrice;

                $.ajax({
                    type: "POST",
                    url: stringURL,
                    contentType: "application/x-www-form-urlencoded",
                    dataType: "json",
                    data: orderData,
                    success: alert("Your order was added to the cart"),
                    error: function (data) {
                        $("flight-price").val(data);
                    }
                })
            } else {
                alert("Please select a hotel first");
            }
        } else {
            alert("One of the inputs for either Number of rooms or Number of flights is not an int")
        }
    })
    $("#checkout").click(function () {
        window.location.href = "http://localhost:1337/Checkout.html";
    })
})