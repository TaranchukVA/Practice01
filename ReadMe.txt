Тестовое задание 1
Необходимо реализовать веб-сервис на ASP.NET Core. Информация о запросах и ответов методов должна логгироваться в БД.
Серверная часть
Разработать 2 метода API по технологии REST.
1.  Метод предназначен для сохранения данных в БД. Краткое описание:
	- Данный метод получает на вход json вида
		[
			{“1”: “value1”},
			{“5”: “value2”},
			{“10”: “value3”},
			...
		]
	- Преобразует его к объекту вида:
		code – код. Тип int.
		value – значение. Тип string.
	- Полученный массив необходимо отсортировать по полю code и сохранить в БД (в решении необходимо описать структуру таблицы). 
	В таблице должно быть 3 поля:
		порядковый номер,
		код,
		значение.
	Перед сохранением данных таблицу необходимо очистить.
2. Возвращает данные клиенту из таблицы в виде json. 
	Возвращаемые данные:
		порядковый номер,
		код,
		значение.
	Добавить возможность фильтрации возвращаемых данных.

Настройка:
1. В файле Appsettings.json в каталоге Exercise1 заполнить пропуски для подключения к СУБД PosetgreSQL
2. Выбрать проект Exersice1 для дальнейших действий.
3. Собрать проект
4. Запустить проект

Проверка методов:
1. Внести данные.
url: [post] {host}/action
Пример тела запроса:
[
	{"1": "value1"},
	{"5": "value2"},
	{10": "value3"},
]

2. Получить записи
	url все записи : [get] {host}/action,
Первые count записей используется параметр take
	url первые две : [get] {host}/action?method=take&count=2
Пропустить count используется параметр skip
	url пропустить одну : [get] {host}/action?method=skip&count=1

Тестовое задание 2
Даны таблицы:
Clients - клиенты
(
	Id bigint, -- Id клиента
	ClientName nvarchar(200) -- Наименование клиента
);
ClientContacts - контакты клиентов
(
	Id bigint, -- Id контакта
	ClientId bigint, -- Id клиента
	ContactType nvarchar(255), -- тип контакта
	ContactValue nvarchar(255) --  значение контакта
);
1.	Написать запрос, который возвращает наименование клиентов и кол-во контактов клиентов
2.	Написать запрос, который возвращает список клиентов, у которых есть более 2 контактов

Решение:
1. SQL запрос, который возвращает наименование клиентов и кол-во контактов клиентов
SELECT C.ClientName, count(CC.Id) FROM Clients AS C
	INNER JOIN ClientContacts as CC
	ON C.ID  CC.ClientId
	GROUP BY	(CC.ClientId)

	
2. SQL запрос, который возвращает список клиентов, у которых есть более 2 контактов
SELECT C.Id, C.ClientName, FROM Clients AS C
	INNER JOIN ClientContacts as CC
	ON C.ID  CC.ClientId
	GROUP BY (CC.ClientId)
	HAVING (count(CC.Id)>2)
