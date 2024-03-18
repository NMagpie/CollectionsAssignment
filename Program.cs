using Repository.Entities;
using Clients;

// Creating offices

var office1 = new PostOffice(1, "St. cel Mare 12");

var office2 = new PostOffice(2, "Bd. Kiev 9");

// Providing Packages to offices

var packages1 = new List<Package>
{
    new(0, "Metal lighter", "Pushkin 53", "Piotr Ivanov"),
    new(1, "Christmas socks", "Pietrarilor 5", "John Smith"),
    new(2, "Phone case", "Putnei 98", "Jane Doe"),
};

foreach (var package in packages1)
    office1.ReceivePackage(package);


var packages2 = new List<Package>
{
    new(3, "Earrings", "V. Lupu 45", "Someone"),
    new(4, "Wool Hat", "Ginta Latina", "Someone2")
};

foreach (var package in packages2)
    office2.ReceivePackage(package);

// Clients receiving their Packages

// Works as expected
office1.BringPackage(new Client("John Smith", "Pietrarilor 5"));

// Wrong office
office2.BringPackage(new Client("Piotr Ivanov", "Pushkin 53"));

// Unkown person/address
office1.BringPackage(new Client("Jane Doe", "Putnei 108"));