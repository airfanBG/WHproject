Web API project based on AdwentureWorks2019 database.
If you want to consume API, first step is to get one Email from bottom emails and make registration. All emails are **employes** in company. After that you must **Login** and take your **Bearer** token to login.
# API routings:
## register address 
at: "/api/auth/register" you must send **POST** request with one of emails below (if you want to use Products API you must select one email from **EMployees** else if you want to make orders select one from **Salespersons**). You must set { **Password, ConfirmPassword, Name(your name)**} and send data as **JSON**. After status code **200** go to "/api/auth/login" with your email and password to get **bearer token**. Each route demands token authentication.
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
  "productModel": null,
  "productSubcategory": null
}
##ProductModel##
{
  "productModelId": 0,
  "name": null,
  "catalogDescription": null,
  "instructions": null
}
##ProductCategory##
{
  "productCategoryId": 0,
  "name": null
}
##ProductSubCategory##
{
  "productSubcategoryId": 0,
  "productCategoryId": 0,
  "name": null,
  "productCategory": null
}

**NOTE:** Product Subcategory it is optional
ProductSubcategoryID|	ProductCategoryID|	Name
            1       1	Mountain Bikes
            2       1	Road Bikes
            3       1	Touring Bikes
            4       2	Handlebars
            5       2	Bottom Brackets
            6       2	Brakes
            7       2	Chains
            8       2	Cranksets
            9       2	Derailleurs
            10      2	Forks
            11      2	Headsets
            12      2	Mountain Frames
            13      2	Pedals
            14      2	Road Frames
            15      2	Saddles
            16      2	Touring Frames
            17      2	Wheels
            18      3	Bib-Shorts
            19      3	Caps
            20      3	Gloves
            21      3	Jerseys
            22      3	Shorts
            23      3	Socks
            24      3	Tights
            25      3	Vests
            26      4	Bike Racks
            27      4	Bike Stands
            28      4	Bottles and Cages
            29      4	Cleaners
            30      4	Fenders
            31      4	Helmets
            32      4	Hydration Packs
            33      4	Lights
            34      4	Locks
            35      4	Panniers
            36      4	Pumps
            37      4	Tires and Tubes

** Product Category**
ProductCategoryID	Name
4	Accessories
1	Bikes
3	Clothing
2	Components

**Product Model**
ProductModelID	Name
122	All-Purpose Bike Stand
119	Bike Wash
115	Cable Lock
98	Chain
1	Classic Vest
2	Cycling Cap
121	Fender Set - Mountain
102	Front Brakes
103	Front Derailleur
3	Full-Finger Gloves
4	Half-Finger Gloves
109	Headlights - Dual-Beam
110	Headlights - Weatherproof
118	Hitch Rack - 4-Bike
97	HL Bottom Bracket
101	HL Crankset
106	HL Fork
61	HL Headset
5	HL Mountain Frame
46	HL Mountain Front Wheel
55	HL Mountain Handlebars
64	HL Mountain Pedal
125	HL Mountain Rear Wheel
73	HL Mountain Seat/Saddle 1
81	HL Mountain Seat/Saddle 2
87	HL Mountain Tire
6	HL Road Frame
51	HL Road Front Wheel
58	HL Road Handlebars
70	HL Road Pedal
78	HL Road Rear Wheel
76	HL Road Seat/Saddle 1
84	HL Road Seat/Saddle 2
90	HL Road Tire
7	HL Touring Frame
48	HL Touring Handlebars
67	HL Touring Seat/Saddle
107	Hydration Pack
95	LL Bottom Bracket
99	LL Crankset
104	LL Fork
59	LL Headset
8	LL Mountain Frame
42	LL Mountain Front Wheel
52	LL Mountain Handlebars
62	LL Mountain Pedal
123	LL Mountain Rear Wheel
71	LL Mountain Seat/Saddle 1
79	LL Mountain Seat/Saddle 2
85	LL Mountain Tire
9	LL Road Frame
49	LL Road Front Wheel
56	LL Road Handlebars
68	LL Road Pedal
126	LL Road Rear Wheel
82	LL Road Seat/Saddle 1
74	LL Road Seat/Saddle 2
88	LL Road Tire
10	LL Touring Frame
47	LL Touring Handlebars
66	LL Touring Seat/Saddle
11	Long-Sleeve Logo Jersey
12	Men's Bib-Shorts
13	Men's Sports Shorts
116	Minipump
96	ML Bottom Bracket
100	ML Crankset
105	ML Fork
60	ML Headset
14	ML Mountain Frame
15	ML Mountain Frame-W
45	ML Mountain Front Wheel
54	ML Mountain Handlebars
63	ML Mountain Pedal
124	ML Mountain Rear Wheel
72	ML Mountain Seat/Saddle 1
80	ML Mountain Seat/Saddle 2
86	ML Mountain Tire
16	ML Road Frame
17	ML Road Frame-W
50	ML Road Front Wheel
57	ML Road Handlebars
69	ML Road Pedal
77	ML Road Rear Wheel
75	ML Road Seat/Saddle 1
83	ML Road Seat/Saddle 2
89	ML Road Tire
65	ML Touring Seat/Saddle
18	Mountain Bike Socks
112	Mountain Bottle Cage
117	Mountain Pump
92	Mountain Tire Tube
19	Mountain-100
20	Mountain-200
21	Mountain-300
39	Mountain-400
22	Mountain-400-W
23	Mountain-500
114	Patch kit
24	Racing Socks
128	Rear Brakes
127	Rear Derailleur
113	Road Bottle Cage
93	Road Tire Tube
25	Road-150
26	Road-250
41	Road-350
27	Road-350-W
28	Road-450
40	Road-550
29	Road-550-W
30	Road-650
31	Road-750
32	Short-Sleeve Classic Jersey
33	Sport-100
108	Taillight
44	Touring Front Wheel
53	Touring Pedal
43	Touring Rear Wheel
91	Touring Tire
94	Touring Tire Tube
34	Touring-1000
35	Touring-2000
36	Touring-3000
120	Touring-Panniers
111	Water Bottle
37	Women's Mountain Shorts
38	Women's Tights
