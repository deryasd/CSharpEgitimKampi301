using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }

        EgitimKampiEFTravelDbEntities db = new EgitimKampiEFTravelDbEntities();
        private void FrmStatistics_Load(object sender, EventArgs e)
        {

            lblLocationCount.Text = db.TblLocation.Count().ToString();
            lblSumCapasity.Text = db.TblLocation.Sum(x => x.Capacity).ToString();
            lblGuideCount.Text = db.TblGuide.Count().ToString();
            lblAvgCapacity.Text = db.TblLocation.Average(x => (double)x.Capacity).ToString("0.##");
            lblAvgTourPrice.Text = db.TblLocation.Average(x => (double)x.Price).ToString("0.##") + "₺";

            int lastCountryId = db.TblLocation.Max(x => x.LocationId);
            lblLastCountryName.Text = db.TblLocation.Where(x => x.LocationId == lastCountryId).Select(y => y.Country).FirstOrDefault();

            lblCappadociaLocationCapasity.Text = db.TblLocation.Where(x => x.City == "Kapadokya").Select(y => y.Capacity).FirstOrDefault().ToString();
            lblTurkiyeCapacityAverage.Text = db.TblLocation.Where(x => x.Country == "Türkiye").Average(y => y.Capacity).ToString();

            var romeGuideId = db.TblLocation.Where(x => x.City == "Roma Turistik").Select(y =>y.GuideId).FirstOrDefault();
            lblRomeGuideName.Text = db.TblGuide.Where(x => x.GuideId == romeGuideId).Select(y => y.GuideName + " " + y.GuideSurname).FirstOrDefault().ToString();

            var maxCapacity = db.TblLocation.Max(x => x.Capacity);
            lblMaxCapacityLocation.Text = db.TblLocation.Where(x => x.Capacity == maxCapacity).Select(y => y.Capacity).FirstOrDefault().ToString();

            var maxPrice = db.TblLocation.Max(y => y.Price);
            lblMaxPriceLocation.Text = db.TblLocation.Where(x => x.Price == maxPrice).Select(y => y.City).FirstOrDefault().ToString();

            var guideIdAysegulCinar = db.TblGuide.Where(x => x.GuideName == "Ayşegül" &&  x.GuideSurname == "Çınar").Select(x => x.GuideId).FirstOrDefault();
            lblAysegulCinarLocationNum.Text = db.TblLocation.Where(x => x.GuideId == guideIdAysegulCinar).Count().ToString();
        }
    }
}
