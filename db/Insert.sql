INSERT INTO Countries ([Name]) VALUES ('Belarus'), ('Ukrain'), ('Russia')

INSERT INTO Cities ([Name]) VALUES ('Minsk'), ('London'), ('Moscow'), ('Rome'), ('New York');

INSERT INTO MaritalStatuses ([Name]) VALUES ('Married'), ('Broken'), ('Free');

INSERT INTO Disabilities ([Name]) VALUES ('None'), ('First group'), ('Second group'), ('Third group')

INSERT INTO [dbo].[Users] ([Name], [Surname], [Lastname], [BirthDate], [Sex], [PassportSeries], [PassportNumber], [IssuedBy], [IssuedDate], [PassportId], [BirthPlace], [ResidenceCity], [ResidenceAddress], [MaritalStatus], [Citizenship], [Disability], [IsRetiree], [IsConscripted], [Deleted]) VALUES
('Eugene', 'Nikolaevich', 'Trakhanau', '02-10-2000', 1, 'KB', '2355426', 'Lenin', '01-01-2010', '12313121', 'Mohilow', 2, 'residence', 1, 2, 4, 0, 1, 0),
('Alexey', 'Surname', 'Kashirsku', '10-18-2000', 1, 'KB', '2355326', 'Lenin', '01-01-2010', '123111231', 'Minsk', 2, 'residence', 1, 2, 4, 0, 1, 0),
('????', '??????', '?????????', '10-18-2000', 1, 'KB', '2355726', 'Lenin', '01-01-2010', '123131232', '??????', 2, 'residence', 1, 2, 4, 0, 1, 0)

INSERT INTO Currencies ([Code]) VALUES ('BYN'), ('USD'), ('EUR');

INSERT INTO AccountsTypes ([Name], [Code]) VALUES ('???????', '3014'), ('?????????', '2400'), ('????? ?????', '1010'), ('???? ???????? ?????', '7327'); 

INSERT INTO Accounts ([Number], [Code], [Active], [Debit], [Credit], [Owner], [AccountType], [Currency]) VALUES
('1010123456789', '1234', 1, 0, 0, NULL, 3, 1),
('7327987654321', '1234', 0, 0, 100000000000, NULL, 4, 1)

INSERT INTO DepositsNames ([Name]) VALUES ('?????, Ergo Sum'), ('?????, Ergo Sum+'), ('?????? ???????'), ('????? ? ???????')

INSERT INTO DepositsPlans ([Name], [Currency], [Duration], [Revocable], [Percent], [Online]) VALUES
(1, 1, 45, 0, 11.11, 0),
(1, 1, 45, 0, 11.11, 1),
(1, 1, 190, 0, 15.11, 0),
(1, 1, 190, 0, 15.11, 1),
(1, 1, 375, 0, 16.16, 1),
(1, 1, 45, 1, 9.09, 0),
(1, 1, 45, 1, 9.09, 1),
(3, 2, 24 * 30, 0, 3.50, 1) 


INSERT INTO CreditsObjects ([Name]) VALUES ('Automobiles'), ('Houses'), ('Personal');


INSERT INTO CreditsNames ([Name]) VALUES 
('NISSAN'),
('????????????'),
('White Sales'),
('???? ?')

SELECT * FROM CreditPlans;

INSERT INTO CreditPlans ([Duration], [Percent], [Name], [Object], [MinValue], [Currency], [Annuity]) VALUES
(365, 20.38, 4, 3, 100000, 1, 1),
(365, 0.01, 1, 1, 3000, 1,  1),
(36 * 30, 15.99, 1, 1, 3000, 1, 0),
(30 * 12, 20.38, 4, 3, 3000, 1, 0)

INSERT INTO SystemVariables ([CurrentDate]) VALUES ('07-02-2022')

--FOR ATM--
INSERT INTO Accounts ([Number], [Code], [Active], [Debit], [Credit], [Owner], [AccountType], [Currency]) VALUES
('2400123456789', '1234', 1, 0, 0, NULL, 2, 1),
('2400987654321', '1234', 1, 1000, 0, NULL, 2, 1)

INSERT INTO Cards ([Number], [Pin], [Account]) VALUES
('0000111122223333', '1223', (SELECT TOP 1 [Id] FROM Accounts WHERE [Accounts].Number='2400123456789')),
('1111222233334444', '1334', (SELECT TOP 1 [Id] FROM Accounts WHERE [Accounts].Number='2400987654321'))

UPDATE Accounts SET [Debit] = 128 WHERE Accounts.Number='c'
----

SELECT * FROM Cards

UPDATE SystemVariables SET CurrentDate='02-18-2022'

SELECT * FROM SystemVariables;

SELECT * FROM Users

SELECT * FROM Countries;

SELECT * FROM Disabilities

SELECT * FROM AccountsTypes;

SELECT * FROM Accounts;

SELECT * FROM Transactions;

SELECT * FROM Deposits;

SELECT * FROM Credits;

SELECT * FROM CreditPlans;

SELECT * FROM CreditsObjects;

DELETE FROM Accounts WHERE Id > 1003 AND Id < 1006

DELETE FROM Deposits;

DELETE FROM Credits;

DELETE FROM Accounts;

DELETE FROM Cards;

DELETE FROM Transactions;

SELECT * FROM Users;

UPDATE Users SET Deleted=0

SELECT * FROM Transactions JOIN Accounts ON Transactions.Source 