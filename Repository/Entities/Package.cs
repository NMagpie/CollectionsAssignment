namespace Repository
{
    public class Package : Entity
    {

        public Package(int id, string description, string clientAddress, string clientName, EPackageStatus status = EPackageStatus.Waiting, int officeId = 0)
        {
            base.Id = id;
            Description = description;
            Status = status;
            OfficeId = officeId;
            ClientAddress = clientAddress;
            ClientName = clientName;
        }

        public string Description { get; set; }
        public EPackageStatus Status { get; set; }
        public int OfficeId { get; set; }
        public string ClientAddress { get; set; }
        public string ClientName { get; set; }
    }

    public enum EPackageStatus
    {
        Waiting,
        Arrived,
        Lost
    }
}
