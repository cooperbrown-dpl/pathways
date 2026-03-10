🏠 Angular First App - Housing Locations (Lesson 14)
This project consists of an Angular Frontend and a JSON-Server Backend. Both must be running simultaneously for the app to display data.

🛠 Prerequisites
Ensure you have the JSON server installed globally:

Bash
npm install -g json-server
🚀 Getting Started
To run this app, you need to open two separate terminal tabs.

1. Start the Data Server (JSON Backend)
This server acts as your API and serves the data from the db.json file.

Command:

Bash
json-server --watch db.json
Endpoint: http://localhost:3000/locations

File: db.json (root directory)

2. Start the Angular App (Frontend)
This launches the actual user interface.

Command:

Bash
ng serve
URL: http://localhost:4200

📝 Quick Reminders
Port Conflict: If terminal 1 says port 3000 is in use, make sure you don't have another instance of json-server running.

Async Data: Because this version uses fetch (HTTP), the app will show a blank screen or errors if the JSON server is not running when the page loads.

Images: The photos in db.json are hosted on Angular's assets server; you must have an active internet connection for them to load.

📂 Project Structure
db.json: Your "database." Edit this to add or change housing locations.

src/app/housing.service.ts: Contains the url pointing to localhost:3000.

src/app/home/home.component.ts: Calls the service to fetch the locations on initialization.