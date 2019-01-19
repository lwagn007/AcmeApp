using Acme.Common;
using static Acme.Common.LoggingService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
    /// <summary>
    /// Manages products carried in inventory
    /// </summary>
    public class Product
    {
        public const double InchesPerMeter = 39.37;
        public readonly decimal MinimumPrice;
        private string _productName;
        private string _productDescription;
        private int _productId;
        private Vendor _productVendor;
        private DateTime? _availabilityDate;

        public Product()
        {
            Console.WriteLine("Product instance created");
            //this._productVendor = new Vendor();
            this.MinimumPrice = .96m;
            this.Category = "Tools";
        }

        //Constructor chaining
        public Product(int productId, string productName, string productDescription) : this()
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.ProductDescription = productDescription;
            if (ProductName.StartsWith("Bulk"))
            {
                this.MinimumPrice = 9.99m;
            }
            Console.WriteLine("Product instance has a name: " + ProductName);
        }

        internal string Category { get; set; }
        public int SequenceNumber { get; set; } = 1;
        public string ValidationMessage { get; private set; }

        public string ProductCode => Category + "-" + SequenceNumber;

        public DateTime? AvailibilityDate
        {
            get { return _availabilityDate; }
            set { _availabilityDate = value; }
        }

        public string ProductName
        {
            get
            {
                var formattedValue = _productName?.Trim();
                return formattedValue;
            }
            set
            {
                if (value.Length < 3)
                {
                    ValidationMessage = "Product name must be at least 3 characters";
                }
                else if(value.Length>20)
                {
                    ValidationMessage = "Product name must be less then 20 characters";
                }
                else
                {
                    _productName = value.Trim();
                }
            }
        }

        public string ProductDescription
        {
            get { return _productDescription; }
            set { _productDescription = value; }
        }

        public int ProductId
        {
            get { return _productId; }
            set { _productId = value; }
        }

        public Vendor ProductVendor
        {
            get
            {
                if(_productVendor == null)
                {
                    _productVendor = new Vendor();
                }
                return _productVendor;
            }
            set
            {
                _productVendor = value;
            }
        }

        public string SayHello()
        {
            //var vendor = new Vendor();
            //vendor.SendWelcomeEmail("Message from Product");
            var emailService = new EmailService();
            emailService.SendMessage("New Product", this.ProductName, "sales@abc.com");
            //can implement a using static statement
            var result = LoggingService.LogAction("saying hello");
            return "Hello " + ProductName +
                    " (" + ProductId + "): " +
                    ProductDescription +
                    " Available on: " + 
                    AvailibilityDate?.ToShortDateString();
        }
    }
}
