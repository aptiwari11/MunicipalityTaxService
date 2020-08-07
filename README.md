# MunicipalityTaxService
 .net Core Web App to solve the problem of Municipality Tax selection based on thier Schedule.

 Cretate a DB: "MunicipalityTaxRecord" and run the SQL script in DataMigration folder(MunicipalityTaxTable.sql)

 To call the gettaxrate service, Use the below URL after running the application:
 http://localhost:2797/GetTaxRate?MunicipalityName=Copenhagen&ScheduleStart=2016.01.01


# Impovements to make:
    - Use of In-memory DB , No need to create DB and table seperatly.
    - Add service/another end point to import data with .csv file. 
    - Adding Await task to handle multiple requests with API end point.