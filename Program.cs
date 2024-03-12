using Repository;

var office1 = new PostOffice(1, "St. cel Mare 12");

var office2 = new PostOffice(2, "Bd. Kiev 9");

office1.ReceivePackage(new Package(0, "Metal lighter", "Pushkin 53", "Piotr Ivanov"));

office1.ReceivePackage(new Package(1, "Christmas socks", "Pietrarilor 5", "John Smith"));

office1.ReceivePackage(new Package(2, "Phone case", "Putnei 98", "Jane Doe"));

office2.ReceivePackage(new Package(3, "Earrings", "V. Lupu 45", "Someone"));

office2.ReceivePackage(new Package(4, "Wool Hat", "Ginta Latina", "Someone2"));

// Works as expected
office1.BringPackage(new Client("John Smith", "Pietrarilor 5"));

// Wrong office
office2.BringPackage(new Client("Piotr Ivanov", "Pushkin 53"));

// Unkown person/address
office1.BringPackage(new Client("Jane Doe", "Putnei 108"));