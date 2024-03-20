using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using SnapObjects.Data;
using DWNet.Data;
using Newtonsoft.Json;
using System.Collections;

namespace TaxabilityWebAPI.Models 
{
    [DataWindow("ds_sf_poc_vertex_rates", DwStyle.Grid)]
    #region DwSelectAttribute  
    [DwSelect("select @(_COLUMNS_PLACEHOLDER_) \r\n "
                  +"from sf_poc_vertex_rates \r\n "
                  +"where destination_state = :s_state_id \r\n "
                  +"and destination_zip = :s_zip_code")]
    #endregion
    [DwParameter("s_state_id", typeof(string))]
    [DwParameter("s_zip_code", typeof(string))]
    public class VertexRates
    {
        [StringLength(20)]
        [DwColumn("TAID")]
        public string Taid { get; set; }

        [DwColumn("combined_rate")]
        public decimal? Combined_Rate { get; set; }

        [DwColumn("state_rate")]
        public decimal? State_Rate { get; set; }

        [DwColumn("county_rate")]
        public decimal? County_Rate { get; set; }

        [DwColumn("city_rate")]
        public decimal? City_Rate { get; set; }

        [DwColumn("other_rate")]
        public decimal? Other_Rate { get; set; }

        [DwColumn("gst_hst_rate")]
        public decimal? Gst_Hst_Rate { get; set; }

        [DwColumn("pst_rate")]
        public decimal? Pst_Rate { get; set; }

    }

}



