let map;

export function load_map(coordinatesJson) {
    map = L.map('map').setView({ lon: 0, lat: 0 }, 2);
    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', { maxZoom: 19 }).addTo(map);

    map.on('click', onMapClick);

    var coordinates = JSON.parse(coordinatesJson);
    for (var i = 0; i < coordinates.length; i++) {
        var coordinate = coordinates[i];
        console.log(coordinate)
        var marker = L.marker([coordinate.Latitude, coordinate.Longitude]).addTo(map);
        marker.bindPopup(coordinate.Name)
    }

    return "";
}

function onMapClick(e) {
    let name = prompt("Please enter a name for the marker:");
    if (name === null || name === "")
    {
        return;
    }

    let marker = L.marker(e.latlng).addTo(map);
    marker.bindPopup(name).openPopup();
    DotNet.invokeMethodAsync('TravelingSalesman', 'AddCoordinate', e.latlng.lat, e.latlng.lng, name);
}