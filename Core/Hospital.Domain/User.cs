using System;

namespace Hospital.Domain;
public class User {
  public Guid Id { get; set; }
  public string PhoneNumber { get; set; }
  public string Name { get; set; }
  public Role Role { get; set; }

  public User(Guid guid, string phone, string name, Role role)
  {
    Id = guid;
    PhoneNumber = phone;
    Name = name;
    Role = role;
  }
}