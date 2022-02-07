--DROP TRIGGER [trg_account_balance_update]
--CREATE TRIGGER [trg_account_balance_update]
--ON [Accounts]
--AFTER INSERT, UPDATE
--AS
--	DECLARE @Balance money;
--	IF ((SELECT [Active] FROM inserted) = 0)
--		SET @Balance = (SELECT [Credit] FROM inserted) - (SELECT [Debit] FROM [inserted])
--	ELSE
--		SET @Balance = (SELECT [Debit] FROM inserted) - (SELECT [Credit] FROM inserted);

--	UPDATE [Accounts] SET [Balance] = @Balance WHERE [Accounts].[Id] = (SELECT [Id] FROM inserted);


DROP TRIGGER [trg_account_number_check];
CREATE TRIGGER [trg_account_number_check]
ON [Accounts]
AFTER INSERT
AS
	DECLARE @code CHAR(4);
	DECLARE @number CHAR(13);
	DECLARE @msg VARCHAR(256);
	SET @code=(SELECT [Code] FROM [AccountsTypes] WHERE [AccountsTypes].[Id] = (SELECT [AccountType] FROM [inserted]));
	SET @number=(SELECT [Number] FROM [Accounts] WHERE [Accounts].[Id]=(SELECT [Id] FROM inserted));
	
	IF (SUBSTRING(@number, 0, 5) != @code)
	BEGIN
		SET @msg=CONCAT('Invalid account number, expeted code:', @code, ' Actual: ', SUBSTRING(@number, 0, 5));
		RAISERROR(@msg, 16, 1);
		ROLLBACK TRANSACTION;
		RETURN;
	END;

