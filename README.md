# ProyectFullStackStore



An application of my store is created, where the user entity exists, which are the employees to register/work for my store. Followed by this are the entities store, location and product. Where the distribution of the products to enter and their respective distribution between the store and the location is carried out.

Diagrama UML:
![image](https://user-images.githubusercontent.com/98430956/232353125-06536ed3-659b-4b58-a4c2-415a0566a577.png)

Script SQL:

CREATE DATABASE AdmonStore;
use AdmonStore;

CREATE TABLE Stores(

Store_Id INT IDENTITY NOT NULL,
Id_User VARCHAR(40),
Names VARCHAR(50),
Description VARCHAR(100),
PRIMARY KEY (Store_Id)
);


CREATE TABLE Products(

Product_Id INT IDENTITY NOT NULL,
Id_Store INT NOT NULL,
Names VARCHAR(100),
Description VARCHAR(200),
Stock INT,
Price DECIMAL,
AdmissionDate DATETIME,
DepartureDate DATETIME,
State bit(50),
PRIMARY KEY (Product_Id),
CONSTRAINT Fk_Id_Store
FOREIGN KEY(Id_Store)
REFERENCES Stores(Store_Id),
);


CREATE TABLE Locations(
Location_Id INT  IDENTITY NOT NULL,
Id_Store INT NOT NULL,
Names VARCHAR(50),
Description VARCHAR(100),
Location_Type VARCHAR(50),
PRIMARY KEY (Location_Id),
CONSTRAINT Fk_Id_Store_Locations 
FOREIGN KEY(Id_Store)
REFERENCES Stores(Store_Id)
);

Endpoint User:

![image](https://user-images.githubusercontent.com/98430956/232352536-46403ad1-737a-4266-904f-e67834bf0cb8.png)

Endpoints Store,Location and Product:

![image](https://user-images.githubusercontent.com/98430956/232353531-4943a198-cadd-40b4-9b0f-835fc49b13a8.png)

