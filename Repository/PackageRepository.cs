namespace Repository
{
    internal class PackageRepository : ListRepository<Package>
    {
        public Package? GetPackage(Client client)
        {
            foreach (var package in _list)
                if (
                    string.Equals(client.Address, package.ClientAddress) &&
                    string.Equals(client.Name, package.ClientName)
                    )
                    return package;

            return null;
        }
    }
}
