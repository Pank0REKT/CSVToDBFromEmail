### Выполнено по техническому заданию:
```
На почтовый ящик компании "ООО "Запчасти даром" приходит прайс-лист от поставщика "ООО "Доставим в срок"
Прайс-лист представляет из себя csv файл, образец которого во вложении. В прайсе содержится информация об автозапчастях, которые доставляет поставщик.
Необходимо написать консольное или web приложение, которое скачивает прайс с почтового ящика и загружает в базу.

Входные данные.

Необходимо загрузить в таблицу PriceItems БД (любую реляционную) со структурой
	- Vendor varchar(64) - производитель
	- Number varchar(64) - номер запчасти
	- SearchVendor varchar(64) - производитель для поиска
	- SearchNumber varchar(64) - номер для поиска
	- Description varchar(512) - наименование
	- Price decimal(18,2) - цена
	- Count int - количество

Данные из прайс листа, но только определенные колонки.
Нужные колонки из файла: 
	- "Бренд" загрузить в Vendor
	- "Каталожный номер" загрузить в Number
	- "Описание" загрузить в Description
	- "Цена" в Price
	- "Наличие" в Count

	
При выполнении задания следует учесть:
	- компании "ООО "Запчасти даром" присылают прайсы несколько поставщиков, поэтому порядок колонок и их наименование
	в прайсе может меняться, поэтому сопоставление колонок нужно конфигурировать в зависимости от поставщика. В данном случае
	достаточно одной конфигурации под поставщика "ООО "Доставим в срок"
	- почтовый ящик так же должен конфигурироваться (использовать протокол IMAP для получения письма). 
	Прайс-лист будет вложением к письму, при чем имя файла не регламентировано, известно только, что расширение .csv
	- при загрузке в базу следует заполнить поля SearchVendor и SearchNumber путем удаления из них всех нецифернобуквенных символов 
	и преобразования к верхнему регистру символов полей Vendor и Number соответственно
	- колонка с количеством может содержать в себе записи вида >10, <13, 10-50. В первом случае нужно загрузить просто 10 и 13, во втором 50
	- колонка "Описание" может содержать более 512 символов, в таком случае необходимо ее обрезать до 512
```
