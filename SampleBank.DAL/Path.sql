USE SampleBank

CREATE TABLE City (
	Id INT NOT NULL IDENTITY(1, 1),
	Name NVARCHAR(100) NOT NULL,
	Description NVARCHAR(100) NOT NULL
)

ALTER TABLE City ADD CONstraint PK_City PRIMARY KEY (Id)

GO

CREATE TABLE Customer (
	Id INT NOT NULL IDENTITY(1, 1),
	Guid uniqueidentifier NOT NULL DEFAULT NEWID(),
	FirstName NVARCHAR(100) NOT NULL,
	LastName NVARCHAR(100) NOT NULL,
	Balance DECIMAL(28, 2) NOT NULL,
	CustomerType NVARCHAR(100) NOT NULL,
	Gender NVARCHAR(100) NOT NULL,
	IsActive BIT NOT NULL,
	PinCode INT NULL,
	CityId INT NOT NULL
)

ALTER TABLE Customer ADD CONSTRAINT PK_Customer PRIMARY KEY (Id)

ALTER TABLE Customer ADD CONSTRAINT FK_Customer_CityId FOREIGN KEY (CityId) References City

GO

CREATE TABLE [Transaction] (
	Id INT NOT NULL IDENTITY(1, 1),
	CustomerId INT NOT NULL,
	BeneficiaryId INT NOT NULL,
	Amount DECIMAL(28, 2) NOT NULL
)

ALTER TABLE [Transaction] ADD CONSTRAINT PK_Transaction PRIMARY KEY (Id)

ALTER TABLE [Transaction] ADD CONSTRAINT FK_Transaction_CustomerId FOREIGN KEY (CustomerId) References Customer

ALTER TABLE [Transaction] ADD CONSTRAINT FK_Transaction_BeneficiaryId FOREIGN KEY (CustomerId) References Customer

GO

CREATE PROCEDURE CreateCustomer (
	@FirstName NVARCHAR(100),
	@LastName NVARCHAR(100),
	@Balance DECIMAL(28, 2),
	@CustomerType NVARCHAR(100),
	@Gender NVARCHAR(100),
	@IsActive BIT,
	@PinCode INT,
	@CityId INT
) 
AS
BEGIN
	INSERT INTO [dbo].[Customer]
           ([FirstName]
           ,[LastName]
           ,[Balance]
           ,[CustomerType]
           ,[Gender]
           ,[IsActive]
		   ,[PinCode]
           ,[CityId])
     VALUES (
			@FirstName,
			@LastName,
			@Balance,
			@CustomerType,
			@Gender,
			@IsActive,
			@PinCode,
			@CityId
		)
END

GO 

CREATE PROCEDURE UpdateCustomer (
	@Id INT,
	@FirstName NVARCHAR(100),
	@LastName NVARCHAR(100),
	@Balance DECIMAL(28, 2),
	@CustomerType NVARCHAR(100),
	@Gender NVARCHAR(100),
	@IsActive BIT,
	@PinCode INT,
	@CityId INT
) 
AS
BEGIN
	Update [dbo].[Customer]
    SET [FirstName] = @FirstName,
		[LastName] = @LastName,
        [Balance] = @Balance,
        [CustomerType] = @CustomerType,
        [Gender] = @Gender,
        [IsActive] = @IsActive,
        [PinCode] = @PinCode,
        [CityId] = @CityId
    WHERE Id = @Id
END

GO 

CREATE PROCEDURE CreateTransaction (
	@CustomerId INT,
	@BeneficiaryId INT,
	@Amount DECIMAL(28, 2)
) 
AS
BEGIN
	INSERT INTO [dbo].[Transaction] (
           CustomerId,
		   BeneficiaryId,
		   Amount
	)
     VALUES (
			@CustomerId,
			@BeneficiaryId,
			@Amount
		)
END

GO 

CREATE PROCEDURE GetCustomers (
	@Name NVARCHAR(100),
	@CustomerType NVARCHAR(100),
	@CityId INT
) 
AS
BEGIN
	DECLARE @NameLike NVARCHAR(200) = '%' + ISNULL(@Name, '') + '%'
	SELECT c.Id,
		c.Guid,
		c.[FirstName]
        ,c.[LastName]
        ,c.[Balance]
        ,c.[CustomerType]
        ,c.[Gender]
        ,c.[IsActive]
		,c.[PinCode]
        ,c.[CityId]
	FROM Customer c
	WHERE (@Name IS NULL OR c.FirstName LIKE @NameLike OR c.LastName LIKE @NameLike) AND
		(@CustomerType IS NULL OR @CustomerType = c.CustomerType) AND
		(@CityId IS NULL OR @CityId = c.CityId)
END

GO 

CREATE PROCEDURE GetCustomer (
	@Id INT
) 
AS
BEGIN
	SELECT c.Id,
		c.Guid,
		c.[FirstName]
        ,c.[LastName]
        ,c.[Balance]
        ,c.[CustomerType]
        ,c.[Gender]
        ,c.[IsActive]
		,c.[PinCode]
        ,c.[CityId]
	FROM Customer c
	WHERE c.Id = @Id
END

GO 


CREATE PROCEDURE GetCities
AS
BEGIN
	SELECT c.Id,
		c.Name,
		c.Description
	FROM City c
END

GO 

INSERT INTO City VALUES ('Akola', 'Akola'),
('Amaravati', 'Amaravati'),
('Maharashtra', 'Maharashtra'),
('Pune', 'Pune'),
('Ratnagiri', 'Ratnagiri')

GO

--EXEC GetCustomers NULL, NULL, NUll

--EXEC GetCities