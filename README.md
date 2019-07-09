# Install & Set Up MySQL DB
## Install MySql Community Server (DB server) & MySql Workbench (DB manager) 
[Download MySql Community Server](https://dev.mysql.com/downloads/
)
[Download MySql Workbench](https://dev.mysql.com/downloads/workbench/
)

## Create Database & Schema
Go to **Schemas** tab and right click to go to **Create Schema**.
![image](https://github.dev.xero.com/storage/user/1534/files/d131b368-57f8-11e9-9965-9f4afc240e74)

Name the Schema as **RCCRMDB**.
![image](https://github.dev.xero.com/storage/user/1534/files/4cbb947c-57f9-11e9-9a0d-dc3d9b2f1c6a)

Create a table from tables, name it **rccontact**, and create the columns like so:
![image](https://github.dev.xero.com/storage/user/1534/files/8153d276-57f9-11e9-8b34-021e4d048453)

## Create DB User
Connect to the local instance on port 3306 as root. Use your MySQL root password that you set up on the installation wizard. 
![image](https://github.dev.xero.com/storage/user/1534/files/63b68714-57f8-11e9-90f7-a25360c8ba8a)

Go to **Administration** tab, and **User and Privileges**.
![image](https://github.dev.xero.com/storage/user/1534/files/851d8bc8-57f8-11e9-8fe8-59b097859b94)

Add account with the following info:
![image](https://github.dev.xero.com/storage/user/1534/files/a2fad93e-57f8-11e9-82d1-cc8fff5cbd4f)

Let's make the passwords: **_ReallyChill!_**

Got to **Schema Privileges** tab, and click on **Add Entry** button (you might need to make the window wider to see this button), give the user all privileges to rccrmdb schema. 
![image](https://github.dev.xero.com/storage/user/1534/files/1e6d14c4-57f9-11e9-94d2-cd7170336907)

You can test the table is there by running a sql query, you should see a blank result:
![image](https://github.dev.xero.com/storage/user/1534/files/d302b5d2-57fa-11e9-8249-7a7e54baf400)


# Install & Start the Vue.js App
## Install Node & NPM
https://www.npmjs.com/get-npm
check if you have installed them correctly:
mine are:
```
$ npm --version
6.4.1
$ node --version
v8.11.4
```
## Install the project dependencies 
Navigate to the root folder:
`$ npm install
`
## Run the vue.js app
Run the app in development mode, this will allow your code to be rebuild when npm detects a change in the file:
`$ npm run dev
`
You should see the following on your terminal:
```
DONE  Compiled successfully in 8097ms   
         
> Listening at http://localhost:8080
```
You should see the app running on browser at http://localhost:8080, like so:
![image](https://github.dev.xero.com/storage/user/1534/files/814fa3d4-57fb-11e9-9cf6-0742937364a1)

# Install & Start the ASP.NET Core App
## Install .NET SDK (dotnet)
[Download .NET Core SDK](https://dotnet.microsoft.com/download)

Verify it is working by checking version from terminal:
```
$ dotnet --version
2.2.104
```

## Change the consumer keys and token in appsetting.json
Navigate to AspNetCore/ReallyChillCRMApi then open appsetting.json, replace the ConsumerKey and Consumer Secret with your own public app's keys from the developer.xero.com.
![image](https://github.dev.xero.com/storage/user/1534/files/9119cafc-57fa-11e9-8658-aacd2af8d7b3)

## Run the app
It's very simple, Navigate to AspNetCore/ReallyChillCRMApi/, then 
`$ dotnet run
`

to test if the app is running, go to [https://localhost:5001/contact]( https://localhost:5001/contact) this should give you a blank array as there is no contact in our database yet. 

## change the 

## Testing with Post Man
You can also test the application with postman on the following endpoints:

domain:
http://localhost:5000, or 
https://localhost:5001

for contacts: 
GET api/contact
GET api/contact/{id}
POST api/contact
DELETE api/contact/{id}

for Xero authentication
GET /api/auth/ <- when used in browser, user will be redirected for authentication
GET /api/auth/check <- used to check if we are still connected with Xero
GET /api/auth/disconnect <- used to destroy access token from Really Chill CRM


