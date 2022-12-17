using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data;
using Microsoft.Data.SqlClient;


internal class INSERT
{
    public static async Task Insert()
    {

            string connectionString = "Server=.\\SQLEXPRESS;Data Source=DESKTOP-H50SRGF;Initial Catalog=movie_catalog;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";

        using (var connection = new SqlConnection(connectionString))
        {
            await connection.OpenAsync();

            var command = new SqlCommand() { Connection = connection };
            //[genres]
            try
            {
                command.CommandText = @"
                    IF NOT EXISTS (SELECT 1 FROM [genres] WHERE [id] = '1') 
                          insert into [genres]
               VALUES (1,'Комедія '),
                    (2,'Фантастика '),
                    (3, 'Жахи '),
                    (4, 'Бойовик'),
                    (5, 'Мелодрами'),
                    (6, 'Містика'),
                    (7, 'Детектив');

                ";

                await command.ExecuteNonQueryAsync();

                Console.WriteLine("[genres] успішно заповнено");
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Помилка insert [genres] ");
                Console.Write("\nНатисніть для продовження...");
                Console.ReadKey(); Console.Clear();
            }
            //producers
            try
            {
                command.CommandText = @"
                    IF NOT EXISTS (SELECT 1 FROM producers WHERE [id] = '1') 
                          insert into producers
                 values(1, 'Альфред Хічкок'),
(2, 'Тоні Скотт'),
(3, 'Квентін Тарантіно'),
(4, 'Олівер Стоун'),
(5, 'Стенлі Кубрик'),
(6, 'Мілош Форман'),
(7, 'Джон Ву'),
(8, 'Девід Лінч'),
(9, 'Джеймс Кемерон'),
(10, 'Джон Уотерс'),
(11, 'Джон Кассаветес'),
(12, 'Макджі');

                ";

                await command.ExecuteNonQueryAsync();

                Console.WriteLine("producers успішно заповнено");
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Помилка insert producers ");
                Console.Write("\nНатисніть для продовження...");
                Console.ReadKey(); Console.Clear();
            }
            // countries
            try
            {
                command.CommandText = @"
                    IF NOT EXISTS (SELECT 1 FROM countries WHERE [id] = '1') 
                          insert into countries
                 VALUES(1, 'Австрія'),
(2, 'Бельгія'),
(3, 'Болгарія'),
(4, 'Хорватія '),
(5, 'Чехія'),
(6, 'Данія'),
(7, 'Франція'),
(8, 'Греція'),
(9, 'Франція'),
(10, 'Америка');

                ";

                await command.ExecuteNonQueryAsync();

                Console.WriteLine("countries успішно заповнено");
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Помилка countries producers ");
                Console.Write("\nНатисніть для продовження...");
                Console.ReadKey(); Console.Clear();
            }

            //languages
            try
            {
                command.CommandText = @"
                    IF NOT EXISTS (SELECT 1 FROM languages WHERE [id] = '1') 
                    INSERT INTO languages
VALUES(1, 'Англійська'),
(2, 'Іспанська'),
(3, 'Французька'),
(4, 'Португальська  '),
(5, 'Українська');

                ";

                await command.ExecuteNonQueryAsync();

                Console.WriteLine("languages успішно заповнено");
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Помилка languages producers ");
                Console.Write("\nНатисніть для продовження...");
                Console.ReadKey(); Console.Clear();
            }
            //[companies]
            try
            {
                command.CommandText = @"
                    IF NOT EXISTS (SELECT 1 FROM [companies] WHERE [id] = '1') 
                    INSERT INTO [companies]
VALUES (1,'Disney '),
(2,'Netflix '),
(3, 'Marvel '),
(4, 'DC');
                ";

                await command.ExecuteNonQueryAsync();

                Console.WriteLine("[companies] успішно заповнено");
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Помилка [companies] producers ");
                Console.Write("\nНатисніть для продовження...");
                Console.ReadKey(); Console.Clear();
            }

            //[[films]]
            try
            {
                command.CommandText = @"
                    IF NOT EXISTS (SELECT 1 FROM [films] WHERE [id] = '1') 
                    INSERT INTO [films]
values(1, 'Тенет', 'https://uakino.club/', '2020', '180', 10.0, 1, 1,1,1),
(2, 'Голодні Ігри', 'https://uakino.club/', '2010', '110', 7.3, 2, 2,2,2),
(3, 'Голодні Ігри -2', 'https://uakino.club/', '2008', '90', 9.3, 1, 2,1,3),
(4, 'Зелена миля', 'https://uakino.club/', '2000', '140', 8.3, 4, 2,2,4),
(5, 'Грінч', 'https://uakino.club/', '2014', '110', 7.0, 1, 2,1,3),
(6, 'Алладін', 'https://uakino.club/', '2012', '210', 4.0, 1, 2,1,3),
(7, 'Месники', 'https://uakino.club/', '2019', '110', 7.3, 2, 2,2,2),
(8, 'Дружина мандрівника в часі', 'https://uakino.club/', '2008', '90', 9.3, 1, 2,1,3),
(9, 'Острів козаків', 'https://uakino.club/', '1999', '140', 3.3, 4, 2,2,4),
(10, 'Платформа', 'https://uakino.club/', '2022', '90', 5.3, 2, 2,2,2),
(11, 'Перекладачі', 'https://uakino.club/', '2018', '60', 4.3, 1, 2,1,3),
(12, 'Грань майбутнього', 'https://uakino.club/', '2009', '140', 2.3, 4, 2,2,4)";


                await command.ExecuteNonQueryAsync();

                Console.WriteLine("[films] успішно заповнено");
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Помилка [films] ");
                Console.Write("\nНатисніть для продовження...");
                Console.ReadKey(); Console.Clear();
            }
            //[films_to_genres]
            try
            {
                command.CommandText = @"
                    IF NOT EXISTS (SELECT 1 FROM [films_to_genres] WHERE [film_id] = '1') 
                    INSERT INTO [films_to_genres]
values(1, 7),
(2, 5),
(3,4),
(4, 5),
(5,1),
(6,3),
(7, 5),
(7, 3),
(8, 4),
(9, 5),
(10, 1),
(11, 1),
(11, 2),
(12, 3)";

                await command.ExecuteNonQueryAsync();

                Console.WriteLine("[films_to_genres] успішно заповнено");
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Помилка [films_to_genres] producers ");
                Console.Write("\nНатисніть для продовження...");
                Console.ReadKey(); Console.Clear();
            }

            //users
            try
            {
                command.CommandText = @"
                    IF NOT EXISTS (SELECT 1 FROM users WHERE [id] = '1') 
                    INSERT INTO users
VALUES(1, 'Марія Ярема', 'maria_yav', 'qwerty'),
 (2, 'Стас Боєчко', 'stas_boue', 'tyuty'),
 (3, 'Віка Ворох', 'vika_v', 'rtyqwe'),
 (4, 'Валентин Ярема', 'v_yarema', 'ertyqw'),
 (5, 'Тарас Микитюк', 'taras_m', 'rerty');

                ";

                await command.ExecuteNonQueryAsync();

                Console.WriteLine("users успішно заповнено");
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Помилка users producers ");
                Console.Write("\nНатисніть для продовження...");
                Console.ReadKey(); Console.Clear();
            }
           
            try
            {
                command.CommandText = @"
                    IF NOT EXISTS (SELECT 1 FROM coments WHERE [id] = '1') 
                    INSERT INTO coments
 values(1, 'Класний фільм', '1', '1'),
 (2, 'Якість бомба', '2', '2'),
 (3,'Найкраще, що я бачила', '3', '3'),
 (4,'Фільм чудовий, але інтерфейс програми бажає кращого', 4, 4),
 (5, 'З нетерпінням чекаю наступної частини', 5, 5 );

                ";

                await command.ExecuteNonQueryAsync();

                Console.WriteLine("coments успішно заповнено");
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Помилка coments  ");
                Console.Write("\nНатисніть для продовження...");
                Console.ReadKey(); Console.Clear();
            }
        }
    }
}


