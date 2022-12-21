namespace Exchange_rates.Models
{
    public class Cache
    {
        public BankAPI USD { get; set; }//id 431 
        public BankAPI EUR { get; set; }//id 451
        public BankAPI RUB { get; set; }// id 456
        public BankAPI BTC { get; set; } // Необязательно

        //сохранение кеша в файл

        //как будет работать считывание кеша. 
        //Есть файл кеша, если там нет данных по текущему периоду, то добавить их туда, если есть то обращаться
        //к файлу а не апи.

        //запрос на динамический период:
        //https://www.nbrb.by/api/exrates/rates/dynamics/{id}?startdate={2022-5-5}&enddate={date}

        //Единичный запрос данных
        // 
        //проверка дат должна быть по объектам конкретной валюты linq запросы
        //для проверки на отсутствие можно использовать разность множеств
    }

}
