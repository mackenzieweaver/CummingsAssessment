// city
const PROVIDING_AGENCY_CITY = document.getElementById('ProvidingAgency_City');
const PROVIDING_AGENCY_CITY_DROPDOWN = document.getElementById('providingAgencyCityDropdown');
// state
const PROVIDING_AGENCY_STATE = document.getElementById('ProvidingAgency_State');
const PROVIDING_AGENCY_STATE_DROPDOWN = document.getElementById('providingAgencyStateDropdown');
// county
const PROVIDING_AGENCY_COUNTY = document.getElementById('ProvidingAgency_County');
const PROVIDING_AGENCY_COUNTY_DROPDOWN = document.getElementById('providingAgencyCountyDropdown');

//initially disable state and county inputs
$(function () {
    PROVIDING_AGENCY_STATE.disabled = true;
    PROVIDING_AGENCY_COUNTY.disabled = true;
});

PROVIDING_AGENCY_CITY.addEventListener('change', async function () {
    let city = normalizeInput(this.value);
    this.value = city;

    let states = [];
    let options = await getData("city", city);
    options.forEach(option => states.push(option.state));
    // put options in state dropdown
    populateDropdown(states, PROVIDING_AGENCY_STATE, PROVIDING_AGENCY_STATE_DROPDOWN);

    // if no state yet, fill cities dropdown with all possible cities regardless of state
    if (!PROVIDING_AGENCY_STATE.value) {
        let cities = [];
        let options = await getData("city", PROVIDING_AGENCY_CITY.value);
        options.forEach(option => cities.push(option.city));
        cities = cities.filter(c => c.includes(PROVIDING_AGENCY_CITY.value));
        populateDropdown(cities, PROVIDING_AGENCY_CITY, PROVIDING_AGENCY_CITY_DROPDOWN);
    }
});

PROVIDING_AGENCY_STATE.addEventListener('change', async function () {
    let state = normalizeInput(this.value);
    this.value = state;
    let cities = [];
    let options = await getData("state", state);
    options.forEach(option => cities.push(option.city));

    // only give options that meet whats in the city box already
    cities = cities.filter(c => c.includes(PROVIDING_AGENCY_CITY.value));

    // put options in city dropdown
    populateDropdown(cities, PROVIDING_AGENCY_CITY, PROVIDING_AGENCY_CITY_DROPDOWN);

    /*===============================================================================================*/
    // COUNTIES uses seperate api endpoint
    (async () => {
        const where = encodeURIComponent(JSON.stringify({ "state": state }));
        const response = await fetch(`https://parseapi.back4app.com/classes/Uscounties_Area?count=1&limit=1000&order=countyName&keys=countyName&where=${where}`, {
            headers: {
                'X-Parse-Application-Id': 'kPKisfUbHPMcZmQreFDTZlpwt0449vmvDr9CmcHy', // This is your app's application id
                'X-Parse-REST-API-Key': 'HHiODsZUVi2ZWNiMSlrSeQEf6cMx2202b6PjK4Mn', // This is your app's REST API key
            }
        });
        let data = await response.json().then(d => { return d });
        let counties = [];
        data.results.forEach(x => counties.push(x.countyName));

        populateDropdown(counties, PROVIDING_AGENCY_COUNTY, PROVIDING_AGENCY_COUNTY_DROPDOWN);
    })();
});

/* ========================================================================================== */

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

async function getData(type, search) {
    // search "db" ~ 6000 cities in various states
    return await fetch('https://gist.githubusercontent.com/mackenzieweaver/c848adf78ebac73a38ffa38f1d65370e/raw/70544e6dac9fbf435d0fae68e44fdd6f0c26b940/gistfile1.txt')
        .then(res => res.json())
        .then(d => {
            return d.filter(objs => objs[type].includes(search));
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
