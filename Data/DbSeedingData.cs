using Application.Models;
using System.Collections.Generic;

namespace Application.Data
{
    public class DbSeedingData
    {
        public static List<BookData> GetList()
        {
            var data = new List<BookData>() {

                new BookData(new Book(){
                    Title =  "451° по Фаренгейту",
                    Author =  "Рэй Брэдбери",
                    ImageURL =  "https://readrate.com/img/pictures/book/292/29286/29286/w160h240-stretch-5ed3128e.jpg"},
                    new List<string>() {"Роман", "Фантастика", "Антиутопия", "Политика"}
                ),
                new BookData(new Book()
                {
                    Title = "1984",
                    Author = "Джордж Оруэлл",
                    ImageURL = "https://readrate.com/img/pictures/book/295/29554/29554/w160h240-stretch-eccecf43.jpg"
                },
                    new List<string>() { "Фантастика", "Антиутопия", "Политика" }
                ),
                new BookData(new Book()
                {
                    Title = "Мастер и Маргарита",
                    Author = "Михаил Булгаков",
                    ImageURL = "https://readrate.com/img/pictures/book/294/29495/29495/w160h240-stretch-98cc5ada.jpg"
                },
                    new List<string>() {"Роман", "Фантастика", "Сатира", "Фарс",}
                ),
                new BookData(new Book()
                {
                    Title = "Шантарам",
                    Author = "Грегори Дэвид Робертс",
                    ImageURL = "https://readrate.com/img/pictures/book/300/30024/30024/w160h240-stretch-1cf76e6f.jpg"
                },
                    new List<string>() { "Роман", "Автобиография", "Приключения" }
                ),
                new BookData(new Book()
                {
                    Title = "Три товарища",
                    Author = "Эрих Мария Ремарк",
                    ImageURL = "https://readrate.com/img/pictures/book/338/33800/33800/w160h240-stretch-dfdf5ef1.jpg"
                },
                    new List<string>() { "Роман", "Военная проза", }
                ),
                new BookData(new Book()
                {
                    Title = "Цветы для Элджернона",
                    Author = "Дэниел Киз",
                    ImageURL = "https://readrate.com/img/pictures/book/292/29234/29234/w160h240-stretch-c262b73b.jpg"
                },
                    new List<string>() { "Роман", "Фантастика" }
                ),
                new BookData(new Book()
                {
                    Title = "Портрет Дориана Грея",
                    Author = "Оскар Уайльд",
                    ImageURL = "https://readrate.com/img/pictures/book/298/29818/29818/w160h240-stretch-bd100eb2.jpg"
                },
                    new List<string>() { "Драма", "Философия" }
                ),
                new BookData(new Book()
                {
                    Title = "Маленький принц",
                    Author = "Антуан де Сент-Экзюпери",
                    ImageURL = "https://readrate.com/img/pictures/book/293/29327/29327/w160h240-stretch-499ebbc7.jpg"
                },
                    new List<string>() { "Сказка", "Философия" }
                ),
                new BookData(new Book()
                {
                    Title = "Над пропастью во ржи",
                    Author = "Джером Д. Сэлинджер",
                    ImageURL = "https://readrate.com/img/pictures/book/292/29246/29246/w160h240-stretch-f51a369a.jpg"
                },
                    new List<string>() { "Роман", "Реализм" }
                ),
                new BookData(new Book()
                {
                    Title = "Вино из одуванчиков",
                    Author = "Рэй Брэдбери",
                    ImageURL = "https://readrate.com/img/pictures/book/336/33689/33689/w160h240-stretch-b635537e.jpg"
                },
                    new List<string>() { "Роман", "Автобиография", "Фантастика" }
                ),
                new BookData(new Book()
                {
                    Title = "Анна Каренина",
                    Author = "Лев Толстой",
                    ImageURL = "https://readrate.com/img/pictures/book/292/29215/29215/w160h240-stretch-14102c89.jpg"
                },
                    new List<string>() { "Роман", "Реализм" }
                ),
                new BookData(new Book()
                {
                    Title = "Убить пересмешника",
                    Author = "Харпер Ли",
                    ImageURL = "https://readrate.com/img/pictures/book/296/29607/29607/w160h240-stretch-52cda18b.jpg"
                },
                    new List<string>() { "Роман", "Триллер" }
                ),
                new BookData(new Book()
                {
                    Title = "Преступление и наказание",
                    Author = "Фёдор Достоевский",
                    ImageURL = "https://readrate.com/img/pictures/book/292/29212/29212/w160h240-stretch-1d96f673.jpg"
                },
                    new List<string>() { "Роман", "Реализм", "Философия" }
                ),
                new BookData(new Book()
                {
                    Title = "Сто лет одиночества",
                    Author = "Габриэль Гарсиа Маркес",
                    ImageURL = "https://readrate.com/img/pictures/book/292/29264/29264/w160h240-stretch-11eb2520.jpg"
                },
                    new List<string>() { "Роман" }
                ),
                new BookData(new Book()
                {
                    Title = "Библия. Синодальный перевод",
                    Author = "Священный синод",
                    ImageURL = "https://readrate.com/img/pictures/book/291/29199/29199/w160h240-stretch-f59684b8.jpg"
                },
                    new List<string>() { "Роман", "Фантастика" }
                ),
                new BookData(new Book()
                {
                    Title = "Двенадцать стульев",
                    Author = "Евгений Петров",
                    ImageURL = "https://readrate.com/img/pictures/book/291/29197/29197/w160h240-stretch-63957cb3.jpg"
                },
                    new List<string>() { "Комедия", "Приключения" }
                ),
                new BookData(new Book()
                {
                    Title = "Идиот",
                    Author = "Фёдор Достоевский",
                    ImageURL = "https://readrate.com/img/pictures/book/291/29181/29181/w160h240-stretch-6a74c9a1.jpg"
                },
                    new List<string>() { "Роман" }
                ),
                new BookData(new Book()
                {
                    Title = "Триумфальная арка",
                    Author = "Эрих Мария Ремарк",
                    ImageURL = "https://readrate.com/img/pictures/book/337/33786/33786/w160h240-stretch-743534b6.jpg"
                },
                    new List<string>() { "Роман", "Военная проза", "История" }
                ),
                new BookData(new Book()
                {
                    Title = "Граф Монте-Кристо",
                    Author = "Александр Дюма",
                    ImageURL = "https://readrate.com/img/pictures/book/326/32605/32605/w160h240-stretch-82407015.jpg"
                },
                    new List<string>() { "Роман", "Приключения", "История" }
                ),
                new BookData(new Book()
                {
                    Title = "Великий Гэтсби",
                    Author = "Фрэнсис Скотт Фицджеральд",
                    ImageURL = "https://readrate.com/img/pictures/book/294/29494/29494/w160h240-stretch-a9fa0311.jpg"
                },
                    new List<string>() { "Роман", "Драма" }
                ),
                new BookData(new Book()
                {
                    Title = "Евгений Онегин",
                    Author = "Александр Пушкин",
                    ImageURL = "https://readrate.com/img/pictures/book/292/29277/29277/w160h240-stretch-93836749.jpg"
                },
                    new List<string>() { "Роман" }
                ),
                new BookData(new Book()
                {
                    Title = "Гарри Поттер и философский камень",
                    Author = "Джоан К. Роулинг",
                    ImageURL = "https://readrate.com/img/pictures/book/295/29520/29520/w160h240-stretch-e852756c.jpg"
                },
                    new List<string>() { "Фантастика", "Приключения" }
                ),
                new BookData(new Book()
                {
                    Title = "Жизнь взаймы",
                    Author = "Эрих Мария Ремарк",
                    ImageURL = "https://readrate.com/img/pictures/book/334/33466/33466/w160h240-stretch-b74fb2d6.jpg"
                },
                    new List<string>() { "Роман" }
                ),
                new BookData(new Book()
                {
                    Title = "Гордость и предубеждение",
                    Author = "Джейн Остин",
                    ImageURL = "https://readrate.com/img/pictures/book/293/29341/29341/w160h240-stretch-9d43f037.jpg"
                },
                    new List<string>() { "Роман", "Драма" }
                ),
                new BookData(new Book()
                {
                    Title = "Бойцовский клуб",
                    Author = "Чак Паланик",
                    ImageURL = "https://readrate.com/img/pictures/book/339/33934/33934/w160h240-stretch-7c857764.jpg"
                },
                    new List<string>() { "Триллер", "Драма" }
                ),new BookData(new Book()
                    {
                        Title = "Зелёная миля",
                        Author = "Стивен Кинг",
                        ImageURL = "https://readrate.com/img/pictures/book/293/29370/29370/w160h240-stretch-f2170730.jpg"
                    },
                    new List<string>() { "Драма" }
                ),
                new BookData(new Book()
                {
                    Title = "Война и мир",
                    Author = "Лев Толстой",
                    ImageURL = "https://readrate.com/img/pictures/book/292/29243/29243/w160h240-stretch-20b3eacf.jpg"
                },
                    new List<string>() { "Роман", "Военная проза", "История", "Философия" }
                ),
                new BookData(new Book()
                {
                    Title = "О дивный новый мир",
                    Author = "Олдос Хаксли",
                    ImageURL = "https://readrate.com/img/pictures/book/347/34788/34788/w160h240-stretch-b5067d6d.jpg"
                },
                    new List<string>() { "Роман", "Фантастика", "Антиутопия" }
                ),
                new BookData(new Book()
                {
                    Title = "Герой нашего времени",
                    Author = "Михаил Лермонтов",
                    ImageURL = "https://readrate.com/img/pictures/book/292/29268/29268/w160h240-stretch-4e3ff9cf.jpg"
                },
                    new List<string>() { "Роман", "Реализм" }
                ),
                new BookData(new Book()
                {
                    Title = "Братья Карамазовы",
                    Author = "Фёдор Достоевский",
                    ImageURL = "https://readrate.com/img/pictures/book/292/29235/29235/w160h240-stretch-42bbd4ef.jpg"
                },
                    new List<string>() { "Роман", "Философия" }
                ),
                new BookData(new Book()
                {
                    Title = "Унесённые ветром",
                    Author = "Маргарет Митчелл",
                    ImageURL = "https://readrate.com/img/pictures/book/292/29276/29276/w160h240-stretch-7b5a6c18.jpg"
                },
                    new List<string>() { "Роман", "Военная проза", "История", "Драма" }
                ),
                new BookData(new Book()
                {
                    Title = "Гарри Поттер и орден Феникса",
                    Author = "Джоан К. Роулинг",
                    ImageURL = "https://readrate.com/img/pictures/book/303/30396/30396/w160h240-stretch-7538b34a.jpg"
                },
                    new List<string>() { "Фантастика", "Приключения" }
                ),
                new BookData(new Book()
                {
                    Title = "Дом, в котором…",
                    Author = "Мариам Петросян",
                    ImageURL = "https://readrate.com/img/pictures/book/340/34067/34067/w160h240-stretch-c561d3c2.jpg"
                },
                    new List<string>() { "Роман" }
                ),
                new BookData(new Book()
                {
                    Title = "Понедельник начинается в субботу",
                    Author = "братья Стругацкие",
                    ImageURL = "https://readrate.com/img/pictures/book/324/32468/32468/w160h240-stretch-939d197d.jpg"
                },
                    new List<string>() { "Фантастика" }
                ),
                new BookData(new Book()
                {
                    Title = "Бесы",
                    Author = "Фёдор Достоевский",
                    ImageURL = "https://readrate.com/img/pictures/book/292/29213/29213/w160h240-stretch-8fc1133d.jpg"
                },
                    new List<string>() { "Роман", "Сатира", "Философия", "Политика" }
                ),
                new BookData(new Book()
                {
                    Title = "Гарри Поттер и тайная комната",
                    Author = "Джоан К. Роулинг",
                    ImageURL = "https://readrate.com/img/pictures/book/303/30393/30393/w160h240-stretch-6d7b1c1b.jpg"
                },
                    new List<string>() { "Фантастика", "Приключения" }
                ),
                new BookData(new Book()
                {
                    Title = "Мёртвые души",
                    Author = "Николай Гоголь",
                    ImageURL = "https://readrate.com/img/pictures/book/292/29249/29249/w160h240-stretch-b1f28b0b.jpg"
                },
                    new List<string>() { "Роман", "Сатира" }
                ),
                new BookData(new Book()
                {
                    Title = "Алхимик",
                    Author = "Пауло Коэльо",
                    ImageURL = "https://readrate.com/img/pictures/book/341/34165/34165/w160h240-stretch-3d59c972.jpg"
                },
                    new List<string>() { "Роман", "Драма", "Фантастика", "Приключения" }
                ),
                new BookData(new Book()
                {
                    Title = "Собачье сердце",
                    Author = "Михаил Булгаков",
                    ImageURL = "https://readrate.com/img/pictures/book/323/32373/32373/w160h240-stretch-f2cc5e14.jpg"
                },
                    new List<string>() { "Фантастика", "Сатира" }
                ),
                new BookData(new Book()
                {
                    Title = "Гарри Поттер и узник Азкабана",
                    Author = "Джоан К. Роулинг",
                    ImageURL = "https://readrate.com/img/pictures/book/303/30394/30394/w160h240-stretch-c1dc3b7d.jpg"
                },
                    new List<string>() { "Фантастика", "Приключения" }
                ),
                new BookData(new Book()
                {
                    Title = "Игра престолов",
                    Author = "Джордж Р. Р. Мартин",
                    ImageURL = "https://readrate.com/img/pictures/book/293/29392/29392/w160h240-stretch-dc21b588.jpg"
                },
                    new List<string>() { "Роман", "Драма", "Фантастика", "Приключения" }
                ),
                new BookData(new Book()
                {
                    Title = "Гарри Поттер и Кубок огня",
                    Author = "Джоан К. Роулинг",
                    ImageURL = "https://readrate.com/img/pictures/book/303/30395/30395/w160h240-stretch-15bac4cb.jpg"
                },
                    new List<string>() { "Фантастика", "Приключения" }
                ),
                new BookData(new Book()
                {
                    Title = "Старик и море",
                    Author = "Эрнест Хемингуэй",
                    ImageURL = "https://readrate.com/img/pictures/book/336/33645/33645/w160h240-stretch-6a7e137a.jpg"
                },
                    new List<string>() { "Роман" }
                ),
                new BookData(new Book()
                {
                    Title = "На Западном фронте без перемен",
                    Author = "Эрих Мария Ремарк",
                    ImageURL = "https://readrate.com/img/pictures/book/341/34140/34140/w160h240-stretch-595864ee.jpg"
                },
                    new List<string>() { "Драма", "Военная проза", "Приключения" }
                ),
                new BookData(new Book()
                {
                    Title = "Мартин Иден",
                    Author = "Джек Лондон",
                    ImageURL = "https://readrate.com/img/pictures/book/339/33999/33999/w160h240-stretch-8b7e179b.jpg"
                },
                    new List<string>() { "Роман", "Фантастика" }
                )

            };
            return data;
        }
    }
}
