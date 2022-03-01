This Web API project is part of **Student Assignment** about Web project based on AdventureWorksLT2019 database. <h2> Products have images stored in db as binary data.</h2> <b>This is original data format from MS.</b> <h2>Some requests with huge amount of data are slow, have in mind this.</h2> There is some changes from original DB so the Db is in *ClientSide.WebAPI/DatabaseBackup/AdventureWorksLT2019.bak** folder. Students must create their onw web project which consumes WEB API data.
When load api project for the first time it automatically creates database in SQL if not exists.

If you want to consume API, first step is to select an Email from bottom emails and make registration. After that you must **Login** and take your **Bearer** token to login.
**The API is deployed on students.vtuwork.com .**

The progect is optimizing regularly
# API routings: 
All routes returns JSON formatted data. First step is to register a customer with an email from list <b>Emails</b>. If you want to register as User the email must be different from list.
If you want to register a customer, register address is at: "/api/Auth/register-customer" ("/api/Auth/register-user"-as user (seller) respectively) you must send **POST** request with one of the emails below (if you want to use Products API you must select one email from **Emails** . You must set { **Password, ConfirmPassword**} and send data as **JSON**. After status code **200** go to "/api/Auth/login-customer"-"/api/Auth/login-user" with your email and password to get **bearer token**. If login is successful you will receive status code 200 and bearer jwt. Token expiration time is set of 60 minutes.  

**Example**
```
-"/api/auth/register-customer"-
{
    "email":"ken0@adventure-works.com",
	"name":"Ken Orwell",
    "password":"12345",
    "confirmpassword":"12345"
}

-"/api/auth/login-customer"-
{
    "email":"ken0@adventure-works.com",
    "password":"12345",
    
}
```

## In progress...
<b>Emails</b>:
orlando0@adventure-works.com
keith0@adventure-works.com
donna0@adventure-works.com
janet1@adventure-works.com
lucy0@adventure-works.com
rosmarie0@adventure-works.com
dominic0@adventure-works.com
kathleen0@adventure-works.com
katherine0@adventure-works.com
johnny0@adventure-works.com
christopher1@adventure-works.com
david20@adventure-works.com
john8@adventure-works.com
jean1@adventure-works.com
jinghao1@adventure-works.com
linda4@adventure-works.com
kerim0@adventure-works.com
kevin5@adventure-works.com
donald0@adventure-works.com
jackie0@adventure-works.com
bryan2@adventure-works.com
todd0@adventure-works.com
barbara4@adventure-works.com
jim1@adventure-works.com
betty0@adventure-works.com
sharon2@adventure-works.com
darren0@adventure-works.com
erin1@adventure-works.com
jeremy0@adventure-works.com
elsa0@adventure-works.com
david19@adventure-works.com
hattie0@adventure-works.com
anita0@adventure-works.com
rebecca2@adventure-works.com
eric6@adventure-works.com
brian5@adventure-works.com
judy1@adventure-works.com
peter4@adventure-works.com
douglas2@adventure-works.com
sean4@adventure-works.com
jeffrey3@adventure-works.com
vamsi1@adventure-works.com
jane2@adventure-works.com


##
**Categories** -not requires a Authentication<br />
"/api/Categories/all-categories" *-returns all Categories* <br />
"/api/Categories/all-products-by-category" *-returns all Products in categories. Returns a huge amount of data. Use it once and store data in local Db.* <br />
"/api/Categories/category-products/{categoryId}" *-returns all products in Category by Category ID* <br />

##
**Customers** <br />
 "/api/Customers/{customerId}" *-returns Customer by ID* <br />
 "/api/Customers/customer-orders/{customerId}" *-returns Customer orders* <br />
 "/api/Customers/customer-order/{customerId}/{orderId}" *-returns data about customer and order* <br />

##
**Orders** <br />
 "/api/Orders/{customerId}/all" *-returns all customers* <br />
 "/api/Orders/order/{orderId}" *-returns Order info* <br />
  "/api/Orders/place-order" *-Add order* <br />

  If you place an order the required data format is:
  SalesOrderHeader
```
{
  "orderDate": "0001-01-01T00:00:00",
  "dueDate": "0001-01-01T00:00:00",
  "shipDate": "0001-01-01T00:00:00",
  "status": Order current status. 1 = In process; 2 = Approved; 3 = Backordered; 4 = Rejected; 5 = Shipped; 6 = Cancelled,
  "billToAddressId": 0,
  "shipToAddressId": 0,
  "taxAmt": 0.0,
  "subTotal": 0.0,
  "freight": 0.0,
  "totalDue": 0.0,
  "comment": null,
  "salesOrderDetails":[
		{
			"orderQty": 0,
			"productId": 0,
			"unitPrice": 0.0,
			"unitPriceDiscount": 0.0,
			"lineTotal": 0.0
			
		}
  ]
}
```

<b>This is order example:</b>
```
{
  "status": 1,
  "onlineOrderFlag": 1,
  "taxAmt": 0.0,
  "subTotal": 15.0,
  "freight": 0.0,
  "totalDue": 15.0,
  "comment": null,
  "salesOrderDetails":[
		{
			"orderQty": 1,
			"productId": 836,
			"unitPrice": 15,
			"unitPriceDiscount": 0.0,
			"lineTotal": 15   
			
		}
  ]
}
```

##
**Products** -not requires an Authentication<br />
Product description is available in ("ar" "fr" "th" "he" "zh-cht"), but "ar", "th","he","zh-cht" are deleted from Db because of encoding problems.
 "/api/Products/all-products/{string:culture}" *-returns all products*  **By default you do not need to send culture, by default is "en". Other cultures are: ("ar" "fr" "th" "he" "zh-cht"). Returns a huge amount of data. Use it once and store data in local Db.<br />
 "/api/Products/product/{poductId}/("ar" "fr" "th" "he" "zh-cht") -this is optional" *returns concrete product* <br />
 "/api/Products/product/top-twenty" *returns top 20 selled* <br />
 "/api/Products/product/top-ten/{categoryId}" *returns most selled by category* <br />




