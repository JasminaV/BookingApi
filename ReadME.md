#How to start the project
git clone
cd project directory where was cloned
execute dotnet run
server localhost:7100 shoud be up
open the browser 
https://localhost:7100/api/Resource to test the get point in the browser 
or use swagger to execute end point on https://localhost:7100/swagger

for POST against the api end point please use the following example body
with the folloging date time format.
{
  "dateFrom": "2022-03-26",
  "dateTo": "2022-03-26",
  "bookedQuantity": 2,
  "resourceId": 1
}

