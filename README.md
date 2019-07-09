# Install & Set Up MySQL DB
## Install MySql Community Server (DB server) & MySql Workbench (DB manager) 
[Download MySql Community Server](https://dev.mysql.com/downloads/
)
[Download MySql Workbench](https://dev.mysql.com/downloads/workbench/
)

## Create Database & Schema
Go to **Schemas** tab and right click to go to **Create Schema**.

![d131b368-57f8-11e9-9965-9f4afc240e74](https://user-images.githubusercontent.com/41350731/60854116-69517c80-a242-11e9-8974-69f8c68481b9.png)

Name the Schema as **RCCRMDB**.

![4cbb947c-57f9-11e9-9a0d-dc3d9b2f1c6a](https://user-images.githubusercontent.com/41350731/60854126-753d3e80-a242-11e9-95f9-c03c966a459f.png)

Create a table from tables, name it **rccontact**, and create the columns like so:

![8153d276-57f9-11e9-8b34-021e4d048453](https://user-images.githubusercontent.com/41350731/60854132-79695c00-a242-11e9-8dd4-9fcd5de7b695.png)

## Create DB User
Connect to the local instance on port 3306 as root. Use your MySQL root password that you set up on the installation wizard. 

![63b68714-57f8-11e9-90f7-a25360c8ba8a](https://user-images.githubusercontent.com/41350731/60854140-7f5f3d00-a242-11e9-9373-faa99bc0eaf2.png)

Go to **Administration** tab, and **User and Privileges**.

![851d8bc8-57f8-11e9-8fe8-59b097859b94](https://user-images.githubusercontent.com/41350731/60854146-838b5a80-a242-11e9-9398-5c199983000d.png)

Add account with the following info:

![a2fad93e-57f8-11e9-82d1-cc8fff5cbd4f](https://user-images.githubusercontent.com/41350731/60854154-88e8a500-a242-11e9-8b18-1da7b4f2049c.png)

Let's make the passwords: **_ReallyChill!_**

Got to **Schema Privileges** tab, and click on **Add Entry** button (you might need to make the window wider to see this button), give the user all privileges to rccrmdb schema. 

![1e6d14c4-57f9-11e9-94d2-cd7170336907](https://user-images.githubusercontent.com/41350731/60854165-94d46700-a242-11e9-9fc6-fee4f345eb97.png)

You can test the table is there by running a sql query, you should see a blank result:

![d302b5d2-57fa-11e9-8249-7a7e54baf400](https://user-images.githubusercontent.com/41350731/60854178-9aca4800-a242-11e9-893c-c334344b7225.png)


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

![814fa3d4-57fb-11e9-9cf6-0742937364a1](https://user-images.githubusercontent.com/41350731/60854196-a289ec80-a242-11e9-973c-c52d7cc2fd17.png)

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

![9119cafc-57fa-11e9-8658-aacd2af8d7b3](https://user-images.githubusercontent.com/41350731/60854316-2512ac00-a243-11e9-8e88-d5a8eca17ee5.png)

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


