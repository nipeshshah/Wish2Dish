CREATE procedure cleardatabase
as
delete from Batch
delete from Commissions
delete from Customer
delete from ProductBatch
delete from Products
delete from Sales
delete from SalesInventory

select * from Batch
select * from Commissions
select * from Customer
select * from ProductBatch
select * from Products
select * from Sales
select * from SalesInventory