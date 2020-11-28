$(document).ready(function () {
    //Section to modify dates to current date, not section to modify if changed
    let today = new Date().toISOString().slice(0, 10)
    $("#start").val(today);

    let flight = null;

    //Set price for Delta and Economy on page load
    $.ajax({
        type: "GET",
        url: "https://localhost:44342/api/Destination/GetFlight/Delta",
        contentType: "application/json/; charset=utf-8",
        dataType: "json",
        success: function (data) {
            flight = data;
            $("#flight-price").val("$" + flight.EconomyPrice);

        }
    })
    let getHotelStartup = "https://localhost:44342/api/Destination/GetAllHotel/" + $("#state-select option:selected").text();
    $.ajax({
        type: "GET",
        url: getHotelStartup,
        contentType: "application/json/; charset=utf-8",
        dataType: "json",
        success: function (data) {
            let hotelList = data;
            $.each(hotelList, function (index, hotel) {
                $("#hotel-select").append(new Option(hotel.Name));
            })
            $("#hotel-price").val("$" + hotelList[0].SuiteBedPrice + "/night");

        }
    })


    $("#state-select").change(function () {
        $("#hotel-select").empty();
        let getHotelString = "https://localhost:44342/api/Destination/GetAllHotel/" + $("#state-select option:selected").text();
        $.ajax({
            type: "GET",
            url: getHotelString,
            contentType: "application/json/; charset=utf-8",
            dataType: "json",
            success: function (data) {
                let hotelList = data;
                $.each(hotelList, function (index, hotel) {
                    $("#hotel-select").append(new Option(hotel.Name));
                })
                let hotelTypeSelected = $("#hotel-type-select option:selected").text();

                if (hotelTypeSelected == "Suite") {
                    $("#hotel-price").val("$" + hotelList[0].SuiteBedPrice + "/night");
                } else if (hotelTypeSelected == "Two Bed") {
                    $("#hotel-price").val("$" + hotelList[0].TwoBedPrice + "/night");
                } else {
                    $("#hotel-price").val("$" + hotelList[0].SingleBedPrice + "/night");
                }

            }
        })
    })
    $("#hotel-type-select").change(function () {
        let hotelSelected = $("#hotel-select option:selected").text();
        let hotelTypeSelected = $("#hotel-type-select option:selected").text();
        let state = $("#state-select option:selected").text();
        let getHotelString = "https://localhost:44342/api/Destination/GetHotel/" + hotelSelected +
            "/" + state;

        $.ajax({
            type: "GET",
            url: getHotelString,
            contentType: "application/json/; charset=utf-8",
            dataType: "json",
            success: function (data) {
                let hotel = data;
                if (hotelTypeSelected == "Suite") {
                    $("#hotel-price").val("$" + hotel.SuiteBedPrice + "/night");
                } else if (hotelTypeSelected == "Two Bed") {
                    $("#hotel-price").val("$" + hotel.TwoBedPrice + "/night");
                } else {
                    $("#hotel-price").val("$" + hotel.SingleBedPrice + "/night");
                }
            }
        })
    })
    $("#flight").change(function () {
        let getFlightString = "https://localhost:44342/api/Destination/GetFlight/" + $("#flight option:selected").text();
        $.ajax({
            type: "GET",
            url: getFlightString,
            contentType: "application/json/; charset=utf-8",
            dataType: "json",
            success: function (data) {
                flight = data;
                let flightClass = $("#flight-class option:selected").text();
                if (flightClass == "Economy Class") {
                    $("#flight-price").val("$" + flight.EconomyPrice);
                } else if (flightClass == "Business Class") {
                    $("#flight-price").val("$" + flight.BusinessPrice);
                } else {
                    $("#flight-price").val("$" + flight.FirstPrice);
                }
            }
        })
    })
    $("#flight-class").change(function () {
        let flightClass = $("#flight-class option:selected").text();
        if (flightClass == "Economy Class") {
            $("#flight-price").val("$" + flight.EconomyPrice);
        } else if (flightClass == "Business Class") {
            $("#flight-price").val("$" + flight.BusinessPrice);
        } else {
            $("#flight-price").val("$" + flight.FirstPrice);
        }
    })
})