// Create a marker for the parking garage
var garageMarker = L.marker([lat, lng]).addTo(map);

// Add an event listener to the marker
garageMarker.on('click', function () {
    // Redirect the user to parking list views
    window.location.href = "parkinglistviews.html";
});