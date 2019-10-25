use master;
IF DB_ID('VehicleShop') IS NOT NULL
 DROP database VehicleShop

create database VehicleShop;
IF DB_ID('VehicleShop') IS NOT NULL
	use VehicleShop;


CREATE TABLE VehicleSales(
	SaleId int identity(1,1) NOT NULL,
	VehicleName VARCHAR(50) NOT NULL Check(VehicleName In ('Bicycle', 'Car','Truck', 'Motorcycle', 'Jet')),
	SaleDate DateTime NOT NULL

	CONSTRAINT PK_SaleId PRIMARY KEY (SaleId)
);