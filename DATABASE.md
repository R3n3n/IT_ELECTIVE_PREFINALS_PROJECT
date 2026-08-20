## TABLES DISCOVERED

**1. Departments**

|**Name**|**Datatype**|
|-|-|
|Id|INTEGER|
|Name|TEXT|
|Description|TEXT|
|IsActive|TEXT|



**Primary Key:** Id (single-column, auto-increment)  
**Foreign Key:** None  
**Nullable Column:** Description  
**Notes:** IsActive has a default of *1*  



**2. Employees**

|**Name**|**Datatype**|
|-|-|
|Id|INTEGER|
|DepartmentId|INTEGER|
|FirstName|TEXT|
|LastName|TEXT|
|Email|TEXT|
|JobTitle|TEXT|
|HireDate|TEXT|
|IsActive|INTEGER|



**Primary Key:** Id (single-column, auto-increment)    
**Foreign Key:** DepartmentId -> Departments.Id    
**Nullable Column:** None    
**Notes:** Email is UNIQUE and IsActive has a default of *1*    



**3. Tags**

|**Name**|**Datatype**|
|-|-|
|Id|INTEGER|
|Name|TEXT|



**Primary Key:** Id (single-column, auto-increment)    
**Foreign Key:** None    
**Nullable Column:** None    
**Notes:** Name is UNIQUE    



**4. TicketTags**

|**Name**|**Datatype**|
|-|-|
|TicketId|INTEGER|
|TagId|INTEGER|



**Primary Key:** Composite - (TicketId, TagId)    
**Foreign Key:** TicketId -> Tickets.Id, TagId -> Tags.Id     
**Nullable Column:** None    



**5. Customers**

|**Name**|**Datatype**|
|-|-|
|Id|INTEGER|
|CompanyName|TEXT|
|ContactName|TEXT|
|Email|TEXT|
|Phone|TEXT|
|CreatedAt|TEXT|
|IsActive|INTEGER|



**Primary Key:** Id (auto-increment)  
**Foreign Key:** None  
**Nullable Column:** Phone   



**6. Teams**

|**Name**|**Datatype**|
|-|-|
|Id|INTEGER|
|DepartmentId|INTEGER|
|Name|TEXT|
|Description|TEXT|



**Primary Key:** Id (auto-increment)  
**Foreign Key:** DepartmentID => Departments.Id  
**Nullable Column:** Description  
**Note:** DepartmentId and Name are UNIQUE  



**7. TeamMembers**

|**Name**|**Datatype**|
|-|-|
|TeamId|INTEGER|
|EmployeeId|INTEGER|
|JoinedAt|TEXT|



**Primary Key:** Id (auto-increment)  
**Foreign Keys:** Composite, TeamID => Teams.Id , EmployeeID => Employees.Id  
**Nullable Column:** None  



**8. TicketPriorities**

|**Name**|**Datatype**|
|-|-|
|Id|INTEGER|
|Name|TEXT|
|SortOrder|INTEGER|
|ResponseHours|INTEGER|



**Primary Key:** Id (auto-increment)  
**Foreign Key:** None  
**Nullable Column:** None  
**Note:** Name is UNIQUE  



**9. TicketStatus**

|**Name**|**Datatype**|
|-|-|
|Id|INTEGER|
|Name|TEXT|
|IsClosed|INTEGER|



**Primary Key:** Id (auto-increment)  
**Foreign Key:** None  
**Nullable Column:** None  
**Note:** Name is UNIQUE  



**10. TicketAssignments**

|**Name**|**Datatype**|
|-|-|
|TicketId|INTEGER|
|EmployeeId|INTEGER|
|AssignedAt|TEXT|
|UnassignedAt|TEXT|
|IsPrimary|INTEGER|



**Primary Key:** Composite - (TicketId, EmployeeID)  
**Foreign Key:** EmployeeId -> Eployees.Id, TicketId -> Tickets.Id  
**Nullable Column:** UnassignedAt  
**Notes:** IsPrimary has a default of *0*  



**11. Tickets**

|**Name**|**Datatype**|
|-|-|
|Id|INTEGER|
|CustomerId|INTEGER|
|CategoryId|INTEGER|
|PriorityId|INTEGER|
|StatusId|INTEGER|
|Subject|TEXT|
|Description|TEXT|
|CreatedAt|TEXT|
|UpdatedAt|TEXT|
|DueAt|TEXT|
|ResolvedAt|TEXT|
|ClosedAt|TEXT|



**Primary Key:** Id (auto-increment)  
**Foreign Key:** StatusId -> TicketStatuses.Id, PriorityId -> TicketPriorities.Id, CategoryId -> TicketCategories.Id , CustomerId -> Customers.Id  
**Nullable Column:** DueAt, ResolvedAt, ClosedAt  



**12. TicketAttachments**

|**Name**|**Datatype**|
|-|-|
|Id|INTEGER|
|TicketId|INTEGER|
|FileName|TEXT|
|ContentType|TEXT|
|FileSize|INTEGER|
|UploadedAt|TEXT|



**Primary Key:** Id (auto-increment)  
**Foreign Key:** TicketId -> Tickets.Id  
**Nullable Column:** None  



**13. TicketCategories**

|**Name**|**Datatype**|
|-|-|
|Id|INTEGER|
|ParentCategoryId|INTEGER|
|Name|TEXT|
|Description|TEXT|



**Primary Key:** Id (auto-increment)  
**Foreign Key:** ParentCategoryId -> TicketCategories.Id  
**Nullable Column:** ParentCategoryId, Description  



**14. TicketComments**

|**Name**|**Datatype**|
|-|-|
|Id|INTEGER|
|TicketId|INTEGER|
|EmployeeId|INTEGER|
|Comment|TEXT|
|CreatedAt|TEXT|
|IsInternal|INTEGER|



**Primary Key:** Id (auto-increment)  
**Foreign Key:** EmployeeId -> Eployees.Id, TicketId -> Tickets.Id  
**Nullable Column:** EmployeeId  
**Notes:** IsInternal has a default of *0*  



**RELATIONSHIPS**



**One-to-many**  

* Departments -> Employees: One Department has many Employees  
* Departments -> Teams: One Department has many Teams  
* Customers -> Tickets: One Costumer can have many Tickets  
* TicketCategories -> Tickets: One Category can consist of many Tickets  
* TicketPriorities -> Tickets: One Priority can consist of many Tickets  
* TicketStatuses -> Tickets: A Status can consist of many Tickets  
* Tickets -> TicketComments: One Ticket can have many Comments  
* Employees -> TicketComments: One Employee can have many Comments  
* Tickets -> TicketAttachments: One Ticket can contain many Attachments  





**Many-to-many**  

* Tickets <-> Tags  
* Tickets <-> Employees  
* Teams <-> Employees  



**Self-referencing**  

* TicketCategories   





**Optional relationships**  

* TicketComments.EmployeeId - Nullable     
* TicketCategories.ParentCategoryId - Nullable   





**Composite primary keys**  

* TicketTags (TicketId, TagId)  
* TeamMembers (TeamId, EmployeeId)  
* TicketAssignments (TicketId, EmployeeId)  



