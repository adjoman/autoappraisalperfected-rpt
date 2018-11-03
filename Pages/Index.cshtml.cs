using Microsoft.AspNetCore.Mvc.RazorPages;
using testAAP.DB;
using testAAP.Models;
using AutoAppraisalsPerfected.Models;
using System;
using System.Net.Http;

namespace testAAP.Pages
{
    public class IndexModel : PageModel
    {
        public Report report 
        { 
            get 
                { return _report; } 
            set
            {
                _report = value;
            } 
        }

        private Report _report;

        public string Name { get; set; }

        public Vin VinDecoded { get; set; }

        public string ClientID { get; set; }

        public void OnGet()
        {
            Name = "this";

            if (Request.Query["id"].Count >= 1 )
            {
                ClientID = Request.Query["id"].ToString();
            }

            AppraisalsContext context = new AppraisalsContext("server=aaperfected.cvsd2ftiozra.us-east-1.rds.amazonaws.com;port=3306;database=Appraisals;user=aapreferred;password=FiftyMillion%%01;");

            if (ClientID != string.Empty && ClientID != null)
            {
                _report = context.getReport(ClientID);
                _report.photos = context.getPhotoByClientID(ClientID);

                if (_report.basicInfo.vin != null)
                {
                   VinDecoded = decodeVIN(_report.basicInfo.vin.ToUpper());
                }
                string test = string.Empty;
            }
            else
            {
                _report = context.getReport("a07ba482-2551-445a-977a-9a4d86bfa0c4");
                _report.photos = context.getPhotoByClientID("a07ba482-2551-445a-977a-9a4d86bfa0c4");
                VinDecoded = new Vin();
            }
        }

        public Vin decodeVIN(string VIN)
        {
            Vin decodedVehicleVINInfo = new Vin();

            try
            {
                var uri = new Uri(string.Format("https://vpic.nhtsa.dot.gov/api/vehicles/DecodeVin/" + VIN + "?format=json", string.Empty));

                HttpClient aapHttpClient = new HttpClient()
                {
                    MaxResponseContentBufferSize = 2147483647,
                    Timeout = new System.TimeSpan(0, 0, 15) // 15 second timeout
                };

                HttpResponseMessage response = null;
                response = aapHttpClient.GetAsync(uri).Result;

                if (response.IsSuccessStatusCode)
                {
                    var vResponseContent = response.Content.ReadAsStringAsync().Result;
                    decodedVehicleVINInfo = Vin.FromJson(vResponseContent);
                }
            }
            catch (System.Exception ex)
            {
                //await Application.Current.MainPage.DisplayAlert("", "Error creating new customer " + ex.Message.ToString(), "OK");
            }

            return decodedVehicleVINInfo;
        }
    }
}
