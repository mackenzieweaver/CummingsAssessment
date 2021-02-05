const PROVIDING_AGENCY_CITY = document.getElementById('ProvidingAgency_City');
const PROVIDING_AGENCY_CITY_DROPDOWN = document.getElementById('providingAgencyCityDropdown');
const PROVIDING_AGENCY_STATE = document.getElementById('ProvidingAgency_State');
const PROVIDING_AGENCY_STATE_DROPDOWN = document.getElementById('providingAgencyStateDropdown');
const PROVIDING_AGENCY_COUNTY = document.getElementById('ProvidingAgency_County');
const PROVIDING_AGENCY_COUNTY_DROPDOWN = document.getElementById('providingAgencyCountyDropdown');

const JAIL_CITY = document.getElementById('Jail_City');
const JAIL_STATE = document.getElementById('Jail_State');
const JAIL_COUNTY = document.getElementById('Jail_County');

const REQUESTING_AGENCY_CITY = document.getElementById('RequestingAgency_City');
const REQUESTING_AGENCY_STATE = document.getElementById('RequestingAgency_State');
const REQUESTING_AGENCY_COUNTY = document.getElementById('RequestingAgency_County');

async function getStates(search) {
    // search "db"
    return await fetch('https://gist.githubusercontent.com/mackenzieweaver/c848adf78ebac73a38ffa38f1d65370e/raw/70544e6dac9fbf435d0fae68e44fdd6f0c26b940/gistfile1.txt')
        .then(res => res.json())
        .then(d => {
            return d.filter(objs => objs.city == search);
        });
}

PROVIDING_AGENCY_CITY.addEventListener('blur', async function () {
    // Capitalize input
    let search = PROVIDING_AGENCY_CITY.value[0].toUpperCase() + PROVIDING_AGENCY_CITY.value.slice(1).toLowerCase();
    PROVIDING_AGENCY_CITY.value = search;

    let states = [];
    let options = await getStates(search);
    options.forEach(option => states.push(option.state));
    populateProvidingAgencyStateOptions(states);
});



function populateProvidingAgencyStateOptions(states) {
    PROVIDING_AGENCY_STATE_DROPDOWN.innerHTML = '';
    let html = '';
    states.forEach(s => {
        html += `<button class="a dropdown-item" onclick="populateState(event, '${s}')">${s}</button>`;
    });
    PROVIDING_AGENCY_STATE_DROPDOWN.innerHTML = html;
}

function populateState(event, state) {
    event.preventDefault();
    PROVIDING_AGENCY_STATE.value = state;
}
