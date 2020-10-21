using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace MyBookingRoles.Models.Store
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public string OrderName { get; set; }
        public DateTime OrderDate { get; set; }
        public string PaymentType { get; set; }
        public double PaymentAmount { get; set; }
        public string Status { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerAddress { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227: CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }

        //
        //public string setOrderName()
        //{
        //    OrderName = CustomerName + "-" + OrderDate + "-" + PaymentAmount;
        //    return OrderName;
        //}

        ///Email Notification///
        ///Please provide all the emails sent to clients in order
        public void SendMail()
        {
            var subject = "Studio Foto45 Purchase Order Details";
            var body = "Dear " + CustomerName + ", <br /><br />Order : <b style='color: green'>" + OrderName +" Was Successfull!</b><br />Delivery to -<b>"+ CustomerAddress + "</b>-</b><br /> Please Login to <b>Studio Foto45!</b> for your Orders.<hr /><b style='color: red'>Please Do not reply</b>.<br /> Thanks & Regards, <br /><b>Studio Foto45!</b>";

            //Copy from here
            //Change @Body content
            string fromEmail = System.Configuration.ConfigurationManager.AppSettings["fromEmail"].ToString();
            string fromPassword = System.Configuration.ConfigurationManager.AppSettings["fromPassword"].ToString();

            MailMessage mm = new MailMessage(fromEmail, CustomerEmail);
            mm.Subject = subject;
            mm.Body = body;
            mm.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient("smtp.office365.com", 587);
            smtp.Timeout = 100000;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            NetworkCredential nc = new NetworkCredential(fromEmail, fromPassword);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = nc;

            smtp.Send(mm);
        }
    }
}