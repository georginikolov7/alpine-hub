
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


const popupElement = $('#popupContent');
const popupBody = popupElement.find('#popupBody');
let hoveredStateId = null;


$(function () {
    const map = new maplibregl.Map({
        container: 'map',
        style: `https://api.maptiler.com/maps/${mapId}/style.json?key=${mapKey}`,
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
                    data: geoJson,
                    promoteId: 'id'
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
                        'line-color': ['get', 'color'],
                        'line-width': 6,
                        'line-color':
                            ['get', 'color'],

                    },
                });

                // Add a symbol layer for feature names
                map.addLayer({
                    'id': 'labels',
                    'type': 'symbol',
                    'source': 'map-data',
                    //'layout': {
                    //    'text-field': ['get', 'name'], // Display the "Name" property
                    //    'symbol-placement': 'line',           // Align the text along the line
                    //    'text-size': 16,                      // Text size
                    //    'text-rotation-alignment': 'map',     // Align text with the map direction
                    //    'text-keep-upright': true,            // Keep text upright, even if the line rotates
                    //    'text-offset': [0, 0],                // Position the text directly on the line
                    //},
                    //'paint': {
                    //    'text-color': '#000000',        // Black text color
                    //    'text-halo-color': '#FFFFFF',   // White halo around text
                    //    'text-halo-width': 2           // Halo width
                    layout: {
                        'symbol-placement': 'line-center', // Align text along the line
                        'text-field': ['get', 'name'], // Use the 'name' property for labels
                        'text-font': ['Open Sans Bold', 'Arial Unicode MS Bold'],
                        'text-size': 16,
                        'text-justify': 'center', // Center text on the line
                        'text-offset': [0, 0.5], // Offset text from the line
                    },
                    paint: {
                        'text-color': ['get', 'color'], // Red text for slopes
                        'text-halo-color': '#ffffff', // White halo for better readability
                        'text-halo-width': 1.5
                    }
                });

                map.addLayer({
                    id: 'features-hover',
                    type: 'line',
                    source: 'map-data',
                    layout: {},
                    paint: {
                        'line-color': '#FFFF00', // Invisible layer
                        'line-opacity': [
                            'case',
                            ['boolean', ['feature-state', 'hover'], false],
                            1,
                            0
                        ],
                        'line-width': 10 // Larger width for easier clicks

                    }
                });
                atachHoverEffect(map);
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
        const type = feature.properties.type;
        const name = feature.properties.name;
        if (type.toLowerCase() === 'slope') {
            const slope = slopesData.find(s => s.name.toLowerCase() === name.toLowerCase());
            if (!slope) {
                return feature;
            }
            const slopeDifficulty = slope.difficulty.toLowerCase();
            feature.properties.color = slopeColorMap[slopeDifficulty];
            feature.properties.id = slope.id;
        } else if (type.toLowerCase() === 'lift') {
            feature.properties.color = liftColor;
            const lift = liftData.find(l => l.name.toLowerCase() == name.toLowerCase());
            if (!lift) {
                return feature;
            }
            feature.properties.id = lift.id;

        }
        return feature;
    });
}

function atachHoverEffect(map) {
    // Add a feature state for hover
    // When the user moves their mouse over the state-fill layer, we'll update the
    // feature state for the feature under the mouse.
    map.on('mousemove', 'features-hover', (e) => {
        if (e.features.length > 0) {
            if (hoveredStateId) {
                map.setFeatureState(
                    { source: 'map-data', id: hoveredStateId },
                    { hover: false }
                );
            }
            hoveredStateId = e.features[0].id;
            map.setFeatureState(
                { source: 'map-data', id: hoveredStateId },
                { hover: true }
            );
        }
    });

    // When the mouse leaves the state-fill layer, update the feature state of the
    // previously hovered feature.
    map.on('mouseleave', 'features-hover', () => {
        if (hoveredStateId) {
            map.setFeatureState(
                { source: 'map-data', id: hoveredStateId },
                { hover: false }
            );
        }
        hoveredStateId = null;
    });
}
function displayPopupOnClick(map) {

    map.on('click', 'features-hover', async (e) => {

        const properties = e.features[0].properties;
        const type = properties.type;

        if (type.toLowerCase() == 'slope') {
            await generateSlopePopup(properties);
        } else if (type.toLowerCase() == 'lift') {
            await generateLiftPopup(properties);
        }
        new maplibregl.Popup()
            .setLngLat(e.lngLat)
            .setHTML(popupElement.html())
            .addTo(map);
    });

    // Change the cursor to a pointer when the mouse is over the places layer.
    map.on('mouseenter', 'features-hover', () => {
        map.getCanvas().style.cursor = 'pointer';
    });

    // Change it back to a pointer when it leaves.
    map.on('mouseleave', 'features-hover', () => {
        map.getCanvas().style.cursor = '';
    });
}
async function generateSlopePopup(slopeProperties) {

    popupBody.empty();
    await $.ajax({
        method: 'GET',
        url: `https://localhost:7103/Slopes/${slopeProperties.id}`,
    })
        .done((data) => {
            popupElement.find('#popupTitle').text(`Slope ${slopeProperties.name}`);
            const difficultyPara = $('<p></p>').text(`Difficulty: ${data.difficulty}`);
            const lengthPara = $('<p></p>').text(`Length: ${data.length}m`);
            const conditionPara = $('<p></p>').text(`Condition: ${data.condition}`);
            const topAltPara = $('<p></p>').text(`Top Elevation: ${data.topElevation}`);
            const bottomAltPara = $('<p></p>').text(`Bottom Elevation: ${data.bottomElevation}`);

            const statusPara = $('<p></p>');
            statusPara.text('Status: ')
            const statusSpan = $('<span></span>');
            statusSpan.addClass('badge');
            if (data.isOpen) {
                statusSpan.text('Open');
                statusSpan.addClass('bg-success');
            } else {
                statusSpan.text('Closed');
                statusSpan.addClass('bg-danger');
            }
            statusPara.append(statusSpan);

            popupBody.append(difficultyPara);
            popupBody.append(statusPara);
            popupBody.append(lengthPara);
            popupBody.append(conditionPara);
            popupBody.append(topAltPara);
            popupBody.append(bottomAltPara);
            popupElement.addClass('d-block');
        })
        .fail(data => {

            console.error("Could not fetch data for slope popup");
        });
}

async function generateLiftPopup(liftProperties) {

    popupBody.empty();

    await $.ajax({
        method: 'GET',
        url: `https://localhost:7103/Lifts/${liftProperties.id}`,
    })
        .done((data) => {
            popupElement.find('#popupTitle').text(`Lift ${liftProperties.name}`);

            const typePara = $('<p></p>').text(`Type: ${data.type}`);
            const lengthPara = $('<p></p>').text(`Length: ${data.length} m`);
            const seatsPara = $('<p></p>').text(`Seats: ${data.seatsCount}`);
            const capacityPara = $('<p></p>').text(`Capacity: ${data.capacity}`);
            const timePara = $('<p></p>').text(`Working time: ${data.workingTime}`);

            const statusPara = $('<p></p>');
            statusPara.text('Status: ')
            const statusSpan = $('<span></span>');
            statusSpan.addClass('badge');
            if (data.isOpen) {
                statusSpan.text('Open');
                statusSpan.addClass('bg-success');
            } else {
                statusSpan.text('Closed');
                statusSpan.addClass('bg-danger');
            }
            statusPara.append(statusSpan);

            popupBody.append(typePara);
            popupBody.append(seatsPara);
            popupBody.append(statusPara);
            popupBody.append(lengthPara);
            popupBody.append(capacityPara);
            popupBody.append(timePara);

            popupElement.addClass('d-block');
        })
        .fail(data => {

            console.error("Could not fetch data for lift popup");
        })


}