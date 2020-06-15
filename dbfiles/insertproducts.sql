USE [CarRental3]
GO

INSERT INTO [dbo].[Products]
           ([Id]
           ,[car_brand]
           ,[car_model]
           ,[YearOfManufacturing]
           ,[image]
           ,[capacity]
           ,[doors]
           ,[Engine]
           ,[Gearbox]
           ,[status]
           ,[CreatedOn]
           ,[ModifiedOn]
           ,[hire_cost]
           ,[CreatedAt])
     VALUES
			(1, 'Range Rover', 'Evoque', 2018, 'car2.jpg', 6, 5, 'Gasoline', 'Automatic', 'Available', '2019-09-08', '2019-09-08', 33, '2019-09-08'),
			(2, 'Toyota', 'Supra', 2020, 'car3.jpg', 2, 3, 'Gasoline', 'Manual', 'Available', '2019-09-08', '2019-09-08', 45, '2019-09-08'),
			(3, 'Toyota', 'Land Cruiser ', 2009, 'images (2).jpg', 6, 5, 'Diesel', 'Manual', 'Available', '2019-09-08', '2019-09-08', 23, '2019-09-08'),
			(4, 'BMW', '520', 2019, '630.jpg', 4, 3, 'Diesel', 'Automatic', 'Available', '2019-09-08', '2019-09-08', 11, '2019-09-08'),
			(5, 'Volkswagen', 'Mk 7', 2018, 'golf7.jpg', 5, 3, 'Diesel', 'Manual', 'Available', '2019-09-08', '2019-09-08', 59, '2019-09-08'),
			(6, 'Tesla', 'Model S', 2018, 'teslaS.jpg', 8, 5, 'Electric', 'Automatic', 'Available', '2019-09-08', '2019-09-08', 39, '2019-09-08'),
			(7, 'Mercedes Benz', 'E class', 2016, 'car1.jpg', 2, 3, 'Gasoline', 'Automatic', 'Available', '2019-09-12', '2019-09-12', 70, '2019-09-08');
GO


