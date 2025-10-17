using System.Security;

namespace HW_03_7_7
{

    abstract class Delivery
    {
        public string? Address;
        public abstract void DeliverToAdress();
    }

    class HomeDelivery : Delivery
    {
        public string CourierName;
        public HomeDelivery(string courierName, string address) 
        {
            Address = address;
            CourierName = courierName;
        }
        public override void DeliverToAdress()
        {
            Console.WriteLine($"Вашу поссылку доставит {CourierName} по адрессу {Address}");
        }
    }

    class PickPointDelivery<TPickPoint> : Delivery
    {
        public TPickPoint PickPointNumber;

        public PickPointDelivery(TPickPoint pickPoint, string address)
        {
            Address = address;
            PickPointNumber = pickPoint;
        }
        public override void DeliverToAdress()
        {
            Console.WriteLine($"Доставка в пункт выдачи {PickPointNumber}, находящейся по адрессу {Address}");
        }
    }

    class ShopDelivery : Delivery
    {
        public string ShopName;

        public ShopDelivery(string shopName, string address)
        {
            Address=address;
            ShopName = shopName;
        }
        public override void DeliverToAdress()
        {
            Console.WriteLine($"Заберите ваш товар из магазина {ShopName}, который находится по адрессу {Address}");
        }
    }


    class Product
    {
        private string productName;
        private decimal price;

        public string ProductName
        {
            get
            {
                return productName;
            }
        }
        public decimal Price 
        {
            get 
            {
                return price;
            }
            set
            {
                if (value >= 0)
                {
                    price = value;
                }else 
                    Console.WriteLine("Цена не может быть меньше 0");
            }
        }
        public Product(string productName, decimal price)
        {
            this.productName = productName;
            this.price = price;
        }
    }

    class Client
    {
        public int Id { get; }
        private string Name { get; }
        private string Surname { get; }
        private int Age { get; }

        private string phoneNumber = "00000000000";
        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                if (value.Length == 11 && long.TryParse(value, out long corr))
                {
                    phoneNumber = value;
                }
                else
                    Console.WriteLine("Ошибка: номер телефона должен содержать ровно 11 цифр!");
            }
        }

        public Client(int id, string name, string surname, int age)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Age = age;
        }
        public void ShowInfo(int inputId)
        {
            if (inputId == Id) 
            {
                Console.WriteLine("Имя: " + Name);
                Console.WriteLine("Фамилия: " + Surname);
                Console.WriteLine("Возраст: " + Age);
            }
            
        }
    }

    class Order<TDelivery,
    TStruct> where TDelivery : Delivery
    {
        public TDelivery Delivery;

        public int Number;

        public string Description;

        public void DisplayAddress()
        {
            Console.WriteLine(Delivery.Address);
        }

        // ... Другие поля
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
