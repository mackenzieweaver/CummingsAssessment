﻿// city
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

    /*====================================*/

    // COUNTIES uses seperate api endpoint
    await setCounties(PROVIDING_AGENCY_CITY.value, PROVIDING_AGENCY_STATE.value, PROVIDING_AGENCY_COUNTY, PROVIDING_AGENCY_COUNTY_DROPDOWN);
});

/* ========================================================================================== */

async function setCounties(city, state, box, dropdown) {
    city = strToCounty(city);
    state = strToCounty(state);

    let data = await fetch(`https://us-zipcode.api.smartystreets.com/lookup?key=45532187673878532&city=${city}&state=${state}`).then(res => res.json());
    let zipcodes = data[0].zipcodes;
    let counties = [];
    for (let i = 0; i < zipcodes.length; i++) {
        counties.push(zipcodes[i].county_name);
    }
    counties = [...new Set(counties)];
    populateDropdown(counties, box, dropdown);
}

function strToCounty(str) {
    return str.toLowerCase().split(' ').join('%20');
}

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
