ALTER TABLE Accounts DROP COLUMN CalculatedBalance;
ALTER TABLE Accounts ADD Balance AS Credit - Debit + 2 * Active * (Debit - Credit) PERSISTED;