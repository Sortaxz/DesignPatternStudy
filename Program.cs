namespace DesignPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CustomerManager customerManager = CustomerManager.CreateAsSingeleton();

            Example_1.GetInstance();
            Example_1.GetInstance();
            Example_1.GetInstance();
            Example_1.GetInstance();
            Example_1.GetInstance();

        }
    }



    #region
    class CustomerManager
    {
        static CustomerManager customerManager;
        static object lockObject = new object();
        private CustomerManager()
        {

        }

        public static CustomerManager CreateAsSingeleton()
        {
            lock(lockObject)
            {
                if(customerManager == null) 
                {
                    customerManager = new CustomerManager();
                }
            }
            return customerManager;
        }

        public  void Save()
        {
            Console.WriteLine("Save");
        }
            

    }
    #endregion

    #region Example 1
    class Example
    {
        private Example()
        {
            Console.WriteLine($"{nameof(Example)} nesnesi oluşturuldu");
        }

        private static Example instance;
        
        static Example()
        {
            instance = new Example();
        }


        public static Example GetInstance
        {
            get
            {
                /*
                if(instance == null) 
                {
                    instance = new Example();
                }
                return instance;
                */

                return instance;
            }
        }
    }
    #endregion

    #region Example 2

    public class DatabaseService
    {
        private DatabaseService() 
        {
            Console.WriteLine($"{nameof(DatabaseService)} is created");
        }

        private static DatabaseService instance;

        public static DatabaseService GetInstance
        {
            get
            {
                if( instance == null )
                {
                    instance = new DatabaseService();
                }

                return instance;
            }
        }

        private int connectionCount;
        public int ConnectionCount { get => connectionCount; set => connectionCount = value; }

        public bool Connection()
        {
            connectionCount++;
            Console.WriteLine("Bağlanti sağlandi");
            return true;
        }
        

        public bool Disconnect()
        {
            Console.WriteLine("Bağlanti koptu");
            return false;
        }

    }

    #endregion

    #region Example 3

    class Example_1
    {
        private Example_1()
        {
            Console.WriteLine($"{nameof(Example_1)} nesnesi oluşturuldu");

        }


        private static Example_1 instance;
        static object _obj = new object();
        public static Example_1 GetInstance()
        {
            lock (_obj)
            {
                if (instance == null)
                {
                    instance = new Example_1();
                }
            }
            
            return instance;
        }

    }

    #endregion
}
