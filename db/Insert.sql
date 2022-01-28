INSERT INTO Countries ([Name]) VALUES ('Belarus'), ('Ukrain'), ('Russia')

INSERT INTO Cities ([Name]) VALUES ('Minsk'), ('London'), ('Moscow'), ('Rome'), ('New York');

INSERT INTO MaritalStatuses ([Name]) VALUES ('Married'), ('Broken'), ('Free');

INSERT INTO Disabilities ([Name]) VALUES ('None'), ('First group'), ('Second group'), ('Third group')


INSERT INTO [dbo].[Users] ([Name], [Surname], [Lastname], [BirthDate],  [PassportSeries], [PassportNumber], [IssuedBy], [IssuedDate], [PassportId], [BirthPlace], [ResidenceCity], [ResidenceAddress], [MaritalStatus], [Citizenship], [Disability], [IsRetiree], [IsConscripted]) VALUES
('Eugene', 'Nikolaevich', 'Trakhanau', '02-10-2000', 1, 'KB', '2355526', 'Lenin', '01-01-2010', '123131231', 'Mohilow', 2, 'residence', 1, 2, 4, 0, 1),
('Alexey', 'Surname', 'Kashirsku', '10-18-2000', 1, 'KB', '2355526', 'Lenin', '01-01-2010', '123131231', 'Minsk', 2, 'residence', 1, 2, 4, 0, 1 ),
('Иван', 'Иванов', 'Иванонвич', '10-18-2000', 1, 'KB', '2355526', 'Lenin', '01-01-2010', '123131231', 'Сибирь', 2, 'residence', 1, 2, 4, 0, 1 )

SELECT * FROM Users

SELECT * FROM Countries;

SELECT * FROM Disabilities