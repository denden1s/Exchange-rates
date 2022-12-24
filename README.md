## Screenshots
<p align="center">
      <img src="https://i.ibb.co/q7zJqNB/Screenshot-1.png" width="auto">
</p>
<p align="center">
      <img src="https://i.ibb.co/gDnHZ1m/Screenshot-3.png" width="auto">
</p>
<p align="center">
     <img src="https://i.ibb.co/DRkKNcC/Screenshot-2.png" width="auto">
</p>
<p align="center">
   <img src="https://img.shields.io/badge/Sever-.NET%206.0-blueviolet" alt=" Server .NET version 6">
   <img src="https://img.shields.io/badge/Client-.NET%206.0-yellow" alt="Client .NET version 6">
</p>

## About

This app consist of two parts:
1. Server app. This part take data from NBRB API and save newest data in file. After starting app data from file loaded into cache and save that data in cache while running. Role of this part is API for client app. 
2. Client app. This part take data from server app and build graphic based on this data.
## Documentation

For good app work you need: 
1. Run server app;
2. Set url for server app (only domain name), for example if way to api request is "https://localhost:7190/api/ExchangeRates/concrete/USD&12.12.2022&24.12.2022" than url is "https://localhost:7190". For set url you need open window by using client upper panel;
3. Enter start, end date period and currency type. App have two types of request: first - concrete period, second - period with only start date.

Program have date validation and max early date for taking data is five year. 
Graphic have scaling function, labels when mouse set on column, and setting column.
Graphic header view info about request and if exception will be thrown header will view exception message.
For make second request type you need write only start period.

## Used services

Server app:
- RestSharp (108.0.3);
- Swashbuckle.AspNetCore (6.2.3).

Client app:
- RestSharp (108.0.3)(Page Link);
- Syncfusion.SfChart.WPF (20.4.0.38).
