namespace ProductManager
{

     class Categories
    {
        public Categories()
        {
            Name = name;
           
        }

        public string Name {
            get
            {
                return name;
            }
            
            set
            {
                if (string.IsNullOrEmpty(value))
                    Console.WriteLine("Namnet kan inte vara tomt");
                
                name = value;
            }
        }

        public string name;
    }
}