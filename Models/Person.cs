namespace PDFView.Models
{
    public class Person
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime DoB { get; set; }

        public static List<Person> GEtData() => new List<Person>{
            new Person() {
                Id = Guid.NewGuid(),
                Age=33,
                DoB= new DateTime(1990 , 10 , 12),
                Name="ali"
            },

            new Person()
            {
                Id = Guid.NewGuid(),
                Age = 31,
                DoB = new DateTime(1992, 10, 12),
                Name = "ahmed"
            },
            new Person()
            {
                Id = Guid.NewGuid(),
                Age = 28,
                DoB = new DateTime(1995, 10, 12),
                Name = "aya"
            },
            new Person()
            {
                Id = Guid.NewGuid(),
                Age = 26,
                DoB = new DateTime(1996, 10, 12),
                Name = "Ibrahim"
            },
        };

    }


    
}
