const mapId = '4148a38c-75ee-45d2-9dd9-2412b68ee995';
const mapKey = 'VUwwRChvYAAivF5saWzR';
const geojsonId = '3f7eb6cc-2b6a-4ad0-b4f9-c614af7a8a78';

const slopeColorMap = {
    'Easy': '#009f3c',
    'Intermediate': '#007aba',
    'Hard': '#ba0925',
    'Expert': '#000000'
};
const liftColor = '#797979';



$(function () {
    const map = new maplibregl.Map({
        container: 'map',
        style: `https://api.maptiler.com/maps/${mapId}/style.json?key=${mapKey}`,
        //style: {
        //    version:8,
        //    sources: {
        //        vector: {
        //            type: 'raster',
        //            url: `https://api.maptiler.com/maps/${mapId}/style.json?key=${mapKey}`
        //        },
        //        terrainSource: {
        //            type: 'raster-dem',
        //            url: `https://api.maptiler.com/tiles/terrain-rgb-v2/tiles.json?key=${mapKey}`
        //        }
        //    },
        //    layers:[ {
        //        id: 'vector',
        //        type: 'raster',
        //        source:'vector'
        //    }],
        //    terrain: {
        //        source:'terrainSource'
        //    }
        //},
        //maxzoom: 18,
        //hash:true
    });

    $.when(fetchGeoJson(), fetchSlopes(), fetchLifts())
        .done((geoJsonResponse, slopeResponse, liftResponse) => {
            // Extract responses
            const geoJson = geoJsonResponse[0]; // GeoJSON from MapTiler
            const slopeData = slopeResponse[0]; // Additional data from server
            const liftData = liftResponse[0]; // Additional data from server
            processData(geoJson, slopeData, liftData);


            map.on('load', () => {
                map.addSource('map-data', {
                    type: 'geojson',
                    data: geoJson
                });
                map.addSource('terrain-data', {
                    type: 'raster-dem',
                    url: `https://api.maptiler.com/tiles/terrain-rgb-v2/tiles.json?key=${mapKey}`
                });
                map.setTerrain({ 'source': 'terrain-data' });
                // Add a line layer for slopes and lifts
                map.addLayer({
                    'id': 'features',
                    'type': 'line',
                    'source': 'map-data',
                    'paint': {
                        'line-color': ['get', 'Color'],
                        'line-width': 4,
                    },
                });

                // Add a symbol layer for feature names
                map.addLayer({
                    'id': 'labels',
                    'type': 'symbol',
                    'source': 'map-data',
                    'layout': {
                        'text-field': ['get', 'Name'], // Display the "Name" property
                        'symbol-placement': 'line',           // Align the text along the line
                        'text-size': 16,                      // Text size
                        'text-rotation-alignment': 'map',     // Align text with the map direction
                        'text-keep-upright': true,            // Keep text upright, even if the line rotates
                        'text-offset': [0, 0],                // Position the text directly on the line
                    },
                    'paint': {
                        'text-color': '#000000',        // Black text color
                        'text-halo-color': '#FFFFFF',   // White halo around text
                        'text-halo-width': 2           // Halo width
                    }
                });

                //Hover effect layer:
                map.addLayer({
                    'id': 'features-hover',
                    'type': 'line',
                    'source': 'map-data',
                    'paint': {
                        'line-color': '#FFFF00',
                        'line-opacity': [
                            'case',
                            ['boolean', ['feature-state', 'hover'], false],
                            1,
                            0
                        ],
                        'line-width': 6,
                    }
                });
                displayPopupOnClick(map);

            });
        })
        .fail((error) => {
            console.error("Unexpected error occurred");
        });


});

function fetchGeoJson() {
    return $.ajax({
        method: 'GET',
        url: `https://api.maptiler.com/data/${geojsonId}/features.json?key=${mapKey}`,
        dataType: 'json',
        error: function (xhr, status, error) {
            console.error('Failed to fetch GeoJSON:');
        }
    });
}
function fetchSlopes() {
    return $.ajax({
        method: 'GET',
        url: 'https://localhost:7103/Slopes',
        dataType: 'json',
        error: function (xhr, status, error) {
            console.error('Failed to fetch data:');
        }
    })

}
function fetchLifts() {
    return $.ajax({
        method: 'GET',
        url: 'https://localhost:7103/Lifts',
        dataType: 'json',
        error: function (xhr, status, error) {
            console.error('Failed to fetch data:');
        }
    })

}
function processData(geoJson, slopesData, liftData) {
    geoJson.features = geoJson.features.map((feature) => {
        const type = feature.properties.Type;
        const name = feature.properties.Name;

        if (type.toLowerCase() === 'slope') {
            const slope = slopesData.find(s => s.name.toLowerCase() === name.toLowerCase())
            const slopeDifficulty = slope.difficulty;
            feature.properties.Color = slopeColorMap[slopeDifficulty];

        } else if (type.toLowerCase() === 'lift') {
            feature.properties.Color = liftColor;
        }

        return feature;
    });
}
function displayPopupOnClick(map) {
    map.on('click', 'features', (e) => {
        new maplibregl.Popup()
            .setLngLat(e.lngLat)
            .setHTML('<h1>Pesho e pedal</h1>')
            .addTo(map);
    });

    // Change the cursor to a pointer when the mouse is over the places layer.
    map.on('mouseenter', 'features', () => {
        map.getCanvas().style.cursor = 'pointer';
    });

    // Change it back to a pointer when it leaves.
    map.on('mouseleave', 'features', () => {
        map.getCanvas().style.cursor = '';
    });
}