INSERT INTO Countries ([Name]) VALUES ('Belarus'), ('Ukrain'), ('Russia')

INSERT INTO Cities ([Name]) VALUES ('Minsk'), ('London'), ('Moscow'), ('Rome'), ('New York');

INSERT INTO MaritalStatuses ([Name]) VALUES ('Married'), ('Broken'), ('Free');

INSERT INTO Disabilities ([Name]) VALUES ('None'), ('First group'), ('Second group'), ('Third group')

INSERT INTO [dbo].[Users] ([Name], [Surname], [Lastname], [BirthDate], [Sex], [PassportSeries], [PassportNumber], [IssuedBy], [IssuedDate], [PassportId], [BirthPlace], [ResidenceCity], [ResidenceAddress], [MaritalStatus], [Citizenship], [Disability], [IsRetiree], [IsConscripted]) VALUES
('Eugene', 'Nikolaevich', 'Trakhanau', '02-10-2000', 1, 'KB', '2355426', 'Lenin', '01-01-2010', '12313121', 'Mohilow', 2, 'residence', 1, 2, 4, 0, 1),
('Alexey', 'Surname', 'Kashirsku', '10-18-2000', 1, 'KB', '2355326', 'Lenin', '01-01-2010', '123111231', 'Minsk', 2, 'residence', 1, 2, 4, 0, 1 ),
('Иван', 'Иванов', 'Иванонвич', '10-18-2000', 1, 'KB', '2355726', 'Lenin', '01-01-2010', '123131232', 'Сибирь', 2, 'residence', 1, 2, 4, 0, 1 )

INSERT INTO Currencies ([Code]) VALUES ('BYN'), ('USD'), ('EUR');

INSERT INTO AccountsTypes ([Name], [Code]) VALUES ('текущие', '3014'), ('Кредитные', '2400'), ('Касса банка', '1010'), ('Фонд развития банка', '7327'); 

INSERT INTO Accounts ([Number], [Code], [Active], [Debit], [Credit], [Owner], [AccountType], [Currency]) VALUES
('1010123456789', '1234', 1, 0, 0, NULL, 3, 1),
('7327', '1234', 0, 0, 100000000000, NULL, 4, 1)

INSERT INTO DepositsNames ([Name]) VALUES ('Рублю, Ergo Sum'), ('Рублю, Ergo Sum+'), ('Лучшее будущее'), ('Вклад в будущее')

INSERT INTO DepositsPlans ([Name], [Currency], [Duration], [Revocable], [Percent], [Online]) VALUES
(1, 1, 45, 0, 11.11, 0),
(1, 1, 45, 0, 11.11, 1),
(1, 1, 190, 0, 15.11, 0),
(1, 1, 190, 0, 15.11, 1),
(1, 1, 375, 0, 16.16, 1),
(1, 1, 45, 1, 9.09, 0),
(1, 1, 45, 1, 9.09, 1),
(3, 2, 24 * 30, 0, 3.50, 1) 


INSERT INTO CreditObject ([Name]) VALUES ('Automobiles'), ('Houses'), ('Personal');



SELECT * FROM Users

SELECT * FROM Countries;

SELECT * FROM Disabilities

SELECT * FROM AccountsTypes;

SELECT * FROM Accounts;

SELECT * FROM Transactions;

SELECT * FROM Deposits;

DELETE FROM Accounts WHERE Id > 1003 AND Id < 1006
