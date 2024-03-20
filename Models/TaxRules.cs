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
    [DataWindow("ds_tax_rules_by_state_id", DwStyle.Grid)]
    #region DwSelectAttribute  
    [DwSelect("SELECT @(_COLUMNS_PLACEHOLDER_) \r\n "
                  +"FROM co_tax_rules \r\n "
                  +"inner join co_state_tax_rules on co_tax_rules.rule_code = co_state_tax_rules.rule_code \r\n "
                  +"inner join co_tax_rule_options on co_state_tax_rules.rule_code = co_tax_rule_options.rule_code \r\n "
                  +"WHERE co_state_tax_rules.state = :s_state_id \r\n "
                  +"AND co_tax_rules.rule_applies_to_flag ='O' \r\n "
                  +"and co_state_tax_rules.applies_to_state_flag = 'Y' \r\n "
                  +"order by co_tax_rules.rule_name, \r\n "
                  +"co_tax_rules.rule_code")]
    #endregion
    [DwParameter("s_state_id", typeof(string))]
    public class TaxRules
    {
        [StringLength(60)]
        [DwColumn("co_tax_rules", "rule_name")]
        public string Rule_Name { get; set; }

        [DwColumn("co_tax_rules", "rule_code")]
        public short Rule_Code { get; set; }

        [DwColumn("co_tax_rules", "position_no")]
        public short? Position_No { get; set; }

        [StringLength(60)]
        [DwColumn("co_tax_rule_options", "option_name")]
        public string Option_Name { get; set; }

        [StringLength(1)]
        [DwColumn("co_tax_rule_options", "option_id")]
        public string Option_Id { get; set; }

    }

}



