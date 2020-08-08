# MunicipalityTaxService
 .net Core Web App to solve the problem of Municipality Tax selection based on thier Schedule.

If you are not using in-memory DB then please Cretate a DB: "MunicipalityTaxRecord" and run the SQL script in DataMigration folder(MunicipalityTaxTable.sql)

To Create a new record: 
http://localhost:5000/AddMTax

JSON Body Template:
{
    "MunicipalityName": "Copenhagen",
    "Period": "Year",
    "ScheduleStart": "2016-01-01",
    "ScheduleEnd": "2016-12-31",
    "TaxRate": 0.2
}


 To call the gettaxrate service, Use the below URL after running the application:
 http://localhost:5000/GetTaxRate?MunicipalityName=Copenhagen&ScheduleStart=2016.01.01

 Added Swagger endpoint for users to show Entity model and various End points. 
 http://localhost:5000/swagger/index.html


# Impovements to make:
    - Use of In-memory DB , No need to create DB and table seperatly.
    - Add service/another end point to import data with .csv file. 
    - Adding Await task to handle multiple requests with API end point.