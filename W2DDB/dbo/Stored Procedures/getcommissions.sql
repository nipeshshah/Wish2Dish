create procedure getcommissions
as
select cu.Name, Sum(Amount)  from Commissions c 
left join Customer cu on c.ToCustomer = cu.Id
group by cu.Name

select cu.Name , Sum(Points)  from Points p 
left join Customer cu on p.CustomerId = cu.Id
group by cu.Name  
