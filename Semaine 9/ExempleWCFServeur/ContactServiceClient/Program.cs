

namespace ContactServiceClient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            ServiceReference1.ContactServiceClient client = new ServiceReference1.ContactServiceClient();

            ServiceReference1.ContactDTO contact = await client.GetContactAsync(384);
            
            Console.WriteLine("Contact:\t" + contact.FirstName + "\t" + contact.LastName);

            foreach (ServiceReference1.AddressDTO address in contact.Addresses) {
                Console.WriteLine("Addresse:\t" + address.Street1);
            
            }

        }
    }
}
