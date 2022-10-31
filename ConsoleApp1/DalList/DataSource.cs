﻿namespace Dal;

static internal class DataSource
{
    static readonly System.Random _random;

    static internal class Config
    {
        internal static int amountOrder = 0;
        internal static int amountOrderItem = 0;
        internal static int amountProducts = 0;

        static private int _order = 0;
        static public int Order
        {
            get { return _order; }
        }

        static private int _itemInOrder = 0;
        static public int ItemInOrder
        {
            get { return _itemInOrder++; }
        }
    }

    static DataSource()
    {
        s_Initialize();
    }
    const int orders1 = 100;
    const int orderItem1 = 200;
    const int product1 = 50;

    static internal DO.Orders[] orders = new DO.Orders[orders1];
    static internal DO.OrderItem[] orderItems = new DO.OrderItem[orderItem1];
    static internal DO.Product[] products = new DO.Product[product1];




    static void AddOrederItem(DO.OrderItem orderItem)
    {
        if(Config.amountOrderItem <= orderItem1)
        {
            orderItems[Config.amountOrderItem] = orderItem;
            Config.amountOrderItem++;
        }
        else
        {
            Console.WriteLine("error");
        }
    }

    static void AddOrder(DO.Orders NewOrder)
    {
        if(Config.amountOrder <= orders1)
        {
            orders[Config.amountOrder] = NewOrder;
            Config.amountOrder++;
        }
        else
        {
            Console.WriteLine("error");
        }
    }

    static void AddProduct(DO.Product newProduct)
    {
        if(Config.amountProducts <= product1)
        {
            products[Config.amountProducts] = newProduct;
            Config.amountProducts++;
        }
        else
        {
            Console.WriteLine("error");
        }
    }

    static private void s_Initialize()
    {
        (string, string)[] products1 =
        {
            ("",""),
            ("",""),
            ("",""),
            ("",""),
            ("",""),
            ("",""),
            ("",""),
            ("",""),
            ("",""),
            ("",""),
        };

        for (int i = 0; i < 10; i++)
        {
            int price = (int)_random.NextInt64(20000, 7000000);
            int amount = (int)_random.NextInt64(100);
            int id = (int)_random.NextInt64(100000, 999999);
            int j = 0;
            while (j < products.Length)
            {
                if (products[j].ID == id)
                {
                    id = (int)_random.NextInt64(100000, 999999);
                    j = 0;
                }
                else
                {
                    j++;
                }
            }
            DO.Product product = new DO.Product { ID = id, Name = products1[i].Item1, Category = products1[i].Item2, Price = price, InStock= amount };
            AddProduct(product);
        }
        (string, string, string)[] orders1 = {
            ("shany kravitz", "shany@gmail.com","bircat avraham"),
            ("chani mizrachi", "chani@gmail.com","mintz"),
            ("bat-chen dikman", "bat-chen@gmail.com","recanaty"),
            ("batsheva ben paz", "batsheva@gmail.com","ely hacohen"),
            ("tahila maimon", "tahila@gmail.com","bar ealan"),
            ("noa siton", "noa@gmail.com","rubin"),
            ("bitya shlezunger", "bitya@gmail.com","zarchi"),
            ("ariela druk", "ariel@gmail.com","truman"),
            ("yair dupark", "yair@gmail.com","ben zeev"),
            ("avishay mehudar", "avishay@gmail.com","idelzon"),
            ("neomi chadad","neomi@gmail.com","druk"),
            ("yael shitrit", "yael@gmail.com", "zolty"),
            ("tamar cohen","tamar@gmail.com","makor baruch"),
            ("hadasa levi","hadasa@gmail.com","brim"),
            ("efrat shiran","efrat@gmail.com","chazon eash"),
            ("ruth nachumy", "ruth@gmail.com","fatal"),
            ("michal ochayon","michal@gmail.com","mutzafy"),
            ("dvora tavill","dvora@gmail.com", "shtefenesh"),
            ("ayala rozner","ayala@gmail.com","toledano"),
            ("sara lavi", "sara@gmail.com","cahaneman")
        };
        for (int i = 0; i < 20; i++)
        {
            DateTime date1 = DateTime.MinValue;
            DateTime date2 = DateTime.MinValue;
            int daySend = (int)_random.NextInt64(5, 10);
            int dayGet = (int)_random.NextInt64(5, 10);
            TimeSpan dateSend = new TimeSpan(daySend, 0, 0, 0);
            TimeSpan dateGet = new TimeSpan(dayGet, 0, 0, 0);
            DO.Orders order = new DO.Orders { ID = Config.Order, CustomerName = orders1[i].Item1, CustomerEmail = orders1[i].Item2, CustomerAdress = orders1[i].Item3, OrderDate = date1, ShipDate = date1.Add(dateSend), DeliveryDate = date2.Add(dateGet) };
            AddOrder(order);
        }
        for (int i = 0; i < 40; i++)
        {
            int idOrder = (int)_random.NextInt64(Config.amountOrder);
            int idProduct = (int)_random.NextInt64(100000, Config.amountProducts);
            DO.OrderItem itemInOrder = new DO.OrderItem { ID = Config.ItemInOrder, OrderID = orders[idOrder].ID, ProductID = products[idProduct].ID, Price = products[idProduct].Price };
            AddOrederItem(itemInOrder);
        }
    }
}
