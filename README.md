Web API project **Students Assignment** based on AdventureWorksLT2019 database. There is some changes from original DB so the Db is in *ClientSide.WebAPI/DatabaseBackup/AdventureWorksLT2019.bak** folder. When load project for the first time it automatically creates database in SQL if not exists.
If you want to consume API, first step is to get one Email from bottom emails and make registration. After that you must **Login** and take your **Bearer** token to login.
**The API is deployed on students.vtuwork.com also.**

The progect is optimizing regularly
# API routings: 
All routes returns JSON formatted data
Register address
at: "/api/auth/register" you must send **POST** request with one of emails below (if you want to use Products API you must select one email from **Emails** . You must set { **Password, ConfirmPassword**} and send data as **JSON**. After status code **200** go to "/api/auth/login" with your email and password to get **bearer token**. Each route demands token authentication. 

**Example**
```
-"/api/auth/register"-
{
    "email":"ken0@adventure-works.com",
	"name":"George Orwell",
    "password":"12345",
    "confirmpassword":"12345"
}

-"/api/auth/login"-
{
    "email":"ken0@adventure-works.com",
    "password":"12345",
    
}
```

## In progress...

<b>Emails customer</b>:
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
**Categories** <br />
"/api/Categories/all-categories" *-returns all Categories* <br />
"/api/Categories/all-categories-products" *-returns all Products in categories* <br />
"/api/Categories/category-products/{categoryId}" *-returns all products in Category by Category ID* <br />

##
**Customers** <br />
 "/api/Customers/{customerId}" *-returns Customer by ID* <br />
 "/api/Customers/customer-orders/{customerId}" *-returns Customer orders* <br />
 "/api/Customers/customer-order/{customerId}/{orderId}" *-returns data about customer and order* <br />

##
**Orders** <br />
 "/api/Orders/{customerId}/all" *-returns all customer* <br />
 "/api/Orders/order/{orderId}" *-returns Order info* <br />
  "/api/Orders/place-order" *-Add order* <br />

##
**Products** <br />
 "/api/Products/all-products" *-returns all products* <br />
 "/api/Products/product/{poductId}" *returns concrete product* <br />


