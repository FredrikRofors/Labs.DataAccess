Labs.DataAccess
===============

Simple demo project showing various .NET database access techniques. 

Database access techniques included
-----------------------------------
* Hand crafted ADO.NET
  <br/><i>Released with .NET 1.0</i>
* Strongly typed datasets
  <br/><i>Released with .NET 1.1</i>
* LINQ to SQL
  <br/><i>Released with .NET 3.5</i>
* Entity Framework 4.x (database-first)
  <br/><i>Released with .NET 3.5 SP1</i>
  <br/><a href="http://msdn.microsoft.com/en-US/data/jj574253">Entity Framework version history</a>

Database access techniques TO BE included
-----------------------------------------
* ASP.NET WebForms Data UserControls
* NHibernate (ORM)
* SubSonic (ORM)
* Some micro ORM's (Dapper, Massive, PetaPoco...)
  <br/><a href="http://www.diplo.co.uk/blog/2011/8/15/small-is-beautiful-net-micro-orms.aspx">Small is Beautiful - .NET Micro ORMs</a>

TODO
----
* Refactor the UI: Add a "DB technique" radio button instead of separate search-buttons. 
* Refactor the code-behind: Introduce a factory that hands out the right IUserRepository impl depending on the selected DB technique. 
* Extend the demo database schema with some relations. 
* Add list, edit and delete support. 