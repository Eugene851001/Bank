UPDATE SystemVariables SET CurrentDate='02-07-2022';

DELETE FROM Transactions;

DELETE FROM Deposits;

DELETE FROM Credits;
 
DELETE FROM Accounts;

INSERT INTO Accounts ([Number], [Code], [Active], [Debit], [Credit], [Owner], [AccountType], [Currency]) VALUES
('1010123456789', '1234', 1, 0, 0, NULL, 3, 1),
('7327987654321', '1234', 0, 0, 100000000000, NULL, 4, 1)
