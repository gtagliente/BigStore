create Database BigStore;
use  BigStore;

CREATE SEQUENCE seqitem
    START WITH 1  
    INCREMENT BY 1 ;  
   
CREATE SEQUENCE seqorder
    START WITH 1  
    INCREMENT BY 1 ;  
   
create table category
(
	  category_id int primary key NOT NULL default  next value for seqitem
	, description varchar(50) NOT NULL
	, is_root bit NULL
)

alter table category
add constraint DF_category
default next value for seqitem
for category_id

for idcreate table category_hierarchy
(
	 id int IDENTITY primary key NOT NULL
	,father_category int NOT NULL
	,child_category int NOT NULL
	,UNIQUE(child_category)
	,FOREIGN KEY (father_category) REFERENCES category(category_id)
	,FOREIGN KEY (child_category) REFERENCES category(category_id)
)


create table product
(
	 product_id int primary key NOT NULL
	,name varchar(50) NOT NULL
	,details varchar(1000) NULL
	,price decimal NOT NULL
	,category_id int NOT NULL
	,FOREIGN KEY (category_id) REFERENCES category(category_id)
)


alter table product
add constraint SeqPK_product
default next value for seqitem
for product_id


create table discount
(
	 discount_id int primary key not null 
	 ,product_id int not null
	 ,name varchar(50) not null
	 ,from_date date default getdate() + 1
	 ,to_date date
	 ,discount_percentage int not null
	 ,enabled bit not null default 1
	 ,FOREIGN KEY (product_id) REFERENCES product(product_id)
)


alter table discount
add constraint SeqPK_discount
default next value for seqitem
for discount_id


create table menu_discount
(
	menu_id int primary key not null 
	,name varchar(50) not null
	,from_date date default getdate()+1
	,to_date date
	,discount_percentage int not null
	,enabled bit not null default 1
)

alter table menu_discount
add constraint SeqPK_menu_discount
default next value for seqitem
for menu_id

create table menu_product
(
	 product_id int not null
	,menu_id int not null
	,FOREIGN KEY (product_id) REFERENCES product(product_id)
	,FOREIGN KEY (menu_id) REFERENCES menu_discount(menu_id)
	,UNIQUE(product_id,menu_id)
)


create table p_order
(
	order_id int primary key NOT NULL
	,product_or_menu int NOT NULL
	, date DATETIME NOT NULL
	,update_date date NOT NULL
	,order_state VARCHAR(50) NULL
	,is_menu BIT NOT NULL
	,FOREIGN KEY (product_or_menu) REFERENCES product(product_id)
	,FOREIGN KEY (product_or_menu) REFERENCES menu_discount(menu_id)
)

alter table p_order
add constraint SeqPK_p_order
default next value for seqorder
for order_id


 select * from BigStore.dbo.category
 
 -- category 
 INSERT INTO BigStore.dbo.category
( description, is_root)
VALUES( 'Primi piatti', 1);
 INSERT INTO BigStore.dbo.category
( description, is_root)
VALUES( 'Secondi', 1);

--product
INSERT INTO BigStore.dbo.product
( name, price, category_id)
VALUES('Spaghetti allo scoglio', 12.5, 2);
INSERT INTO BigStore.dbo.product
( name, price, category_id)
VALUES('Pasta al ragù', 9.5, 2);
INSERT INTO BigStore.dbo.product
( name, price, category_id)
VALUES('Tagliata di Manzo', 15, 3);
INSERT INTO BigStore.dbo.product
( name, price, category_id)
VALUES('Cotoletta alla milanese', 9.5, 3);

--MENU
INSERT INTO BigStore.dbo.menu_discount
( name, discount_percentage)
VALUES( 'Menu Terra', 20);
INSERT INTO BigStore.dbo.menu_product
(product_id, menu_id)
VALUES(5, 8);
INSERT INTO BigStore.dbo.menu_product
(product_id, menu_id)
VALUES(7, 8);

