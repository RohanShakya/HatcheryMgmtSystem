<Query Kind="Statements">
  <Connection>
    <ID>f08328e2-8c3b-4f34-a3fa-c87d913c91e5</ID>
    <Persist>true</Persist>
    <Server>.\SQLEXPRESS</Server>
    <SqlSecurity>true</SqlSecurity>
    <UserName>sa</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAA+4yN8Nv/BEy1NR8U4pXyPAAAAAACAAAAAAAQZgAAAAEAACAAAADzyRAB3naRLLX7HPcNqVlIT574RvehifA6k5Pu3h92yAAAAAAOgAAAAAIAACAAAADy169oqmQbOLEgAeA5g8Qq9MMZC9fAjeTVh38ElZWatRAAAADaoHZCKM9G2SgJtxu+GuoVQAAAACWzalLo55dcKYstWosRvhsdHAy7rS62eczpTbWh0iQkWN1iO/rPq46P91LWD/jqUY3024jja0Ml42vtlu0Ca8c=</Password>
    <NoCapitalization>true</NoCapitalization>
    <Database>TestDB</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

//Inner join between two tables example
	
	var q=(from pd in tblProducts
		  join  od in tblOrders on pd.ProductID equals od.ProductID 
		  orderby od.OrderID
		  select new
		  {
		    od.OrderID,
		    pd.ProductID,
			pd.Name,
			pd.UnitPrice,
			od.Quantity,
			od.Price,
			}).ToList();
		  
	q.Dump(); //to see result use LINQ Pad Dump() method
	
//Inner join among more than two tables example
	
	var q=(from pd in tblProducts
		  join  od in tblOrders on pd.ProductID equals od.ProductID 
		  join  ct in tblCustomers on od.CustomerID equals ct.CustID
		  orderby od.OrderID
		  select new
		  {
		    od.OrderID,
			pd.ProductID,
			pd.Name,
			pd.UnitPrice,
			od.Quantity,
			od.Price,
			Customer=ct.Name //define anonymous type Customer
			}).ToList();
		  
	q.Dump();	
	
//Inner join on multiple conditions example

//Note : data type, name, accept null or not null will be exact same

	var q=(from pd in tblProducts
		  join  od in tblOrders on pd.ProductID equals od.ProductID 
		  join  ct in tblCustomers on new {a=od.CustomerID,b=od.ContactNo} 
		  equals new {a=ct.CustID,b=ct.ContactNo}
		  orderby od.OrderID
		  select new
		  {
		    od.OrderID,
		    pd.ProductID,
			pd.Name,
			pd.UnitPrice,
			od.Quantity,
			od.Price,
			Customer=ct.Name //define anonymous type Customer
			}).ToList();
		  
	q.Dump();	

//Note : data type, name, accept null or not null will be exact same 
//if one of them is not same then do type casting like as

var q=(from pd in tblProducts
	join  od in tblOrders on pd.ProductID equals od.ProductID 
	join  ct in tblCustomers 
	on new {a=od.CustomerID,b=od.ContactNo} //IF CustomerID is NULL field in tblOrders
	equals new {a=(int?)ct.CustID,b=ct.ContactNo} //If CustID is NOT NULL field in tblOrders 
	//To make CustID field to NULL do type casting by using int?
	orderby od.OrderID
	select new
	{
		od.OrderID,
		pd.ProductID,
		pd.Name,
		pd.UnitPrice,
		od.Quantity,
		od.Price,
		Customer=ct.Name //define anonymous type Customer
	}).ToList();
		  
	q.Dump();	
	
//Left join between two tables example
	
	var q=(from pd in tblProducts
		  join  od in tblOrders on pd.ProductID equals od.ProductID into t
		  from rt in t.DefaultIfEmpty()
		  orderby pd.ProductID
		  select new
		  {
		    //To handle null values do type casting as int?(NULL int) 
			//since OrderID is defined NOT NULL in tblOrders
			OrderID=(int?)rt.OrderID,
		    pd.ProductID,
			pd.Name,
			pd.UnitPrice,
			//no need to check for null since it is defined NULL in database
			rt.Quantity,
			rt.Price,
			}).ToList();
		  
	q.Dump(); 
	
//Group join between two tables example
	
	var q=(from pd in tblProducts
		  join  od in tblOrders on pd.ProductID equals od.ProductID into t
		  orderby pd.ProductID
		  select new
		  {
			pd.ProductID,
			pd.Name,
			pd.UnitPrice,
			Order=t
		}).ToList();
		  
	q.Dump(); 
	
//Group join between two tables as a subquery example

	var q=(from pd in tblProducts
		  join  od in tblOrders on pd.ProductID equals od.ProductID into t
		  from rt in t
		  where rt.Price>70000
		  orderby pd.ProductID
		  select new
		  {
		    rt.OrderID,
		    pd.ProductID,
			pd.Name,
			pd.UnitPrice,
			rt.Quantity,
			rt.Price,
			}).ToList();
		  
	q.Dump(); 
	
//Cross join between two tables example
	
	var q=(from pd in tblProducts
		  from  od in tblOrders 
		  orderby pd.ProductID
		  select new
		  {
		    od.OrderID,
		    pd.ProductID,
			pd.Name,
			pd.UnitPrice,
			od.Quantity,
			od.Price,
			}).ToList();
		  
	q.Dump();