INSERT INTO Countries ([Name]) VALUES ('Belarus'), ('Ukrain'), ('Russia')

INSERT INTO Cities ([Name]) VALUES ('Minsk'), ('London'), ('Moscow'), ('Rome'), ('New York');

INSERT INTO MaritalStatuses ([Name]) VALUES ('Married'), ('Broken'), ('Free');

INSERT INTO Disabilities ([Name]) VALUES ('None'), ('First group'), ('Second group'), ('Third group')

INSERT INTO [dbo].[Users] ([Name], [Surname], [Lastname], [BirthDate], [Sex], [PassportSeries], [PassportNumber], [IssuedBy], [IssuedDate], [PassportId], [BirthPlace], [ResidenceCity], [ResidenceAddress], [MaritalStatus], [Citizenship], [Disability], [IsRetiree], [IsConscripted]) VALUES
('Eugene', 'Nikolaevich', 'Trakhanau', '02-10-2000', 1, 'KB', '2355426', 'Lenin', '01-01-2010', '12313121', 'Mohilow', 2, 'residence', 1, 2, 4, 0, 1),
('Alexey', 'Surname', 'Kashirsku', '10-18-2000', 1, 'KB', '2355326', 'Lenin', '01-01-2010', '123111231', 'Minsk', 2, 'residence', 1, 2, 4, 0, 1 ),
('����', '������', '���������', '10-18-2000', 1, 'KB', '2355726', 'Lenin', '01-01-2010', '123131232', '������', 2, 'residence', 1, 2, 4, 0, 1 )

INSERT INTO Currencies ([Code]) VALUES ('BYN'), ('USD'), ('EUR');

INSERT INTO AccountsTypes ([Name], [Code]) VALUES ('�������', '3014'), ('���������', '2400'), ('����� �����', '1010'), ('���� �������� �����', '7327'); 

INSERT INTO Accounts ([Number], [Code], [Active], [Debit], [Credit], [Owner], [AccountType], [Currency]) VALUES
('7327', '1234', 0, 0, 100000000000, NULL, 4, 1)

INSERT INTO DepositTypes ([IsRevocable], [Duration], [OfflinePercentByn], [OfflinePercentUsd], [OnlinePercentByn], [OnlinePercentUsd]) VALUES
(0, 45, 11.5, 2.3, 11.5, 2.3),
(1, 45, 11.5, 2.3, 10.5, 2.3);


SELECT * FROM Users

SELECT * FROM Countries;

SELECT * FROM Disabilities

SELECT * FROM AccountsTypes;

SELECT * FROM Accounts;