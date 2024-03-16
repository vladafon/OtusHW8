INSERT INTO public.users(
	first_name, last_name, age)
	VALUES ('Василий', 'Пупкин', 45);
INSERT INTO public.users(
	first_name, last_name, age)
	VALUES ('Георгий', 'Иванов', 32);
INSERT INTO public.users(
	first_name, last_name, age)
	VALUES ('Владислав', 'Громыко', 24);
INSERT INTO public.users(
	first_name, last_name, age)
	VALUES ('Константин', 'Павленко', 28);
INSERT INTO public.users(
	first_name, last_name, age)
	VALUES ('Сергей', 'Куценко', 41);

INSERT INTO public.categories(
	name)
	VALUES ('Одежда');
INSERT INTO public.categories(
	name)
	VALUES ('Электроника');
INSERT INTO public.categories(
	name)
	VALUES ('Автомобилные аксессуары');
INSERT INTO public.categories(
	name)
	VALUES ('Обувь');
INSERT INTO public.categories(
	name)
	VALUES ('Мебель');

INSERT INTO public.advertisments(
	name, description, creatorid, categoryid, price)
	VALUES ('Монитор компьютерный 15 дюймов', 'Продаю новый монитор в коробке, возможен торг.', 1, 2, 15500);
INSERT INTO public.advertisments(
	name, description, creatorid, categoryid, price)
	VALUES ('Шкаф для вещей', 'Продаем шкаф для верхней одежды, торг уместен.', 2, 5, 3500);
INSERT INTO public.advertisments(
	name, description, creatorid, categoryid, price)
	VALUES ('Куртка зимняя', 'Торга нет, носил один сезон.', 3, 1, 3000);
INSERT INTO public.advertisments(
	name, description, creatorid, categoryid, price)
	VALUES ('Магнитола Incar', 'Продам магнитолу для Лада Гранта, использовалась 2 года.', 4, 3, 20000);
INSERT INTO public.advertisments(
	name, description, creatorid, categoryid, price)
	VALUES ('Кроссовки Адидас', 'Кроссовки требуют ремонта, поэтмоу продаются дешево', 5, 4, 500);
