let map;

export function load_map() {
    map = L.map('map').setView({ lon: 0, lat: 0 }, 2);
    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', { maxZoom: 19 }).addTo(map);

    map.on('click', onMapClick);

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