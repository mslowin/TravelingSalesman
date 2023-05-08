export function load_map() {
    let map = L.map('map').setView({ lon: 0, lat: 0 }, 2);
    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', { maxZoom: 19 }).addTo(map);
    return "";
}