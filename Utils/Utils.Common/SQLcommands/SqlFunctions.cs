using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Common.SQLcommands
{
    public class SqlFunctions
    {
        public static string checkCreatedFunctions = "SELECT Name AS 'Function Name', SCHEMA_NAME(schema_id) AS 'Schema', type_desc AS 'Function Type', create_date AS 'Created Date' FROM sys.objects WHERE Type in ('FN', 'IF', 'FN', 'AF', 'FS', 'FT') And Name like('%function_%');";


        public static string UserFunctions = "CREATE function[dbo].function_CustomerOrder (@customerId int, @orderId int) returns table as return select c.CustomerID,c.EmailAddress,c.CompanyName,c.FirstName,c.MiddleName,c.LastName,c.Phone,c.Title,soh.AccountNumber,soh.OrderDate,soh.ShipDate,soh.TotalDue,soh.DueDate,soh.Comment,soh.SalesOrderNumber,soh.ShipMethod,soh.Status,soh.SubTotal from SalesLT.Customer as c right join SalesLT.SalesOrderHeader as soh on c.CustomerID= soh.CustomerID where c.CustomerID= @customerId and soh.SalesOrderID= @orderId";
        
    }
}
