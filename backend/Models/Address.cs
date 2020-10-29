namespace Backend
{
  public class Address
  {
    public int Id { get; set; }

    public string Street { get; set; }

    public string City { get; set; }

    public int Number { get; set; }

    public string Province { get; set; }

    public string Country { get; set; }

    public Address()
    {

    }

    public Address(int id, string street, string city, int number, string province, string country)
    {
      Id = id;
      Street = street;
      City = city;
      Number = number;
      Province = province;
      Country = country;
    }
  }
}