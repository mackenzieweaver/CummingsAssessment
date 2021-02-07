# CummingsAssessment

## To Run
Click the green 'Code' button in the top right to download. Open with visual studio and click run or press F5 to run locally.
 
 ## The website
![Cummings Assessment website](https://i.imgur.com/KXH0tPL.jpg)

## The database design
![MS SQL server Database design](https://i.imgur.com/9zzeMDO.jpg)

## Backend
Each section has a header, icon, and data associated with it, so that’s how I designed my data models. There is a model for the Providing Agency, Jail, Bond Transfer, Requesting Agency, Defendant, and Indemnitor. In order to make one form submit all this information I used a view model to hold each of these model’s information plus the additional information field.

## City / State / County Frontend
I knew I would need some external database to access city, state, and county information. After a lot of searching I found a JSON file of all cities and states to a reasonable degree and an API to find counties per city & state. To start, the state and county boxes are disabled. When a user types in the city box its dropdown populates with all cities that contain the text in the box. At the same time, the state dropdown has been filled with all states that include the cities in the city dropdown. Once a city and state have been properly selected then the county dropdown will have options*.

## User Interface 
I took screenshots of the icons and searched those pictures on google until I found the exact one. Then I used a service to convert images to svgs which are used in the website. To get the correct font I used another service to look at a picture and return the font name. In order to get the exact colors I loaded the pdf into Gimp and used the eyedropper to get the exact hex color value. For responsiveness, I used bootstrap 4 and their built-in breakpoints as well as various media queries for the icons to be removed on small screens.
