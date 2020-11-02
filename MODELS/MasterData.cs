using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
   public class MasterData : ResponseMessageModel
    {
        public string cust_no { get; set; }
        public string cust_name { get; set; }//combined of first and last name
        public string street_addr_1 { get; set; }
        public string street_addr_city { get; set; }
        public string street_addr_state { get; set; }
        public string street_post_code { get; set; }
        public string postal_addr_1 { get; set; }
        public string postal_addr_city { get; set; }
        public string postal_addr_state { get; set; }
        public string postal_post_code { get; set; }
        public string phone_no { get; set; }
        public string mobile_no { get; set; }
        public string email_address { get; set; }
        public string last_invoice_date { get; set; }
        public string last_invoice_amount { get; set; }
        public string last_payment_date { get; set; }
        public string last_payment_amount { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string AccountStatus { get; set; }
        public string amount { get; set; }
        public string date_terminated { get; set; }
        public string CustomerType { get; set; }
//        public string [0 - 17 days] { get; set; }
//    public string [17-30 days] { get; set; }
//public string [31 -60 days] { get; set; }
//public string [61 -90 days] { get; set; }
//public string [91 -120 days]{ get; set; }
//public string  [120plus] { get; set; }
public string cust_date_of_birth { get; set; }
public string credit_score { get; set; }
public string language_code { get; set; }
public string ExitType { get; set; }
public string isPrePay { get; set; }
public string Insert_Date { get; set; }
public string Modified_Date { get; set; }
public string Sent_Date { get; set; }
public string credit_control_status { get; set; }
public string  RevisedDue { get; set; }
public string CampaignDate { get; set; }
public string Assign_Date { get; set; }
public string ID { get; set; }
    }
}
