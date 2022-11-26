	CREATE TABLE Employees 
(
Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
Name NVARCHAR(255) NOT NULL,
TabelId INT  NOT NULL,
Gender NVARCHAR(10) NOT NULL,
DateBirthday DATE NOT NULL,
Division NVARCHAR(100) NOT NULL,
Education NVARCHAR(100) NOT NULL,
Employment DATE NOT NULL,
Dismissals DATE
);

INSERT INTO Employees (Name, TabelId, Gender, DateBirthday, Division, Education, Employment) 
VALUES ('Плюснин Максим Александрович', 1, 'Мужской', '2000-11-26', 'Информационные технологии', 'Высшее, Бакалавриат', '2022-11-23')
INSERT INTO Employees (Name, TabelId, Gender, DateBirthday, Division, Education, Employment) 
VALUES ('Когдина Елизавета Андреевна', 2, 'Женский', '1999-01-01', 'Управление персоналом', 'Высшее, Магистратура', '2022-11-19')