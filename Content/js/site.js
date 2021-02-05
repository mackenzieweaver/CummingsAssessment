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
    // Capitalize input
    let city = PROVIDING_AGENCY_CITY.value[0].toUpperCase() + PROVIDING_AGENCY_CITY.value.slice(1).toLowerCase();
    PROVIDING_AGENCY_CITY.value = city;

    let states = [];
    let options = await getData("city", city);
    options.forEach(option => states.push(option.state));

    // put options in dropdown
    populateDropdown(states, PROVIDING_AGENCY_STATE, PROVIDING_AGENCY_STATE_DROPDOWN);
});

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
}
