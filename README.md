Web API project **Students Assignment** based on AdwentureWorks2019 database.
If you want to consume API, first step is to get one Email from bottom emails and make registration. All emails (*employees, salespersons**) works in the company. Customer emails could be an employee or just client. After that you must **Login** and take your **Bearer** token to login.
# API routings:
## register address 
at: "/api/auth/register" you must send **POST** request with one of emails below (if you want to use Products API you must select one email from **EMployees** else if you want to make orders select one from **Salespersons**). You must set { **Password, ConfirmPassword, Name(your name)**} and send data as **JSON**. After status code **200** go to "/api/auth/login" with your email and password to get **bearer token**. Each route demands token authentication. **Remember! If you want to register an Customer you must select one from section Customers**.  
## In progress...

<b>Emails Employees</b>:
ken0@adventure-works.com
terri0@adventure-works.com
roberto0@adventure-works.com
rob0@adventure-works.com
gail0@adventure-works.com
jossef0@adventure-works.com
dylan0@adventure-works.com
diane1@adventure-works.com
gigi0@adventure-works.com
michael6@adventure-works.com
ovidiu0@adventure-works.com
thierry0@adventure-works.com
janice0@adventure-works.com
michael8@adventure-works.com
sharon0@adventure-works.com
david0@adventure-works.com
kevin0@adventure-works.com
john5@adventure-works.com
mary2@adventure-works.com
wanida0@adventure-works.com
terry0@adventure-works.com
sariya0@adventure-works.com
mary0@adventure-works.com
jill0@adventure-works.com
james1@adventure-works.com
peter0@adventure-works.com
jo0@adventure-works.com
guy1@adventure-works.com
mark1@adventure-works.com
britta0@adventure-works.com
margie0@adventure-works.com
rebecca0@adventure-works.com
annik0@adventure-works.com
suchitra0@adventure-works.com
brandon0@adventure-works.com
jose0@adventure-works.com
chris2@adventure-works.com
kim1@adventure-works.com
ed0@adventure-works.com
jolynn0@adventure-works.com
bryan0@adventure-works.com
james0@adventure-works.com
nancy0@adventure-works.com
simon0@adventure-works.com
thomas0@adventure-works.com
eugene1@adventure-works.com
andrew0@adventure-works.com
ruth0@adventure-works.com
barry0@adventure-works.com
sidney0@adventure-works.com

<b>Emails Salespersons</b>:
stephen0@adventure-works.com
michael9@adventure-works.com
linda3@adventure-works.com
jillian0@adventure-works.com
garrett1@adventure-works.com
tsvi0@adventure-works.com
pamela0@adventure-works.com
shu0@adventure-works.com
josé1@adventure-works.com
david8@adventure-works.com
tete0@adventure-works.com
syed0@adventure-works.com
lynn0@adventure-works.com
amy0@adventure-works.com
rachel0@adventure-works.com
jae0@adventure-works.com
ranjit0@adventure-works.com

<b>Customers</b>
david22@adventure-works.com
rebecca3@adventure-works.com
dorothy3@adventure-works.com
kristina10@adventure-works.com
kristina11@adventure-works.com
kristina12@adventure-works.com
rachel36@adventure-works.com
kristina13@adventure-works.com
kristina14@adventure-works.com
kristina15@adventure-works.com
kristina16@adventure-works.com
kristina17@adventure-works.com
rachel37@adventure-works.com
rachel38@adventure-works.com
kristina18@adventure-works.com
rachel39@adventure-works.com
rachel40@adventure-works.com
kristina19@adventure-works.com
rachel41@adventure-works.com
kristina20@adventure-works.com
cynthia4@adventure-works.com
rachel42@adventure-works.com
cynthia5@adventure-works.com
cynthia6@adventure-works.com
rachel43@adventure-works.com
cynthia7@adventure-works.com
cynthia8@adventure-works.com
cynthia9@adventure-works.com
rachel44@adventure-works.com
cynthia10@adventure-works.com
rachel45@adventure-works.com
byron8@adventure-works.com
cynthia11@adventure-works.com
cynthia12@adventure-works.com
rachel46@adventure-works.com
cynthia13@adventure-works.com
cynthia14@adventure-works.com
rachel47@adventure-works.com
cynthia15@adventure-works.com
rachel48@adventure-works.com
cynthia16@adventure-works.com
cynthia17@adventure-works.com
rachel49@adventure-works.com
cynthia18@adventure-works.com
rachel50@adventure-works.com
cynthia19@adventure-works.com
rachel51@adventure-works.com
cynthia20@adventure-works.com
byron9@adventure-works.com
cynthia21@adventure-works.com
cynthia22@adventure-works.com
rachel52@adventure-works.com
cynthia23@adventure-works.com
rachel53@adventure-works.com

*Add new product schema:*
```{
  "productId": 0,
  "name": null,
  "productNumber": null,
  "makeFlag": false,
  "finishedGoodsFlag": false,
  "color": null,
  "safetyStockLevel": 0,
  "reorderPoint": 0,
  "standardCost": 0.0,
  "listPrice": 0.0,
  "size": null,
  "sizeUnitMeasureCode": null,
  "weightUnitMeasureCode": null,
  "weight": 0.0,
  "daysToManufacture": 0,
  "productLine": null,
  "class": null,
  "style": null,
  "productSubcategoryId": 0,
  "productModelId": null,
  "sellStartDate": "0001-01-01T00:00:00",
  "sellEndDate": "0001-01-01T00:00:00",
  "discontinuedDate": "0001-01-01T00:00:00",
  
}


**ProductModel**
/api/productmodels/all_models **GET**
{
  "productModelId": 0,
  "name": null,
  "catalogDescription": null,
  "instructions": null
}

**ProductCategory**
returns category and subcategory
/api/categories/all_categories **GET**
{
  "productCategoryId": 0,
  "name": null,
  "subCategories":[
	  "ProductSubcategory":{
							  "productSubcategoryId": 0,
							  "productCategoryId": 0,
							  "name": null,
							  "productCategory": null
							}
  ]
}

```
#Order and it's relations#
![This is an image](https://user-images.githubusercontent.com/15988325/147693165-528905e8-fcb5-47b2-a651-7bb9d671eac6.png)
```

#Orders#
If you create order next schemas are required. Basic order is **SalesOrderHeader**
The API address is : api/orders/customers/place_order **POST** request . All other required data for this request can be reached at next url's:

**

SalesOrderHeader
{
  "salesOrderId": 0,
  "orderDate": "0001-01-01T00:00:00",
  "dueDate": "0001-01-01T00:00:00",
  "shipDate": "0001-01-01T00:00:00",
  "customerId": 0,
  "territoryId": 0,
  "billToAddressId": 0,
  "shipToAddressId": 0,
  "shipMethodId": 0,
  "subTotal": 0.0,
  "taxAmt": 0.0,
  "freight": 0.0,
  "totalDue": 0.0,
  "comment": null
}
**Customer**
/api/customers/{customerId} **GET**
{
  "customerId": 0,
  "personId": 0,
  "storeId": 0,
  "territoryId": 0,
  "accountNumber": null,
  "salesTerritory": {
					  "territoryId": 0,
					  "name": null,
					  "countryRegionCode": null,
					  "countryRegionCodeNavigation": null
					}
}
**Countries**
/api/regions/all_countries **GET**
{
  "countryRegionCode": null,
  "name": null
}

**CountryRegions**
/api/regions/country_regions/{countryCode} **GET** -countryCode is -countryRegionCode-
{
  "stateProvinceId": 0,
  "stateProvinceCode": null,
  "countryRegionCode": null,
  "name": null,
  "territoryId": 0
}

**Addresses**
/api/regions/addresses/{provinceId}  **GET** -provinceId is -stateProvinceId-
{
  "addressId": 0,
  "addressLine1": null,
  "addressLine2": null,
  "city": null,
  "stateProvinceId": 0,
  "postalCode": null
}

**Territory**
/api/territories/all_territories **GET**

{
  "territoryId": 0,
  "name": null,
  "countryRegionCode": null,
  "group": null,
  "countryRegionCodeNavigation": null
}

