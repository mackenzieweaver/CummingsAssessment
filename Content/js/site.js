// city
const PROVIDING_AGENCY_CITY = document.getElementById('ProvidingAgency_City');
const PROVIDING_AGENCY_CITY_DROPDOWN = document.getElementById('providingAgencyCityDropdown');
// state
const PROVIDING_AGENCY_STATE = document.getElementById('ProvidingAgency_State');
const PROVIDING_AGENCY_STATE_DROPDOWN = document.getElementById('providingAgencyStateDropdown');
// county
const PROVIDING_AGENCY_COUNTY = document.getElementById('ProvidingAgency_County');
const PROVIDING_AGENCY_COUNTY_DROPDOWN = document.getElementById('providingAgencyCountyDropdown');

// when user has input the city
PROVIDING_AGENCY_CITY.addEventListener('blur', async function () {
    let city = normalizeInput(this.value);
    this.value = city;

    let states = [];
    let options = await getData("city", city);
    options.forEach(option => states.push(option.state));

    // put options in dropdown
    populateDropdown(states, PROVIDING_AGENCY_STATE, PROVIDING_AGENCY_STATE_DROPDOWN);
});

function normalizeInput(str) {
    // Capitalize first letter, lower case the rest
    // handle multiple words

    str = str.split(' ');
    for (let i = 0; i < str.length; i++) {
        str[i] = str[i][0].toUpperCase() + str[i].slice(1).toLowerCase();
    }
    str = str.join(' ');
    return str;
}

// returns data that have a given type; either: city or state
async function getData(type, search) {
    // search "db" ~ 6000 cities in various states
    return await fetch('https://gist.githubusercontent.com/mackenzieweaver/c848adf78ebac73a38ffa38f1d65370e/raw/70544e6dac9fbf435d0fae68e44fdd6f0c26b940/gistfile1.txt')
        .then(res => res.json())
        .then(d => {
            return d.filter(objs => objs[type] == search);
        });
}

function populateDropdown(data, box, dropdown) {
    dropdown.innerHTML = '';
    let html = '';
    data.forEach(val => {
        html += `<button type="button" class="a dropdown-item" onclick="populateBox( '${box.id}', '${val}' )" style="cursor: pointer;">${val}</button>`;
    });
    dropdown.innerHTML = html;
}

function populateBox(id, val) {
    let element = document.getElementById(id);
    element.value = val;

    // value changed so let dom know of event
    var event = new Event('change');
    element.dispatchEvent(event);
}

/* ========================================================================================== */

PROVIDING_AGENCY_STATE.addEventListener('change', async function () {
    let state = normalizeInput(this.value);
    this.value = state;
    let cities = [];
    let options = await getData("state", state);
    options.forEach(option => cities.push(option.city));

    // put options in dropdown
    populateDropdown(cities, PROVIDING_AGENCY_CITY, PROVIDING_AGENCY_CITY_DROPDOWN);
});