
CREATE DATABASE QuanLyKhachSan
GO

USE QuanLyKhachSan
GO 

-------------------- Tạo bảng ----------------------

-----Tạo Bảng Account------
CREATE TABLE Account
(
	UserName nchar(100) NOT NULL PRIMARY KEY,
	DisplayName nvarchar(100) NOT NULL DEFAULT N' ',
	PassWord nchar(1000) NOT NULL,
	Type int NOT NULL, -----1: Admin, 0: Staff----------
)
GO

----Tạo Bảng Loại Phòng--------
CREATE	TABLE RoomType
(
	id INT IDENTITY PRIMARY KEY,
	NameType nvarchar(100) NOT NULL,
	Price INT NOT NULL,
)
GO

--Tạo Bảng Phòng------
CREATE TABLE Room
(
	id INT IDENTITY PRIMARY KEY,
	NameRoom nvarchar(100) NOT NULL,
	Status nvarchar(100) NOT NULL DEFAULT N'Phòng Trống',
	idRoomType INT NOT NULL,
	FOREIGN KEY(idRoomType) REFERENCES RoomType (id)
)
GO

-------Tạo Bảng Dịch Vụ---------
CREATE TABLE Service
(
	id INT IDENTITY PRIMARY KEY,
	NameService nvarchar(100) NOT NULL,
	Price int NOT NULL,
)
GO

-------------Tạo bảng Khách hàng--------
CREATE TABLE Customer
(
	id INT IDENTITY PRIMARY KEY,
	NameCustomer nvarchar(100) NOT NULL,
	DateTimeCustomer Date NOT NULL,
	GenderCustomer nvarchar(3) NOT NULL,
	AddressCustomer nvarchar(100),
	idCardCustomer nchar(15) NOT NULL,
	PhoneNumber Nchar(10)
)
GO

-----Tạo Bảng Bill-----
CREATE TABLE Bill
(
	id INT IDENTITY PRIMARY KEY,
	idCustomer int NOT NULL,
	DateCheckIn Date NOT NULL DEFAULT GETDATE(),
	DateCheckOut Date ,
	idRoom int NOT NULL,
	Status int NOT NULL, ------1: Đã Thanh Toán, 0: Chưa Thanh Toán.
	FOREIGN KEY (idRoom) REFERENCES Room(id),
	FOREIGN KEY (idCustomer) REFERENCES Customer(id),
)
GO
----Tạo Bảng BillInfo-------
CREATE TABLE BillInfo
(
	id INT IDENTITY PRIMARY KEY,
	idBill int NOT NULL,
	idService int NOT NULL,
	intCount INT NOT NULL,
	DateService DATE NOT NULL DEFAULT GETDATE(),
	FOREIGN KEY (idBill) REFERENCES Bill (id),
	FOREIGN KEY (idService) REFERENCES Service (id)
)
GO

-----------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------------------------------

-----------------DELETE------------------------------------------------
/*
	DELETE FROM BillInfo
	DELETE FROM Bill
	DELETE FROM Customer
	DELETE FROM SERVICE
	DELETE FROM Room
	DELETE FROM RoomType
*/

/*
	DROP TABLE Customer
	DROP TABLE BillInfo
	DROP TABLE Bill
	DROP TABLE SERVICE
	DROP TABLE Room
	DROP TABLE RoomType
*/

---------------------------------------------------------------------------------

--------------- UPDATE -------------------------------------------------
/*
	SELECT *FROM Room
	UPDATE Room SET Status= N'Trống' where id =7
	UPDATE Room SET Status= N'Trống' where id =1
	UPDATE Room SET Status= N'Trống' where id =3
	GO
*/
-------------------SELECT ---------------------------------------
/*
	SELECT * FROM RoomType
	SELECT * FROM Room
	SELECT * FROM Customer
	SELECT * FROM Bill
	SELECT * FROM BillInfo
	SELECT * FROM Service
	GO

*/



-------------------------------------------------------------------------------------

-----------------Tạo strigger----------------------------------------------
--------------Update dựa vào Bill - có bill là phòng có người
CREATE TRIGGER UTG_UpdatePhong
ON Bill FOR INSERT, UPDATE
AS
BEGIN 
	DECLARE @idRoom int
	SELECT @idRoom =  idRoom FROM Inserted

	Update Room SET Status = N'Có người' WHERE id = @idRoom
END
GO
/*
ALTER TRIGGER UTG_InsertCustomer
ON Customer FOR INSERT
AS
BEGIN 
	DECLARE @idCardCustomer nchar(15)
	SELECT @idCardCustomer = idCardCustomer FROM Inserted
	IF EXISTS (SELECT * FROM Inserted WHERE @idCardCustomer != idCardCustomer)
	BEGIN
		PRINT 'Khách hàng này đã được thêm rồi'
		ROLLBACK TRANSACTION
	END
END
GO
*/

/* 
-------------Update dựa vào billInfo
CREATE TRIGGER UTG_UpdateBillnfo
ON BillInfo FOR INSERT, UPDATE
AS
BEGIN 
	DECLARE @idBill int
	SELECT @idBill = idBill FROM Inserted
	DECLARE @idRoom int
	SELECT @idRoom = idRoom FROM Bill WHERE id = @idBill and Status = 0
	Update Room SET Status = N'Có người' WHERE id = @idRoom
END
GO
*/
-------------thanh toán bill thì phòng thành phòng trống
CREATE TRIGGER UTG_UpdateBill
ON Bill FOR UPDATE
AS
BEGIN 
	DECLARE @idBill int
	SELECT @idBill = id FROM Inserted
	DECLARE @idRoom int
	SELECT @idRoom = idRoom FROM Bill WHERE id = @idBill
	DECLARE @count int =0
	SELECT @count  =COUNT(*) FROM Bill WHERE idRoom = @idRoom and Status = 0
	if(@count =0)
		Update Room SET Status = N'Trống' where id = @idRoom
END
GO



---------------------------------------------------------------------------------------------------
------------------Thêm dữ liệu vào bảng------------

------------------- Thêm dữ liệu vào bảng RoomType ----------
SELECT * FROM RoomType
GO

SET IDENTITY_INSERT [dbo].[RoomType] ON
INSERT INTO RoomType ([id], [NameType], [Price]) Values (1, N'Phòng VIP', 720000)
INSERT INTO RoomType ([id], [NameType], [Price]) Values (2, N'Phòng thường', 120000)
INSERT INTO RoomType ([id], [NameType], [Price]) Values (3, N'Phòng thương gia', 400000)
INSERT INTO RoomType ([id], [NameType], [Price]) Values (4, N'Phòng đôi', 180000)
INSERT INTO RoomType ([id], [NameType], [Price]) Values (5, N'Phòng ba', 200000)
SET IDENTITY_INSERT [dbo].[RoomType] OFF
GO
--------------------------Thêm dữ liệu vào bảng phòng ------------------------
SELECT * FROM Room
GO

SET IDENTITY_INSERT [dbo].[Room] ON
INSERT INTO Room([id], [NameRoom], [Status], [idRoomType]) Values (1, N'Phòng VIP', N'Trống', 1)
INSERT INTO Room([id], [NameRoom], [Status], [idRoomType]) Values (2, N'Phòng 10', N'Trống', 3)
INSERT INTO Room([id], [NameRoom], [Status], [idRoomType]) Values (3, N'Phòng 11', N'Trống', 3)
INSERT INTO Room([id], [NameRoom], [Status], [idRoomType]) Values (4, N'Phòng 31', N'Trống', 4)
INSERT INTO Room([id], [NameRoom], [Status], [idRoomType]) Values (5, N'Phòng 32', N'Trống', 5)
INSERT INTO Room([id], [NameRoom], [Status], [idRoomType]) Values (6, N'Phòng 33', N'Trống', 5)
INSERT INTO Room([id], [NameRoom], [Status], [idRoomType]) Values (7, N'Phòng 101', N'Trống', 2)
INSERT INTO Room([id], [NameRoom], [Status], [idRoomType]) Values (8, N'Phòng 102', N'Trống', 2)
INSERT INTO Room([id], [NameRoom], [Status], [idRoomType]) Values (9, N'Phòng 103', N'Trống', 2)
INSERT INTO Room([id], [NameRoom], [Status], [idRoomType]) Values (10, N'Phòng 104', N'Trống', 2)
SET IDENTITY_INSERT [dbo].[Room] OFF
GO

---------------------------------------Thêm dữ liệu vào bảng Customer -------------------

SET DATEFORMAT dmy
SET IDENTITY_INSERT [dbo].Customer ON
INSERT INTO Customer ([id], [NameCustomer], [DateTimeCustomer], [GenderCustomer], [AddressCustomer], [idCardCustomer], [PhoneNumber])
VALUES (1, N'Nguyễn Văn B', '02/01/1996', N'Nam', N'Bạc Liêu', '385758646', '0964429603')
SET IDENTITY_INSERT [dbo].Customer OFF
GO
INSERT INTO Customer ( [NameCustomer], [DateTimeCustomer], [GenderCustomer], [AddressCustomer], [idCardCustomer], [PhoneNumber])
VALUES (N'Nguyễn Văn C', '22/08/1996', N'Nam', N'Bạc Liêu', '385758659', '0964423435')
GO
INSERT INTO Customer ([NameCustomer], [DateTimeCustomer], [GenderCustomer], [AddressCustomer], [idCardCustomer], [PhoneNumber])
VALUES (N'Nguyễn Thị Bông', '14/06/1994', N'Nữ', N'Bạc Liêu', '385758634', '0964234432')
GO
SELECT * FROM Customer
GO


----------------------Thêm dữ liệu vào bảng Service -------------------------
SELECT * FROM Service
GO

SET IDENTITY_INSERT [dbo].[Service] ON
INSERT INTO Service ([id], [NameService], [Price]) Values (1, N'Quầy bar', 100000)
INSERT INTO Service ([id], [NameService], [Price]) Values (2, N'Café', 10000)
INSERT INTO Service ([id], [NameService], [Price]) Values (3, N'Spa', 100000)
INSERT INTO Service ([id], [NameService], [Price]) Values (4, N'Phòng họp', 120000)
INSERT INTO Service ([id], [NameService], [Price]) Values (5, N'Giặt ủi', 20000)
INSERT INTO Service ([id], [NameService], [Price]) Values (6, N'Dịch vụ 24/24', 200000)
INSERT INTO Service ([id], [NameService], [Price]) Values (7, N'Fitness centre', 10000)
SET IDENTITY_INSERT [dbo].[Service] OFF
GO


------------------------Thêm dữ liệu vào bảng Bill ------------------
/*
SET IDENTITY_INSERT [dbo].[Bill] ON
INSERT INTO Bill ([id],[idCustomer], [DateCheckIn], [DateCheckOut], [idRoom], [Status])  Values (1, 1, GETDATE(), NULl,  1, 0)
INSERT INTO Bill ([id], [idCustomer], [DateCheckIn], [DateCheckOut], [idRoom], [Status])  Values (2, 2, GETDATE(), GETDATE(),  1, 1)
INSERT INTO Bill ([id], [idCustomer], [DateCheckIn], [DateCheckOut], [idRoom], [Status])  Values (3, 5, GETDATE(), NULl,  7, 0)
SET IDENTITY_INSERT [dbo].[Bill] OFF
GO
INSERT INTO Bill ([idCustomer], [DateCheckIn], [DateCheckOut], [idRoom], [Status])  
Values (4, GETDATE(), NULl,  3, 0)
GO
*/
SELECT * FROM Bill
GO

-----------------------------------Thêm dữ liệu vào bảng billInfo ---------------------
SELECT * FROM BillInfo
GO
/*
SET IDENTITY_INSERT [dbo].[BillInfo] ON
INSERT INTO BillInfo ([id], [idBill], [idService], [intCount], [DateService]) Values (1, 1, 1, 1, GETDATE())
INSERT INTO BillInfo ([id], [idBill], [idService], [intCount], [DateService]) Values (2, 2, 6, 1, GETDATE())
INSERT INTO BillInfo ([id], [idBill], [idService], [intCount], [DateService]) Values (3, 2, 3, 1, GETDATE())
INSERT INTO BillInfo ([id], [idBill], [idService], [intCount], [DateService]) Values (4, 2, 2, 4, GETDATE())
SET IDENTITY_INSERT [dbo].[BillInfo] OFF
GO
INSERT INTO BillInfo ([idBill], [idService], [intCount], [DateService]) Values (1, 2, 4, GETDATE())
INSERT INTO BillInfo ([idBill], [idService], [intCount], [DateService]) Values (3, 3, 4, GETDATE())
INSERT INTO BillInfo ([idBill], [idService], [intCount], [DateService]) Values (33, 6, 3, GETDATE())
*/
--------------------------Thêm dữ liệu vào bảng Account--------------------
select * from Account

INSERT INTO Account ([UserName], [DisplayName], [PassWord], [Type]) Values ('admin', N'Trưởng Phòng', 'admin', 1)
GO
INSERT INTO Account ([UserName], [DisplayName], [PassWord], [Type]) Values ('dinh', N'Trưởng Phòng', 'dinh', 0)
GO
--------------------------------------------------------------------------------------------------------
-------------------- TẠO STORED PROCEDURE  ---------------------

 -- DROP PROCEDURE USP_LoadCustomer ----ALTER	
 -------Load đặt phòng
CREATE PROC USP_LoadDatPhong
AS
	SELECT r.NameRoom as [Phòng], c.NameCustomer as [Khách hàng], c.idCardCustomer as[CMND], b.DateCheckIn as[Ngày vào], rt.NameType as[Loại phòng], rt.Price as [Giá Phòng]
	FROM Room as r, RoomType as rt, Bill as b, Customer as c
	Where rt.id = r.idRoomType and r.id = b.idRoom and b.idCustomer = c.id 
GO
EXECUTE USP_LoadDatPhong;
GO
 --------Load khách hàng
CREATE PROC USP_LoadCustomer
AS
	SELECT id, NameCustomer as [Tên KH], DateTimeCustomer as [Ngày sinh], GenderCustomer as [Giới tính], AddressCustomer as [Địa chỉ], idCardCustomer as [Số CM], PhoneNumber as [Điện thoại] FROM Customer
GO
EXECUTE USP_LoadCustomer;
GO
--------Đăng nhập tài khoản
CREATE PROCEDURE USP_Login
@userName nchar(100), @passWord nchar(1000)
as
begin
	select * from Account where UserName = @userName and Password = @passWord
end
Go
EXEC USP_Login @userName = N'admin', @passWord = 'admin'
GO
-----Lấy ra phòng hiện tại
CREATE PROC USP_GetRoomList
AS
	SELECT * FROM Room
GO
EXEC USP_GetRoomList;
GO
------Lấy ra service hiện tại
CREATE PROC USP_GetService
AS
	SELECT * FROM Service
GO
EXEC USP_GetService;
GO
-----------Thêm vào BillInfo
CREATE PROCEDURE USP_InsertBillInfo
@idBill int, @idService int, @intCount int
as
BEGIN
	
	DECLARE @KtraBillInfo INT
	DECLARE @CountService INT = 1
	SELECT @KtraBillInfo = id, @CountService = intCount FROM BillInfo 
	WHERE idBill = @idBill and idService = @idService -- coi có idBill chưa và xem có thức ăn nào như v đã có trong bill chưa
	IF (@KtraBillInfo >0)
		BEGIN
			DECLARE @newCount int = @CountService + @intCount
			IF(@newCount > 0)
				UPDATE BillInfo SET intCount = @CountService + @intCount WHERE idService = @idService and idBill = @idBill
			ELSE
				DELETE BillInfo WHERE idBill = @idBill and idService = @idService -----ngược lại xoá billInfo 
		END
	ELSE
		BEGIN
			INSERT INTO BillInfo ([idBill], [idService], [intCount], [DateService])
			VALUES (@idBill, @idService, @intCount, GETDATE())
		END
END
GO
--EXEC USP_InsertBillInfo @idBill = 6 , @idService =5, @intCount =10

---------Thêm vào Bill
CREATE PROCEDURE USP_InsertBill
@idRoom INT, @idCustomer INT
AS
BEGIN
	DECLARE @KtraStatus INT
	SELECT @KtraStatus  = COUNT(*) FROM Bill WHERE idRoom = @idRoom and Status = 0
	IF(@KtraStatus =  0)
		BEGIN
			INSERT INTO Bill ([idCustomer], [DateCheckIn], [DateCheckOut], [idRoom], [Status])  
			VALUES ( @idCustomer, GETDATE(), NULl,  @idRoom , 0)
		END
	ELSE
		BEGIN
			Print N'Nhập lại'
		END
END
GO
--EXEC USP_InsertBill @idCustomer = 3 , @idRoom = 3




----------------------------------------------------------------------------------------------------------

