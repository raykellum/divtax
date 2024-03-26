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
    [DataWindow("ds_sf_poc_jw_tax_rules", DwStyle.Grid)]
    #region DwSelectAttribute  
    [DwSelect("select @(_COLUMNS_PLACEHOLDER_) \r\n "
                  +"from sf_poc_jw_tax_rules \r\n "
                  +"where [state] = :s_state_id")]
    #endregion
    [DwParameter("s_state_id", typeof(string))]
    public class JWTaxRules
    {
        [StringLength(2)]
        [DwColumn("[state]")]
        public string State { get; set; }

        [DwColumn("[level]")]
        public short Level { get; set; }

        [StringLength(100)]
        [DwColumn("question")]
        public string Question { get; set; }

        [StringLength(1)]
        [DwColumn("answer")]
        public string Answer { get; set; }

        [DwColumn("result")]
        public short? Result { get; set; }

        [StringLength(100)]
        [DwColumn("result_text")]
        public string Result_Text { get; set; }

        [StringLength(1)]
        [DwColumn("material_tax")]
        public string Material_Tax { get; set; }

        [StringLength(1)]
        [DwColumn("labor_tax")]
        public string Labor_Tax { get; set; }

        [StringLength(1)]
        [DwColumn("other_tax")]
        public string Other_Tax { get; set; }

        [DwColumn("effective_date", TypeName = "date")]
        public DateTime? Effective_Date { get; set; }

        [StringLength(14)]
        [SqlCompute("CASE result " 
                  + "WHEN 0 THEN [state] + convert(varchar(3), [level]) + answer + convert(varchar(4), datepart(yy, effective_date)) + right('00' + convert(varchar(2), datepart(mm, effective_date)),2) + right('00' + convert(varchar(2), datepart(dd, effective_date)),2) "
                  + "ELSE '' "
                  + "END as tax_code")]
        public string Tax_Code { get; set; }

    }

}



