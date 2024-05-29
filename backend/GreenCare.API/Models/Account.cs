namespace GreenCare.API.Models
{
    public class Account
    {
        public int id { get; private set; }
        public string email { get; private set; }
        public string password { get; private set; }
        public string role { get; private set; }
        public string name { get; private set; }
        public string phone { get; private set; }
        public string address { get; private set; }

        public Account(int id, string email, string password, string role, string name, string phone, string address)
        {
            this.id = id;
            this.email = email;
            this.password = password;
            this.role = role;
            this.name = name;
            this.phone = phone;
            this.address = address;
        }

        public Account() { }
    }
}
