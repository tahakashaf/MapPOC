$(document).ready(function () {
    Initialize();
});


    function Initialize() {
        var mapProp = {
            center: new google.maps.LatLng(21.7679, 78.8718),
            zoom: 5,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        var map = new google.maps.Map(document.getElementById("googleMap"), mapProp);

        $.ajax({

            type: 'GET',

            url: '/Home/GetMapData/',
            dataType: 'json',
            success: function (data) {
                var items = '';
                $.each(data, function (i, item) {
                    console.dir(item);

                    var marker = new google.maps.Marker({
                        'position': new google.maps.LatLng(item.Latitude, item.Longitude),
                        'map': map,
                        //'title': item.City
                    });

                    //// Make the marker-pin blue! 
                    marker.setIcon('http://maps.google.com/mapfiles/ms/icons/red-dot.png')

                    var infowindow = new google.maps.InfoWindow({
                        content: "<div class='infoDiv'><h2>" + item.City + "</div></div>"
                    });

                    // finally hook up an "OnClick" listener to the map so it pops up out info-window when the marker-pin is clicked! 
                    google.maps.event.addListener(marker, 'mouseover', function () {
                        infowindow.open(map, marker);
                    });
                    google.maps.event.addListener(marker, 'mouseout', function () {
                        infowindow.close();
                    });


                    
                });

            },
            error: function (ex) {
                var r = jQuery.parseJSON(response.responseText);
                alert("Message: " + r.Message);
                alert("StackTrace: " + r.StackTrace);
                alert("ExceptionType: " + r.ExceptionType);
            }
        });




        //var data = [
        //     { "Id": 1, "PlaceName": "Delhi", "GeoLong": "28.6139", "GeoLat": "77.2090" },
        //     { "Id": 2, "PlaceName": "Mumbai ", "GeoLong": "19.0760", "GeoLat": "72.8777" },
        //     { "Id": 3, "PlaceName": "Pune", "GeoLong": "18.5204", "GeoLat": "73.8567" }
                
        //];

        //$.each(data, function (i, item) { 
        //    var marker = new google.maps.Marker({ 
        //        'position': new google.maps.LatLng(item.GeoLong, item.GeoLat), 
        //        'map': map, 
        //        'title': item.PlaceName 
        //    }); 
 
        //    // Make the marker-pin blue! 
        //    marker.setIcon('http://maps.google.com/mapfiles/ms/icons/blue-dot.png')

        //    var infowindow = new google.maps.InfoWindow({
        //        content: "<div class='infoDiv'><h2>" + item.PlaceName + "</div></div>"
        //    });

        //    // finally hook up an "OnClick" listener to the map so it pops up out info-window when the marker-pin is clicked! 
        //    google.maps.event.addListener(marker, 'hover', function () {
        //        infowindow.open(map, marker);
        //    });

 

        //})






    }
   // google.maps.event.addDomListener(window, 'load', initialize);

