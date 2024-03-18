namespace Repository.Entities;

using Clients;

public class PostOffice : Entity
{
    private static readonly ListRepository<PostOffice> _postOfficeRepository = new();

    private static readonly PackageRepository _packageRepository = new();

    public string Address { get; set; }

    public PostOffice(int id, string address)
    {
        Id = id;
        Address = address;
        _postOfficeRepository.Add(this);
    }

    public bool BringPackage(Client client)
    {

        //checking if package is introduced to the system (repository)
            
        var package = _packageRepository.GetPackage(client);

        if (package is null)
        { 
            Console.WriteLine($"No package for such client: {client.Name}!\n");
            return false; 
        }

        switch (package.Status)
        {
            case EPackageStatus.Lost:
                Console.WriteLine($"Package for {client.Name} was lost!\n");
                return false;

            case EPackageStatus.Waiting:
                Console.WriteLine($"Package for {client.Name} has not arrived yet.\n");
                return false;

        // Switch if there could be more package statuses
        }

        if (package.OfficeId != this.Id) {

            var otherOfficeAddress = _postOfficeRepository.GetById(package.OfficeId)?.Address;

            Console.WriteLine($"Package for {client.Name} is not located in this PostOffice! The package is in the office located on: {otherOfficeAddress}.\n");
            return false;
        }

        Console.WriteLine($"Client {client.Name} has received their package!\n");
        _packageRepository.Delete(package.Id);

        return true;
    }

    public void ReceivePackage(Package package)
    {
        package.OfficeId = this.Id;

        package.Status = EPackageStatus.Arrived;

        _packageRepository.Add(package);

        Console.WriteLine($"Package for {package.ClientName} has arrived at the office {this.Address}.\n");
    }
}